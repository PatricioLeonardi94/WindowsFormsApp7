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
    public partial class AñadirPersonaBase : Form
    {
        public string NamePersona { get; set; }

        public AñadirPersonaBase(string name)
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            textBox1.Text = name;
        }

        public AñadirPersonaBase()
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        String nombre = string.Empty;
        String telefono = string.Empty;
        String mail = string.Empty;

        private void Form2_Load()
        {
           textBox1.Text = Form1.SetValueForName2;
        }
        
        //Aceptar, manda informacion a la base de datos y ademas vuelve al form 1
        private void button1_Click(object sender, EventArgs e)
        {
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var document = new BsonDocument
                {
                    { "Nombre", nombre },
                    { "Telefono", telefono },
                    { "Mail", mail }
                };
            collection.InsertOne(document);
            MessageBox.Show(nombre + " Agregado");
            this.NamePersona = nombre;
            this.DialogResult = DialogResult.OK;
        }

        //Nombre Persona
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nombre = textBox1.Text;
        }
        //Telefono
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            telefono = textBox2.Text;
        }
        //Mail
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            mail = textBox3.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Alumno aux = new Main_Alumno();
            aux.Show();
        }

        private void AñadirPersonaBase_Load(object sender, EventArgs e)
        {

        }
    }
}
