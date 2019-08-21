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
    public partial class Cierres : Form
    {
        public Cierres()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void CierresGenerar_Click(object sender, EventArgs e)
        {
            this.Close();
            CirreDiario aux = new CirreDiario();
            aux.Show();
        }

        private void CierresVer_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Comprobantes aux = new Main_Comprobantes();
            aux.Show();
        }

        private void Cierres_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            VerCierres aux = new VerCierres();
            aux.Show();
        }
    }
}
