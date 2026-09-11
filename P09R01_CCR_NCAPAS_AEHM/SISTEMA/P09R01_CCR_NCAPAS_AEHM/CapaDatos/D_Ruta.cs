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
    public class D_Ruta
    {
        public List<E_Ruta> ListarRutas()
        {
            List<E_Ruta> lista = new List<E_Ruta>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Select_Rutas_Detalle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new E_Ruta
                    {
                        IdRuta = Convert.ToInt32(dr["IdRuta"]),
                        Origen = dr["Origen"].ToString(),
                        Destino = dr["Destino"].ToString(),
                        FechaSalida = Convert.ToDateTime(dr["FechaSalida"]),
                        FechaLlegada = Convert.ToDateTime(dr["FechaLlegada"]),
                        ATiempo = Convert.ToBoolean(dr["ATiempo"]),
                        Distancia = Convert.ToDouble(dr["Distancia"]),
                        //Id's de tbl camion y chofer
                        IdChofer = Convert.ToInt32(dr["IdChofer"]),
                        NombreChofer = dr["NombreChofer"].ToString(),
                        Licencia = dr["Licencia"].ToString(),
                        TelefonoChofer = dr["TelefonoChofer"].ToString(),
                        FotoChofer = dr["FotoChofer"].ToString(),
                        IdCamion = Convert.ToInt32(dr["IdCamion"]),
                        Matricula = dr["Matricula"].ToString(),
                        FotoCamion = dr["FotoCamion"].ToString(),
                    });
                }
            }//Fin del using sqlconnections
            return lista;
        }

        public bool InsertarRuta(E_Ruta ruta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Insert_Rutas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdChofer", ruta.IdChofer);
                cmd.Parameters.AddWithValue("@IdCamion", ruta.IdCamion);
                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", ruta.FechaSalida);
                cmd.Parameters.AddWithValue("@FechaLlegada", ruta.FechaLlegada);
                cmd.Parameters.AddWithValue("@ATiempo", ruta.ATiempo);
                cmd.Parameters.AddWithValue("@Distancia", ruta.Distancia);

                //El SP usa SET NOCOUNT ON, por lo que ExecuteNonQuery() no regresa
                //el número real de filas afectadas (normalmente regresa -1)
                //Como el SP ya valida duplicados y lanza throw ante cualquier error,
                //si esta línea no lanza excepción, el INSERT se ejecutó correctamente.
                cmd.ExecuteNonQuery();
                return true;
            }
        }//Fin del método insertar rutas

        public bool ActualizarRuta(E_Ruta ruta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Update_Rutas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRuta", ruta.IdRuta);
                cmd.Parameters.AddWithValue("@IdChofer", ruta.IdChofer);
                cmd.Parameters.AddWithValue("@IdCamion", ruta.IdCamion);
                cmd.Parameters.AddWithValue("@Origen", ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino", ruta.Destino);
                cmd.Parameters.AddWithValue("@FechaSalida", ruta.FechaSalida);
                cmd.Parameters.AddWithValue("@FechaLlegada", ruta.FechaLlegada);
                cmd.Parameters.AddWithValue("@ATiempo", ruta.ATiempo);
                cmd.Parameters.AddWithValue("@Distancia", ruta.Distancia);
                //Para ver que fue ENVIADO
                foreach (SqlParameter p in cmd.Parameters)
                {
                    System.Diagnostics.Debug.WriteLine($"{p.ParameterName} = {p.Value}");
                }
                cmd.ExecuteNonQuery();
                return true; //Si no hubo excepción, el SP se ejecutó correctamente
            }
        }//Fin del método ActualizarRuta

        public bool EliminarRuta(int idRuta)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("dbo.Delete_Ruta", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRuta", idRuta);
                //Mismo caso SET NOCOUNT ON + THROW en el SP¨si no existe el registro.
                cmd.ExecuteNonQuery(); //Retorna número de filas afectadas
                return true;
            }
        }

    }//Fin de clase
}//Fin del namespace
