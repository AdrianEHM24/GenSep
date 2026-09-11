using CapaWindowsForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaWindowsForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cHOFERESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChoferes frm = new FormChoferes();
            frm.ShowDialog();
        }

        private void cAMIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCamiones frm = new FormCamiones();
            frm.ShowDialog();
        }

        private void rUTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRutas frm = new FormRutas();
            frm.ShowDialog();
        }
    }
}
