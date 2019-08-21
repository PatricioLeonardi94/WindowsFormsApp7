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

namespace WindowsFormsApp7
{
    public partial class ComprobantesAlumnos : Form
    {
        string Truename;
        MinComprobante resp = new MinComprobante();
        Alumno alumno = new Alumno();

        public ComprobantesAlumnos(string name)
        {
            InitializeComponent();
            Truename = name;
            label2.Text = "Comprobantes de " + Truename;
            Initialize();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void ComprobantesAlumnos_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(alumno.ComprobantesCompletosAlumnos);
            objectListView1.Sort(NumeroComprobante, SortOrder.Descending);
            //objectListView1.Sort(NumeroComprobante, SortOrder.Descending);
        }

        private void Initialize()
        {
            string aux = string.Empty;        
            try
            {
                alumno.ComprobantesCompletosAlumnos.Clear();
                alumno.Name = Truename;
                alumno.CargarComprobantes();
                InitializeListView();
            }


            catch
            {

            }           
        }

        private void objectListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }



        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            MinComprobante comprobante = new MinComprobante();
            try
            {
                if (MessageBox.Show("Desea Abrir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    comprobante = ((MinComprobante)objectListView1.SelectedObject);
                    comprobante.retriveComprobante();
                    this.Hide();
                    //string name, string price, string teacher, string amount, string clasesTotal)
                    Comprobante_Para_Reimpresion frm3 = new Comprobante_Para_Reimpresion(comprobante);
                    frm3.ShowDialog();
                    this.Show();
                }
            }
            catch
            {

            }
        }

        private void objectListView1_CellToolTipShowing(object sender, BrightIdeasSoftware.ToolTipShowingEventArgs e)
        {
            try
            {
                string exit = "Clases con los Profesores: ";
                MinComprobante comprobante = new MinComprobante();
                comprobante = ((MinComprobante)objectListView1.SelectedObject);
                comprobante.retriveComprobante();
                foreach (var compr in comprobante.comprobantes)
                {
                    exit += compr.Profesor + ", ";
                }
                int aux = exit.Count();
                exit = exit.Substring(0, aux - 2);
                e.Text = exit;
            }
            catch
            {

            }       
        }
    }
}
