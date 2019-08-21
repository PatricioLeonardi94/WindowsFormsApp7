using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
    public class DatoExcel
    {
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Profesor { get; set; }
        public int Precio { get; set; }
        public int Ticket { get; set; }
        Global Global = new Global();

        public void addComprobante()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            string dayto = this.Fecha.Substring(0, 4) + "/" + this.Fecha.Substring(4, 2) + "/" + this.Fecha.Substring(6, 2);
            var document = new BsonDocument
                {
                    { "Nombre", this.Nombre },
                    { "NumeroComprobante", this.Ticket },
                    { "Fecha", dayto },
                    { "Descripcion", this.Descripcion},
                    { "Cantidad", this.Cantidad},
                    { "Profesor", this.Profesor},
                    { "MontoAbonado", this.Precio}
                };
            collection.InsertOne(document);
            addComprobanteAlumno();
        }

        //hacer Last
        public int LastNumber(string direccion, string save)
        {
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                xlApp.Quit();
                return 0001;
            }
            else
            {
                try
                {
                    File.Copy(Global.MensualServer + Path.GetFileName(save), Global.Mensual + Path.GetFileName(save), true);
                }
                catch (System.IO.FileNotFoundException)
                {

                }
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count;
                while (xlRange.Cells[rowNumber, "F"].Value < 0 || (xlRange.Cells[rowNumber, "G"].Value) == null)
                {
                    rowNumber--;
                }
                var resp = (xlRange.Cells[rowNumber, "G"].Value + 1);


                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                return Convert.ToInt32(resp);
            }
        }

        private void addComprobanteAlumno()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", this.Nombre);
            var update = Builders<BsonDocument>.Update.Push("Comprobantes", this.Ticket);
            var result = collection.UpdateOne(filter, update);
        }


        public void CargaExcelDia(string direccion, Global Global, string save)
        {

            try
            {
                File.Copy(Global.DiarioServer + Path.GetFileName(save), Global.Diario + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
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
                xlRange.Cells[2, "A"] = this.Fecha;
                xlRange.Cells[2, "B"] = this.Nombre;
                xlRange.Cells[2, "C"] = this.Descripcion;
                xlRange.Cells[2, "D"] = this.Cantidad;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Precio;
                xlRange.Cells[2, "G"] = this.Ticket;

                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Diario + Path.GetFileName(save), Global.DiarioServer + Path.GetFileName(save), true);

            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = this.Fecha;
                xlRange.Cells[rowNumber, "B"] = this.Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.Cantidad;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Precio;
                xlRange.Cells[rowNumber, "G"] = this.Ticket;

                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message 
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Diario + Path.GetFileName(save), Global.DiarioServer + Path.GetFileName(save), true);
            }
        }

        //cargar excel mes
        public void CargaExcelMes(string direccion, Global Global, string save)
        {
            try
            {
                File.Copy(Global.MensualServer + Path.GetFileName(save), Global.Mensual + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
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
                xlRange.Cells[2, "A"] = this.Fecha;
                xlRange.Cells[2, "B"] = this.Nombre;
                xlRange.Cells[2, "C"] = this.Descripcion;
                xlRange.Cells[2, "D"] = this.Cantidad;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Precio;
                xlRange.Cells[2, "G"] = this.Ticket;

                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);
            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = this.Fecha;
                xlRange.Cells[rowNumber, "B"] = this.Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.Cantidad;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Precio;
                xlRange.Cells[rowNumber, "G"] = this.Ticket;

                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message  
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);
            }

        }

        //Carga el Excel del Profesor
        public void CargarExcelProfesor(string direccion, Global Global, string save)
        {
            try
            {
                File.Copy(Global.LiquidacionesServer + Path.GetFileName(save), Global.Liquidaciones + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
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
                xlRange.Cells[2, "A"] = this.Fecha;
                xlRange.Cells[2, "B"] = this.Nombre;
                xlRange.Cells[2, "C"] = this.Descripcion;
                xlRange.Cells[2, "D"] = this.Cantidad;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Precio;
                xlRange.Cells[2, "G"] = this.Ticket;

                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Liquidaciones + Path.GetFileName(save), Global.LiquidacionesServer + Path.GetFileName(save), true);

            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = this.Fecha;
                xlRange.Cells[rowNumber, "B"] = this.Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.Cantidad;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Precio;
                xlRange.Cells[rowNumber, "G"] = this.Ticket;


                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message  
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Liquidaciones + Path.GetFileName(save), Global.LiquidacionesServer + Path.GetFileName(save),  true);
            }
        }
    }
}
