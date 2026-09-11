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
    /// Descripción breve de CamionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CamionService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }


        [WebMethod]
        public List<string> ObtenerCamiones()
        {
            List<string> camiones = new List<string>();

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Camiones",
                    conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    camiones.Add(reader["IdCamion"].ToString());
                    camiones.Add(reader["Matricula"].ToString());
                    camiones.Add(reader["TipoCamion"].ToString());
                    camiones.Add(reader["Modelo"].ToString());
                    camiones.Add(reader["Marca"].ToString());
                    camiones.Add(reader["Capacidad"].ToString());
                    camiones.Add(reader["Kilometraje"].ToString());
                    camiones.Add(reader["Disponibilidad"].ToString());
                    camiones.Add(reader["UrlFoto"].ToString());
                }
            }
            return camiones;
        }
         

        [WebMethod]
        public CamionInfo ObtenerCamionesPorId(int id)
        {
            CamionInfo camionInfo = null;

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Camiones WHERE IdCamion = @IdCamion", conn
                    );
                cmd.Parameters.AddWithValue("@IdCamion", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    camionInfo = new CamionInfo
                    {
                        IdCamion = (int)reader["IdCamion"],
                        Matricula = reader["Matricula"].ToString(),
                        TipoCamion = reader["TipoCamion"].ToString(),
                        Modelo = (int)reader["Modelo"],
                        Marca = reader["Marca"].ToString(),
                        Capacidad = (int)reader["Capacidad"],
                        Kilometraje = (double)reader["Kilometraje"],
                        Disponibilidad = (bool)reader["Disponibilidad"],
                        UrlFoto = reader["UrlFoto"].ToString(),
                    };

                }
            }
            return camionInfo;
        }

        [WebMethod]
        public string AgregarCamion(string Matricula, string TipoCamion, int Modelo, string Marca, int Capacidad, double Kilometraje, bool Disponibilidad, string UrlFoto)
        {

            try
            {
                
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Camiones (Matricula, TipoCamion, Modelo, Marca, Capacidad, Kilometraje, Disponibilidad,  UrlFoto) VALUES (@Matricula, @TipoCamion, @Modelo, @Marca, @Capacidad, @Kilometraje, @Disponibilidad,  @UrlFoto)",
                        conn
                        );

                    cmd.Parameters.AddWithValue("@Matricula", Matricula);
                    cmd.Parameters.AddWithValue("@TipoCamion", TipoCamion);
                    cmd.Parameters.AddWithValue("@Modelo", Modelo);
                    cmd.Parameters.AddWithValue("@Marca", Marca);
                    cmd.Parameters.AddWithValue("@Capacidad", Capacidad);
                    cmd.Parameters.AddWithValue("@Kilometraje", Kilometraje);
                    cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                    cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
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
        public string ActualizarCamion(int IdCamion, string Marca)
        {

            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Camiones SET Marca = @Marca WHERE IdCamion = @IdCamion",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdCamion", IdCamion);
                    cmd.Parameters.AddWithValue("@Marca", Marca);

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
        public string EliminarCamion(int IdCamion)
        {

            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Camiones WHERE IdCamion = @IdCamion",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdCamion", IdCamion);

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
    }//fin clase
    //Clase personalizada para retornar datos estructurados
    [Serializable]//Permite que la clase convierta a XML
    public class CamionInfo
    {
        public int IdCamion { get; set; }
        public string Matricula { get; set; }
        public string TipoCamion { get; set; }
        public int Modelo { get; set; }
        public string Marca { get; set; }
        public int Capacidad { get; set; }
        public double Kilometraje { get; set; }
        public bool Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

    }
}//Fin namespace
