using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Chofer
    {
        public List<E_Chofer> ListarChoferes(bool? disponibilidad = null)
        {
            List<E_Chofer> lista = new List<E_Chofer>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Select_Chofer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (disponibilidad.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Disponibilidad", disponibilidad.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Disponibilidad", DBNull.Value);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new E_Chofer
                    {
                        IdChofer = Convert.ToInt32(dr["IdChofer"]),
                        Nombre = dr["Nombre"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                        Licencia = dr["Licencia"].ToString(),
                        UrlFoto = dr["UrlFoto"].ToString(),
                        Disponibilidad = Convert.ToBoolean(dr["Disponibilidad"]),
                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                    });
                }
            }//Fin del using sqlconnections
            return lista;
        }

        public bool InsertarChofer(E_Chofer chofer)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Insert_Choferes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", chofer.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", chofer.ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", chofer.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", chofer.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Licencia", chofer.Licencia);
                cmd.Parameters.AddWithValue("@UrlFoto",
                    string.IsNullOrEmpty(chofer.UrlFoto) ? (object)DBNull.Value : chofer.UrlFoto);
                cmd.Parameters.AddWithValue("@Disponibilidad", chofer.Disponibilidad);
                

                //El SP usa SET NOCOUNT ON, por lo que ExecuteNonQuery() no regresa
                //el número real de filas afectadas (normalmente regresa -1)
                //Como el SP ya valida duplicados y lanza throw ante cualquier error,
                //si esta línea no lanza excepción, el INSERT se ejecutó correctamente.
                cmd.ExecuteNonQuery();
                return true;
            }
        }//Fin del método insertar chofer

        public bool ActualizarChofer(E_Chofer chofer)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Update_Choferes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdChofer", chofer.IdChofer);
                cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre);
                cmd.Parameters.AddWithValue("@ApPaterno", chofer.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", chofer.ApMaterno);
                cmd.Parameters.AddWithValue("@Telefono", chofer.Telefono);
                cmd.Parameters.AddWithValue("@FechaNacimiento", chofer.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Licencia", chofer.Licencia);
                cmd.Parameters.AddWithValue("@UrlFoto",
                    string.IsNullOrEmpty(chofer.UrlFoto) ? (object)DBNull.Value : chofer.UrlFoto);
                cmd.Parameters.AddWithValue("@Disponibilidad", chofer.Disponibilidad);
                //Para ver que fue ENVIADO
                foreach (SqlParameter p in cmd.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"{p.ParameterName} = {p.Value}");
                }
                cmd.ExecuteNonQuery();
                return true; //Si no hubo excepción, el SP se ejecutó correctamente
            }
        }//Fin del método ActualizarChofer

        public bool EliminarChofer(int idChofer)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Delete_Chofer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdChofer", idChofer);
                cmd.ExecuteNonQuery(); //Retorna número de filas afectadas
                return true;
            }
        }

        public bool ExisteLicencia(string licencia)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Existe_Licencia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Licencia", licencia);
                //Devuelve ExecuteScalar el primer valor de la primera fila del resultado
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado > 0;
            }
        }

    }//Fin clase
}//Fin namespace
