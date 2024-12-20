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
    public partial class DetallesReparaciones : System.Web.UI.Page
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

        //METODO PARA INGRESAR DETALLE
        protected void bAgregar1_Click(object sender, EventArgs e)
        {
            clsDetallesReparaciones.ReparacionID = int.Parse(tReparacionID.Text);
            clsDetallesReparaciones.Descripcion = tDescripcion.Text;
            clsDetallesReparaciones.FechaInicio = tFechaInicio.Text;
            clsDetallesReparaciones.FechaFin = tFechaFin.Text;
            clsDetallesReparaciones.estado = DropDownList1.SelectedValue;

            if (DetallesReparacionesL.AgregarDetalle(clsDetallesReparaciones.ReparacionID, clsDetallesReparaciones.Descripcion, clsDetallesReparaciones.FechaInicio, clsDetallesReparaciones.FechaFin, clsDetallesReparaciones.estado) > 0)
            {
                MostrarAlerta(this, "----Detalle Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Detalle :(...");
            }

        }
        //METODO PARA BORRAR DETALLE
        protected void bBorrar1_Click(object sender, EventArgs e)
        {

            clsDetallesReparaciones.DetalleID = int.Parse(tID.Text);
            if (DetallesReparacionesL.BorrarDetalle(clsDetallesReparaciones.DetalleID) > 0)
            {
                MostrarAlerta(this, "----Detalle Eliminado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Eliminar Detalle :(...");
            }
        }
        //METODO PARA MODIFICAR DETALLE
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            clsDetallesReparaciones.DetalleID = int.Parse(tID.Text);
            clsDetallesReparaciones.ReparacionID = int.Parse(tReparacionID.Text);
            clsDetallesReparaciones.Descripcion = tDescripcion.Text;
            clsDetallesReparaciones.FechaInicio = tFechaInicio.Text;
            clsDetallesReparaciones.FechaFin = tFechaFin.Text;
            clsDetallesReparaciones.estado = DropDownList1.Text;

            if (DetallesReparacionesL.ModificarDetalle(clsDetallesReparaciones.DetalleID, clsDetallesReparaciones.ReparacionID, clsDetallesReparaciones.Descripcion, clsDetallesReparaciones.FechaInicio, clsDetallesReparaciones.FechaFin, clsDetallesReparaciones.estado) > 0)
            {
                MostrarAlerta(this, "----Detalle Modificado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Modificar Detalle :(...");
            }

        }




        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparacion "))
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
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM DetallesReparacion WHERE DetalleID = @DetalleID", con))
                {
                    cmd.Parameters.AddWithValue("@DetalleID", tID.Text);

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