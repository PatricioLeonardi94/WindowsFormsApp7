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
    public partial class NewUser : Form
    {
        Global Global = new Global();

        public NewUser()
        {
            this.BackgroundImage = Properties.Resources.Salon_de_Té_FoGuangShanArgentina;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void NewUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewUserPas_TextChanged(object sender, EventArgs e)
        {

        }

        private void Crear_Click(object sender, EventArgs e)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            var document = new BsonDocument
                {
                    { "Nombre", NewUserName.Text.ToUpper()},
                    { "Contraseña",  NewUserPas.Text },
                };
            collection.InsertOne(document);
                this.Close();
            Main_Usuarios aux = new Main_Usuarios();
                aux.Show();
            }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Usuarios aux = new Main_Usuarios();
            aux.Show();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
