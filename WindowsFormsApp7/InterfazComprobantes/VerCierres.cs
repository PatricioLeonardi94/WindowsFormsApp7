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

namespace WindowsFormsApp7
{
    public partial class VerCierres : Form
    {
        DateTime desde, hasta;

        public VerCierres()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
           // FormGrid();
        }

        private void VerCierres_Load(object sender, EventArgs e)
        {

        }


        //Para ver los eventhandlers

        /*private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.MouseDoubleClick += new MouseEventHandler(listBox1_DoubleClick);
        }

        public void listBox1_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(listBox1.SelectedItem.ToString());
                if (textBox1.Text == Connect())
                {
                    
                }
                else
                {
                    MessageBox.Show("La contraseña es incorrecta");
                }
                
            }
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            desde = dateTimePicker1.Value.Date;
            hasta = dateTimePicker2.Value.Date;
            listView1.Clear();
            FormGrid();

            for (DateTime date = desde; date <= hasta; date = date.AddDays(1))
            {
                
                listView1.Items.Add(new MyOwnListViewItem(new DiaMonto() { Dia = date.ToString("dd/MM/yyyy"), Monto = getMonto(date.ToString("yyyy/MM/dd")) }));


            }
            
        }

        public class MyOwnListViewItem : ListViewItem
        {
            private DiaMonto userData;

            public MyOwnListViewItem(DiaMonto userData)
            {
                this.userData = userData;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = userData.Dia; //for first detailed column

                this.SubItems.Add(new ListViewSubItem(this, userData.Monto)); //for second can be more
            }
        }

        public class DiaMonto
        {
            public string Dia;
            public string Monto;
        }

        private string getMonto(string date)
        {
            string resp = string.Empty;
            Global Global = new Global();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cierresdiarios");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Fecha", date);
            //filter = filter & Builders<BsonDocument>.Filter.Eq("NumeroComprobante", numero);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = "$" + (doc.GetValue("MontoTotal", new BsonString(string.Empty)).AsString);
            }
            return resp;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Cierres volver = new Cierres();
            volver.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        public void FormGrid()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Dia", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Monto Total", 150, HorizontalAlignment.Left);
        }


        private static string Connect()
        {
            Global Global = new Global();
            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("contraseñas");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = (doc.GetValue("app_pago", new BsonString(string.Empty)).AsString);
            }
            return resp;
        }
    }
}
