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
    public partial class FormCamiones : Form
    {
        private N_Camion Neg_Camion = new N_Camion();
        private int idCamionSelected = 0;
        public FormCamiones()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            E_Camion camion = new E_Camion
            {
                Matricula = textBoxMatricula.Text,
                TipoCamion = comboBoxTipoCamion.Text,
                Modelo = (int)numericUpDownModelo.Value,
                Marca = textBoxMarca.Text,
                Capacidad = (int)numericUpDownCapacidad.Value,
                Kilometraje = (double)numericUpDownKilometraje.Value,
                Disponibilidad = checkBoxDisponibilidad.Checked,
                UrlFoto = textBoxUrlFoto.Text
            };
            string result = Neg_Camion.InsertarCamion(camion);

            MessageBox.Show(result.ToString());
            AplicarFiltroActual();
            LimpiarCampos();
        }

        private void FormCamiones_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCamiones();
            CargarFiltroDisponibilidad();
            CargarTiposCamion();

            numericUpDownModelo.Minimum = 1900;
            numericUpDownModelo.Maximum = 2027;
            numericUpDownModelo.Value = 2026;

            numericUpDownCapacidad.Minimum = 1;
            numericUpDownCapacidad.Value = 1;
            numericUpDownCapacidad.Maximum = 200000;

            numericUpDownKilometraje.Minimum = 0;
            numericUpDownKilometraje.Maximum = 200000;
            numericUpDownKilometraje.Value = 0;
        }

        private void CargarCamiones(bool? disponibilidad = null)
        {
            try
            {
                dataGridViewCamiones.DataSource = null;
                dataGridViewCamiones.DataSource = Neg_Camion.ListarCamiones(disponibilidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarTiposCamion()
        {
            comboBoxTipoCamion.Items.Clear();
            comboBoxTipoCamion.Items.Add("Torton");
            comboBoxTipoCamion.Items.Add("Tractocamion");
            comboBoxTipoCamion.Items.Add("Trailer");
            comboBoxTipoCamion.Items.Add("Volteo");
            comboBoxTipoCamion.Items.Add("Refrigerado");
            comboBoxTipoCamion.Items.Add("Caja seca");
        }

        public class OpcionFiltro
        {
            public string Texto { get; set; }
            public bool? Valor { get; set; }
        }
        private void AplicarFiltroActual()
        {
            var valor = comboBoxFiltrarPor.SelectedValue as bool?;
            CargarCamiones(valor);
        }

        private void CargarFiltroDisponibilidad()
        {
            var lista = new List<OpcionFiltro>
            {
                new OpcionFiltro { Texto = "Todos", Valor = null },
                new OpcionFiltro { Texto = "Disponibles", Valor = true },
                new OpcionFiltro { Texto = "No Disponibles", Valor = false }
            };
            comboBoxFiltrarPor.DataSource = lista;
            comboBoxFiltrarPor.DisplayMember = "Texto";
            comboBoxFiltrarPor.ValueMember = "Valor";
        }

        private void LimpiarCampos()
        {
            textBoxMatricula.Clear();
            comboBoxTipoCamion.SelectedIndex = -1;
            numericUpDownModelo.Value = 2026;
            textBoxMarca.Clear();
            numericUpDownCapacidad.Value = 1;
            numericUpDownKilometraje.Value = 0;
            checkBoxDisponibilidad.Checked = false;
            textBoxUrlFoto.Clear();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (idCamionSelected == 0)
            {
                MessageBox.Show("Seleccione un camión para eliminar.");
                return;
            }
            string result = Neg_Camion.EliminarCamion(idCamionSelected);
            MessageBox.Show(result);
            AplicarFiltroActual();
            CargarCamiones();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (idCamionSelected == 0)
            {
                MessageBox.Show("Seleccione un camión para modificar.");
                return;
            }

            E_Camion camion = new E_Camion()
            {
                IdCamion = idCamionSelected,
                Matricula = textBoxMatricula.Text,
                TipoCamion = comboBoxTipoCamion.Text,
                Modelo = (int)numericUpDownModelo.Value,
                Marca = textBoxMarca.Text,
                Capacidad = (int)numericUpDownCapacidad.Value,
                Kilometraje = (double)numericUpDownKilometraje.Value,
                Disponibilidad = checkBoxDisponibilidad.Checked,
                UrlFoto = textBoxUrlFoto.Text
            };

            string result = Neg_Camion.ActualizarCamion(camion);
            MessageBox.Show(result);
            AplicarFiltroActual();
            LimpiarCampos();
        }

        private void comboBoxFiltrarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFiltrarPor.SelectedValue == null) return;
            AplicarFiltroActual();
        }

        private void dataGridViewCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var camion = (E_Camion)dataGridViewCamiones.Rows[e.RowIndex].DataBoundItem;
                idCamionSelected = camion.IdCamion;
                textBoxMatricula.Text = camion.Matricula;
                comboBoxTipoCamion.SelectedItem = camion.TipoCamion;
                numericUpDownModelo.Value = camion.Modelo;
                textBoxMarca.Text = camion.Marca;
                numericUpDownCapacidad.Value = camion.Capacidad;
                numericUpDownKilometraje.Value = (decimal)camion.Kilometraje;
                checkBoxDisponibilidad.Checked = camion.Disponibilidad;
                textBoxUrlFoto.Text = camion.UrlFoto;
            }
        }

        private void ConfigurarGrid()
        {
            dataGridViewCamiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCamiones.MultiSelect = false;
            dataGridViewCamiones.ReadOnly = true;
            dataGridViewCamiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }//Fin clase
}//Fin namespace
