using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Main_Listas : Form
    {
        public Main_Listas()
        {
            this.BackgroundImage = Properties.Resources.templo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Interfaz_Listas_Clases frm3 = new Interfaz_Listas_Clases();
            frm3.ShowDialog();
            this.Show();
        }

        private void ListasClases_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Ver_Listas_Clases frm3 = new Ver_Listas_Clases();
            frm3.ShowDialog();
            this.Show();
        }

        private void Main_Listas_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
