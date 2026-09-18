using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace P16R01_WCF_AEHM
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string HolaMundo()
        {
            return "Hola mundo desde WCF";
        }

        public List<string> ObtenerUsuarios()
        {
            List<string> usuarios = new List<string>();

            //Obtener cadena de conexion
            string connStr = ConfigurationManager
                .ConnectionStrings["ConexionSQL"]
                .ConnectionString;

            //Conectar a la BD
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Nombre FROM Usuarios",
                    conn
                    );

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(reader["Nombre"].ToString());
                }
            }
            return usuarios;
        }

    }//Fin clase
}//Fin namespace
