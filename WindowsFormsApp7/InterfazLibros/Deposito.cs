using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.VisualBasic;
using System;
using System.Reflection;


namespace WindowsFormsApp7
{
    public partial class Deposito : Form
    {
        UserData aux;
        List<UserData> libros;
        List<UserData> CollectionTotal;
        ProductSearchModel auxSearcher;
        ProductLibroLogic auxColeccion;
        UserData auxEdit = new UserData();

        public Deposito()
        {
            this.BackgroundImage = Properties.Resources.Libros;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            //FormGrid();
            Form1_Load();
            Form2_Load();
            Form3_Load();
            aux = new UserData
            {
                Nombre = "",
                Autor = "",
                ISBN = "",
                Edicion = "",
                AñoImpresion = "",
                Modelo = "",
                Idioma = ""
            };
            auxSearcher = new ProductSearchModel
            {
            };
            auxColeccion = new ProductLibroLogic();
            libros = auxColeccion.GetLibros(auxSearcher);
            CollectionTotal = libros;
            InitializeListView();
        }

        private void Deposito_Load(object sender, EventArgs e)
        {

        }

        //Clases para introducir la informacion de manera prolija en un ListViewItem

        public class MyOwnListViewItem : ListViewItem
        {
            private UserData userData;

            public MyOwnListViewItem(UserData userData)
            {
                this.userData = userData;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = userData.Nombre; //for first detailed column

                this.SubItems.Add(new ListViewSubItem(this, userData.Autor)); //for second can be more
                this.SubItems.Add(new ListViewSubItem(this, userData.Cantidad.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, userData.PrecioPeso.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, userData.PrecioDolar.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, userData.ISBN));
                this.SubItems.Add(new ListViewSubItem(this, userData.Edicion));
                this.SubItems.Add(new ListViewSubItem(this, userData.AñoImpresion));
                this.SubItems.Add(new ListViewSubItem(this, userData.Modelo));
                this.SubItems.Add(new ListViewSubItem(this, userData.Idioma));

            }

        }









        //Funciones      

        //Modela Los titulos de los ListView
        /* public void FormGrid()
         {
             listView1.View = View.Details;
             listView1.Columns.Add("Libro", 150, HorizontalAlignment.Left);
             listView1.Columns.Add("Autor", 125, HorizontalAlignment.Left);
             listView1.Columns.Add("Cantidad", 60, HorizontalAlignment.Left);
             listView1.Columns.Add("Precio Pesos", 75, HorizontalAlignment.Left);
             listView1.Columns.Add("Precio Dolar", 75, HorizontalAlignment.Left);
             listView1.Columns.Add("ISBN", 75, HorizontalAlignment.Left);
             listView1.Columns.Add("Edicion", 100, HorizontalAlignment.Left);
             listView1.Columns.Add("AñoImpresion", 50, HorizontalAlignment.Left);
             listView1.Columns.Add("Modelo", 75, HorizontalAlignment.Left);
             listView1.Columns.Add("Idioma", 50, HorizontalAlignment.Left);
         }



         //Introduce los libros que estan dentro de la lista
         private void CargarDeposito(List<UserData> libros)
         {
             foreach (var doc in libros)
             {
                 listView1.Items.Add(new MyOwnListViewItem(doc));
             }

         }

 */


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Libro aux = new Main_Libro();
            aux.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }








        /* private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

             if (comboBox1.SelectedIndex > -1)
             {
                 listView1.Clear();
                 FormGrid();
                 CargarDeposito(selected);

             }
         }

              public string Nombre { get; set; }
             public string Autor { get; set; }
             public int? PriceFrom { get; set; }
             public int? PriceTo { get; set; }
             public int? Cantidad { get; set; }
             public int? CantidadFrom { get; set; }
             public int? PrecioPeso { get; set; }
             public int? PrecioDolar { get; set; }
             public string ISBN { get; set; }
             public string Edicion { get; set; }
             public string AñoImpresion { get; set; }
             public string Modelo { get; set; }
             public string Idioma { get; set; }
         */

        private void button2_Click(object sender, EventArgs e)
        {
            auxSearcher = new ProductSearchModel
            {
                Nombre = textBox8.Text,
                Autor = textBox9.Text,
                ISBN = textBox10.Text,
                Edicion = textBox11.Text,
                AñoImpresion = textBox7.Text,
                Idioma = textBox12.Text,
            };

            if (numericUpDown3.Value > 0)
            {
                auxSearcher.CantidadFrom = Convert.ToInt32(numericUpDown3.Value);

            }
            if (comboBox6.SelectedItem != null)
            {
                auxSearcher.Modelo = comboBox6.SelectedItem.ToString();
            }
            if (!String.IsNullOrEmpty(textBox14.Text))
            {
                auxSearcher.PriceFrom = Convert.ToInt32(textBox14.Text);
            }
            if (!String.IsNullOrEmpty(textBox13.Text))
            {
                auxSearcher.PriceTo = Convert.ToInt32(textBox13.Text);
            }


            /*listView1.Clear();
            FormGrid();*/
            auxColeccion = new ProductLibroLogic();
            libros = auxColeccion.GetLibros(auxSearcher);
            InitializeListView();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox6.SelectedItem = null;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox7.Text = "";
            textBox12.Text = "";
            textBox13.Text = String.Empty;
            textBox14.Text = String.Empty;
            numericUpDown3.Value = 0;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Main_Libro aux = new Main_Libro();
            aux.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }



        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        //Funciones para el autocompletado de datos
        private void Form1_Load()
        {
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            textBox8.AutoCompleteCustomSource = combData;
        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                dataCollection.Add(doc.GetElement("Nombre").Value.AsString);
            }
        }

        private void getData2(AutoCompleteStringCollection dataCollection)
        {
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase); var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                dataCollection.Add(doc.GetElement("Autor").Value.AsString);
            }
        }

        private void Form2_Load()
        {
            textBox9.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData2(combData);
            textBox9.AutoCompleteCustomSource = combData;
        }

        private void getData3(AutoCompleteStringCollection dataCollection)
        {
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase); var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                dataCollection.Add(doc.GetElement("Idioma").Value.AsString);
            }
        }

        private void Form3_Load()
        {
            textBox12.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox12.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData2(combData);
            textBox12.AutoCompleteCustomSource = combData;
        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(libros);
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void objectListView1_CellClick_1(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            UserData LibroNow = new UserData();
            try
            {
                // statements causing exception
                LibroNow.Nombre = objectListView1.SelectedItem.Text;
                LibroNow.getUbicacion();
                richTextBox1.Text = LibroNow.Ubicacion;
                auxEdit.Nombre = LibroNow.Nombre;
                LibroNow.Modelo = objectListView1.SelectedItem.SubItems[9].Text;
                auxEdit.Ubicacion = LibroNow.Ubicacion;
                auxEdit.Modelo = LibroNow.Modelo;
            }
            catch (System.NullReferenceException)
            {
                // error handling code
                //MessageBox.Show("Seleccione el usuario debajo del titulo");
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {

        }

        private void objectListView1_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
           /* MessageBox.Show(e.NewValue.ToString());
            MessageBox.Show(e.Column.Text.ToString());
            MessageBox.Show(e.ListViewItem.SubItems[9].Text.ToString());*/
            aux.UpdateUserData(e.ListViewItem.Text.ToString(), e.Column.Text.ToString(), e.NewValue.ToString(), e.ListViewItem.SubItems[9].Text.ToString());

        }

        private void objectListView1_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Modificar la nota del libro " + auxEdit.Nombre + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                auxEdit.ChangeUbicacion(richTextBox1.Text);
            }
        }

        private void objectListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                UserData libroDel = new UserData();
                libroDel.Nombre = objectListView1.SelectedItem.Text.ToString();
                libroDel.Cantidad = Convert.ToInt32(objectListView1.SelectedItem.SubItems[2].Text);
                libroDel.Autor = objectListView1.SelectedItem.SubItems[1].Text;
                if (MessageBox.Show("Desea Eliminar " + libroDel.Nombre + " en la base de datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    libroDel.DeleteUserData();
                    InitializeListView();
                }

            }
        }

        //Crea un Archivo con el Stock
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Imprimir Stock?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserData aux = new UserData();
                aux.ImprimirStockLibros(CollectionTotal);
            }          
        }
    }
}
