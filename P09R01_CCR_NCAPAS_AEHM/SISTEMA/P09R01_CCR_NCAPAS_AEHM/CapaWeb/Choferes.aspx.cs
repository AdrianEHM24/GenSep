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
   
    public partial class Choferes : System.Web.UI.Page
    {
        private N_Chofer objNegocio = new N_Chofer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarChoferes();
                // Esto le inyecta la clase directamente al elemento input generado
                chkDisponible.InputAttributes.Add("class", "form-check-input");
            }
        }//Fin page load

        private void CargarChoferes()
        {
            try
            {
                bool? disponibilidad = null;
                if (ddlFiltro.SelectedValue == "1")
                    disponibilidad = true;
                else if (ddlFiltro.SelectedValue == "2")
                    disponibilidad = false;

                // Obtener lista de camiones
                List<E_Chofer> lista = objNegocio.ListarChoferes(disponibilidad)
                    .OrderByDescending(chofer => chofer.FechaRegistro).ToList();

                // Asignar al GridView
                gvChoferes.DataSource = lista;
                gvChoferes.DataBind();

                // Mostrar mensaje si no hay datos
                if (lista == null || lista.Count == 0)
                {
                    MostrarMensaje("No se encontraron choferes con el filtro seleccionado", "alert-info");
                }
                else
                {
                    pnlMensaje.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar choferes: " + ex.Message, "error");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarChoferes();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string script = @"mostrarModalFormulario(true)";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalFormulario", script, true);
            hfIdChofer.Value = "0";
            limpiarFormulario();
        }

        protected E_Chofer generarChofer()
        {
            return new E_Chofer
            {
                IdChofer = Convert.ToInt32(hfIdChofer.Value),
                Nombre = txtNombre.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Telefono = txtTelefono.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Licencia = txtLicencia.Text,
                Disponibilidad = chkDisponible.Checked,
                UrlFoto = txtUrlFoto.Text
            };
        }


        protected void limpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtApPaterno.Text = string.Empty;
            txtApMaterno.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtLicencia.Text = string.Empty;
            chkDisponible.Checked = false;
            txtUrlFoto.Text = string.Empty;
        }
        protected void llenarFormulario(E_Chofer chofer)
        {
            txtNombre.Text = chofer.Nombre;
            txtApPaterno.Text = chofer.ApPaterno.ToString();
            txtApMaterno.Text = chofer.ApMaterno.ToString();
            txtTelefono.Text = chofer.Telefono.ToString();
            txtFechaNacimiento.Text = chofer.FechaNacimiento.ToString("yyyy-MM-dd");
            txtLicencia.Text = chofer.Licencia;
            chkDisponible.Checked = chofer.Disponibilidad;
            txtUrlFoto.Text = chofer.UrlFoto.ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar el modal usando funciones de JavaScript
                string script = @"mostrarModalFormulario(true)";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarModalFormulario", script, true);

                // Obtener el ID del chofer que se está editando
                LinkButton btnEditar = (LinkButton)sender;
                hfIdChofer.Value = btnEditar.CommandArgument;
                int idChoferEditado = Convert.ToInt32(hfIdChofer.Value);

                // Cargar los datos del chofer seleccionado
                List<E_Chofer> lista = objNegocio.ListarChoferes();
                E_Chofer chofer = lista.Find(c => c.IdChofer == idChoferEditado);

                llenarFormulario(chofer);

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al editar el camión " + ex.Message, "alert-error");
            }
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ddlFiltro.SelectedIndex = 0;
            CargarChoferes();
        }

        protected void cvMayorEdad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                DateTime fechaNacimiento;

                // Intentar parsear el valor enviado por el input
                if (DateTime.TryParse(args.Value, out fechaNacimiento))
                {
                    DateTime hoy = DateTime.Today;
                    int edad = hoy.Year - fechaNacimiento.Year;

                    // Ajuste por si aún no ha pasado su cumpleaños este año
                    if (fechaNacimiento.Date > hoy.AddYears(-edad))
                    {
                        edad--;
                    }

                    // Es válido si la edad calculada es mayor o igual a 18
                    args.IsValid = (edad >= 18);
                }
                else
                {
                    args.IsValid = false; // Si el formato de fecha es corrupto
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
                if (!Page.IsValid)
                {
                    return;
                }
                E_Chofer entidadChofer = generarChofer();
                string resultado;
                if (entidadChofer.IdChofer == 0)
                {
                    resultado = objNegocio.InsertarChofer(entidadChofer);
                }
                else
                {
                    resultado = objNegocio.ActualizarChofer(entidadChofer);
                }
                if (resultado.ToUpper() != "OK")
                {
                    throw new Exception(resultado);
                }
                CargarChoferes();
                MostrarMensaje("Datos del chofer actualizados correctamente", "alert-success");

            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar el chofer " + ex.Message, "alert-danger");
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

            // Obtener el ID del chofer que se desea eliminar
            LinkButton btnEliminar = (LinkButton)sender;
            hfIdChofer.Value = btnEliminar.CommandArgument;
        }


        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idChoferPorEliminar = Convert.ToInt32(hfIdChofer.Value);
                string resultado = objNegocio.EliminarChofer(idChoferPorEliminar);
                if (resultado.ToUpper() == "OK")
                {
                    CargarChoferes();
                    MostrarMensaje("Chofer eliminado correctamente", "alert-success");
                }
                else {
                    MostrarMensaje($"Error al eliminar chofer, ya tiene una ruta asignada Integridad referencial- {resultado}", "alert-warning");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar el chofer " + ex.Message, "alert-danger");
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