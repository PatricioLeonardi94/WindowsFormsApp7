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
    public partial class ChangePassword : Form
    {
        Usuario User = new Usuario();
        public ChangePassword()
        {
            this.BackgroundImage = Properties.Resources.Salon_de_Té_FoGuangShanArgentina;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            User.Nombre = User.getUsuarioActual();
            User.getContraseña();
        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            if (!(User.Contraseña == textBox1.Text))
            {
                MessageBox.Show("Su contraseña actual es incorrecta");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    User.setContraseña(textBox3.Text);
                    MessageBox.Show("Su contraseña ha sido actualizada");
                    this.Close();
                    Main_Usuarios aux = new Main_Usuarios();
                    aux.Show();
                }
                else
                {
                    MessageBox.Show("Su nueva contraseña no coincide");
                }
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Usuarios aux = new Main_Usuarios();
            aux.Show();
        }

        private void NewContr1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewContr2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
