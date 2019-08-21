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
    public partial class Interfaz_Re_Impresion : Form
    {
       
        Global Global = new Global();
        List<MinComprobante> comprobantes = new List<MinComprobante>();

        public Interfaz_Re_Impresion()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void Interfaz_Re_Impresion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comprobantes.Clear();
            string dateSelected = monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy");
            var client = new MongoClient(Global.Path_DataBase); var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Fecha", dateSelected);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                MinComprobante auxComprobante = new MinComprobante();
                auxComprobante.Fecha = doc.GetValue("Fecha", "No posee").AsString;
                auxComprobante.Nombre = doc.GetValue("Nombre", "No posee").AsString;
                auxComprobante.NumeroComprobante = doc.GetValue("NumeroComprobante", "No posee").AsString;
                comprobantes.Add(auxComprobante);
            }
            InitializeListView();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(comprobantes);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void reimprimir_Click(object sender, EventArgs e)
        {

        }


        private void objectListView1_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
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
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
