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
    public partial class Main_Usuarios : Form
    {
        public Main_Usuarios()
        {
            this.BackgroundImage = Properties.Resources.Salon_de_Té_FoGuangShanArgentina;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Main_Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            NewUser aux = new NewUser();
            aux.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangePassword aux = new ChangePassword();
            aux.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Usuario_Delete aux = new Usuario_Delete();
            aux.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Voler_Click(object sender, EventArgs e)
        {
            this.Close();
            Main aux = new Main();
            aux.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            this.Close();
            CambiarContraseña aux = new CambiarContraseña();
            aux.Show();
        }
    }
    }

