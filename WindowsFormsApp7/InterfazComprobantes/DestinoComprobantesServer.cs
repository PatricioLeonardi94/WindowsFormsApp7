using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp7
{
    public partial class DestinoComprobantesServer : Form
    {
        Global Global = new Global();
        public DestinoComprobantesServer()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            textBox1.Text = Global.getPath();
        }

        private void DestinoComprobantesServer_Load(object sender, EventArgs e)
        {

        }

        private void Carpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if (fdb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = (fdb.SelectedPath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cambiar el Destino de los Comprobantesen el Server?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    Global.setPath(textBox2.Text);
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
                MainDestinoComprobantes frm4 = new MainDestinoComprobantes();
                frm4.Show();
            }
            else
            {
                // user clicked no
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainDestinoComprobantes frm4 = new MainDestinoComprobantes();
            frm4.Show();
        }
    }
}
