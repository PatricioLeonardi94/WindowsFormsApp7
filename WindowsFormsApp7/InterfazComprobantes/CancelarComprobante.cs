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
using System.IO;


namespace WindowsFormsApp7
{
    public partial class CancelarComprobante : Form
    {
        Global Global = new Global();
        

        public CancelarComprobante()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            try
            {

            MinComprobante auxComprobante = new MinComprobante();

            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("NumeroComprobante", textBox1.Text);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
                {
                    auxComprobante.Fecha = doc.GetValue("Fecha", "no posee").AsString;
                    auxComprobante.NumeroComprobante = doc.GetValue("NumeroComprobante", "no posee").AsString;
                    auxComprobante.Nombre = doc.GetValue("Nombre", "no posee").AsString;

                    var clase = doc.GetValue("Clases", "No posee").AsBsonArray;
                    foreach (var doc2 in clase)
                    {
                        var clase2 = doc2.AsBsonDocument;
                        Comprobantemin comprobanteaux = new Comprobantemin();
                        comprobanteaux.CantidadClases = clase2.GetValue("CantidadClases", "No Posee").AsString;
                        comprobanteaux.Profesor = clase2.GetValue("Profesor", "No Posee").AsString;
                        comprobanteaux.Precio = clase2.GetValue("Precio", "No Posee").AsString;
                        comprobanteaux.ClasesTomar = clase2.GetValue("ClasesTomar", "No Posee").AsString;
                        comprobanteaux.Descripcion = clase2.GetValue("Descripcion", "No Posee").AsString;
                        comprobanteaux.cantidadElegidos = clase2.GetValue("cantidadElegidos", "No Posee").AsString;
                        comprobanteaux.Total = clase2.GetValue("Total", "No Posee").AsString;
                        auxComprobante.comprobantes.Add(comprobanteaux);
                    }
                }           

            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Comprobante_Para_Reimpresion frm3 = new Comprobante_Para_Reimpresion(auxComprobante);
            frm3.ShowDialog();
            this.Show();

            }
            catch
            {
                MessageBox.Show("El Numero de recibo es incorrecto o el recibo no existe");
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
       
    }
}
