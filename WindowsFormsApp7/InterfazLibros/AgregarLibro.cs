using System;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;



namespace WindowsFormsApp7
{
    public partial class AgregarLibro : Form
    {
        public AgregarLibro()
        {
            this.BackgroundImage = Properties.Resources.Libros;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Form1_Load();
        }

        private void AgregarLibro_Load(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Libro aux = new Main_Libro();
            aux.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                UserData aux = new UserData
                {
                    Nombre = textBox1.Text,
                    Autor = textBox2.Text,
                    ISBN = textBox6.Text,
                    Edicion = textBox7.Text,
                    AñoImpresion = textBox8.Text,
                    Idioma = textBox10.Text,
                    Ubicacion = textBox9.Text,
                };

                if (!(comboBox1.SelectedItem == null))
                {
                    aux.Modelo = comboBox1.SelectedItem.ToString();
                }
                else
                {
                    aux.Modelo = "";
                }

                if (String.IsNullOrEmpty(textBox3.Text))
                {
                    textBox3.Text = "0";
                }
                aux.Cantidad = Convert.ToInt32(textBox3.Text);
                if (String.IsNullOrEmpty(textBox4.Text))
                {
                    textBox4.Text = "0";
                }
                aux.PrecioPeso = Convert.ToInt32(textBox4.Text);
                if (String.IsNullOrEmpty(textBox5.Text))
                {
                    textBox5.Text = "0";
                }
                aux.PrecioDolar = Convert.ToInt32(textBox5.Text);



                Global Global = new Global();
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_libro");
                var collection = database.GetCollection<UserData>("Stock");
                /*var document = new BsonDocument
                {
                {   "Nombre", aux.Nombre },
                {   "Autor" , aux.Autor},
                {   "Cantidad" , aux.Cantidad},
                {   "PrecioPeso" , aux.PrecioPeso},
                {   "PrecioDolar" , aux.PrecioDolar},
                {   "ISBN" , aux.ISBN},
                {   "Edicion" , aux.Edicion},
                {   "AñoImpresion" , aux.AñoImpresion},
                {   "Modelo" , aux.Modelo},
                {   "Idioma" , aux.Idioma}
                };
                */
                collection.InsertOne(aux);
                MessageBox.Show("Su libro ha sido agregado");
            }
            else
            {
                Global Global = new Global();
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_libro");
                var collection = database.GetCollection<BsonDocument>("Stock");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Nombre", textBox1.Text) & builder.Eq("ISBN", textBox6.Text) & builder.Eq("Ubicacion", textBox9.Text);
                var update = Builders<BsonDocument>.Update.Inc("Cantidad", Convert.ToInt32(textBox3.Text));
                var result = collection.UpdateOne(filter, update);
                MessageBox.Show("Se ha agregado la cantidad");

            }



        }

        private void label8_Click(object sender, EventArgs e)
        {

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (checkBox1.CheckState)
            {
                case CheckState.Checked:
                    textBox2.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    comboBox1.Enabled = false;
                    break;
                case CheckState.Unchecked:
                    // Code for unchecked state.
                    textBox2.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox7.Enabled = true;
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    comboBox1.Enabled = true;
                    break;
            }
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
            var database = client.GetDatabase("app_libro");
             var collection = database.GetCollection<BsonDocument>("Stock");
             var filter = Builders<BsonDocument>.Filter.Empty;
             var result = collection.Find(filter).ToList();
             foreach (var doc in result)
             {
                 dataCollection.Add(doc.GetElement("Nombre").Value.AsString);
             }
         }



        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string aux = string.Empty;
            if (e.KeyData == Keys.Enter)
            {
                Global Global = new Global();
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_libro");
                var collection = database.GetCollection<BsonDocument>("Stock");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Nombre", textBox1.Text);
                var result = collection.Find(filter).ToList();
                foreach(var doc in result)
                {
                    textBox6.Text = doc.GetValue("ISBN").AsString;
                    textBox9.Text = doc.GetValue("Ubicacion", new BsonString("N/A")).AsString;
                }

            }
        }
    }
}
