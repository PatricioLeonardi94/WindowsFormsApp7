using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp7
{
    public class ComprobanteAlumno
    {
        public string NombrePersona { get; set; }
        public string NumeroComprobante { get; set; }
        public string Fecha { get; set; }
        public string Motivo { get; set; }
        public List<Comprobantemin> Clases = new List<Comprobantemin>();
        Global Global = new Global();
        private string total = null;
        MinComprobante MinComprobanteAll = new MinComprobante();


        public void doneRemoving()
        {
            retriveComprobante();
            BorrarComprobante();
        }


        public void retriveComprobante()
        {
            var client = new MongoClient(Global.Path_DataBase); var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("NumeroComprobante", this.NumeroComprobante) & builder.Eq("Fecha", this.Fecha);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.MinComprobanteAll.Nombre = doc.GetValue("Nombre", "No posee").AsString;
                this.MinComprobanteAll.NumeroComprobante = doc.GetValue("NumeroComprobante", "No posee").AsString;
                this.MinComprobanteAll.Fecha = doc.GetValue("Fecha", "No posee").AsString;
                var clases = doc.GetValue("Clases", "No posee").AsBsonArray;
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
                    this.MinComprobanteAll.comprobantes.Add(comprobanteaux);
                }
            }


        }


        private void BorrarComprobante()
        {
            int totalInterno = 0;

            try
            {
                foreach(var clase in this.MinComprobanteAll.comprobantes)
                {
                    borrarComprobateProfesor(clase);
                    totalInterno += Convert.ToInt32(clase.Total);
                }

                try
                {
                    totalInterno = totalInterno * (-1);
                }
                catch
                {
                    MessageBox.Show("No posee recibos");
                }

                this.total = totalInterno.ToString();

                BorrarDia();
                BorrarMes();
            }
            catch
            {
                MessageBox.Show("No posee");
            }
















                /*


                this.NumeroComprobante = numeroComprobante;
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook;
                Excel._Worksheet xlWorksheet;
                try
                {
                    if (tipo == "diario")
                    {
                        File.Copy(Global.DiarioServer + Path.GetFileName(direccion), Global.Diario + Path.GetFileName(direccion), true);
                    }else if(tipo == "mensual")
                    {
                        File.Copy(Global.MensualServer + Path.GetFileName(direccion), Global.Mensual + Path.GetFileName(direccion), true);
                    }else if(tipo == "liquidaciones")
                    {
                        File.Copy(Global.LiquidacionesServer + Path.GetFileName(direccion), Global.Liquidaciones + Path.GetFileName(direccion), true);
                    }
                }
                catch (System.IO.FileNotFoundException)
                {

                }

                if (!System.IO.File.Exists(save))
                {
                    return "No existe excel del dia solicitado";
                }

                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;
                Excel.Range fila = xlRange.Find(numeroComprobante,*/
                //Type.Missing, /* After */
                //Excel.XlFindLookIn.xlValues, /* LookIn */
                //Excel.XlLookAt.xlWhole, /* LookAt */
                //Excel.XlSearchOrder.xlByRows, /* SearchOrder */
                //Excel.XlSearchDirection.xlNext, /* SearchDirection */
                //Type.Missing, /* MatchCase */
                //Type.Missing, /* MatchByte */
                //Type.Missing /* SearchFormat */);

                /*
                var filabien = fila.Row.ToString();

                if (fila == null)
                {


                    xlApp.DisplayAlerts = false;
                    xlWorkbook.SaveAs(direccion);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);
                    return "No se pudo eliminar el comprobante";
                }
                else
                {
                    DatoExcel datosExcel = new DatoExcel
                    {
                        //Fecha = xlRange.Cells[filabien, "A"].Value.ToString("dd/MM/yyyy"),
                        Nombre = xlRange.Cells[filabien, "B"].Value,
                        Descripcion = xlRange.Cells[filabien, "C"].Value,
                        Cantidad = xlRange.Cells[filabien, "D"].Value,
                        Profesor = xlRange.Cells[filabien, "E"].Value,
                        Precio = Convert.ToInt32(xlRange.Cells[filabien, "F"].Value) * (-1),
                        Ticket = numeroComprobante
                    };
                    this.NombrePersona = datosExcel.Nombre;


                    xlRange.Cells[rowNumber, "A"] = datosExcel.Fecha;
                    xlRange.Cells[rowNumber, "B"] = datosExcel.Nombre;
                    xlRange.Cells[rowNumber, "C"] = motivo;
                    xlRange.Cells[rowNumber, "D"] = datosExcel.Cantidad;
                    xlRange.Cells[rowNumber, "E"] = datosExcel.Profesor;
                    xlRange.Cells[rowNumber, "F"] = datosExcel.Precio;
                    xlRange.Cells[rowNumber, "G"] = datosExcel.Ticket;

                    xlApp.DisplayAlerts = false; 
                    xlWorkbook.SaveAs(direccion);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);

                    return datosExcel.Profesor;
                }
                */
            }



        private void BorrarDia()
        {

            string carpeta = Global.getDire();
            DateTime oDate = Convert.ToDateTime(this.Fecha);
            string direccion = @carpeta + "\\Diario\\" + oDate.ToString("yyyyMMdd");


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
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;


                xlRange.Cells[rowNumber, "A"] = DateTime.Now.ToString("dd/MM/yyyy");
                xlRange.Cells[rowNumber, "B"] = this.MinComprobanteAll.Nombre;

                if (string.IsNullOrEmpty(this.Motivo))
                {
                    this.Motivo=("No especifica Motivo");
                }
                xlRange.Cells[rowNumber, "C"] = this.Motivo;

                xlRange.Cells[rowNumber, "F"] = this.total;
                xlRange.Cells[rowNumber, "G"] = this.MinComprobanteAll.NumeroComprobante;

                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Diario + Path.GetFileName(direccion + ".xlsx"), Global.DiarioServer + Path.GetFileName(direccion + ".xlsx"), true);

            }
            catch
            {

            }
        }

        private void BorrarMes()
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
                xlRange.Cells[rowNumber, "B"] = this.MinComprobanteAll.Nombre;
                if (string.IsNullOrEmpty(this.Motivo))
                {
                    this.Motivo = ("No especifica Motivo");
                }
                xlRange.Cells[rowNumber, "C"] = this.Motivo;

                xlRange.Cells[rowNumber, "F"] = this.total;
                xlRange.Cells[rowNumber, "G"] = this.MinComprobanteAll.NumeroComprobante;

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

        private void borrarComprobateProfesor(Comprobantemin clase)
        {
            string carpeta = Global.getDire();
            DateTime oDate = Convert.ToDateTime(this.Fecha);
            string fecha = oDate.ToString("yyyy") + oDate.ToString("MMMM") + clase.Profesor;
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


                xlRange.Cells[rowNumber, "A"] = this.MinComprobanteAll.Fecha;
                xlRange.Cells[rowNumber, "B"] = this.MinComprobanteAll.Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Motivo;
                xlRange.Cells[rowNumber, "D"] = clase.CantidadClases;
                xlRange.Cells[rowNumber, "E"] = clase.Profesor;
                xlRange.Cells[rowNumber, "F"] = "-" + clase.Total;
                xlRange.Cells[rowNumber, "G"] = this.MinComprobanteAll.NumeroComprobante;

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


        private void getComprobanteParcialAlumno()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var filter = Builders<BsonDocument>.Filter.Eq("Fecha", this.Fecha) & Builders<BsonDocument>.Filter.Eq("NumeroComprobante", this.NumeroComprobante);
            var result = collection.Find(filter).ToList();
            foreach(var doc in result)
            {
                this.NombrePersona = doc.GetValue("Nombre", "NO posee Nombre").AsString;
                var clases = doc.GetValue("Clases", "No posee").AsBsonArray;
                foreach(var clase in clases)
                {
                    Comprobantemin auxComprobantemin = new Comprobantemin();
                    auxComprobantemin.CantidadClases = doc.GetValue("CantidadClases", "No posee").AsString;
                    auxComprobantemin.Profesor = doc.GetValue("Profesor", "No posee").AsString;
                    auxComprobantemin.Precio = doc.GetValue("Precio", "No posee").AsString;
                    auxComprobantemin.ClasesTomar = doc.GetValue("ClasesTomar", "No posee").AsString;
                    auxComprobantemin.Descripcion = doc.GetValue("Descripcion", "No posee").AsString;
                    auxComprobantemin.cantidadElegidos = doc.GetValue("cantidadElegidos", "No posee").AsString;
                    auxComprobantemin.Total = doc.GetValue("Total", "No posee").AsString;
                    this.Clases.Add(auxComprobantemin);
                }


            }
        }

        public void RemoveComprobanteAlumno()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.NombrePersona);
            var update = Builders<BsonDocument>.Update.Pull("Comprobantes", this.NumeroComprobante);
            var result = collection.FindOneAndUpdate(filter, update);
        }

        public void RemoveComprobante()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.NombrePersona) & builder.Eq("NumeroComprobante", this.NumeroComprobante) & builder.Eq("Fecha", this.Fecha);
            var result = collection.DeleteOne(filter);
        }
    }
}
