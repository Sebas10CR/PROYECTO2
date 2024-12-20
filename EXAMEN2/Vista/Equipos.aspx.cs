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
    public partial class Equipos : System.Web.UI.Page
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


        //METODO PARA AGREGAR EQUIPO
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            clsEquipo.TipoEquipo = tTipoDeEquipo.Text;
            clsEquipo.Modelo = tModelo.Text;
            clsEquipo.UsuarioID = int.Parse(tIDUsuario.Text);
            clsEquipo.estado = DropDownList1.Text;

            if (EquiposL.AgregarEquipo(clsEquipo.TipoEquipo, clsEquipo.Modelo, clsEquipo.UsuarioID, clsEquipo.estado) > 0)
            {
                MostrarAlerta(this, "----Equipo Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Equipo :(...");
            }

        }
        //METODO PARA BORRAR EQUIPO
        protected void bBorrar1_Click(object sender, EventArgs e)
        {
            clsEquipo.EquipoID = int.Parse(tID.Text);


            if (EquiposL.BorrarEquipo(clsEquipo.EquipoID) > 0)
            {
                MostrarAlerta(this, "----Equipo Eliminado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar Equipo :(...");
            }
        }

        //METODO PARA MODIFICAR EQUIPO
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            clsEquipo.EquipoID = int.Parse(tID.Text);
            clsEquipo.TipoEquipo = tTipoDeEquipo.Text;
            clsEquipo.Modelo = tModelo.Text;
            clsEquipo.UsuarioID = int.Parse(tIDUsuario.Text);
            clsEquipo.estado = DropDownList1.Text;

            if (EquiposL.ModificarEquipo(clsEquipo.EquipoID, clsEquipo.TipoEquipo, clsEquipo.Modelo, clsEquipo.UsuarioID, clsEquipo.estado) > 0)
            {
                MostrarAlerta(this, "----Equipo Modificado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Equipo :(...");
            }

        }



        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();//Refrecar
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
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Equipos WHERE EquipoID = @EquipoID", con))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", tID.Text);

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