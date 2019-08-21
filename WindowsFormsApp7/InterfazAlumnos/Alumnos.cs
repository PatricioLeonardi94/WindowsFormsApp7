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
    public partial class Alumnos : Form
    {
        Global Global = new Global();

        public Alumnos()
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Form1_Load();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Alumno frm4 = new Main_Alumno();
            frm4.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        //Busca datos en la base de datos
        private void button1_Click(object sender, EventArgs e)
        {
           
            
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
        

        private void Mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clase_TextChanged(object sender, EventArgs e)
        {

        }

        private void Profesor_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            AñadirPersonaBase frm = new AñadirPersonaBase(textBox1.Text);
            frm.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarDatos_Click(object sender, EventArgs e)
        {
            addClase(textBox1.Text, Telefono.Text, Mail.Text);
        }

        //Agrega los Datos de la Persona a la base de datos
        private void addClase(string nombre, string telefono, string mail)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", nombre);
            var update = Builders<BsonDocument>.Update.Set("Telefono", telefono).Set("Mail", mail);
            var result = collection.UpdateOne(filter, update);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                var alumno = textBox1.Text;             
                string aux = string.Empty;
                this.Hide();
                //string name, string price, string teacher, string amount, string clasesTotal)
                ComprobantesAlumnos frm3 = new ComprobantesAlumnos(alumno);
                frm3.ShowDialog();
                this.Show();
                
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar a " + textBox1.Text + " de la Base De Datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("Personas");
                var collection = database.GetCollection<BsonDocument>("Alumnos");
                var filter = Builders<BsonDocument>.Filter.Eq("Nombre", textBox1.Text);
                var result = collection.DeleteOne(filter);
            }

        }

        private void Alumnos_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
                string aux = string.Empty;
                if (e.KeyData == Keys.Enter)
                {
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("Personas");
                var collection = database.GetCollection<BsonDocument>("Alumnos");
                //var filter = Builders<BsonDocument>.Filter.Empty;
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Nombre", textBox1.Text);
                var result = collection.Find(filter).ToList();
                foreach (var doc in result)
                {
                    Telefono.Text = (doc.GetElement("Telefono").Value.AsString);
                    Mail.Text = (doc.GetElement("Mail").Value.AsString);
                }

            }
            }      
    }
}
