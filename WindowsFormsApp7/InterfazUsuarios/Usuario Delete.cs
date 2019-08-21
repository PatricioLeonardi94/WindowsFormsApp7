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
    public partial class Usuario_Delete : Form
    {
        Usuario User = new Usuario();
        List<Usuario> Usuarios = new List<Usuario>();
        Usuario User2 = new Usuario();
        public Usuario_Delete()
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
            Usuarios = User.getAllUsers();
            InitializeListView();
        }

        private void Usuario_Delete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Usuarios aux = new Main_Usuarios();
            aux.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(User.Contraseña == textBox1.Text))
            {
                MessageBox.Show("Su contraseña actual es incorrecta");
            }
            else
            {
                if (MessageBox.Show("Desea Eliminar el Usuario " + User2.Nombre + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User2.getContraseña();
                    User2.deleteUser();
                    MessageBox.Show(User2.Nombre + " fue eliminado.");
                    this.Close();
                    Main_Usuarios aux = new Main_Usuarios();
                    aux.Show();
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(Usuarios);
        }

        private void objectListView1_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            try
            {
                // statements causing exception
                User2.Nombre = objectListView1.SelectedItem.Text;
            }
            catch (System.NullReferenceException)
            {
                // error handling code
                MessageBox.Show("Seleccione el usuario debajo del titulo");
            }
            
            //UserSelected = aux.ToString();
            //MessageBox.Show(aux.ToString());

        }
    }
}
