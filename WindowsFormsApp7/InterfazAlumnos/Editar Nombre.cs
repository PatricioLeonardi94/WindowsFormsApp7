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
    public partial class Editar_Nombre : Form
    {
        public string ReturnValue1 { get; set; }
        string name = String.Empty;
        public Editar_Nombre(string nombre)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            name = nombre;
            textBox1.Text = name;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea Cambiar el Nombre de la Persona?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AlumnoMin alum = new AlumnoMin(name);
                    try
                    {
                        alum.ChangeName(textBox1.Text);
                        this.ReturnValue1 = textBox1.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }
        

        private void volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Editar_Nombre_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
