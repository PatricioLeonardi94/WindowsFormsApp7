using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;


namespace WindowsFormsApp7
{
    public class MinComprobante
    {
        Global Global = new Global();
        public string Nombre { get; set; }
        public string NumeroComprobante { get; set; }
        public string Fecha { get; set; }
        public string Diferencia_Comprobante_Numero { get; set; }
        public List<Comprobantemin> comprobantes = new List<Comprobantemin>();
        public string Motivo { get; set; }
        public string Responsable { get; set; }



        public void retriveComprobante()
        {
            var client = new MongoClient(Global.Path_DataBase); var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("NumeroComprobante", this.NumeroComprobante) & builder.Eq("Nombre", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Diferencia_Comprobante_Numero = doc.GetValue("DiferenciaReciboNumero", "").AsString;
                var clases = doc.GetValue("Clases", "No posee").AsBsonArray;
                this.comprobantes.Clear();
                foreach (var clase in clases)
                {
                    var clase2 = clase.AsBsonDocument;
                    Comprobantemin comprobanteaux = new Comprobantemin();
                    comprobanteaux.CantidadClases = clase2.GetValue("CantidadClases", "No Posee").AsString;
                    comprobanteaux.Profesor = clase2.GetValue("Profesor", "No Posee").AsString;
                    comprobanteaux.Precio = clase2.GetValue("Precio", "No Posee").AsString;
                    comprobanteaux.ClasesTomar = clase2.GetValue("ClasesTomar", "No Posee").AsString;
                    comprobanteaux.Descripcion = clase2.GetValue("Descripcion", "No Posee").AsString;
                    comprobanteaux.cantidadElegidos = clase2.GetValue("cantidadElegidos", "No Posee").AsString;
                    comprobanteaux.Total = clase2.GetValue("Total", "No Posee").AsString;
                    this.comprobantes.Add(comprobanteaux);
                }
            }
        }

       



        public string getTotal()
        {
            int resp = 0;
            foreach(var clase in this.comprobantes)
            {
                resp += Convert.ToInt32(clase.Total);
            }
            return resp.ToString();
        }

        public void CancelarMinComprobante(string motivo,string responsable)
        {
            this.Responsable = responsable;
            int total = 0;
            string today = DateTime.Today.ToString("dd/MM/yyyy");

            foreach(var clase in this.comprobantes)
            {
                clase.borrarComprobateProfesor(this, this.Motivo, this.Responsable);
                total += Convert.ToInt32(clase.Total);
            }

            total = total * (-1);

 
            BorrarDia(total.ToString());
            

            BorrarMes(total.ToString());
            PrintCancelRecipe(total);
            MessageBox.Show("Recibo Cancelado");
        }

        private void PrintCancelRecipe(int total)
        {
            var auxTotal = total * (-1);
            string fecha = "Fecha " + DateTime.Today.ToString("d");
            string hora = "Hora " + DateTime.Now.ToString("HH:mm");
            CreaTicket Ticket1 = new CreaTicket();

            Ticket1.impresora = Global.getImpresora();
            Ticket1.AgregaLinea(2);
            Ticket1.TextoExtremos(fecha, hora);
            Ticket1.AgregaLinea(1);
            Ticket1.LineasGuion();
            Ticket1.AgregaLinea(1);
            Ticket1.TextoCentro("Se Cancelo");
            Ticket1.AgregaLinea(1);
            Ticket1.TextoIzquierda("Numero de Comprobante:");
            Ticket1.TextoIzquierda(this.NumeroComprobante);
            Ticket1.TextoExtremos("Total", auxTotal.ToString());
            Ticket1.AgregaLinea(1);
            Ticket1.TextoExtremos("Usuario", Global.getActualUser());
            Ticket1.TextoIzquierda("Autorizo:");
            Ticket1.TextoIzquierda(this.Responsable);
            Ticket1.CortaTicket();
        }

        private void BorrarDia(string total)
        {
            string today = DateTime.Today.ToString("yyyyMMdd");
            string carpeta = Global.getDire();
            DateTime oDate = Convert.ToDateTime(this.Fecha);
            string direccion = @carpeta + "\\Diario\\" + today;

            try
            {
                File.Copy(Global.DiarioServer + Path.GetFileName(direccion + ".xlsx"), Global.Diario + Path.GetFileName(direccion + ".xlsx"), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }


            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            try
            {
                if (!System.IO.File.Exists(Global.Diario + Path.GetFileName(direccion + ".xlsx")))
                {
                    xlWorkbook = xlApp.Workbooks.Add(misValue);
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    int rowCount = xlRange.Rows.Count;

                    xlRange.Cells[1, "A"] = "Fecha";
                    xlRange.Cells[1, "B"] = "Nombre";
                    xlRange.Cells[1, "C"] = "Descripcion";
                    xlRange.Cells[1, "D"] = "Cantidad";
                    xlRange.Cells[1, "E"] = "Profesor";
                    xlRange.Cells[1, "F"] = "Precio";
                    xlRange.Cells[1, "G"] = "Nro Comprobante";
                    xlRange.Cells[2, "A"] = DateTime.Now.ToString("dd/MM/yyyy");
                    xlRange.Cells[2, "B"] = this.Nombre;

                    if (string.IsNullOrEmpty(this.Motivo))
                    {
                        this.Motivo = ("No especifica Motivo");
                    }
                    xlRange.Cells[2, "C"] = this.Motivo;

                    xlRange.Cells[2, "F"] = total;
                    xlRange.Cells[2, "G"] = "C" + this.NumeroComprobante;
                    xlRange.Cells[2, "H"] = this.Responsable;


                    xlWorkbook.Password = Global.Connect();
                    xlWorkbook.SaveAs(direccion);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);
                    File.Copy(Global.Diario + Path.GetFileName(direccion + ".xlsx"), Global.DiarioServer + Path.GetFileName(direccion + ".xlsx"), true);

                }
                else
                {

                
                    xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;


                xlRange.Cells[rowNumber, "A"] = DateTime.Now.ToString("dd/MM/yyyy");
                xlRange.Cells[rowNumber, "B"] = this.Nombre;

                if (string.IsNullOrEmpty(this.Motivo))
                {
                    this.Motivo = ("No especifica Motivo");
                }
                xlRange.Cells[rowNumber, "C"] = this.Motivo;

                xlRange.Cells[rowNumber, "F"] = total;
                xlRange.Cells[rowNumber, "G"] = "C" + this.NumeroComprobante;
                xlRange.Cells[rowNumber, "H"] = this.Responsable;

                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Diario + Path.GetFileName(direccion + ".xlsx"), Global.DiarioServer + Path.GetFileName(direccion + ".xlsx"), true);

            }
            }
            catch
            {

            }
        }

        private void BorrarMes(string total)
        {

            string carpeta = Global.getDire();
            DateTime oDate = Convert.ToDateTime(this.Fecha);
            string direccion = @carpeta + "\\Mensual\\" + oDate.ToString("yyyyMMMM");

            try
            {
                File.Copy(Global.MensualServer + Path.GetFileName(direccion + ".xlsx"), Global.Mensual + Path.GetFileName(direccion + ".xlsx"), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            try
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;


                xlRange.Cells[rowNumber, "A"] = DateTime.Now.ToString("dd/MM/yyyy");
                xlRange.Cells[rowNumber, "B"] = this.Nombre;
                if (string.IsNullOrEmpty(this.Motivo))
                {
                    this.Motivo = ("No especifica Motivo");
                }
                xlRange.Cells[rowNumber, "C"] = this.Motivo;

                xlRange.Cells[rowNumber, "F"] = total;
                xlRange.Cells[rowNumber, "G"] = "C" + this.NumeroComprobante;
                xlRange.Cells[rowNumber, "H"] = this.Responsable;


                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Mensual + Path.GetFileName(direccion + ".xlsx"), Global.MensualServer + Path.GetFileName(direccion + ".xlsx"), true);

            }
            catch
            {

            }
        }
    }

    public class Comprobantemin 
    {
        Global Global = new Global();
        public string CantidadClases { get; set; }
        public string Profesor { get; set; }
        public string Precio { get; set; }
        public string ClasesTomar { get; set; }
        public string Descripcion { get; set; }
        public string cantidadElegidos { get; set; }
        public string Total { get; set; }

        public Comprobantemin()
        {

        }


        public Clase trasforToClase()
        {
            Clase resp = new Clase();
            resp.Profesor = this.Profesor;
            resp.Precio = this.Precio;
            resp.Total = this.Total;
            resp.ClasesTomar = this.ClasesTomar;
            resp.Descripcion = this.Descripcion;
            resp.cantidadElegidos = this.cantidadElegidos;
            resp.CantidadClases = this.CantidadClases;

            return resp;
        }


        public void borrarComprobateProfesor(MinComprobante MinComprobanteAll,string motivo, string responsable)
        {

            string carpeta = Global.getDire();
            DateTime oDate = Convert.ToDateTime(MinComprobanteAll.Fecha);
            string fecha = oDate.ToString("yyyy") + oDate.ToString("MMMM") + this.Profesor;
            string direccion = @carpeta + "\\Liquidaciones\\" + fecha;

            try
            {
                File.Copy(Global.LiquidacionesServer + Path.GetFileName(direccion + ".xlsx"), Global.Liquidaciones + Path.GetFileName(direccion + ".xlsx"), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }


            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;

            try
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;


                xlRange.Cells[rowNumber, "A"] = MinComprobanteAll.Fecha;
                xlRange.Cells[rowNumber, "B"] = MinComprobanteAll.Nombre;
                xlRange.Cells[rowNumber, "C"] = motivo;
                xlRange.Cells[rowNumber, "D"] = this.CantidadClases;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = "-" + this.Total;
                xlRange.Cells[rowNumber, "G"] = "C"  + MinComprobanteAll.NumeroComprobante;
                xlRange.Cells[rowNumber, "H"] = responsable;


                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Liquidaciones + Path.GetFileName(direccion + ".xlsx"), Global.LiquidacionesServer + Path.GetFileName(direccion + ".xlsx"), true);

            }
            catch
            {
                MessageBox.Show("No existe ese archivo");
            }

        }
    }
}
