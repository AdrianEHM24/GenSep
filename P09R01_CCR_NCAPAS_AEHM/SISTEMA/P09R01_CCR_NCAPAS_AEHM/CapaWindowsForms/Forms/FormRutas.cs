using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaWindowsForms.Forms
{
    public partial class FormRutas : Form
    {
        private N_Ruta Neg_Ruta = new N_Ruta();
        private int idRutaSelected = 0;
        private int idChoferSelected = 0;
        private int idCamionSelected = 0;
        public FormRutas()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var ruta = new E_Ruta
            {
                IdChofer = (int)comboBoxChofer.SelectedValue,
                IdCamion = (int)comboBoxCamion.SelectedValue,
                Origen = textBoxOrigen.Text,
                Destino = textBoxDestino.Text,
                FechaSalida = dateTimePickerFeSalida.Value,
                FechaLlegada = dateTimePickerFeLlegada.Value,
                Distancia = (double)numericUpDownDistancia.Value,
                ATiempo = checkBoxATiempo.Checked
            };
            string resultado = Neg_Ruta.InsertarRuta(ruta);
            MessageBox.Show(resultado);
            CargarRutas();
            LimpiarCampos();
        }

        private void FormRutas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarRutas();
            CargarCamiones();
            CargarChoferes();
            numericUpDownDistancia.Minimum = 1;
            numericUpDownDistancia.Value = 1;
            numericUpDownDistancia.Maximum = 200000;
        }

        private void CargarCamiones()
        {
            var camiones = new N_Camion().ListarCamiones(null);

            comboBoxCamion.DataSource = camiones;
            comboBoxCamion.DisplayMember = "Matricula";
            comboBoxCamion.ValueMember = "IdCamion";
        }

        private void CargarChoferes()
        {
            var choferes = new N_Chofer().ListarChoferes();
            comboBoxChofer.DataSource = choferes;
            comboBoxChofer.DisplayMember = "Nombre";
            comboBoxChofer.ValueMember = "IdChofer";
        }

        private void CargarRutas(bool? disponibilidad = null)
        {
            try
            {
                dataGridViewRutas.DataSource = null;
                dataGridViewRutas.DataSource = Neg_Ruta.ListarRutas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LimpiarCampos()
        {
            idRutaSelected = 0;
            idChoferSelected = 0;
            idCamionSelected = 0;
            textBoxOrigen.Clear();
            textBoxDestino.Clear();
            dateTimePickerFeSalida.Value = DateTime.Now;
            dateTimePickerFeLlegada.Value = DateTime.Now;
            numericUpDownDistancia.Value = 0;
            checkBoxATiempo.Checked = false;
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (idRutaSelected == 0)
            {
                MessageBox.Show("Seleccione una ruta para modificar.");
                return;
            }

            E_Ruta ruta = new E_Ruta
            {
                IdRuta = idRutaSelected,
                IdChofer = (int)comboBoxChofer.SelectedValue,
                IdCamion = (int)comboBoxCamion.SelectedValue,
                Origen = textBoxOrigen.Text,
                Destino = textBoxDestino.Text,
                FechaSalida = dateTimePickerFeSalida.Value,
                FechaLlegada = dateTimePickerFeLlegada.Value,
                Distancia = (double)numericUpDownDistancia.Value,
                ATiempo = checkBoxATiempo.Checked
            };
            string resultado = Neg_Ruta.ActualizarRuta(ruta);
            MessageBox.Show(resultado);
            CargarRutas();
            LimpiarCampos();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (idChoferSelected == 0)
            {
                MessageBox.Show("Seleccione una ruta para eliminar.");
                return;
            }
            string resultado = Neg_Ruta.EliminarRuta(idRutaSelected);
            MessageBox.Show(resultado);
            CargarRutas();
        }

        private void dataGridViewRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var ruta = (E_Ruta)dataGridViewRutas.Rows[e.RowIndex].DataBoundItem;
                idRutaSelected = ruta.IdRuta;
                comboBoxChofer.SelectedItem = ruta.IdChofer;
                comboBoxCamion.SelectedItem = ruta.IdCamion;
                textBoxOrigen.Text = ruta.Origen;
                textBoxDestino.Text = ruta.Destino;
                dateTimePickerFeSalida.Value = ruta.FechaSalida;
                dateTimePickerFeLlegada.Value = ruta.FechaLlegada;
                numericUpDownDistancia.Value = (decimal)ruta.Distancia;
                checkBoxATiempo.Checked = ruta.ATiempo;
            }
        }

        private void ConfigurarGrid()
        {
            dataGridViewRutas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRutas.MultiSelect = false;
            dataGridViewRutas.ReadOnly = true;
            dataGridViewRutas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        //public class OpcionFiltro
        //{
        //    public string Texto { get; set; }
        //    public bool? Valor { get; set; }
        //}
        //private void AplicarFiltroActual()
        //{
        //    var valor = comboBoxFiltrarPor.SelectedValue as bool?;
        //    CargarRutas(valor);
        //}

        //private void CargarFiltroDisponibilidad()
        //{
        //    var lista = new List<OpcionFiltro>
        //    {
        //        new OpcionFiltro { Texto = "Todos", Valor = null },
        //        new OpcionFiltro { Texto = "A tiempo", Valor = true },
        //        new OpcionFiltro { Texto = "No a tiempo", Valor = false }
        //    };
        //    comboBoxFiltrarPor.DataSource = lista;
        //    comboBoxFiltrarPor.DisplayMember = "Texto";
        //    comboBoxFiltrarPor.ValueMember = "Valor";
        //}
        private void comboBoxFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxFiltrarPor.SelectedValue == null) return;
            //AplicarFiltroActual();
        }
    }//Fin clase
}//Fin Namespace
