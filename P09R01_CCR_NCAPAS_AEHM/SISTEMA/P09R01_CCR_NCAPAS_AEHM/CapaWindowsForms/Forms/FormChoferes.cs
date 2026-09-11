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
    public partial class FormChoferes : Form
    {
        private CapaNegocios.N_Chofer Neg_Chofer = new CapaNegocios.N_Chofer();
        private int idChoferSelected = 0;
        public FormChoferes()
        {
            InitializeComponent();

        }

        private void FormChoferes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarChoferes();
            CargarFiltroDisponibilidad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idChoferSelected == 0)
            {
                MessageBox.Show("Seleccione un chofer para eliminar.");
                return;
            }
            string resultado = Neg_Chofer.EliminarChofer(idChoferSelected);
            MessageBox.Show(resultado);
            AplicarFiltroActual();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = choferesGridView.Rows[e.RowIndex];
                idChoferSelected = Convert.ToInt32(row.Cells["IdChofer"].Value);
                NombreTextBox.Text = row.Cells["Nombre"].Value.ToString();
                ApPatTextBox.Text = row.Cells["ApPaterno"].Value.ToString();
                ApMatTextBox.Text = row.Cells["ApMaterno"].Value.ToString();
                TelefonoTextBox.Text = row.Cells["Telefono"].Value.ToString();
                birthdayTimePicker.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                LicenciaTextBox.Text = row.Cells["Licencia"].Value.ToString();
                DisponibilidadCheckBox.Checked = Convert.ToBoolean(row.Cells["Disponibilidad"].Value);
                UrlFotoTextBox.Text = row.Cells["UrlFoto"].Value.ToString();
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            CapaEntidades.E_Chofer chofer = new CapaEntidades.E_Chofer
            {
                Nombre = NombreTextBox.Text,
                ApPaterno = ApPatTextBox.Text,
                ApMaterno = ApMatTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                FechaNacimiento = birthdayTimePicker.Value,
                Licencia = LicenciaTextBox.Text,
                Disponibilidad = DisponibilidadCheckBox.Checked,
                UrlFoto = UrlFotoTextBox.Text
            };
            string resultado = Neg_Chofer.InsertarChofer(chofer);
            MessageBox.Show(resultado.ToString());
            AplicarFiltroActual();
            LimpiarCampos();
        }
        private void CargarChoferes(bool? disponibilidad = null)
        {
            try
            {
                choferesGridView.DataSource = null;
                choferesGridView.DataSource = Neg_Chofer.ListarChoferes(disponibilidad);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public class OpcionFiltro
        {
            public string Texto { get; set; }
            public bool? Valor { get; set; }
        }
        private void AplicarFiltroActual()
        {
            var valor = FiltrarComboBox.SelectedValue as bool?;
            CargarChoferes(valor);
        }

        private void CargarFiltroDisponibilidad()
        {
            var lista = new List<OpcionFiltro>
            {
                new OpcionFiltro { Texto = "Todos", Valor = true || false },
                new OpcionFiltro { Texto = "Disponibles", Valor = true },
                new OpcionFiltro { Texto = "No Disponibles", Valor = false }
            };
            FiltrarComboBox.DataSource = lista;
            FiltrarComboBox.DisplayMember = "Texto";
            FiltrarComboBox.ValueMember = "Valor";
        }

        private void LimpiarCampos()
        {
            idChoferSelected = 0;
            NombreTextBox.Text = "";
            ApPatTextBox.Text = "";
            ApMatTextBox.Text = "";
            TelefonoTextBox.Text = "";
            birthdayTimePicker.Value = DateTime.Now;
            LicenciaTextBox.Text = "";
            UrlFotoTextBox.Text = "";
        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            if (idChoferSelected == 0)
            {
                MessageBox.Show("Seleccione un chofer para modificar.");
                return;
            }

            CapaEntidades.E_Chofer chofer = new CapaEntidades.E_Chofer
            {
                IdChofer = idChoferSelected,
                Nombre = NombreTextBox.Text,
                ApPaterno = ApPatTextBox.Text,
                ApMaterno = ApMatTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                FechaNacimiento = birthdayTimePicker.Value,
                Licencia = LicenciaTextBox.Text,
                Disponibilidad = DisponibilidadCheckBox.Checked,
                UrlFoto = UrlFotoTextBox.Text
            };

            string resultado = Neg_Chofer.ActualizarChofer(chofer);
            MessageBox.Show(resultado);
            AplicarFiltroActual();
            LimpiarCampos();
        }

        private void FiltrarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrarComboBox.SelectedValue == null) return;
            var valor = FiltrarComboBox.SelectedValue as bool?;
            CargarChoferes(valor);
        }

        private void ConfigurarGrid()
        {
            choferesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            choferesGridView.MultiSelect = false;
            choferesGridView.ReadOnly = true;
            choferesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }//Fin clase
}//fin namespace
