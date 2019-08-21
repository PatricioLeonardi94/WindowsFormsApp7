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
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;




namespace WindowsFormsApp7
{
    class Comprobante_Especial
    {
        Global Global = new Global();
        public string Nombre { get; set; }
        public string Monto { get; set; }
        public string Clase_Curso { get; set; }
        public string Motivo { get; set; }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string NameFile { get; set; }
        public string ComprobanteTalonario { get; set; }


        public Comprobante_Especial()
        {

        }

        public List<string> getUsuarios()
        {
            List<string> aux = new List<string>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(builder).ToList();
            foreach (var doc in result)
            {
                aux.Add(doc.GetValue("Nombre").AsString);
            }
            return aux;
        }

        public void Cargar_Recibo_Especial()
        {
            string direccion = this.NameFile;
            string save = direccion + ".xlsx";

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
            if (!System.IO.File.Exists(Global.MensualServer +  save))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                xlRange.Cells[1, "A"] = "Fecha";
                xlRange.Cells[1, "B"] = "Nombre";
                xlRange.Cells[1, "C"] = "Clase o Curso";
                xlRange.Cells[1, "D"] = "Motivo";
                xlRange.Cells[1, "E"] = "N° Talonario";
                xlRange.Cells[1, "F"] = "Monto";
                xlRange.Cells[1, "G"] = "Usuario";
                xlRange.Cells[2, "A"] = this.Fecha;
                xlRange.Cells[2, "B"] = this.Nombre;
                xlRange.Cells[2, "C"] = this.Clase_Curso;
                xlRange.Cells[2, "D"] = this.Motivo;
                xlRange.Cells[2, "E"] = this.ComprobanteTalonario;
                xlRange.Cells[2, "F"] = this.Monto;
                xlRange.Cells[2, "G"] = this.Usuario;


                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(Global.Mensual + direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);


                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);

            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(Global.Mensual + direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = this.Fecha;
                xlRange.Cells[rowNumber, "B"] = this.Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Clase_Curso;
                xlRange.Cells[rowNumber, "D"] = this.Motivo;
                xlRange.Cells[rowNumber, "E"] = this.ComprobanteTalonario;
                xlRange.Cells[rowNumber, "F"] = this.Monto;
                xlRange.Cells[rowNumber, "G"] = this.Usuario;

                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message 
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(Global.Mensual + direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);
            }
        }

    }
}
