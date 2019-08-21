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
using Spire.Xls;

namespace WindowsFormsApp7
{
    public partial class CirreDiario : Form
    {
        Global Global = new Global();
        string carpeta;
        ClaseExcel Excelnew = new ClaseExcel();

        public CirreDiario()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent(); 
            carpeta = Global.getDire();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dia = monthCalendar1.SelectionRange.Start.ToString("dd");
            string mes = monthCalendar1.SelectionRange.Start.ToString("MMMM");
            string year = monthCalendar1.SelectionRange.Start.ToString("yyyy");
            if (MessageBox.Show("Generar El Cierre Diario del dia " + year + "/" + monthCalendar1.SelectionRange.Start.ToString("MM") + "/" + dia + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Excelnew.archivoSin = year + monthCalendar1.SelectionRange.Start.ToString("MM") + dia;
                string archivodia = @carpeta + "\\Diario\\" + year + monthCalendar1.SelectionRange.Start.ToString("MM") + dia;
                // user clicked yes
                Excelnew.Archivo = archivodia;
                Excelnew.Date = year + "/" + monthCalendar1.SelectionRange.Start.ToString("MM") + "/" + dia;            
                Excelnew.Descripcion = "ReporteDiario";
                Excelnew.CierreParcialDia = year + monthCalendar1.SelectionRange.Start.ToString("MM") + dia;
                try
                {
                    Excelnew.CierreExcel();
                }
                catch { }
            }
            else
            {
                // user clicked no
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mes = monthCalendar1.SelectionRange.Start.ToString("MMMM");
            string archivomes = @carpeta + "\\Mensual\\" + monthCalendar1.SelectionRange.Start.ToString("yyyy") + mes;
            Excelnew.Archivo = archivomes;

            Excelnew.CasoEspecial = archivomes + "Casos Especiales" + ".xlsx";

            Excelnew.Date = monthCalendar1.SelectionRange.Start.ToString("yyyy") + monthCalendar1.SelectionRange.Start.ToString("MMMM");
            string archivoProfe = @carpeta + "\\Liquidaciones\\" + monthCalendar1.SelectionRange.Start.ToString("yyyy") + mes;

            Excelnew.archivoSin = monthCalendar1.SelectionRange.Start.ToString("yyyy") + mes;
            if (MessageBox.Show("Generar El Cierre Mensual del mes " + mes + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {           
                Excelnew.Descripcion = " ReporteMensual";
                Excelnew.CierreParcialDia = "no tiene dia";
                try
                {
                    Excelnew.CierreExcel2(archivoProfe);
                }
                catch { }
            }
            else
            {
                // user clicked no
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Cierres frm1 = new Cierres();
            frm1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dia = monthCalendar1.SelectionRange.Start.ToString("dd");
            string mes = monthCalendar1.SelectionRange.Start.ToString("MM");

            if (MessageBox.Show("Generar El Cierre Parcial" + " del dia " + monthCalendar1.SelectionRange.Start.ToString("yyyy") + "/" + monthCalendar1.SelectionRange.Start.ToString("MM") + "/" + dia + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string archivodia = @carpeta + "\\Diario\\" + monthCalendar1.SelectionRange.Start.ToString("yyyy") + monthCalendar1.SelectionRange.Start.ToString("MM") + dia;
                Excelnew.Archivo = archivodia;
                Excelnew.archivoSin = monthCalendar1.SelectionRange.Start.ToString("yyyy") + monthCalendar1.SelectionRange.Start.ToString("MM") + dia;
                Excelnew.Date = monthCalendar1.SelectionRange.Start.ToString("yyyy") + "/" + monthCalendar1.SelectionRange.Start.ToString("MM") + "/" + dia;
                if (!File.Exists(Excelnew.Archivo + ".xlsx"))
                {
                    MessageBox.Show("No existe el archivo de excel");
                }
                else
                {
                    Excelnew.Descripcion = "ReporteDiarioParcial" + DateTime.Now.ToString("HH")+ "hrs";
                    Excelnew.CierreParcialDia = monthCalendar1.SelectionRange.Start.ToString("yyyy") + "/" + monthCalendar1.SelectionRange.Start.ToString("MM") + "/" + dia;
                    try
                    {
                        Excelnew.CierreParcialExcel();

                    }catch{ }
                }
            }
        }

        private void CirreDiario_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mes = monthCalendar1.SelectionRange.Start.ToString("MMMM");
            string archivomes = @carpeta + "\\Liquidaciones\\" + DateTime.Now.ToString("yyyy") + mes;
            Excelnew.Archivo = archivomes;
            Excelnew.Date = monthCalendar1.SelectionRange.Start.ToString("yyyy") + monthCalendar1.SelectionRange.Start.ToString("MM");

            if (MessageBox.Show("Generar El Cierre Mensual del mes " + mes + " de los Profesores?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                    Excelnew.Descripcion = "ReporteMensual";
                    Excelnew.CierreParcialDia = "no tiene dia";
                    Excelnew.CierreExcel();
                
               // user clicked yes

            }
            else
            {
                // user clicked no
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();

            string carpeta = Global.getPath();
            string destination = string.Empty;

            workbook.OpenPassword = "pato";

            // load Excel file 
            workbook.LoadFromFile(@carpeta + "\\Diario\\" + "20190329.xlsx");
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
            workbook.SaveToFile(@destination + "\\20190329.pdf", FileFormat.PDF);

            System.Diagnostics.Process.Start(@destination + "\\20190329.pdf");
        }
    }
}
