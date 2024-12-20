using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMEN2.CapaLogica
{
    public class AsignacionesL
    {

        public static int AgregarAsignacion(int ReparacionID, int TecnicoID, string FechaAsignacion, string Estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ReparacionID", ReparacionID));
                    cmd.Parameters.Add(new SqlParameter("@TecnicoID", TecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsignacion", FechaAsignacion));
                    cmd.Parameters.Add(new SqlParameter("@estado", Estado));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int BorrarAsignacion(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AsignacionID", codigo));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int ModificarAsignacion(int codigo, int ReparacionID, int TecnicoID, string FechaAsignacion, string Estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarAsignacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@AsignacionID", codigo));
                    cmd.Parameters.Add(new SqlParameter("@ReparacionID", ReparacionID));
                    cmd.Parameters.Add(new SqlParameter("@TecnicoID", TecnicoID));
                    cmd.Parameters.Add(new SqlParameter("FechaAsignacion", FechaAsignacion));
                    cmd.Parameters.Add(new SqlParameter("@estado", Estado));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}