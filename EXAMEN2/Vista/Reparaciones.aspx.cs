using EXAMEN2.CapaLogica;
using EXAMEN2.CapaModelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXAMEN2.Vista
{
    public partial class Reparaciones : System.Web.UI.Page
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

        //METODO PARA INGRESAR REPARACIONES
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            clsReparaciones.EquipoID = int.Parse(tEquipoID.Text);
            clsReparaciones.FechaSolicitud = tFechaSol.Text;
            clsReparaciones.estado = DropDownList1.Text;

            if (ReparacionesL.AgregarReparacion(clsReparaciones.EquipoID, clsReparaciones.FechaSolicitud, clsReparaciones.estado) > 0)
            {
                MostrarAlerta(this, "----Reparacion Ingresada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Reparacion :(...");
            }
        }
        //METODO PARA BORRAR REPARACIONES
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsReparaciones.ReparacionID = int.Parse(tID.Text);
            if (ReparacionesL.BorrarReparacion(clsReparaciones.ReparacionID) > 0)
            {
                MostrarAlerta(this, "----Reparacion Eliminada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Reparacion :(...");
            }
        }
        //METODO PARA MODIFICAR REPARACIONES
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            
            clsAsignaciones.ReparacionID = int.Parse(tID.Text);
            clsReparaciones.EquipoID = int.Parse(tEquipoID.Text);
            clsReparaciones.FechaSolicitud = tFechaSol.Text;
            clsReparaciones.estado = DropDownList1.Text;

            if (ReparacionesL.ModificarReparacion(clsAsignaciones.ReparacionID, clsReparaciones.EquipoID, clsReparaciones.FechaSolicitud, clsReparaciones.estado) > 0)
            {
                MostrarAlerta(this, "----Reparacion Modificada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Modificar Reparacion :(...");
            }

        }




        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView.DataSource = dt;
                            GridView.DataBind();//Refrescar
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
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Reparaciones WHERE ReparacionID = @ReparacionID", con))
                {
                    cmd.Parameters.AddWithValue("@ReparacionID", tID.Text);

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