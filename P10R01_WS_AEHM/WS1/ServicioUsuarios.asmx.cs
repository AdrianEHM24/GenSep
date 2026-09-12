using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace WS1
{
    /// <summary>
    /// Descripción breve de ServicioUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")] //Marca la clase como un WS
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] //Define compatibilidad con estándares
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioUsuarios : System.Web.Services.WebService
    {

        [WebMethod]//Marca un método como accesible vía SOAP
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        //Método que retorna lista
        [WebMethod]
        public List<string> ObtenerUsuarios()
        {
            List<string> usuarios = new List<string>();

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre FROM Usuarios ORDER BY Nombre",
                    conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(reader["Nombre"].ToString());
                }
            }
            return usuarios;
        }

        //Método que inserta datos
        [WebMethod]
        public bool AgregarUsuario(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }
            try
            {
                string connStr = ConfigurationManager
                    .ConnectionStrings["ConexionSQL"]
                    .ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuarios (Nombre) VALUES (@Nombre)",
                        conn
                        );

                    cmd.Parameters.AddWithValue("@Nombre", nombre);

                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch 
            {
                return false;
            }
        }

        //Método que retorna objeto personalizado
        [WebMethod]
        public UsuarioInfo ObtenerUsuarioPorId(int id)
        {
            UsuarioInfo usuario = null;

            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Id, Nombre, FechaRegistro FROM Usuarios WHERE Id = @Id", conn
                    );
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new UsuarioInfo
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        FechaRegistro = (DateTime)reader["FechaRegistro"]
                    };
                }
            }
            return usuario;
        }

    }//Fin clase

    //Clase personalizada para retornar datos estructurados
    [Serializable] //Permite que la clase convierta a XML
    public class UsuarioInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

}//Fin namespace
