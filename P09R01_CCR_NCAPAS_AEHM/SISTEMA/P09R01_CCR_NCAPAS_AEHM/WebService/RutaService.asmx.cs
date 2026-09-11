using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Descripción breve de RutaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class RutaService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<string> ObtenerRutas()
        {
            List<string> rutas = new List<string>();

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Rutas",
                    conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rutas.Add(reader["IdRuta"].ToString());
                    rutas.Add(reader["IdChofer"].ToString());
                    rutas.Add(reader["IdCamion"].ToString());
                    rutas.Add(reader["Origen"].ToString());
                    rutas.Add(reader["Destino"].ToString());
                    rutas.Add(reader["FechaSalida"].ToString());
                    rutas.Add(reader["FechaLlegada"].ToString());
                    rutas.Add(reader["ATiempo"].ToString());
                    rutas.Add(reader["Distancia"].ToString());
                    rutas.Add(reader["FechaRegistro"].ToString());
                }
            }
            return rutas;
        }


        [WebMethod]
        public RutaInfo ObtenerRutasPorId(int id)
        {
            RutaInfo rutasInfo = null;

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Rutas WHERE IdRuta = @IdRuta", conn
                    );
                cmd.Parameters.AddWithValue("@IdRuta", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    rutasInfo = new RutaInfo
                    {
                        IdChofer = (int)reader["IdChofer"],
                        IdCamion = (int)reader["IdCamion"],
                        Origen = reader["Origen"].ToString(),
                        Destino = reader["Destino"].ToString(),
                        FechaSalida = (DateTime)reader["FechaSalida"],
                        FechaLlegada = (DateTime)reader["FechaLlegada"],
                        ATiempo = (bool)reader["ATiempo"],
                        Distancia = (double)reader["Distancia"],
                        FechaRegistro = (DateTime)reader["FechaRegistro"],
                    };

                }
            }
            return rutasInfo;
        }

        [WebMethod]
        public string AgregarRuta(int IdChofer, int IdCamion, string Origen, string Destino, DateTime FechaSalida, DateTime FechaLlegada, bool ATiempo, double Distancia)
        {

            try
            {

                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Rutas (IdChofer, IdCamion, Origen, Destino, FechaSalida, FechaLlegada, ATiempo,  Distancia) VALUES (@IdChofer, @IdCamion, @Origen, @Destino, @FechaSalida, @FechaLlegada, @ATiempo,  @Distancia)",
                        conn
                        );

                    cmd.Parameters.AddWithValue("@IdChofer", IdChofer);
                    cmd.Parameters.AddWithValue("@IdCamion", IdCamion);
                    cmd.Parameters.AddWithValue("@Origen", Origen);
                    cmd.Parameters.AddWithValue("@Destino", Destino);
                    cmd.Parameters.AddWithValue("@FechaSalida", FechaSalida);
                    cmd.Parameters.AddWithValue("@FechaLlegada", FechaLlegada);
                    cmd.Parameters.AddWithValue("@ATiempo", ATiempo);
                    cmd.Parameters.AddWithValue("@Distancia", Distancia);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return "ok";
                }
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message;
            }
        }

        [WebMethod]
        public string ActualizarRuta(int IdRuta, string Distancia)
        {

            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Rutas SET Distancia = @Distancia WHERE IdRuta = @IdRuta",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdRuta", IdRuta);
                    cmd.Parameters.AddWithValue("@Distancia", Distancia);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return "ok";
                }
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message;
            }
        }

        [WebMethod]
        public string EliminarRuta(int IdRuta)
        {

            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Rutas WHERE IdRuta = @IdRuta",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdRuta", IdRuta);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return "ok";
                }
            }
            catch (Exception ex)
            {

                return "Error" + ex.Message;
            }
        }

    }//Fin clase

    //Clase personalizada para retornar datos estructurados
    [Serializable]//Permite que la clase convierta a XML
    public class RutaInfo
    {
        public int IdRuta { get; set; }
        public int IdChofer { get; set; }
        public int IdCamion { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public bool ATiempo { get; set; }
        public double Distancia { get; set; }
        public DateTime FechaRegistro { get; set; }

    }

}//Fin namespace
