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
    public partial class Contraseña_Nota_De_Credito : Form
    {
        Global Global = new Global();
        MinComprobante auxCompor = new MinComprobante();

        public Contraseña_Nota_De_Credito(MinComprobante compr)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            auxCompor = compr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contraseñaIngresada = textBox1.Text;
            var contraseñaNotaCredito = Global.Connect();
            if (contraseñaIngresada == contraseñaNotaCredito)
            {
                this.Hide();
                //string name, string price, string teacher, string amount, string clasesTotal)
                Nota_De_Credito frm3 = new Nota_De_Credito(auxCompor);
                frm3.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("La contraseña NO es correcta.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Contraseña_Nota_De_Credito_Load(object sender, EventArgs e)
        {

        }
    }
}
