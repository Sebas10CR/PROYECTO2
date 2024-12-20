using EXAMEN2.CapaModelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EXAMEN2.CapaLogica;
using System.Security.Cryptography;

namespace EXAMEN2.Vista
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        //METODO PARA MOSTRAR ALERTA
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        //METODO PARA INGRESAR TECNICOS
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            clsTecnico.Nombre = tNombre.Text;
            clsTecnico.Especialidad = tEspecialidad.Text;
            clsTecnico.estado = DropDownList1.Text;

            if (TecnicosL.AgregarTecnico(clsTecnico.Nombre, clsTecnico.Especialidad,clsTecnico.estado) > 0)
            {
                MostrarAlerta(this, "----Tecnico Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar tecnico :(...");
            }
        }
        //METODO PARA BORRAR TECNICOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsTecnico.TecnicoID = int.Parse(tID.Text);
            if (TecnicosL.BorrarTecnico(clsTecnico.TecnicoID) > 0)
            {
                MostrarAlerta(this, "----Tecnico Elimando Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar tecnico :(...");
            }
        }
        //METODO PARA MODIFICAR TECNICOS
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            clsTecnico.TecnicoID = int.Parse(tID.Text);
            clsTecnico.Nombre = tNombre.Text;
            clsTecnico.Especialidad = tEspecialidad.Text;
            clsTecnico.estado = DropDownList1.Text;

            if (TecnicosL.ModificarTecnico(clsTecnico.TecnicoID, clsTecnico.Nombre, clsTecnico.Especialidad,clsTecnico.estado) > 0)
            {
                MostrarAlerta(this, "----Tecnico Modificado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Modificar tecnico :(...");
            }

        }




        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();//Refrescar
                        }
                    }
                }
            }
        }

        //METODO PARA CONSULTAR
        protected void bConsultar1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Tecnicos WHERE TecnicoID = @TecnicoID", con))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tID.Text);

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
        }






    }
}