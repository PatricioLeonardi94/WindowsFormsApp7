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
    public partial class Confirmar_Cancelar_Comprobante : Form
    {

        MinComprobante comprobante = new MinComprobante();
        private string Contraseña;
        Global Global = new Global();

        public Confirmar_Cancelar_Comprobante(MinComprobante comprobanteRecibe)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            this.comprobante = comprobanteRecibe;
            firstInitialize();
        }

        private void firstInitialize()
        {
            getContraseña();
            getSupervisors();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.comprobante.Motivo = textBox2.Text;
            try
            {
                if(this.Contraseña == textBox1.Text)
                {
                    this.comprobante.CancelarMinComprobante(textBox2.Text, comboBox1.Text);
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta");
                }
            }
            catch { }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void getContraseña()
        {
            this.Contraseña = Global.Connect();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Confirmar_Cancelar_Comprobante_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getSupervisors()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("responsables");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", "supervisores");
            var result = collection.Find(filter).First();
            var supervisores = result.GetValue("supervisores").AsBsonArray;
            foreach(var supervisor in supervisores)
            {
                comboBox1.Items.Add(supervisor.ToString());
            }
        }
    }
}
