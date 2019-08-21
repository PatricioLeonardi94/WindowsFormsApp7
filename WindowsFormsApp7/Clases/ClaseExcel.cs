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
using Spire.Xls;

namespace WindowsFormsApp7
{
    public class ClaseExcel
    {
        public string archivoSin { get; set; }
        public string Descripcion { get; set; }
        public int EXIT { get; set; }
        public string Archivo { get; set; }
        public string ArchivoGuardar { get; set; }
        public int UltimaUbicacion { get; set; }
        public string Date { get; set; }
        public Global Global { get; set; }
        public int TotalesOtros { get; set; }
        public string CierreParcialDia { get; set; }
        public int UltimoComprobanteFila { get; set; }
        public List<ProfesorCorto> ProfesoresCortos { get; set; }
        public string CasoEspecial { get; set; }


        public ClaseExcel()
        {
            this.Global = new Global();
            getProfesor();
        }

        //Genera el Excel entero del dia selecionado
        public void CierreExcel()
        {
            int previousTotals = 0;
            Usuario usuario = new Usuario();
            string save = this.Archivo;
            string direccion = save + ".xlsx";
            int total = 0;

            try
            {
                File.Copy(Global.DiarioServer + Path.GetFileName(direccion), Global.Diario + Path.GetFileName(direccion), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            var firstFile = Global.Diario + Path.GetFileName(direccion);
            var FileToCopyWithout = Global.DiarioServer + Path.GetFileName(save) + "copia";
            var FileToCopy = Global.DiarioServer + Path.GetFileName(save) + "copia.xlsx";

            //File.Copy(firstFile, FileToCopy, true);

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;


                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                for (var i = 2; i <= rowCount; i++)
                {
                    if (!(xlRange.Cells[i, "E"].Value == "Total"))
                    {
                        if (xlRange.Cells[i, "F"].Value == null)
                        {
                            total += 0;
                        }
                        else
                        {
                            total += Convert.ToInt32(xlRange.Cells[i, "F"].Value);

                        }
                    }
                    else
                    {
                        if(xlRange.Cells[i, "F"].Value == null)
                        {
                            previousTotals += 0;
                        }
                        else
                        {
                            previousTotals += Convert.ToInt32(xlRange.Cells[i, "F"].Value);
                        }
                    }
                }

                xlRange.Cells[rowCount + 1, "E"] = "Total";
                xlRange.Cells[rowCount + 2, "F"] = (total-previousTotals).ToString();

                xlRange.Cells[rowCount + 3, "E"] = "Total Del Dia";
                xlRange.Cells[rowCount + 4, "F"] = total.ToString();


                xlRange.Cells[rowCount + 6, "A"] = "El cierre fue realizado por: " + usuario.getUsuarioActual();
                xlRange.Cells[rowCount + 7, "A"] = "Numero de Cierre: " + Global.getCierreDiario();

                xlRange.Columns[6].ColumnWidth = 10;
                xlRange.Columns[3].ColumnWidth = 3;

                Global.IncrementCierre();

                guardarRegistro(/*monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy"),*/ total.ToString());

                

                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);


                File.Copy(Global.Diario + Path.GetFileName(direccion), Global.DiarioServer + Path.GetFileName(direccion), true);

                ToPDF(direccion);

        }


        private void ToPDF(string nombre)
        {
            Workbook workbook = new Workbook();

            string carpeta = Global.getPath();
            string destination = string.Empty;

            workbook.OpenPassword = "pato";

            // load Excel file 
            workbook.LoadFromFile(carpeta + "\\Diario\\" + archivoSin + ".xlsx");
            //workbook.UnProtect();

            //convert to PDF file format 
            workbook.ConverterSetting.SheetFitToPage = true;

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                destination = folderBrowser.SelectedPath;
            }

            //save the file 
            workbook.SaveToFile(@destination + "\\" + archivoSin + ".pdf", FileFormat.PDF);

            System.Diagnostics.Process.Start(@destination + "\\" + archivoSin + ".pdf");
        }

        void PrintMyExcelFile(string path)
        {
            Excel.Application excelApp = new Excel.Application();

            // Open the Workbook:
            Excel.Workbook wb = excelApp.Workbooks.Open(
                @path, 
                Type.Missing, Type.Missing, Type.Missing, Global.Connect(), Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Get the first worksheet.
            // (Excel uses base 1 indexing, not base 0.)
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            // Print out 1 copy to the default printer:
            ws.PrintOut(
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Cleanup:
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.FinalReleaseComObject(ws);

            wb.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(wb);

            excelApp.Quit();
            Marshal.FinalReleaseComObject(excelApp);
        }

        //Genera el Excel entero del dia selecionado
        public void CierreExcel2(string carpeta)
        {
           
            string save = this.Archivo + this.Descripcion;
            string direccion = save + ".xlsx";

            try
            {
                File.Copy(Global.MensualServer + Path.GetFileName(direccion), Global.Mensual + Path.GetFileName(direccion), true);
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
                int j = 3;
                int aux2 = 0;
                int aux3 = 0;
                int aux4 = 0;
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                xlRange.FormulaHidden = true;

                xlRange.Cells[1, "A"] = "Cierre Mensual del " + this.Date;
                xlRange.Cells[2, "A"] = "Fecha";
                xlRange.Cells[2, "B"] = "Profesor o Curso";
                xlRange.Cells[2, "C"] = "Total";
                xlRange.Cells[2, "D"] = "Contribucion";
                xlRange.Cells[2, "E"] = "Parte Profesor";

                getTotal(1, "mes");
                foreach (var profesor in this.ProfesoresCortos)
                {
                    if (!(profesor.Total == 0))
                    {
                        int preciopagar = (Convert.ToInt32(profesor.Porcentaje) * profesor.Total) / 100;
                        xlRange.Cells[j, "A"] = this.Date;
                        xlRange.Cells[j, "B"] = profesor.ProfeNombre;
                        xlRange.Cells[j, "C"] = profesor.Total;
                        xlRange.Cells[j, "D"] = profesor.Total - preciopagar;
                        xlRange.Cells[j, "E"] = preciopagar;
                        aux2 += (profesor.Total);
                        aux3 += profesor.Total - preciopagar;
                        aux4 += preciopagar;
                        j++;
                    }
                }

                j += (18 - j);
                Usuario usuario = new Usuario();
                xlRange.Cells[j + 2, "A"] = "Total";
                xlRange.Cells[j + 2, "C"] = aux2.ToString();
                xlRange.Cells[j + 2, "D"] = aux3.ToString();
                xlRange.Cells[j + 2, "E"] = aux4.ToString();
                //Styling
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "E"]].Font.Bold = true;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[j + 2, "E"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[j + 2, "E"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                xlWorksheet.Range[xlWorksheet.Cells[j + 2, "A"], xlWorksheet.Cells[j + 2, "E"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "A"]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlRange.Cells[j + 4, "A"] = "El cierre fue realizado por: " + usuario.getUsuarioActual();


                //guardarRegistro(/*monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy"),*/ aux2.ToString());

                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "E"]].Merge();

                xlWorksheet.Columns[1].ColumnWidth = 14;
                xlWorksheet.Columns[2].ColumnWidth = 24;
                xlWorksheet.Columns[3].ColumnWidth = 10;
                xlWorksheet.Columns[4].ColumnWidth = 11;
                xlWorksheet.Columns[5].ColumnWidth = 12;


                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                CierreExcelProfesor(carpeta);
                File.Copy(Global.Mensual + Path.GetFileName(direccion), Global.MensualServer + Path.GetFileName(direccion), true);
                MessageBox.Show("El " + this.Descripcion + " se ha generado");

            }

            ToPDF(direccion);
            ToPDF(this.CasoEspecial);

        }

        private void ToPDFMensual(string nombre)
        {
            Workbook workbook = new Workbook();

            string carpeta = Global.getPath();
            string destination = string.Empty;

            workbook.OpenPassword = "pato";

            // load Excel file 
            workbook.LoadFromFile(@carpeta + "\\Mensual\\" + archivoSin + ".xlsx");
            //workbook.UnProtect();

            //convert to PDF file format 
            workbook.ConverterSetting.SheetFitToPage = true;

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                destination = folderBrowser.SelectedPath;
            }

            //save the file 
            workbook.SaveToFile(@destination + "\\" + nombre + ".pdf", FileFormat.PDF);

            System.Diagnostics.Process.Start(@destination + "\\" + archivoSin + ".pdf");
        }

        //Genera un excel con el cierre al momento del dia en el que se genero
        public void CierreParcialExcel()
        {
            Usuario usuario = new Usuario();
            string save = this.Archivo;
            string direccion = save + ".xlsx";
            int total = 0;

            
            try
            {
                File.Copy(Global.DiarioServer + Path.GetFileName(save), Global.Diario + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            var NewDirection = save + "copia" + ".xlsx";
            var NewDirectionSave = save + "copia";

            System.IO.File.Copy(direccion, NewDirection);


            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;


            xlWorkbook = xlApp.Workbooks.Open(NewDirectionSave, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;

            for (var i = 2; i <= rowCount; i++)
            {
                if(!(xlRange.Cells[i, "E"].Value == "Total"))
                {
                    if (xlRange.Cells[i, "F"].Value == null)
                    {
                        total += 0;
                    }
                    else
                    {
                        total += Convert.ToInt32(xlRange.Cells[i, "F"].Value);

                    }
                }
            }
            xlRange.Cells[rowCount + 1, "E"] = "Total";
            xlRange.Cells[rowCount + 1, "F"] = total.ToString();


            xlRange.Cells[rowCount + 4, "A"] = "El cierre fue realizado por: " + usuario.getUsuarioActual();


            xlRange.Columns[6].ColumnWidth = 10;
            xlRange.Columns[3].ColumnWidth = 3;


            guardarRegistro(/*monthCalendar1.SelectionRange.Start.ToString("dd/MM/yyyy"),*/ total.ToString());

            xlWorkbook.Password = Global.Connect();
            xlApp.DisplayAlerts = false;
            xlWorkbook.SaveAs(save);
            xlWorkbook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
            File.Copy(Global.Diario + Path.GetFileName(direccion), Global.DiarioServer + Path.GetFileName(direccion), true);

            ToPDF(NewDirectionSave);

            File.Delete(NewDirection);

        }

        

        /*public void CierreExcelMes(string carpetaProfe)
        {
            CierreExcelProfesor(carpetaProfe);
            
            string save = this.Archivo + this.Descripcion;
            string direccion = save + ".xlsx";

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                int j = 3;
                int aux2 = 0;
                int aux3 = 0;
                int aux4 = 0;
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                xlRange.FormulaHidden = true;

                xlRange.Cells[1, "A"] = "Cierre Mensual del " + this.Date;
                xlRange.Cells[2, "A"] = "Fecha";
                xlRange.Cells[2, "B"] = "Profesor o Curso";
                xlRange.Cells[2, "C"] = "Total";
                xlRange.Cells[2, "D"] = "Contribucion";
                xlRange.Cells[2, "E"] = " 50% ";

                //getTotal(1);
                foreach (var profesor in this.ProfesoresCortos)
                {
                    if (!(profesor.Total == 0))
                    {
                        MessageBox.Show(profesor.ProfeNombre);
                        MessageBox.Show(profesor.Total.ToString());
                        int porcentaje = Convert.ToInt32(profesor.Porcentaje);
                        int precio = ((profesor.Total * porcentaje) / 100);
                        xlRange.Cells[j, "A"] = this.Date;
                        xlRange.Cells[j, "B"] = profesor.ProfeNombre;
                        xlRange.Cells[j, "C"] = profesor.Total;
                        xlRange.Cells[j, "D"] = precio;
                        xlRange.Cells[j, "E"] = profesor.Total - precio;
                        aux2 += (profesor.Total);
                        aux3 += precio;
                        aux4 += profesor.Total - precio;
                        j++;
                    }
                }

                j += (18 - j);
                Usuario usuario = new Usuario();
                xlRange.Cells[j + 2, "A"] = "Total";
                xlRange.Cells[j + 2, "C"] = aux2.ToString();
                xlRange.Cells[j + 2, "D"] = aux3.ToString();
                xlRange.Cells[j + 2, "E"] = aux4.ToString();
                //Styling
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "E"]].Font.Bold = true;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[j + 2, "E"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[j + 2, "E"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                xlWorksheet.Range[xlWorksheet.Cells[j + 2, "A"], xlWorksheet.Cells[j + 2, "E"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "A"]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlRange.Cells[j + 4, "A"] = "El cierre fue realizado por: " + usuario.getUsuarioActual();
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "E"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);

                guardarRegistro( aux2.ToString());

                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "E"]].Merge();

                xlWorksheet.Columns[1].ColumnWidth = 20;
                xlWorksheet.Columns[2].ColumnWidth = 30;
                xlWorksheet.Columns[3].ColumnWidth = 10;
                xlWorksheet.Columns[4].ColumnWidth = 15;
                xlWorksheet.Columns[5].ColumnWidth = 10;

                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                this.ProfesoresCortos = null;


                MessageBox.Show("El " + this.Descripcion + " se ha generado");
            }
        
        }
        */

        public void CierreExcelProfesor(string carpeta)
        {

            getProfesor();
            foreach(var profesor in this.ProfesoresCortos)
            {                
                string look = carpeta + profesor.ProfeNombre;
                string save = look + ".xlsx";

                try
                {
                    File.Copy(Global.LiquidacionesLibrosServer + Path.GetFileName(save), Global.Liquidaciones + Path.GetFileName(save), true);
                }
                catch (System.IO.FileNotFoundException)
                {

                }
                cierreProfesor(look, profesor, getComrobantesEspecialesProfesor(profesor.ProfeNombre));

            }
        }

        //Retrive Special Recipes 
        private List<Comprobante_Especial> getComrobantesEspecialesProfesor(string profesor)
        {
            List<Comprobante_Especial> resp = new List<Comprobante_Especial>();

            string direccion = this.Date + "Casos Especiales";
            string save = direccion + ".xlsx";

            try
            {
                File.Copy(Global.MensualServer + Path.GetFileName(save), Global.Mensual + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            //open the excel to search for the specific one

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            xlWorkbook = xlApp.Workbooks.Open(Global.Mensual + direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowNumber = xlRange.Rows.Count + 1;

            for(int i=0; i< rowNumber; i++)
            {
                string clase = xlRange.Cells[i, "C"];
                if (profesor == clase)
                {
                    Comprobante_Especial auxComp = new Comprobante_Especial();
                    auxComp.Fecha = xlRange.Cells[i, "A"];
                    auxComp.Nombre = xlRange.Cells[i, "B"];
                    auxComp.Clase_Curso = xlRange.Cells[i, "C"];
                    auxComp.Motivo = xlRange.Cells[i, "D"];
                    auxComp.ComprobanteTalonario = xlRange.Cells[i, "E"];
                    auxComp.Monto = xlRange.Cells[i, "F"];
                    auxComp.Usuario = xlRange.Cells[i, "G"];
                    resp.Add(auxComp);
                }
            }

            return resp;
        } 

        private void cierreProfesor(string excel, ProfesorCorto profesor, List<Comprobante_Especial> comprobantesEspeciales)
        {
            string carpeta = Global.getDire();
            int valorRecaudado = 0;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            string save = excel + ".xlsx";

            try
            {
                File.Copy(Global.LiquidacionesLibrosServer + Path.GetFileName(save), Global.Liquidaciones + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }



            if (System.IO.File.Exists(save))
            {
                xlWorkbook = xlApp.Workbooks.Open(excel, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                xlRange.FormulaHidden = true;

                for (var i = 2; i <= rowCount  && xlRange.Cells[rowCount + 2, "E"].Value != "Total"; i++)
                {
                    valorRecaudado += Convert.ToInt32(xlRange.Cells[i, "F"].Value);
                }

                xlRange.Cells[rowCount + 2, "E"] = "Total";
                xlRange.Cells[rowCount + 2, "F"] = valorRecaudado;
                profesor.Total = valorRecaudado;
                if (!(profesor.ProfeNombre == "Profesor Diego"))
                {
                    xlRange.Cells[rowCount + 3, "E"] = profesor.Porcentaje + "%";
                    int porcentaje = Convert.ToInt32(profesor.Porcentaje);
                    xlRange.Cells[rowCount + 3, "F"] = ((valorRecaudado * porcentaje) / 100);
                }
                else
                {
                    xlRange.Cells[rowCount + 3, "E"] = profesor.Porcentaje + "%";
                    int porcentaje = Convert.ToInt32(profesor.Porcentaje);
                    int porcentaje2 = ((valorRecaudado * porcentaje) / 100);
                    xlRange.Cells[rowCount + 3, "F"] = porcentaje2;
                    xlRange.Cells[rowCount + 4, "F"] = ((porcentaje2 * 66) / 100);
                    xlRange.Cells[rowCount + 5, "F"] = ((porcentaje2 * 33) / 100);
                }

                xlRange.Cells[rowCount + 7, "A"] = "Casos Especiales";

                int LastPlace = rowCount + 8;
                foreach(var particular in comprobantesEspeciales)
                {
                    xlRange.Cells[LastPlace, "A"] = particular.Fecha;
                    xlRange.Cells[LastPlace, "B"] = particular.Nombre;
                    xlRange.Cells[LastPlace, "C"] = particular.Clase_Curso;
                    xlRange.Cells[LastPlace, "D"] = particular.Motivo;
                    xlRange.Cells[LastPlace, "E"] = particular.ComprobanteTalonario;
                    xlRange.Cells[LastPlace, "F"] = particular.Monto;
                    xlRange.Cells[LastPlace, "G"] = particular.Usuario;
                    LastPlace = LastPlace + 1;
                }



                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "G"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "G"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "G"]].Font.Bold = true;

                if (!(profesor.ProfeNombre == "Profesor Diego"))
                {
                    xlWorksheet.Range[xlWorksheet.Cells[rowCount + 3, "E"], xlWorksheet.Cells[rowCount + 3, "F"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                    xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[rowCount + 3, "G"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[rowCount + 3, "G"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                else
                {
                    xlWorksheet.Range[xlWorksheet.Cells[rowCount + 3, "E"], xlWorksheet.Cells[rowCount + 5, "F"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);
                    xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[rowCount + 5, "G"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[rowCount + 5, "G"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "A"]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "G"]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);


                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(excel);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Liquidaciones + Path.GetFileName(save), Global.LiquidacionesServer + Path.GetFileName(save), true);
            }

        }

     

        //Devuelve en un array de ints los valores sumados de cada profesor
        private void getTotal(int filastart, string formato)
        {
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;


            try
            {
                if(formato == "dia")
                {
                    File.Copy(Global.DiarioServer + Path.GetFileName(this.Archivo) + ".xlsx", Global.Diario + Path.GetFileName(this.Archivo) + ".xlsx", true);
                }else if(formato == "mes")
                {
                    File.Copy(Global.MensualServer + Path.GetFileName(this.Archivo) + ".xlsx", Global.Mensual + Path.GetFileName(this.Archivo) + ".xlsx", true);
                }
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            xlWorkbook = xlApp.Workbooks.Open(this.Archivo, Type.Missing, true, Type.Missing, Global.Connect());
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

            Excel.Range c1 = xlWorksheet.Cells[filastart, 1];
            Excel.Range c2 = xlWorksheet.Cells[200, 200];
            Excel.Range xlRange = xlWorksheet.get_Range(c1,c2);
            int rowNumber = xlRange.Rows.Count + 1;
            int lastrow = xlWorksheet.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
            guardarCierreParcial(this.CierreParcialDia, lastrow);

            foreach (var profesor in this.ProfesoresCortos)
            {
                Excel.Range firstFind = null;
                Excel.Range fila = xlRange.Find(profesor.ProfeNombre,
                Type.Missing, /* After */
                Excel.XlFindLookIn.xlValues, /* LookIn */
                Excel.XlLookAt.xlWhole, /* LookAt */
                Excel.XlSearchOrder.xlByColumns, /* SearchOrder */
                Excel.XlSearchDirection.xlNext, /* SearchDirection */
                true, /* MatchCase */
                Type.Missing, /* MatchByte */
                Type.Missing /* SearchFormat */);

                while (fila != null)
                {
                    if (firstFind == null)
                    {
                        firstFind = fila;
                    }
                    else if (fila.get_Address(Excel.XlReferenceStyle.xlA1)
                        == firstFind.get_Address(Excel.XlReferenceStyle.xlA1))
                    {
                        break;
                    }

                    var filabien = fila.Row.ToString();
                    profesor.Total += Convert.ToInt32(xlRange.Cells[filabien, "F"].Value);
                    //MessageBox.Show(filabien);
                    fila = xlRange.FindNext(fila);
                }
            }

            xlApp.DisplayAlerts = false;
            xlWorkbook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
        }

        //Devuelve el valor de los elementos Otros sumados. 
        /* private void getTotalOtros()
         {
             this.TotalesOtros = 0;
             object misValue = System.Reflection.Missing.Value;
             Excel.Application xlApp = new Excel.Application();
             Excel.Workbook xlWorkbook;
             Excel._Worksheet xlWorksheet;
             xlWorkbook = xlApp.Workbooks.Open(this.Archivo, Type.Missing, true, Type.Missing, Global.Connect());
             xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

             Excel.Range xlRange = xlWorksheet.get_Range("A1:H150");
             int rowNumber = xlRange.Rows.Count;


             for (var i = 1; i < rowNumber; i++)
             {
                 if (xlRange.Cells[i, "C"].Value != null & xlRange.Cells[i, "E"].Value == null)
                 {
                     this.TotalesOtros += xlRange.Cells[i, "F"].Value;
                 }
             }

             xlWorkbook.Close();
             xlApp.Quit();

             Marshal.ReleaseComObject(xlWorksheet);
             Marshal.ReleaseComObject(xlWorkbook);
             Marshal.ReleaseComObject(xlApp);
         }*/

        private void getProfesor()
        {
            List<ProfesorCorto> auxprofe = new List<ProfesorCorto>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                ProfesorCorto aux = new ProfesorCorto();
                aux.ProfeNombre= (doc.GetValue("name").AsString);
                aux.Porcentaje = (doc.GetValue("porcentaje").AsString);
                auxprofe.Add(aux);
            }
            int flag = 0;

            var collection2 = database.GetCollection<BsonDocument>("cursos");
            var result2 = collection2.Find(filter).ToList();
            foreach (var doc in result2)
            {
                ProfesorCorto aux2 = new ProfesorCorto();
                aux2.ProfeNombre = (doc.GetValue("profesor").AsString);
                aux2.Porcentaje = (doc.GetValue("porcentaje").AsString);
                bool containsItem = auxprofe.Any(item => item.ProfeNombre == "Profesor Aldo");
                if(aux2.ProfeNombre == "Aldo" && flag == 0)
                {
                    aux2.ProfeNombre = "Profesor Aldo";
                    auxprofe.Add(aux2);
                    flag = 1;
                }
                else if(!(aux2.ProfeNombre == "Aldo"))
                {
                    auxprofe.Add(aux2);
                }

            }
            ProfesoresCortos = auxprofe;
        }

        private void guardarRegistro(string precio)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cierresdiarios");
            var document = new BsonDocument
                {
                    { "Fecha", this.Date },
                    { "MontoTotal", precio },
                };
            collection.InsertOne(document);
        }

        private void guardarCierreParcial(string dia, int ultimoComprobante)
        {
            ComprobanteParcial aux = new ComprobanteParcial();
            aux.Dia = dia;
            aux.ComprobanteLast = ultimoComprobante;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<ComprobanteParcial>("comprobantesparciales");
            var auxiliar = collection.AsQueryable().Any(avm => avm.Dia == aux.Dia);
            if(auxiliar == true)
            {
                var update = Builders<ComprobanteParcial>.Update.Set(v => v.ComprobanteLast , aux.ComprobanteLast);
            }
            else
            {
                collection.InsertOne(aux);
            }
        }
        
        private int getLastComprobate()
        {
            int res = 0;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<ComprobanteParcial>("comprobantesparciales");
            var result = collection.Find(x => x.Dia == this.CierreParcialDia).ToList();                     
            foreach (var doc in result)
            {
                res = doc.ComprobanteLast;
            }
            if(res == 0)
            {
                res = 1;
            }
            return res;
        }

    }

    public class ProfesorCorto
    {
        public string ProfeNombre { get; set; }
        public string Porcentaje { get; set; }
        public int Total { get; set; }

        public ProfesorCorto(string name, string porcentaje)
        {
            this.ProfeNombre = name;
            this.Porcentaje = porcentaje;
            this.Total = 0;
        }
        public ProfesorCorto() { }

    }
}
