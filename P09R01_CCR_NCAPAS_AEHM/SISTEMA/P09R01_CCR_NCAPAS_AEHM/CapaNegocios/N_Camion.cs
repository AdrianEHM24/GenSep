using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Camion
    {
        private D_Camion objDatos = new D_Camion();

        public List<E_Camion> ListarCamiones(bool? disponibilidad = null) 
        {
            try
            {
                return objDatos.ListarCamiones(disponibilidad);
            }
            catch (Exception ex) { 
                throw new Exception("Error en capa de negocios: "+ ex.Message);
            }
        }

        public string InsertarCamion(E_Camion camion) 
        {
            try 
            {
                //Validaciones de negocio
                if (string.IsNullOrEmpty(camion.Matricula))
                    return "La matricula es obligatoria";
                if (string.IsNullOrEmpty(camion.TipoCamion))
                    return "El tipo de camion es obligatorio";
                if (camion.Modelo <1900 || camion.Modelo > DateTime.Now.Year + 1)
                    return "El modelo debe estar entre 1900 y " + (DateTime.Now.Year + 1);
                if (string.IsNullOrEmpty(camion.Marca))
                    return "La marca es obligatoria";
                if (camion.Capacidad <= 0)
                    return "La capacidad debe ser mayor a 0";
                if (camion.Kilometraje < 0)
                    return "El kilometraje no puede ser menor que 0";
                //Verificar si existe la matricula
                if (objDatos.ExisteMatricula(camion.Matricula))
                    return "Ya existe un camión con esa matricula";
                if (objDatos.InsertarCamion(camion))
                    return "Ok";
                else
                    return "No se pudo insertar el camion";
            }
            catch(Exception ex) 
            { 
                return "Error " + ex.Message; 
            }
        }

        public string ActualizarCamion(E_Camion camion) 
        {
            try
            {
                if (string.IsNullOrEmpty(camion.Matricula))
                    return "La matricula es obligatoria";
                if (camion.Modelo < 1900 || camion.Modelo > DateTime.Now.Year + 1)
                    return "El modelo no es válido";
                if (camion.Capacidad <= 0)
                    return "La capacidad debe ser mayor a 0";

                //Obtenemos el camion tal cual esta en la BD antes de actualizar
                E_Camion camionActual = objDatos.ObtenerCamionPorID(camion.IdCamion);
                if (camionActual == null)
                    return "El camion que intenta actualizar no existe";

                //Solo validamos duplicado si la matricula fue modificada
                bool matriculaCambio = !camionActual.Matricula.Equals(
                    camion.Matricula, StringComparison.OrdinalIgnoreCase);

                if (matriculaCambio && objDatos.ExisteMatricula(camion.Matricula))
                    return "Ya existe otro camion registrado con esa matricula";

                if (objDatos.ActualizarCamion(camion))
                    return "Ok";
                else
                    return "No se pudo actualizar el camion";
            }
            catch (Exception ex) {
                return "Error " + ex.Message;
            }
        }

        public string EliminarCamion(int idCamion) 
        {
            try
            {
                if (objDatos.EliminarCamion(idCamion))
                    return "Ok";
                else
                    return "No se pudo eliminar camion"; 
            }
            catch (Exception ex)
            {
                return "Error " + ex.Message;
            }
        }

        public E_Camion ObtenerCamionPorID(int idCamion)
        {
            try
            {
                return objDatos.ObtenerCamionPorID(idCamion);
            }
            catch (Exception ex)
            {
                throw new Exception ("Error " + ex.Message);
            }
        }

    }//Fin clase
}//Fin namespace
