using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Drawing.Printing;

namespace WindowsFormsApp7
{

    //Form que modela el cambio de la contraseña para poder ver los Cierres y los Excels
    public partial class CambiarContraseña : Form
    {
        Global Global = new Global();
        public CambiarContraseña()
        {
            this.BackgroundImage = Properties.Resources.Salon_de_Té_FoGuangShanArgentina;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Global.Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Global.Connect())
            {
                if(textBox2.Text == textBox3.Text)
                {
                    Global.SetPasword(textBox2.Text);
                    this.Hide();
                    //string name, string price, string teacher, string amount, string clasesTotal)
                    Main_Usuarios frm5 = new Main_Usuarios();
                    frm5.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su contraseña nueva no coincide");
                }
            }
            else
            {
                MessageBox.Show("Su contraseña actual no es correcta");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Usuarios frm1 = new Main_Usuarios();
            frm1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
