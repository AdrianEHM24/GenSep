using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaNegocios;

namespace CapaWeb
{
    public partial class Rutas : System.Web.UI.Page
    {
        private N_Ruta objNegocio = new N_Ruta();
        private N_Chofer objNegocioChofer = new N_Chofer();
        private N_Camion objNegocioCamion = new N_Camion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarRutasDetalle();
                CargarRutas();
                CargarChoferes();
                CargarCamiones();
                // Esto le inyecta la clase directamente al elemento input generado
                chkATiempo.InputAttributes.Add("class", "form-check-input");
            }
        }//Fin del pageload

        private void CargarRutas()
        {
            bool? aTiempo = null;
            if (ddlFiltro.SelectedValue == "1")
                aTiempo = true;
            else if (ddlFiltro.SelectedValue == "2")
                aTiempo = false;

            List<E_Ruta> lista = objNegocio.ListarRutas();
            List<E_Ruta> listaFiltrada = lista.Where(ruta => ruta.ATiempo == aTiempo || aTiempo is null).ToList();

            // Mostrar mensaje si no hay datos
            if (listaFiltrada == null || listaFiltrada.Count == 0)
            {
                MostrarMensaje("No se encontraron rutas con el filtro seleccionado", "alert-info");
            }
            else
            {
                pnlMensaje.Visible = false;
            }

            // Asignar al GridView
            gvChoferes.DataSource = listaFiltrada;
            gvChoferes.DataBind();
        }

        private void CargarChoferes()
        {

            List<E_Chofer> listaChoferes = objNegocioChofer.ListarChoferes();
            ddlIdChofer.DataSource = listaChoferes;
            ddlIdChofer.DataValueField = "IdChofer";     // El valor interno (ID)
            ddlIdChofer.DataTextField = "NombreCompleto";  // Lo que ve el usuario (Texto)
            ddlIdChofer.DataBind();
        }

        private void CargarCamiones()
        {
            List<E_Camion> listaCamiones = objNegocioCamion.ListarCamiones();
            ddlIdCamion.DataSource = listaCamiones;
            ddlIdCamion.DataValueField = "IdCamion";     // El valor interno (ID)
            ddlIdCamion.DataTextField = "Descripcion";  // Lo que ve el usuario (Texto)
            ddlIdCamion.DataBind();
        }
        private void CargarRutasDetalle()
        {
            try
            {
                bool? aTiempo = null;
                if (ddlFiltro.SelectedValue == "1")
                    aTiempo = true;
                else if (ddlFiltro.SelectedValue == "2")
                    aTiempo = false;

                // Obtener lista de camiones
                List<E_Ruta> lista = objNegocio.ListarRutas();
                List<E_Ruta> listaFiltrada = lista.Where(r => r.ATiempo == aTiempo || aTiempo is null).ToList();

                // Asignar al GridView
                gvChoferes.DataSource = listaFiltrada;
                gvChoferes.DataBind();

                // Mostrar mensaje si no hay datos
                if (lista == null || lista.Count == 0)
                {
                    MostrarMensaje("No se encontraron rutas con el filtro seleccionado", "alert-info");
                }
                else
                {
                    pnlMensaje.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar rutas: " + ex.Message, "error");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string script = @"mostrarModalFormulario(true)";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalFormulario", script, true);
            hfIdRuta.Value = "0";
            limpiarFormulario();
        }

        protected E_Ruta generarRuta()
        {
            return new E_Ruta
            {
                IdRuta = Convert.ToInt32(hfIdRuta.Value),
                IdChofer = Convert.ToInt32(ddlIdChofer.SelectedValue),
                IdCamion = Convert.ToInt32(ddlIdCamion.SelectedValue),
                Origen = txtOrigen.Text,
                Destino = txtDestino.Text,
                FechaSalida = Convert.ToDateTime(txtFechaSalida.Text),
                FechaLlegada = Convert.ToDateTime(txtFechaLlegada.Text),
                ATiempo = chkATiempo.Checked,
                Distancia = Convert.ToDouble(txtDistancia.Text)
            };
        }


        protected void limpiarFormulario()
        {
            txtOrigen.Text = string.Empty;
            txtDestino.Text = string.Empty;
            txtFechaSalida.Text = string.Empty;
            txtFechaLlegada.Text = string.Empty;
            chkATiempo.Checked = false;
            txtDistancia.Text = string.Empty;
        }
        protected void llenarFormulario(E_Ruta ruta)
        {
            ddlIdChofer.SelectedValue = ruta.IdChofer.ToString();
            ddlIdCamion.SelectedValue = ruta.IdCamion.ToString();
            txtOrigen.Text = ruta.Origen.ToString();
            txtDestino.Text = ruta.Destino.ToString();
            txtFechaSalida.Text = ruta.FechaSalida.ToString("yyyy-MM-ddTHH:mm");
            txtFechaLlegada.Text = ruta.FechaLlegada.ToString("yyyy-MM-ddTHH:mm");
            chkATiempo.Checked = ruta.ATiempo;
            txtDistancia.Text = ruta.Distancia.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar el modal usando funciones de JavaScript
                string script = @"mostrarModalFormulario(true)";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalFormulario", script, true);

                // Obtener el ID de la ruta que se está editando
                LinkButton btnEditar = (LinkButton)sender;
                hfIdRuta.Value = btnEditar.CommandArgument;
                int idRutaEditada = Convert.ToInt32(hfIdRuta.Value);

                // Cargar los datos de la ruta seleccionada
                List<E_Ruta> lista = objNegocio.ListarRutas();
                E_Ruta ruta = lista.Find(r => r.IdRuta == idRutaEditada);

                llenarFormulario(ruta);

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al editar el camión " + ex.Message, "alert-error");
            }
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ddlFiltro.SelectedIndex = 0;
            CargarRutas();
        }

        protected void cvCompararFechas_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                // Obtenemos el valor de la fecha de llegada directamente desde el TextBox
                DateTime fechaSalida;
                DateTime fechaLlegada;

                bool salidaOk = DateTime.TryParse(args.Value, out fechaSalida);
                bool llegadaOk = DateTime.TryParse(txtFechaLlegada.Text, out fechaLlegada);

                // Si ambas fechas son válidas, comparamos sus valores completos (Fecha + Hora)
                if (llegadaOk && salidaOk)
                {
                    args.IsValid = (fechaLlegada > fechaSalida);
                }
                else
                {
                    args.IsValid = false; // Formato de fecha irreconocible
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Ruta entidadRuta = generarRuta();
                string resultado;
                if (entidadRuta.IdRuta == 0)
                {
                    resultado = objNegocio.InsertarRuta(entidadRuta);
                }
                else
                {
                    resultado = objNegocio.ActualizarRuta(entidadRuta);
                }
                if (resultado.ToUpper() != "OK")
                {
                    throw new Exception(resultado);
                }
                CargarRutas();
                MostrarMensaje("Datos de la ruta actualizados correctamente", "alert-success");

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar la ruta " + ex.Message, "alert-danger");
            }
            finally
            {
                string script = @"mostrarModalFormulario(false)";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OcultarModalFormulario", script, true);
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlMensaje.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string script = @"mostrarModalEliminar(true)";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalEliminar", script, true);

            // Obtener el ID de la ruta que se desea eliminar
            LinkButton btnEliminar = (LinkButton)sender;
            hfIdRuta.Value = btnEliminar.CommandArgument;
        }


        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idRutaPorEliminar = Convert.ToInt32(hfIdRuta.Value);
                string resultado = objNegocio.EliminarRuta(idRutaPorEliminar);
                CargarRutas();
                MostrarMensaje("Ruta eliminada correctamente", "alert-success");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar la ruta " + ex.Message, "alert-danger");
            }
            finally
            {
                string script = @"mostrarModalEliminar(false)";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "OcultarModalEliminar", script, true);
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            pnlMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            pnlMensaje.CssClass = $"alert {tipo} alert-dismissible fade show";
        }

    }//Fin clase
}//Fin namespace