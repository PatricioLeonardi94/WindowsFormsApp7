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
    public partial class Profesores_y_cursos : Form
    {
        public Profesores_y_cursos()
        {
            this.BackgroundImage = Properties.Resources.templo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Profesores_y_cursos_Load(object sender, EventArgs e)
        {

        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            EditarProfesor frm3 = new EditarProfesor();
            frm3.ShowDialog();
            this.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
