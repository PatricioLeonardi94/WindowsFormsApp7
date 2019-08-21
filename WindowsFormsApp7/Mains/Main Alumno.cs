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
    public partial class Main_Alumno : Form
    {
        public Main_Alumno()
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Main_Alumno_Load(object sender, EventArgs e)
        {

        }

        private void Alumnos_Click(object sender, EventArgs e)
        {
            this.Close();
            Alumnos aux = new Alumnos();
            aux.Show();
        }

        private void AlumnosCompr_Click(object sender, EventArgs e)
        {
            this.Close();
            AñadirPersonaBase aux = new AñadirPersonaBase();
            aux.Show();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Main aux = new Main();
            aux.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
