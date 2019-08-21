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
    public partial class MainDestinoComprobantes : Form
    {
        public MainDestinoComprobantes()
        {

            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void MainDestinoComprobantes_Load(object sender, EventArgs e)
        {

        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Comprobantes aux = new Main_Comprobantes();
            aux.Show();
        }

        //Va al form que cambia el destino de los comprobantes dentro de la computadora
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DestinoComprobantes aux = new DestinoComprobantes();
            aux.Show();
        }

        //Va al form que cambia el destino de los comprobantes dentro del server
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DestinoComprobantesServer aux = new DestinoComprobantesServer();
            aux.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
