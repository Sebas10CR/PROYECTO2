using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EXAMEN2.CapaModelo;
using System.Security.Cryptography;
using EXAMEN2.CapaLogica;

namespace EXAMEN2.Vista
{
    public partial class Usuarios : System.Web.UI.Page
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
        //METODO PARA AGREGAR USUARIOS
        protected void bAgregar1_Click(object sender, EventArgs e)
        {

            clsUsuario.Nombre = tNombre.Text;
            clsUsuario.CorreoElectronico = tCorreo.Text;
            clsUsuario.Telefono = tTelefono.Text;
            clsUsuario.estado = DropDownList1.Text;
            if (UsuariosL.AgregarUsuarios(clsUsuario.Nombre, clsUsuario.CorreoElectronico, clsUsuario.Telefono, clsUsuario.estado) > 0)
            {
                MostrarAlerta(this, "----Usuario Ingresado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar usuario :(...");
            }
        }
        //METODO PARA ELIMINAR USUARIOS
        protected void bBorrar1_Click(object sender, EventArgs e)
        {
            clsUsuario.UsuarioID = int.Parse(tID.Text);
            if (UsuariosL.BorrarUsuarios(clsUsuario.UsuarioID) > 0)
            {
                MostrarAlerta(this, "----Usuario Eliminado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al eliminar usuario :(...");
            }
        }
        //METODO PARA MODIFICAR USUARIOS
        protected void bModificar1_Click(object sender, EventArgs e)
        {
            clsUsuario.UsuarioID = int.Parse(tID.Text);
            clsUsuario.Nombre = tNombre.Text;
            clsUsuario.CorreoElectronico = tCorreo.Text;
            clsUsuario.Telefono = tTelefono.Text;
            clsUsuario.estado = DropDownList1.Text;
            if (UsuariosL.ModificarUsuarios(clsUsuario.UsuarioID, clsUsuario.Nombre, clsUsuario.CorreoElectronico, clsUsuario.Telefono, clsUsuario.estado) > 0)
            {
                MostrarAlerta(this, "----Usuario Modificado Correctamente----");
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al Modificar usuario :(...");
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM Usuarios WHERE UsuarioID = @UsuarioID", con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", tID.Text);

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