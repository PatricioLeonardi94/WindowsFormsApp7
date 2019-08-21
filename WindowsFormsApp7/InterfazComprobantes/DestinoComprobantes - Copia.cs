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
using Humanizer;


namespace WindowsFormsApp7
{
    public partial class DestinoComprobantes : Form
    {
        Global Global = new Global();
        public DestinoComprobantes()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            textBox1.Text = Global.getDire();
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "No posee carpeta elegida para guardar los archivos de excel";
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Cambiar el Destino de los Comprobantes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    Global.setDire(textBox2.Text);
                }
                string aux = textBox2.Text + "\\Diario\\";
                string aux1 = textBox2.Text + "\\Mensual\\";
                string aux2 = textBox2.Text + "\\Liquidaciones\\";
                string aux3 = textBox2.Text + "\\LiquidacionesLibros\\";
                Directory.CreateDirectory(aux);
                Directory.CreateDirectory(aux1);
                Directory.CreateDirectory(aux2);
                Directory.CreateDirectory(aux3);
                this.Close();
                Main_Comprobantes frm4 = new Main_Comprobantes();
                frm4.Show();
            }
            else
            {
                // user clicked no
            }
            
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDestinoComprobantes frm1 = new MainDestinoComprobantes();
            frm1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

     

       

        public class Direccion
        {
            string direccion;

            public Direccion(string dire)
            {
                this.direccion = dire;
            }

            public void changeDire(string dire)
            {
                this.direccion = dire;
            }

            public string getDire()
            {
                return this.direccion;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if(fdb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = (fdb.SelectedPath);
            }
        }

        private void DestinoComprobantes_Load(object sender, EventArgs e)
        {

        }
    }
}
