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
    public partial class Main_Comprobantes : Form
    {
        public Main_Comprobantes()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Main_Comprobantes_Load(object sender, EventArgs e)
        {

        }

        private void ComprAlum_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 aux = new Form1();
            aux.Show();
        }

        private void ComprCanc_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            CancelarComprobante frm3 = new CancelarComprobante();
            frm3.ShowDialog();
            this.Show();
        }

        private void ComprDest_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDestinoComprobantes aux = new MainDestinoComprobantes();
            aux.Show();
        }

        private void Cierres_Click(object sender, EventArgs e)
        {
            this.Close();
            Cierres aux = new Cierres();
            aux.Show();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Main aux = new Main();
            aux.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Cursos aux = new Cursos();
            aux.Show();
        }
    }
}
