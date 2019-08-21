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
    public partial class RetiroDeLibro : Form
    {
        Global Global = new Global();
        UserDataMin aux;
        UserDataMin aux2;
        List<UserDataMin> coleccion;
        List<UserData> libros;
        ProductSearchModel auxSearcher;
        ProductLibroLogic auxColeccion;

        public RetiroDeLibro()
        {
            this.BackgroundImage = Properties.Resources.Libros;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            Form2_Load();
            Form1_Load();
            FormGrid();
            auxSearcher = new ProductSearchModel
            {
            };
            aux = new UserDataMin
            {
                Nombre = "",
                PrecioPeso = 0,
                PrecioDolar = 0,
                Cantidad = 0,
            };
            aux2 = new UserDataMin
            {
                Nombre = "",
                PrecioPeso = 0,
                PrecioDolar = 0,
                Cantidad = 0,
            };
            coleccion = new List<UserDataMin>();
        }

        //clases

        public class MyOwnListViewItem : ListViewItem
        {
            private UserDataMin userData;

            public MyOwnListViewItem(UserDataMin userData)
            {
                this.userData = userData;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = userData.Nombre; //for first detailed column
 
                this.SubItems.Add(new ListViewSubItem(this, userData.Cantidad.ToString()));//for second can be more
                this.SubItems.Add(new ListViewSubItem(this, userData.PrecioPeso.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, userData.PrecioDolar.ToString()));
            }
            /*
             *  public string Nombre { get; set; }
            public int PrecioPeso { get; set; }
            public int PrecioDolar { get; set; }
            public int Cantidad { get; set; }
            */
        }

        //funciones

        public void FormGrid()
        {
            listView2.View = View.Details;
            listView2.Columns.Add("Libro", 260, HorizontalAlignment.Left);
            listView2.Columns.Add("Cantidad", 75, HorizontalAlignment.Left);
            listView2.Columns.Add("Precio Pesos", 75, HorizontalAlignment.Left);
            listView2.Columns.Add("Precio Dolar", 75, HorizontalAlignment.Left);
        }




        private void CargarDeposito(List<UserDataMin> libros)
        {
            foreach (var doc in libros)
            {
                listView2.Items.Add(new MyOwnListViewItem(doc));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MakeRecipe(coleccion);
        }

        private string getDire()
        {
            string aux = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("destinos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", "Excels");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                aux = (doc.GetValue("Carpeta", new BsonString(string.Empty)).AsString);
            }
            return aux;
        }



        public void MakeRecipe(List<UserDataMin> list)
        {
            int j = 0;
            int precioTotalP = 0, precioTotalD =0;
                string carpeta = getDire();
                string numeroTicket = (nroTicket());
                string nombreticket = @carpeta + "\\LiquidacionesLibros\\" + numeroTicket;
                int i = 4;
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook;
                Excel._Worksheet xlWorksheet;

            if (!System.IO.File.Exists(numeroTicket + ".xlsx"))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;


                xlRange.Cells[1, "E"] = "Comprobante: " + numeroTicket;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "F"]].Merge();
                var auxstring = "Destinatario: " + textBox5.Text + "                Fecha: " + DateTime.Today.ToString("d");
                xlRange.Cells[2, "A"] = auxstring;
                xlRange.Cells[3, "A"] = "U.";
                xlRange.Cells[3, "B"] = "Detalle";
                xlRange.Cells[3, "C"] = "Precio uni.";
                xlRange.Cells[3, "D"] = "$ Total";
                xlRange.Cells[3, "E"] = "U$D uni.";
                xlRange.Cells[3, "F"] = "U$D Total";
                foreach (var doc in list)
                {
                    xlRange.Cells[i, "A"] = doc.Cantidad;
                    xlRange.Cells[i, "B"] = doc.Nombre;
                    xlRange.Cells[i, "C"] = doc.PrecioPeso;
                    xlRange.Cells[i, "D"] = doc.PrecioPeso * doc.Cantidad;
                    xlRange.Cells[i, "E"] = doc.PrecioDolar;
                    xlRange.Cells[i, "F"] = doc.PrecioDolar * doc.Cantidad;
                    precioTotalP += doc.PrecioPeso * doc.Cantidad;
                    precioTotalD += doc.PrecioDolar * doc.Cantidad;
                    i++;
                    descuentaLibro(doc);
                }
                j = i;
                int precioTotalPaux = 0, precioTotalDaux = 0;
                xlWorksheet.Range[xlWorksheet.Cells[i, "A"], xlWorksheet.Cells[i, "B"]].Merge();
                xlRange.Cells[i, "A"] = "Subtotal";
                xlRange.Cells[i, "D"] = precioTotalP;
                xlRange.Cells[i++, "F"] = precioTotalD;
                xlWorksheet.Range[xlWorksheet.Cells[i, "A"], xlWorksheet.Cells[i, "B"]].Merge();
                xlRange.Cells[i, "A"] = "Descuento " + numericUpDown2.Value.ToString()+ "%";
                if (numericUpDown2.Value != 0)
                {
                    MessageBox.Show(precioTotalP.ToString());
                    precioTotalPaux = ((precioTotalP)*Convert.ToInt32(numericUpDown2.Value))/100;
                    precioTotalDaux = ((precioTotalD) * Convert.ToInt32(numericUpDown2.Value)) / 100;
                    MessageBox.Show(precioTotalPaux.ToString());
                    MessageBox.Show(precioTotalDaux.ToString());

                }
                xlRange.Cells[i, "D"] = precioTotalPaux;
                xlRange.Cells[i++, "F"] = precioTotalDaux;
                xlWorksheet.Range[xlWorksheet.Cells[i, "A"], xlWorksheet.Cells[i, "B"]].Merge();
                xlRange.Cells[i, "A"] = "TOTAL";
                xlRange.Cells[i, "D"] = "$" + (precioTotalP - precioTotalPaux).ToString();
                xlRange.Cells[i, "F"] = "$" + (precioTotalD - precioTotalDaux).ToString();
                xlWorksheet.Range[xlWorksheet.Cells[i, "D"], xlWorksheet.Cells[i, "F"]].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                xlWorksheet.Range[xlWorksheet.Cells[i, "D"], xlWorksheet.Cells[i, "F"]].NumberFormat = "#,###.00 $";
                xlWorksheet.Range[xlWorksheet.Cells[++i, "B"], xlWorksheet.Cells[i, "F"]].Merge();
                xlRange.Cells[i, "A"] = "Observaciones";
                xlRange.Cells[i, "B"] = richTextBox1.Text;
               
                //styling

                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "F"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "F"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "F"]].Font.Bold = true;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[i, "F"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[i, "F"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                xlWorksheet.Columns[2].ColumnWidth = 30;
                xlWorksheet.Columns[1].ColumnWidth = 12;
                xlWorksheet.Range[xlWorksheet.Cells[4, "B"], xlWorksheet.Cells[j, "B"]].WrapText = true;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "A"]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                xlWorkbook.Password = Connect();
                xlWorkbook.SaveAs(nombreticket);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.LiquidacionesLibros + numeroTicket + ".xlsx", Global.LiquidacionesLibrosServer + numeroTicket + ".xlsx", true);
             
            } 
            }
        
        private void descuentaLibro(UserDataMin aux)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", textBox3.Text) & builder.Eq("ISBN", textBox6.Text);
            var update = Builders<BsonDocument>.Update.Inc("Cantidad", (-aux.Cantidad));
            var result = collection.UpdateOne(filter, update);
        }


        private string nroTicket()
        {
            string resp = string.Empty;
            string auxletra1, auxletra2, auxnumero;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("NumeroTicket");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = (doc.GetElement("UltimoTicketLetra1").Value.AsString);
                resp += (doc.GetElement("UltimoTicketLetra2").Value.AsString);
                resp += (doc.GetElement("UltimoTicketNumero").Value.AsString);
                if ((doc.GetElement("UltimoTicketNumero").Value.AsString) == "9999")
                {
                    if((doc.GetElement("UltimoTicketLetra2").Value.AsString) == "Z")
                    {
                        var f1 = (doc.GetElement("UltimoTicketLetra1").Value.AsString);
                        char letter = f1[0];
                        f1 = (Convert.ToInt16(letter) + 1).ToString();
                        auxletra1 = f1;
                        auxletra2 = "A";
                        var aux = Convert.ToInt32(doc.GetElement("UltimoTicketNumero").Value.AsString) + 1;
                        auxnumero = aux.ToString();
                    }
                    else
                    {
                        auxletra1= (doc.GetElement("UltimoTicketLetra1").Value.AsString);
                        var f2 = (doc.GetElement("UltimoTicketLetra2").Value.AsString);
                        char letter = f2[0];
                        f2 = (Convert.ToInt16(letter) + 1).ToString();
                        auxletra2 = f2;
                        var aux = Convert.ToInt32(doc.GetElement("UltimoTicketNumero").Value.AsString) + 1;
                        auxnumero = aux.ToString();
                    }                                    
                }
                else
                {
                    auxletra1 = (doc.GetElement("UltimoTicketLetra1").Value.AsString);
                    auxletra2 = (doc.GetElement("UltimoTicketLetra1").Value.AsString);
                    var aux = Convert.ToInt32(doc.GetElement("UltimoTicketNumero").Value.AsString) + 1;
                    auxnumero = aux.ToString();
                }
                var update = Builders<BsonDocument>.Update.Set("UltimoTicketLetra1", auxletra1).Set("UltimoTicketLetra2", auxletra2).Set("UltimoTicketNumero", auxnumero);
                var result2 = collection.UpdateOne(filter, update);
            }
            

            return resp;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Libro aux = new Main_Libro();
            aux.Show();
        }

        private void Form1_Load()
        {
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData(combData);
            textBox5.AutoCompleteCustomSource = combData;
        }

        private void getData(AutoCompleteStringCollection dataCollection)
        {
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

        private void Form2_Load()
        {
            textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getData2(combData);
            textBox3.AutoCompleteCustomSource = combData;
        }

        private void getData2(AutoCompleteStringCollection dataCollection)
        {
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserDataMin aux2 = new UserDataMin();
            if (checkBox3.Checked)
            {
                aux2.Nombre = aux.Nombre;
                aux2.PrecioPeso = aux.PrecioPeso;
                aux2.PrecioDolar = 0;
                aux2.Cantidad = Convert.ToInt32(numericUpDown3.Value);
            }
            else
            {
                aux2.Nombre = aux.Nombre;
                aux2.PrecioPeso = 0;
                aux2.PrecioDolar = aux.PrecioDolar;
                aux2.Cantidad = Convert.ToInt32(numericUpDown3.Value);
            }
            coleccion.Add(aux2);
            listView2.Clear();
            FormGrid();
            CargarDeposito(coleccion);
        }

        private void getLibro()
        {
            textBox9.Text = "";
            textBox8.Text = "";
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", textBox3.Text);// & builder.Eq("ISBN", textBox6.Text);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                aux.Nombre = doc.GetElement("Nombre").Value.ToString();
                aux.PrecioPeso = Convert.ToInt32(doc.GetElement("PrecioPeso").Value.ToString());
                aux.PrecioDolar = Convert.ToInt32(doc.GetElement("PrecioDolar").Value.ToString());
                
            }
        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
                        
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            getLibro();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            coleccion.RemoveAt(coleccion.Count - 1);
            listView2.Clear();
            FormGrid();
            CargarDeposito(coleccion);
        }

        private void RetiroDeLibro_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            string aux = string.Empty;
            if (e.KeyData == Keys.Enter)
            {
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_libro");
                var collection = database.GetCollection<BsonDocument>("Stock");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Nombre", textBox3.Text);
                var result = collection.Find(filter).ToList();
                foreach (var doc in result)
                {
                    textBox6.Text = doc.GetValue("ISBN").AsString;
                    if (checkBox3.Checked)
                    {
                        textBox9.Text = "$" + doc.GetElement("PrecioPeso").Value.ToString();
                    }
                    if (checkBox2.Checked)
                    {
                        textBox8.Text = "U$S" + doc.GetElement("PrecioDolar").Value.ToString();
                    }
                }

                
            }
        }
    }
}
