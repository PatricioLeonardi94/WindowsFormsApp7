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
    public partial class Main_Libro : Form
    {
        public Main_Libro()
        {
            this.BackgroundImage = Properties.Resources.Libros;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Main_Libro_Load(object sender, EventArgs e)
        {

        }

        private void Stock_Click(object sender, EventArgs e)
        {
            this.Close();
            Deposito deposito = new Deposito();
            deposito.Show();
        }

        private void AgregarLibro_Click(object sender, EventArgs e)
        {
            this.Close();
            AgregarLibro aux = new AgregarLibro();
            aux.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            RetiroDeLibro aux = new RetiroDeLibro();
            aux.Show();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main aux = new Main();
            aux.Show();
        }
    }
}
