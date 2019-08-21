using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;



namespace WindowsFormsApp7
{
    class ListaExcelProfesor
    {
        Global Global = new Global();
        public string Fecha { get; set; }
        public string Destino { get; set; }
        public string DestinoShort { get; set; }
        public List<LittleProfesorList> Clase { get; set; }

        public ListaExcelProfesor()
        {
            List<LittleProfesorList> aux = new List<LittleProfesorList>();
            Clase = aux;
        }

        public class LittleProfesorList
        {
            public string Profesor { get; set; }
            public string Clase { get; set; }
            public string Horario { get; set; }
            public List<string> Alumnos { get; set; }

            public LittleProfesorList()
            {
                List<string> aux = new List<string>();
                Alumnos = aux;
            }
        }

        public void getInformationClases()
        {
            LittleProfesorList auxClase = new LittleProfesorList();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_clases");
            var collection = database.GetCollection<BsonDocument>(this.Fecha);
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(builder).ToList();
            foreach (var doc in result)
            {
                auxClase.Profesor = doc.GetValue("Profesor", "No tiene Nombre").AsString;
                auxClase.Clase = doc.GetValue("Clase", "No tiene Clase").AsString;
                List<string> auxAlumnos = new List<string>();
                var alumno =  doc.GetValue("Alumnos", "No tiene Alumnos").AsBsonDocument;
                foreach(var key in alumno)
                {
                    auxAlumnos.Add(key.ToString());               
                }
                auxClase.Alumnos = auxAlumnos;
            }
        }


        public void SortClasesToGenerate()
        {
            int i = 1;
            foreach(var claseParticular in Clase)
            {
                //string nombre = claseParticular.Profesor + " " + claseParticular.Clase + " " + claseParticular.Horario;

                string nombre = claseParticular.Profesor + " " + claseParticular.Clase + " " + i.ToString();
                generateExcels(claseParticular, nombre);
                i++;
            }
        }

        private void generateExcels(LittleProfesorList clase, string name)
        {
            string path = this.Destino;
            string destinationName = path + "\\" + name;
            string save = destinationName + ".xlsx";
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

                xlRange.Cells[1, "A"] = clase.Profesor;             
                xlRange.Cells[2, "A"] = clase.Clase;
                int i = 4;
                foreach(var alumno in clase.Alumnos)
                {
                    xlRange.Cells[i, "A"] = alumno;
                    i++;
                }

                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "D"]].Merge();
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "B"]].Merge();
                xlWorksheet.Range[xlWorksheet.Cells[2, "C"], xlWorksheet.Cells[2, "D"]].Merge();
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "D"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "D"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "D"]].Font.Bold = true;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[i, "D"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[2, "D"]].Interior.Color = System.Drawing.ColorTranslator.FromHtml("#daffd6");
                xlWorksheet.Columns[1].ColumnWidth = 25;


                xlWorkbook.SaveAs(destinationName);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
            }


        }


    }
}
