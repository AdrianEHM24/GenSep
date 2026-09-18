using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteWCF.ServiceReference1;

namespace ClienteWCF
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Crear instancia del cliente
            Service1Client cliente  = new Service1Client();

            try
            {
                //Llamar al método ObtenerUsuarios
                string[] usuarios = cliente.ObtenerUsuarios();

                Console.WriteLine("Usuarios en la base de datos: ");
                foreach (string usuario in usuarios)
                {
                    Console.WriteLine("- " + usuario);
                }

                //Cerrar la conexion
                cliente.Close();
            }
            catch (Exception ex) { 
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();

        }//Fin main
    }//Fin clase
}//Fin namespace
