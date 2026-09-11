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
    public class D_Camion
    {
        public List<E_Camion> ListarCamiones(bool? disponibilidad = null)
        {
            List<E_Camion> lista = new List<E_Camion>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Listar_Camiones", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (disponibilidad.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Disponibilidad", disponibilidad.Value);
                }
                else { 
                    cmd.Parameters.AddWithValue("@Disponibilidad", DBNull.Value);
                }
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new E_Camion
                    {
                        IdCamion = Convert.ToInt32(dr["IdCamion"]),
                        Matricula = dr["Matricula"].ToString(),
                        TipoCamion = dr["TipoCamion"].ToString(),
                        Modelo = Convert.ToInt32(dr["Modelo"]),
                        Marca = dr["Marca"].ToString(),
                        Capacidad = Convert.ToInt32(dr["Capacidad"]),
                        Kilometraje = Convert.ToDouble(dr["Kilometraje"]),
                        Disponibilidad = Convert.ToBoolean(dr["Disponibilidad"]),
                        UrlFoto = dr["UrlFoto"].ToString()
                    });
                }
            }
            return lista;
        }//Fin del using sqlconnections

        public bool InsertarCamion(E_Camion camion)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Insert_Camion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Matricula", camion.Matricula);
                cmd.Parameters.AddWithValue("@TipoCamion", camion.TipoCamion);
                cmd.Parameters.AddWithValue("@Modelo", camion.Modelo);
                cmd.Parameters.AddWithValue("@Marca", camion.Marca);
                cmd.Parameters.AddWithValue("@Capacidad", camion.Capacidad);
                cmd.Parameters.AddWithValue("@Kilometraje", camion.Kilometraje);
                cmd.Parameters.AddWithValue("@Disponibilidad", camion.Disponibilidad);
                cmd.Parameters.AddWithValue("@UrlFoto", 
                    string.IsNullOrEmpty(camion.UrlFoto) ? (object)DBNull.Value : camion.UrlFoto);

                //El SP usa SET NOCOUNT ON, por lo que ExecuteNonQuery() no regresa
                //el número real de filas afectadas (normalmente regresa -1)
                //Como el SP ya valida duplicados y lanza throw ante cualquier error,
                //si esta línea no lanza excepción, el INSERT se ejecutó correctamente.
                cmd.ExecuteNonQuery();
                return true;
            }
        }//Fin del método insertar camión

        public bool ActualizarCamion(E_Camion camion)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Update_Camion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCamion", camion.IdCamion);
                cmd.Parameters.AddWithValue("@Matricula", camion.Matricula);
                cmd.Parameters.AddWithValue("@TipoCamion", camion.TipoCamion);
                cmd.Parameters.AddWithValue("@Modelo", camion.Modelo);
                cmd.Parameters.AddWithValue("@Marca", camion.Marca);
                cmd.Parameters.AddWithValue("@Capacidad", camion.Capacidad);
                cmd.Parameters.AddWithValue("@Kilometraje", camion.Kilometraje);
                cmd.Parameters.AddWithValue("@Disponibilidad", camion.Disponibilidad);
                cmd.Parameters.AddWithValue("@UrlFoto", 
                    string.IsNullOrEmpty(camion.UrlFoto) ? (object)DBNull.Value : camion.UrlFoto);
                //Para ver que fue ENVIADO
                foreach (SqlParameter p in cmd.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"{p.ParameterName} = {p.Value}");
                }
                cmd.ExecuteNonQuery();
                return true; //Si no hubo excepción, el SP se ejecutó correctamente
            }
        }//Fin del método ActualizarCamion

        public bool EliminarCamion(int idCamion) 
        {
            using (SqlConnection conn = Conexion.ObtenerConexion()) 
            {
                SqlCommand cmd = new SqlCommand("dbo.Delete_Camion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCamion", idCamion);
                cmd.ExecuteNonQuery(); //Retorna número de filas afectadas
                return true;
            }
        }

        public bool ExisteMatricula(string matricula) 
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd= new SqlCommand("dbo.Existe_Matricula", conn);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                //Devuelve ExecuteScalar el primer valor de la primera fila del resultado
                int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                return resultado >0;
            }
        }

        public E_Camion ObtenerCamionPorID(int idCamion) 
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Obtener_Camion_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCamion", idCamion);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new E_Camion
                    {
                        IdCamion = Convert.ToInt32(dr["IdCamion"]),
                        Matricula = dr["Matricula"].ToString(),
                        TipoCamion =dr["TipoCamion"].ToString(),
                        Modelo = Convert.ToInt32(dr["Modelo"]),
                        Marca = dr["Marca"].ToString(),
                        Capacidad = Convert.ToInt32(dr["Capacidad"]),
                        Kilometraje = Convert.ToDouble(dr["Kilometraje"]),
                        Disponibilidad = Convert.ToBoolean(dr["Disponibilidad"]),
                        UrlFoto = dr["UrlFoto"].ToString(),
                    };
                }
                return null;
            }
        }

    }//Fin de la clase
}//Fin del namespace
