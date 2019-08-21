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
    public partial class Comprobante_Particular : Form
    {
        Comprobante_Especial auxComprobanteEspecial = new Comprobante_Especial();
        Global Global = new Global();

        public Comprobante_Particular()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            getUsuariosCursosClases();
            CompletarNames();
        }

        private void CompletarNames()
        {
            Nombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            Nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            Nombre.AutoCompleteCustomSource = combData;
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

        private void Confirmar_Click(object sender, EventArgs e)
        {
            auxComprobanteEspecial.Fecha = dateTimePicker1.Value.ToString("yyyyMMdd");
            auxComprobanteEspecial.Nombre = Nombre.Text;
            auxComprobanteEspecial.Monto = Monto.Text;
            auxComprobanteEspecial.Motivo = Motivo.Text;
            auxComprobanteEspecial.Clase_Curso = comboBox2.Text;
            auxComprobanteEspecial.ComprobanteTalonario = textBox1.Text;
            try
            {
                auxComprobanteEspecial.Usuario = comboBox1.SelectedItem.ToString();
            }
            catch { }
            auxComprobanteEspecial.NameFile = dateTimePicker1.Value.ToString("yyyyMMMM") + "Casos Especiales";

        
                
            auxComprobanteEspecial.Cargar_Recibo_Especial();
            MessageBox.Show("Comprobante Agregado");
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Monto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Motivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clase_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void getUsuariosCursosClases()
        {
            Comprobante_Especial aux = new Comprobante_Especial();
            aux.getUsuarios().ForEach(name => comboBox1.Items.Add(name));
            Clase clase = new Clase();
            clase.getProfesoresTodos().ForEach(x => comboBox2.Items.Add(x));
            clase.getCursos().ForEach(x => comboBox2.Items.Add(x));
        }

        private void Comprobante_Particular_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
