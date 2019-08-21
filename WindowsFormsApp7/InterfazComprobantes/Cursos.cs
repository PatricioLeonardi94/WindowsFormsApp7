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
    public partial class Cursos : Form
    {
        string Persona = string.Empty;
        Curso CursosTotales = new Curso();
        Clase ClaseParaEnviar = new Clase();
        List<Clase> ClasesList = new List<Clase>();

        public Cursos()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Form1_Load();
            LoadCursos(CursosTotales.GetCursos());
        }

        public Cursos(string name, List<Clase> clases)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            ClasesList = clases;
            Persona = name;
            textBox1.Text = Persona;
            Form1_Load();
            LoadCursos(CursosTotales.GetCursos());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Persona = textBox1.Text;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
        }

        public void LoadCursos(List<Curso> auxCursos)
        {
            foreach(var curso in auxCursos)
            {
                checkedListBox1.Items.Add(curso.Nombre);
            }
            
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            try
            {
                CursosTotales.Precio = string.Empty;
                CursosTotales.Precios = new List<string>();
                CursosTotales.Nombre = checkedListBox1.SelectedItem.ToString();
                CursosTotales.getPrecio();
                checkedListBox2.Items.Clear();
                if (CursosTotales.Precios.Any())
                {
                    foreach (var precio in CursosTotales.Precios)
                    {
                        checkedListBox2.Items.Add(precio);
                    }
                }
                else
                {
                    checkedListBox2.Items.Add(CursosTotales.Precio);
                }
            }
            catch { }
               
        }

        /* public string CantidadClases { get; set; }
        public string Profesor { get; set; }
        public string Precio { get; set; }
        public string ClasesTomar { get; set; }
        public string Descripcion { get; set; }*/

        private void Imprimir_Click(object sender, EventArgs e)
        {

            form();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm4 = new Form1( ClasesList);
            frm4.Show();

        }

        private void Form1_Load()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            textBox1.AutoCompleteCustomSource = combData;
        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                dataCollection.Add(doc.GetElement("Nombre").Value.AsString);
            }
        }

        private void credencial_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imprimirCurso_Click(object sender, EventArgs e)
        {
            form();
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            ImprimirTicket frm3 = new ImprimirTicket(ClasesList, textBox1.Text, true);
            frm3.ShowDialog();
            this.Show();
        }

        private void form()
        {
            /*
            ClaseParaEnviar.ClasesTomar = checkedListBox1.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            if (ClaseParaEnviar.ClasesTomar == "")
                //ClaseParaEnviar.Precio = checkedListBox2.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            ClaseParaEnviar.Precio = checkedListBox2.SelectedItem.ToString();
            MessageBox.Show(checkedListBox2.SelectedItem.ToString());
            int cantidad = Convert.ToInt32(checkedListBox3.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString()));
            ClaseParaEnviar.Total =  ((Convert.ToInt32(ClaseParaEnviar.Precio)) * cantidad).ToString();
            ClaseParaEnviar.CantidadClases = "Cuota Curso";
            ClaseParaEnviar.cantidadElegidos = checkedListBox3.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            ClaseParaEnviar.Descripcion = "Curso de " + checkedListBox1.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            */
            Clase claseAux = new Clase();
            claseAux.Precio = checkedListBox2.SelectedItem.ToString();
            claseAux.ClasesTomar = checkedListBox1.SelectedItem.ToString();
            claseAux.cantidadElegidos = checkedListBox3.SelectedItem.ToString();
            claseAux.CantidadClases = "Curso";
            double total = Convert.ToInt32(claseAux.Precio) * Convert.ToInt32(claseAux.cantidadElegidos);
            if (checkBox1.Checked)
            {
                total = total * 0.5;
                claseAux.EsSenia = true;
            }
            claseAux.Total = total.ToString();
            claseAux.Descripcion = "Curso de: " + claseAux.ClasesTomar;


            Curso auxCurso = new Curso();
            auxCurso.Nombre = claseAux.ClasesTomar;
            auxCurso.getPrecio();
            auxCurso.getProfesor(); string aux = string.Empty;
            if (auxCurso.Profesor == "Aldo")
            {
                claseAux.Profesor = "Profesor Aldo";
            }
            else
            {
                claseAux.Profesor = auxCurso.Profesor;
            }

            if (auxCurso.Horarios.Any())
            {
                this.Hide();
                Horario_Curso_Select newCurso = new Horario_Curso_Select(auxCurso.Horarios);
                newCurso.ShowDialog();
                this.Show();
                claseAux.Horarios = newCurso.HorarioSelect;
            }
            else
            {
                List<string> horariosaux = new List<string>();
                horariosaux.Add(auxCurso.Horario);
                claseAux.Horarios = horariosaux;
            }

           

            ClasesList.Add(claseAux);
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        /*
private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
{
if (e.NewValue == CheckState.Checked)
for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
  if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);
}

private void checkedListBox2_ItemCheck_1(object sender, ItemCheckEventArgs e)
{
if (e.NewValue == CheckState.Checked)
for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
  if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
}

private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
{
if (e.NewValue == CheckState.Checked)
for (int ix = 0; ix < checkedListBox3.Items.Count; ++ix)
  if (e.Index != ix) checkedListBox3.SetItemChecked(ix, false);
}
*/
    }
}
