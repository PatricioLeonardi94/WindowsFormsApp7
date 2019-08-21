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
using System.IO;
using System.Drawing.Printing;
using Humanizer;




namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        bool NextMonthCheck = false;
        Global Global = new Global();
        Alumno alumno = new Alumno();
        Clase Clase = new Clase();
        List<Clase> ClasesList = new List<Clase>();


        public Form1()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Form1_Load();
            FormGrid();
            CargarDeposito(ClasesList);
        }

        public Form1(List<Clase> clases)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            ClasesList = clases;
            Form1_Load();
            FormGrid();
            CargarDeposito(ClasesList);
        }

        string namePersona = string.Empty;
        public static string SetValueForText1 = "";
        public static string SetValueForName2 = "";


        //Elegir Profesor
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clase.Profesor = checkedListBox1.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

     



        private void FillComprobantes(HashSet<string> aux)
        {
                foreach(var clase in aux)
            {
                checkedListBox3.Items.Add(clase);
            }
                      
        }

        //Elegir Clases por mes
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                Clase.CantidadClases = checkedListBox2.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());          
        }

        //Elegir Clases a Tomar
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {    
                Clase.ClasesTomar = checkedListBox3.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            Clase.Descripcion = "Clase de " + checkedListBox3.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clase.cantidadElegidos = checkedListBox4.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

        


        //Va a mandar a imprimir abriendo el form3 con los datos
        private void button2_Click(object sender, EventArgs e)
        {   
            if (checkBox2.Checked)
            {
                this.NextMonthCheck = true;
            }
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            ImprimirTicket frm3 = new ImprimirTicket(ClasesList, namePersona, NextMonthCheck);
            frm3.ShowDialog();
            this.Show();
            UncheckAll();
            textBox1.Clear();
            ClasesList.Clear();
            clearAll();
            this.NextMonthCheck = false;
            checkBox2.Checked = false;
            Form1_Load();
            InitializeListView();
        }

        private void clearAll()
        {
            textBox1.Clear();
            checkedListBox3.Items.Clear();
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
            numericUpDown1.Value = 0;
            listView1.Items.Clear();
            objectListView1.Objects = null;
            objectListView2.Objects = null;
        }


        // namePersona Almacena el valor escrito en el textBox (el nombre de la persona)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            namePersona = textBox1.Text;          
        }

        // Añadir a la Base de Datos
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            AñadirPersonaBase frm3 = new AñadirPersonaBase(namePersona);
            frm3.ShowDialog();
            this.Show();
            string aux = frm3.NamePersona;
            textBox1.Text = aux;
        }
        
        //Autocompleta la lista del textBox con los nombres
        private void Form1_Load() 
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            textBox1.AutoCompleteCustomSource = combData;

            completeProfesores();
        }

        public void completeProfesores()
        {
            checkedListBox1.Items.Clear();
            Clase hola = new Clase();
            foreach (var profesor in hola.getProfesoresTodos())
            {
                checkedListBox1.Items.Add(profesor);
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Main_Comprobantes frm4 = new Main_Comprobantes();
            frm4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //string name, string price, string teacher, string amount, string clasesTotal)

            Cursos frm4 = new Cursos(namePersona, ClasesList);
            frm4.Show();
            //string name, string price, string teacher, string amount, string clasesTotal)


        }

        public void FormGrid()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Profesor", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Cantidad por Mes", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Precio", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Cantidad", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Total", 75, HorizontalAlignment.Left);

        }

        private void CargarDeposito(List<Clase> Clases)
        {
            foreach (var doc in Clases)
            {
                listView1.Items.Add(new MyOwnListViewItem(doc));
            }
        }

        public class MyOwnListViewItem : ListViewItem
        {
            private Clase clase;

            public MyOwnListViewItem(Clase clase)
            {
                clase.getPrice();
                this.clase = clase;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = clase.Profesor; //for first detailed column

                this.SubItems.Add(new ListViewSubItem(this, clase.CantidadClases.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, clase.Precio.ToString()));//for second can be more
                this.SubItems.Add(new ListViewSubItem(this, clase.cantidadElegidos.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, clase.ClasesTomar.ToString()));
                clase.Total = ((Convert.ToInt32(clase.Precio)) * (Convert.ToInt32(clase.cantidadElegidos))).ToString();
                this.SubItems.Add(new ListViewSubItem(this, clase.Total.ToString()));
            }
            /*
             *  public string Nombre { get; set; }
            public int PrecioPeso { get; set; }
            public int PrecioDolar { get; set; }
            public int Cantidad { get; set; }
            */
        }

        private void UncheckAll()
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in checkedListBox2.CheckedIndices)
            {
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in checkedListBox4.CheckedIndices)
            {
                checkedListBox4.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in checkedListBox3.CheckedIndices)
            {
                checkedListBox3.SetItemCheckState(i, CheckState.Unchecked);
            }
            checkBox1.Checked = false;
            numericUpDown1.Value = 0;
        }

        private string getUniformesValue() {
            string aux = String.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("uniforme");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("nombreUniforme", "Uniforme");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                aux=  (doc.GetElement("precioUniforme").Value.AsString);
            }
            return aux;
        }

        private void AgregarComprobantes_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (checkBox1.Checked)
                    {
                        Clase auxClase = new Clase();
                        auxClase.Profesor = "Uniforme";
                        auxClase.Descripcion = "Uniforme";
                        auxClase.CantidadClases = "";
                        auxClase.ClasesTomar = "Uniforme";
                        auxClase.cantidadElegidos = (Convert.ToInt32(numericUpDown1.Value)).ToString();
                        auxClase.Precio = getUniformesValue();
                        ClasesList.Add(auxClase);
                        listView1.Clear();
                        FormGrid();
                        CargarDeposito(ClasesList);
                        UncheckAll();
                    }
                    else
                    {
                        Clase auxClase = new Clase();
                        if ((checkedListBox3.CheckedItems.Count == 0))
                        {
                        auxClase.ClasesTomar = "Generico";
                        auxClase.Descripcion = "Generico";
                         }
                        else
                        {
                        auxClase.ClasesTomar = Clase.ClasesTomar;
                        auxClase.Descripcion = Clase.Descripcion;
                        }   
                        
                        auxClase.Profesor = Clase.Profesor;
                        auxClase.CantidadClases = Clase.CantidadClases;
                        auxClase.cantidadElegidos = Clase.cantidadElegidos;
                        


                    /*this.Hide();
                    //string name, string price, string teacher, string amount, string clasesTotal)
                    Horarios frm3 = new Horarios(auxClase);
                    frm3.ShowDialog();
                    this.Show();*/


                    ClasesList.Add(auxClase);
                        listView1.Clear();
                        FormGrid();
                        CargarDeposito(ClasesList);
                        UncheckAll();
                    }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("No es correcto lo seleccionado");
                UncheckAll();
                Clase = new Clase();
            }
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DestinoComprobantes frmCarpeta = new DestinoComprobantes();
            frmCarpeta.ShowDialog();

        }



        private void buscar_Click(object sender, EventArgs e)
        {
            
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(alumno.ComprobantesCompletosAlumnos);
            objectListView1.Sort(NumeroComprobante, SortOrder.Descending);
        }

        /*private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {          
                    Clase.Profesor = checkedListBox1.SelectedItem.ToString();
                    MessageBox.Show(Clase.Profesor);
                    Stack<string> resp = Clase.CargarClases();
                    FillComprobantes(resp);
       
        }*/


        private void checkedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event");
        }

        

        private void checkedListBox1_SizeChanged(object sender, EventArgs e)
        {

        }


        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            Clase.Profesor = checkedListBox1.SelectedItem.ToString();
            HashSet<string> resp = Clase.getKeys();
            checkedListBox3.Items.Clear();
            FillComprobantes(resp);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            string aux = string.Empty;
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    alumno.ComprobantesCompletosAlumnos.Clear();
                    alumno.Name = textBox1.Text;
                    alumno.CargarComprobantes();
                    InitializeListView();
                    InitializeListView2(alumno);
                }
                catch
                {
                    
                }
                

            }
        }

        private void objectListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView2(Alumno aux)
        {
            aux.CargarDatos();
            this.objectListView2.SetObjects(aux.datosAlum);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void objectListView2_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            alumno.UpdateAlumno(textBox1.Text, e.Column.Text.ToString(), e.NewValue.ToString());
        }

        private void objectListView2_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {

        }

        private void objectListView2_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void objectListView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void eliminaultimo_Click(object sender, EventArgs e)
        {
            try
            {
                ClasesList.RemoveAt(ClasesList.Count - 1);
                listView1.Clear();
                FormGrid();
                CargarDeposito(ClasesList);
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clase newclase = new Clase();
            HashSet<string> keys = newclase.getKeys();
            foreach(var stringkey in keys)
            {
                MessageBox.Show(stringkey);
            }
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);

        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
        }

        private void checkedListBox4_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox4.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox4.SetItemChecked(ix, false);
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox3.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox3.SetItemChecked(ix, false);          
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Interfaz_Re_Impresion frm3 = new Interfaz_Re_Impresion();
            frm3.ShowDialog();
            this.Show();           
        }

        private void objectListView1_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Editar_Nombre frm3 = new Editar_Nombre(textBox1.Text);
            frm3.ShowDialog();
            this.Show();
            string aux = frm3.ReturnValue1;
            textBox1.Text = aux; 
            Form1_Load();
            alumno.ComprobantesCompletosAlumnos.Clear();
            alumno.Name = aux;
            alumno.CargarComprobantes();
            InitializeListView();
            InitializeListView2(alumno);
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

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Comprobante_Particular aux = new Comprobante_Particular();
            aux.ShowDialog();
            this.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

    }
}


