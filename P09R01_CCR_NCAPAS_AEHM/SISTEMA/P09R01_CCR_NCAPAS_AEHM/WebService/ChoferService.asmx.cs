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
    /// Descripción breve de ChoferService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ChoferService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<string> ObtenerChoferes()
        {
            List<string> choferes = new List<string>();

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Choferes",
                    conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    choferes.Add(reader["IdChofer"].ToString());
                    choferes.Add(reader["Nombre"].ToString());
                    choferes.Add(reader["ApPaterno"].ToString());
                    choferes.Add(reader["ApMaterno"].ToString());
                    choferes.Add(reader["Telefono"].ToString());
                    choferes.Add(reader["FechaNacimiento"].ToString());
                    choferes.Add(reader["Licencia"].ToString());
                    choferes.Add(reader["UrlFoto"].ToString());
                    choferes.Add(reader["Disponibilidad"].ToString());
                    choferes.Add(reader["FechaRegistro"].ToString());
                }
            }
            return choferes;
        }

        [WebMethod]
        public ChoferInfo ObtenerChoferesPorId(int id)
        {
            ChoferInfo choferInfo = null;

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Choferes WHERE IdChofer = @IdChofer", conn
                    );
                cmd.Parameters.AddWithValue("@IdChofer", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    choferInfo = new ChoferInfo
                    {
                        IdChofer = (int)reader["IdChofer"],
                        Nombre = reader["Nombre"].ToString(),
                        ApPaterno = reader["ApPaterno"].ToString(),
                        ApMaterno = reader["ApMaterno"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                        Licencia = reader["Licencia"].ToString(),
                        UrlFoto = reader["UrlFoto"].ToString(),
                        Disponibilidad = (bool)reader["Disponibilidad"],
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    };

                }
            }
            return choferInfo;
        }

        [WebMethod]
        public string AgregarChofer(string Nombre, string ApPaterno, string ApMaterno, string Telefono, DateTime FechaNacimiento, string Licencia, string UrlFoto, bool Disponibilidad) 
        {
            
            try
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El nombre es obligatorio";
                if (string.IsNullOrEmpty(ApPaterno))
                    return "El apellido paterno es obligatorio";
                if (string.IsNullOrEmpty(ApMaterno))
                    return "El apellido materno es obligatorio";
                if (string.IsNullOrEmpty(Telefono))
                    return "El telefono es obligatorio";
                if (Telefono.Trim().Length != 10)
                    return "El telefono debe ser de 10 digitos";
                if (string.IsNullOrEmpty(Licencia))
                    return "La licencia es obligatoria";
                int edad = DateTime.Now.Year - FechaNacimiento.Year;
                if (FechaNacimiento > DateTime.Now.AddYears(-edad)) edad--;
                if (edad < 18)
                    return "El chofer debe ser mayor de 18 años";
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Choferes (Nombre, ApPaterno, ApMaterno, Telefono, FechaNacimiento, Licencia, UrlFoto, Disponibilidad) VALUES (@Nombre, @ApPaterno, @ApMaterno, @Telefono, @FechaNacimiento, @Licencia, @UrlFoto, @Disponibilidad)",
                        conn
                        );

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@ApPaterno", ApPaterno);
                    cmd.Parameters.AddWithValue("@ApMaterno", ApMaterno);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Licencia", Licencia);
                    cmd.Parameters.AddWithValue("@UrlFoto", UrlFoto);
                    cmd.Parameters.AddWithValue("@Disponibilidad", Disponibilidad);
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return "ok";
                }
            }
            catch (Exception ex) {
            
                return "Error" + ex.Message;
            }
        }

        [WebMethod]
        public string ActualizarChofer(string Nombre, int IdChofer)
        {

            try
            {
                if (string.IsNullOrEmpty(Nombre))
                    return "El nombre es obligatorio";

                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Choferes SET Nombre = @Nombre WHERE IdChofer = @IdChofer",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdChofer", IdChofer);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

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
        public string EliminarChofer(int IdChofer)
        {

            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Choferes WHERE IdChofer = @IdChofer",
                        conn
                        );
                    cmd.Parameters.AddWithValue("@IdChofer", IdChofer);

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
    public class ChoferInfo 
    {
        public int IdChofer { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Licencia { get; set; }
        public string UrlFoto { get; set; }
        public bool Disponibilidad { get; set; }
        public DateTime FechaRegistro { get; set; }

    }

}//Fin namespace
