using EXAMEN2.CapaLogica;
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

namespace EXAMEN2.Vista
{
    public partial class Asignaciones : System.Web.UI.Page
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

        //METODO PARA INGRESAR ASIGNACIONES
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            clsAsignaciones.ReparacionID = int.Parse(tReparacionID.Text);
            clsAsignaciones.TecnicoID = int.Parse(tTecnicoID.Text);
            clsAsignaciones.FechaAsignacion = tFechaAsig.Text;
            clsAsignaciones.estado = DropDownList1.Text;

            if (AsignacionesL.AgregarAsignacion(clsAsignaciones.ReparacionID, clsAsignaciones.TecnicoID, clsAsignaciones.FechaAsignacion, clsAsignaciones.estado) > 0)
            {
                MostrarAlerta(this, "----Asignacion Ingresada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Asignacion :(...");
            }
        }
        //METODO PARA BORRAR ASIGNACIONES
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsAsignaciones.AsignacionID = int.Parse(tID.Text);
            if (AsignacionesL.BorrarAsignacion(clsAsignaciones.AsignacionID) > 0)
            {
                MostrarAlerta(this, "----Asignacion Eliminada Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Asignacion :(...");
            }
        }
        //METODO PARA MODIFICAR ASIGNACIONES
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            clsAsignaciones.AsignacionID = int.Parse(tID.Text);
            clsAsignaciones.ReparacionID = int.Parse(tReparacionID.Text);
            clsAsignaciones.TecnicoID = int.Parse(tTecnicoID.Text);
            clsAsignaciones.FechaAsignacion = tFechaAsig.Text;
            clsAsignaciones.estado = DropDownList1.Text;

            if (AsignacionesL.ModificarAsignacion(clsAsignaciones.AsignacionID,clsAsignaciones.ReparacionID, clsAsignaciones.TecnicoID, clsAsignaciones.FechaAsignacion, clsAsignaciones.estado) > 0)
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Asignaciones"))
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
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Asignaciones WHERE AsignacionID = @AsignacionID", con))
                {
                    cmd.Parameters.AddWithValue("@AsignacionID", tID.Text);

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
