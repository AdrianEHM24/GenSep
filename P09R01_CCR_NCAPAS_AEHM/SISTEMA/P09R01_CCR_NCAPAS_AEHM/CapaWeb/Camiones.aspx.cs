using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using CapaEntidades;

namespace CapaWeb
{
    public partial class Camiones : System.Web.UI.Page
    {
        private N_Camion objNegocio = new N_Camion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                CargarCamiones();
                InicializarControles();
            }

        }//Fin del pageload
        private void InicializarControles()
        {
            // Esto le inyecta la clase directamente al elemento input generado
            chkDisponible.InputAttributes.Add("class", "form-check-input");

            rvModelo.MaximumValue = (DateTime.Now.Year + 1).ToString();
            rvModelo.ErrorMessage = $"El modelo debe estar entre {rvModelo.MinimumValue} y {rvModelo.MaximumValue}";
        }
        private void CargarCamiones()
        {
            try
            {
                bool? disponibilidad = null;
                if (ddlFiltro.SelectedValue == "1")
                    disponibilidad = true;
                else if (ddlFiltro.SelectedValue == "2")
                    disponibilidad = false;

                // Obtener lista de camiones
                List<E_Camion> lista = objNegocio.ListarCamiones(disponibilidad);

                // Asignar al GridView
                gvCamiones.DataSource = lista;
                gvCamiones.DataBind();

                // Mostrar mensaje si no hay datos
                if (lista == null || lista.Count == 0)
                {
                    MostrarMensaje("No se encontraron camiones con el filtro seleccionado", "alert-info");
                }
                else
                {
                    pnlMensaje.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar camiones: " + ex.Message, "error");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCamiones();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            hfIdCamion.Value = "0";
            limpiarFormulario();
            string script = @"mostrarModalFormulario(true)";
            ScriptManager.RegisterStartupScript((Control)sender, sender.GetType(), "MostrarModalAgregar", script, true);
        }

        protected E_Camion generarCamion()
        {
            return new E_Camion
            {
                IdCamion = Convert.ToInt32(hfIdCamion.Value),
                Matricula = txtMatricula.Text,
                TipoCamion = ddlTipoCamion.SelectedValue,
                Modelo = Convert.ToInt32(txtModelo.Text),
                Marca = txtMarca.Text,
                Capacidad = Convert.ToInt32(txtCapacidad.Text),
                Kilometraje = Convert.ToDouble(txtKilometraje.Text),
                Disponibilidad = chkDisponible.Checked,
                UrlFoto = txtUrlFoto.Text
            };
        }


        protected void limpiarFormulario()
        {
            txtMatricula.Text = string.Empty;
            ddlTipoCamion.SelectedValue = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
            txtKilometraje.Text = string.Empty;
            chkDisponible.Checked = false;
            txtUrlFoto.Text = string.Empty;
        }
        protected void llenarFormulario(E_Camion camion)
        {
            txtMatricula.Text = camion.Matricula;
            ddlTipoCamion.SelectedValue = camion.TipoCamion;
            txtModelo.Text = camion.Modelo.ToString();
            txtMarca.Text = camion.Marca.ToString();
            txtCapacidad.Text = camion.Capacidad.ToString();
            txtKilometraje.Text = camion.Kilometraje.ToString();
            chkDisponible.Checked = camion.Disponibilidad;
            txtUrlFoto.Text = camion.UrlFoto.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar el modal usando funciones de JavaScript
                string script = @"mostrarModalFormulario(true)";
                ScriptManager.RegisterStartupScript((Control)sender, sender.GetType(), "MostrarModalEditar", script, true);

                // Obtener el ID del Camión que se está editando
                LinkButton btnEditar = (LinkButton)sender;
                hfIdCamion.Value = btnEditar.CommandArgument;
                int idCamionEditado = Convert.ToInt32(hfIdCamion.Value);

                // Cargar los datos del camión seleccionado
                E_Camion camion = objNegocio.ObtenerCamionPorID(idCamionEditado);
                llenarFormulario(camion);

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al editar el camión " + ex.Message, "alert-error");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ddlFiltro.SelectedIndex = 0;
            CargarCamiones();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                {
                    return;
                }

                E_Camion entidadCamion = generarCamion();
                string resultado;
                if (entidadCamion.IdCamion == 0)
                {
                    resultado = objNegocio.InsertarCamion(entidadCamion);
                }
                else
                {
                    resultado = objNegocio.ActualizarCamion(entidadCamion);
                }
                if (resultado.ToUpper() != "OK")
                {
                    throw new Exception(resultado);
                }
                CargarCamiones();
                MostrarMensaje("Datos del camión actualizados correctamente", "alert-success");

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar el camión " + ex.Message, "alert-danger");

            }
            finally
            {
                string script = @"mostrarModalFormulario(false)";
                ScriptManager.RegisterStartupScript((Control)sender, sender.GetType(), "OcultarModalFormulario", script, true);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlMensaje.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string script = @"mostrarModalEliminar(true)";
            ScriptManager.RegisterStartupScript((Control)sender, sender.GetType(), "MostrarModalEliminar", script, true);


            // Obtener el ID del Camión que se desea eliminar
            LinkButton btnEliminar = (LinkButton)sender;
            hfIdCamion.Value = btnEliminar.CommandArgument;
        }


        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCamionPorEliminar = Convert.ToInt32(hfIdCamion.Value);
                string resultado = objNegocio.EliminarCamion(idCamionPorEliminar);
                if (resultado.ToUpper() == "OK")
                {
                    CargarCamiones();
                    MostrarMensaje("Camión eliminado correctamente", "alert-success");
                }
                else
                {
                    MostrarMensaje($"Error al eliminar camión, ya tiene una ruta asignada Integridad referencial- {resultado}", "alert-warning");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar el camión " + ex.Message, "alert-danger");
            }
            finally
            {
                string script = @"mostrarModalEliminar(false)";
                ScriptManager.RegisterStartupScript((Control)sender, sender.GetType(), "OcultarModalEliminar", script, true);


            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            pnlMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            pnlMensaje.CssClass = $"alert {tipo} alert-dismissible fade show";
        }

    }//Final de la clase
}//Fin namespace