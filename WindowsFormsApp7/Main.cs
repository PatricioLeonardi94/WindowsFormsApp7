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
    public partial class Main : Form
    {
        public Main()
        {
            this.BackgroundImage = Properties.Resources.templo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Comprobantes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Comprobantes aux = new Main_Comprobantes();
            aux.Show();
        }

        private void Alumnos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Alumno aux = new Main_Alumno();
            aux.Show();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Usuarios aux = new Main_Usuarios();
            aux.Show();
        }

        private void Libros_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Libro aux = new Main_Libro();
            aux.Show();
        }

        //Interfaz profesores y cursos
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Profesores_y_cursos frm3 = new Profesores_y_cursos();
            frm3.ShowDialog();
            this.Show();
        }

        private void Clasesycursos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cerrar el Programa?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Main_Listas frm3 = new Main_Listas();
            frm3.ShowDialog();
            this.Show();
        }

        
    }
}
