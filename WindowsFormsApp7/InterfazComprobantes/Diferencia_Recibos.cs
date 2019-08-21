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
using System.IO;

namespace WindowsFormsApp7
{
    public partial class Diferencia_Recibos : Form
    {
        Global Global = new Global();
        MinComprobante Comprobante = new MinComprobante();
        string cantidadNew, nombre = string.Empty;
        List<Clase> ListClase = new List<Clase>();


        public Diferencia_Recibos(MinComprobante comprobante, string namePersona)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Comprobante = comprobante;
            nombre = namePersona;
            label7.Text = comprobante.Nombre;
            label6.Text = comprobante.NumeroComprobante;
        }     

        private void Diferencia_Recibos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var aux = Comprobante.comprobantes.ToList().First();
                //A VER CON PAU QUE PONER
                string descrp = "Diferencia Recibo " + Comprobante.NumeroComprobante + " por el complemento de la reserva del curso";
                Clase respClase = new Clase();
                respClase.Precio = aux.Total;
                respClase.Total = aux.Total;
                respClase.Profesor = aux.Profesor;
                respClase.CantidadClases = "Diferencia de reserva";
                respClase.cantidadElegidos = aux.cantidadElegidos;
                respClase.Descripcion = descrp;
                respClase.ClasesTomar = descrp;
                respClase.Diferencia_Comprobante_Numero = Comprobante.Diferencia_Comprobante_Numero;
                respClase.EsDiferencia = true;
                ListClase.Add(respClase);
            }
            else
            {
                var aux = Comprobante.comprobantes.ToList().First();

                Clase respClase = new Clase();
                string descrp = "Diferencia Recibo " + Comprobante.NumeroComprobante + " por " + cantidadNew;
                var precio = MakeDiference(aux, cantidadNew);
                respClase.Precio = precio;
                respClase.Total = precio;
                respClase.Profesor = aux.Profesor;
                respClase.CantidadClases = "Diferencia a " + cantidadNew;
                respClase.cantidadElegidos = aux.cantidadElegidos;
                respClase.Descripcion = descrp;
                respClase.ClasesTomar = descrp;
                respClase.Diferencia_Comprobante_Numero = Comprobante.Diferencia_Comprobante_Numero;
                respClase.EsDiferencia = true;
                ListClase.Add(respClase);
            }
            
            

            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            ImprimirTicket frm3 = new ImprimirTicket(ListClase, nombre, false);
            frm3.ShowDialog();
            
        }

        public string MakeDiference(Comprobantemin previo, string posterior)
        {
            DateTime lastDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 10);
            DateTime today = DateTime.Today;
            var valor = DateTime.Compare(today, lastDay);

            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", previo.Profesor);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                var aux2 = doc.GetValue(posterior, "no posee").AsString;
                var auxnumber = 0;
                if (valor > 0)
                {
                    auxnumber = (numberRound(Convert.ToInt32(Convert.ToDouble(aux2) * 1.1)));
                }
                else
                {
                    auxnumber = (Convert.ToInt32(aux2));
                }
                resp = (auxnumber - ((Convert.ToInt32(previo.Precio))*(Convert.ToInt32(previo.cantidadElegidos)))).ToString();
            }

            return resp;
        }

        int numberRound(int value)
        {
            int resp = 0;
            for (var i = value; i >= 10; i = i - 10)
            {
                resp = resp + 10;
            }
            return resp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        //Nombre
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Numero de Recibo
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
     

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var aux = Comprobante.comprobantes.ToList().First();
            MessageBox.Show(aux.Profesor);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cantidadNew = checkedListBox2.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
