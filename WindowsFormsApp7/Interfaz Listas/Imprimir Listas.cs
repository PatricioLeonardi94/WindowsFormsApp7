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
    public partial class Interfaz_Listas_Clases : Form
    {
        Clase clase = new Clase();
        List<Clase> lista = new List<Clase>();
        List<string> profesores = new List<string>();
        string profesor = string.Empty;

        public Interfaz_Listas_Clases()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            initialize();
            profesores = clase.getProfesoresTodos();
            CargarDeposito(profesores);
        }

        public void initialize()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Alumnos", 300, HorizontalAlignment.Left);


            listView2.View = View.Details;
            listView2.Columns.Add("Profesores", 200, HorizontalAlignment.Left);


            listView3.View = View.Details;
            listView3.Columns.Add("Clases", 150, HorizontalAlignment.Left);
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            clase.Alumnos.Clear();
            try
            {
                string clasePart = listView3.SelectedItems[0].SubItems[0].Text;
                var StartDay = dateTimePicker1.Value;
                var LastDay = dateTimePicker2.Value;

                clase.getAlumnosRange(profesor, clasePart, StartDay, LastDay);
                CargarDeposito3(clase.Alumnos);
            }
            catch
            {

            }
           
        }

        private void CargarDeposito(List<string> Clases)
        {
            foreach (var doc in Clases)
            {
                listView2.Items.Add(doc);
            }
        }

        //alumnos
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //profesores
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //clases
        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            try
            {
                clase.Clases.Clear();
                profesor = (listView2.SelectedItems[0].SubItems[0].Text);
                clase.getClases(profesor);
                CargarDeposito2(clase.Clases);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void CargarDeposito2(List<string> ClasesProfesor)
        {
            listView3.Items.Clear();
            foreach (var doc in ClasesProfesor)
            {
                listView3.Items.Add(doc);
            }
        }

        private void CargarDeposito3(List<string> ClasesProfesor)
        {
            listView1.Items.Clear();
            foreach (var doc in ClasesProfesor)
            {
                listView1.Items.Add(doc);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var alumno = listView1.SelectedItems[0].SubItems[0].Text;
                if (MessageBox.Show("Abrir los Recibos de " + alumno + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string aux = string.Empty;
                    this.Hide();
                    //string name, string price, string teacher, string amount, string clasesTotal)
                    ComprobantesAlumnos frm3 = new ComprobantesAlumnos(alumno);
                    frm3.ShowDialog();
                    this.Show();
                }
            }
            catch
            {

            }
        }
    }
}
