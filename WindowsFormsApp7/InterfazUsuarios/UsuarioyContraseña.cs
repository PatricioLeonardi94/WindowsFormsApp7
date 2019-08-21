using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;


namespace WindowsFormsApp7
{
    public partial class UsuarioyContraseña : Form
    {
        public UsuarioyContraseña()
        {
            this.BackgroundImage = Properties.Resources.bekir_donmez_335320_unsplash;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void UsuarioyContraseña_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string auxString = textBox2.Text;
            if (String.IsNullOrEmpty(auxString))
            {
                auxString = "";
            }
            Usuario usuario = new Usuario
            {
                Nombre = textBox1.Text,
                Contraseña = auxString
            };
            UserValidation aux = new UserValidation();
            if (aux.getUser(usuario) == true)
            {
                this.Hide();
                Main form2 = new Main();
                form2.Show();
            }
        }
    }
}
  
