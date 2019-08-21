using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Globalization;

namespace WindowsFormsApp7
{
    public partial class Ver_Listas_Clases : Form
    {
        Clase clase = new Clase();
        List<Clase> lista = new List<Clase>();
        List<string> profesores = new List<string>();
        string profesor = string.Empty;
        

        public Ver_Listas_Clases()
        {
            this.BackgroundImage = Properties.Resources.templo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            initialize();
            profesores = clase.getProfesoresTodos();
            CargarDeposito(profesores);
        }

        public void initialize()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Profesores", 300, HorizontalAlignment.Left);


            listView2.View = View.Details;
            listView2.Columns.Add("Clases", 150, HorizontalAlignment.Left);


            listView3.View = View.Details;
            listView3.Columns.Add("Alumnos", 150, HorizontalAlignment.Left);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public class MyOwnListViewItem : ListViewItem
        {
            private Clase clase;

            public MyOwnListViewItem(Clase clase)
            {
                this.clase = clase;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = clase.Profesor; //for first detailed column

                this.SubItems.Add(new ListViewSubItem(this, clase.CantidadClases.ToString()));            
            }
        }

        private void CargarDeposito(List<string> Clases)
        {
            foreach (var doc in Clases)
            {
                listView1.Items.Add(doc);
            }
        }

        private void CargarDeposito2(List<string> ClasesProfesor)
        {
            listView2.Items.Clear();
            foreach (var doc in ClasesProfesor)
            {
                listView2.Items.Add(doc);
            }
        }

        private void CargarDeposito3(List<string> Alumnos)
        {
            listView3.Items.Clear();
            foreach (var doc in Alumnos)
            {
                listView3.Items.Add(doc);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            try
            {
                clase.Clases.Clear();
                profesor = (listView1.SelectedItems[0].SubItems[0].Text);
                clase.getClases(profesor);
                CargarDeposito2(clase.Clases);
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            clase.Alumnos.Clear();
            try
            {
                var clases = (listView2.SelectedItems[0].SubItems[0].Text);
                clase.getAlumnoForList(profesor, clases);
                CargarDeposito3(clase.Alumnos);
            }
            catch
            {

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            var mes = dateTimePicker1.Value.Month;
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);
            var claseParticular = (listView2.SelectedItems[0].SubItems[0].Text);
            string direccion = string.Empty;
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                direccion = folderBrowser.SelectedPath;
            }
            if (MessageBox.Show("Desea Imprimir la Lista de Alumnos de " + claseParticular +"del mes de "+ monthName + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string save = DateTime.Now.ToString("yyyy ")+ monthName+ " " + claseParticular;

                

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

                    //Titulos Grandes
                    xlRange.Cells[2, "A"] = "Profesor: " + profesor;
                    xlRange.Cells[2, "C"] = "Curso: " + claseParticular;
                    xlRange.Cells[1, "H"] = DateTime.Now.ToString("yyyy ")+ monthName;

                    //Titulos Lista
                    xlRange.Cells[4, "B"] = "Nombre y Apellido";
                    xlRange.Cells[4, "C"] = "Pago";



                    Dictionary<string, int> DiasDeCurso = clase.RetriveDays(profesor);

                    int firtOne = 32;
                    string First = string.Empty;
                    AllDayMinClass resp = new AllDayMinClass();
                    foreach (var dia in DiasDeCurso)
                    {
                        DayMinClase diaSpecific = new DayMinClase(dia.Key, dia.Value, dateTimePicker1.Value.Month);
                        resp.add(diaSpecific);
                    }
                    int start = 8;                
                    int cantDias = resp.getWholeDays();
                    while (resp.Any())
                    {
                        int amountBefore = start;
                        DayMinClase aux = resp.getMin();
                        start += aux.CantidadDeClasesPorDia;
                        foreach (var specificDay in aux.Dias)
                        {
                            xlRange.Cells[3, amountBefore] = aux.Day;
                            xlRange.Cells[4, amountBefore] = specificDay;                        
                            /*xlWorksheet.Range[xlWorksheet.Cells[4, (letter + amountBefore)], xlWorksheet.Cells[4, (letter + amountBefore + aux.CantidadDeClasesPorDia)]].Merge();
                            */
                            amountBefore += cantDias;
                        }
                    }

                    int countAlumnos = 1;
                    int place = countAlumnos + 4;

                    foreach (var alumno in clase.Alumnos)
                    {
                        xlRange.Cells[place, "A"] = countAlumnos.ToString();
                        xlRange.Cells[place, "B"] = alumno;
                        place++;
                        countAlumnos++;
                    }

                    xlRange.Cells[place + 5, "A"] = "Cantidad Total de Alumnos";
                    xlRange.Cells[place + 6, "A"] = "Firma del Profesor";

                    xlWorksheet.Range[xlWorksheet.Cells[4, "C"], xlWorksheet.Cells[4, "G"]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[place + 5, "A"], xlWorksheet.Cells[place + 5, "G"]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[place + 6, "C"], xlWorksheet.Cells[place + 6, "G"]].Merge();

                    xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[3, "B"]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[3, "G"]].Merge();


                    xlWorksheet.Columns[2].ColumnWidth = 20;
                    for (var i = 3; i < 35; i++)
                    {
                        if (i < 8)
                        {
                            xlWorksheet.Columns[i].ColumnWidth = 5;
                        }
                        else
                        {
                            xlWorksheet.Columns[i].ColumnWidth = 3.5;
                        }
                    }


                    /*
                    xlWorksheet.Range[xlWorksheet.Cells[place + 5, "A"], xlWorksheet.Cells[3, "G"]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[place + 6, "A"], xlWorksheet.Cells[3, "G"]].Merge();*/



                    /*xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[1, 8 + resp.getTotalDays()]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[1, 8 + resp.getTotalDays()]].Font.Bold = true;
                    xlWorksheet.Range[xlWorksheet.Cells[2, "C"], xlWorksheet.Cells[2, "G"]].Merge();

                    xlWorksheet.Range[xlWorksheet.Cells[2, "C"], xlWorksheet.Cells[2, "D"]].Merge();
                    xlWorksheet.Range[xlWorksheet.Cells[4, "A"], xlWorksheet.Cells[place + 6, resp.getTotalDays()]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                    xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[place + 6, resp.getTotalDays()]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                    */

                    xlWorkbook.SaveAs(direccion + "\\" + save + ".xlsx");
                    xlWorkbook.Close();
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);

                    /*
                    Count


                    //DIAS Y HORARIOS
                    if ()

                    xlRange.Cells[4, "B"] = "Nombre y Apellido";

                    int i = 4;
                    foreach (var alumno in clase.Alumnos)
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
                    Marshal.ReleaseComObject(xlApp);*/
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> DiasDeCurso = clase.RetriveDays(profesor);
            AllDayMinClass resp = new AllDayMinClass();
            foreach (var dia in DiasDeCurso)
            {
                DayMinClase diaSpecific = new DayMinClase(dia.Key, dia.Value, dateTimePicker1.Value.Month);
                MessageBox.Show(dia.Key);
                MessageBox.Show(dia.Value.ToString());
                
                resp.add(diaSpecific);
                foreach (var diar in resp.dias)
                {
                    foreach (var sarasas in diar.Dias)
                        MessageBox.Show(sarasas.ToString());
                }

            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Dictionary<string, int> DiasDeCurso = clase.RetriveDays(profesor);

            foreach(var dia in DiasDeCurso)
            {
                MessageBox.Show(dia.Key);
                MessageBox.Show(dia.Value.ToString());
            }
        }

        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var alumno = listView3.SelectedItems[0].SubItems[0].Text;
                if (MessageBox.Show("Abrir los Recibos de " + alumno + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string aux = string.Empty;
                    this.Hide();
                    //string name, string price, string teacher, string amount, string clasesTotal)
                    ComprobantesAlumnos frm3 = new ComprobantesAlumnos(alumno);
                    frm3.ShowDialog();
                    this.Show();
                }
            }
            catch
            {

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //HACER EL IMPRIME TODAS LAS LISTAS DE TODAS LAS CLASES 
        private void button3_Click_2(object sender, EventArgs e)
        {
            var mes = dateTimePicker1.Value.Month;
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes);

                string direccion = string.Empty;
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                DialogResult result = folderBrowser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    direccion = folderBrowser.SelectedPath;
                }
                if (MessageBox.Show("Desea Imprimir la Lista de Alumnos de Todas las Clases de " + monthName + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    foreach (var profesor in profesores)
                    {
                        Clase auxClase = new Clase();
                        auxClase.Profesor = profesor;
                        auxClase.getClases(profesor);
                        foreach (var clase in auxClase.Clases)
                        {
                            string save = DateTime.Now.ToString("yyyy ")+ monthName + " " + clase + " " + profesor;
                            auxClase.getAlumnoForList(profesor, clase);

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

                                //Titulos Grandes
                                xlRange.Cells[2, "A"] = "Profesor: " + profesor;
                                xlRange.Cells[2, "C"] = "Curso: " + clase;
                                xlRange.Cells[1, "H"] = DateTime.Now.ToString("yyyy ")+ monthName;

                                //Titulos Lista
                                xlRange.Cells[4, "B"] = "Nombre y Apellido";
                                xlRange.Cells[4, "C"] = "Pago";



                                Dictionary<string, int> DiasDeCurso = auxClase.RetriveDays(profesor);

                                string First = string.Empty;
                                AllDayMinClass resp = new AllDayMinClass();
                                foreach (var dia in DiasDeCurso)
                                {
                                    DayMinClase diaSpecific = new DayMinClase(dia.Key, dia.Value, dateTimePicker1.Value.Month);
                                    resp.add(diaSpecific);
                                }
                                int start = 8;
                                int cantDias = resp.getWholeDays();
                                while (resp.Any())
                                {
                                    int amountBefore = start;
                                    DayMinClase aux = resp.getMin();
                                    start += aux.CantidadDeClasesPorDia;
                                    foreach (var specificDay in aux.Dias)
                                    {
                                        xlRange.Cells[3, amountBefore] = aux.Day;
                                        xlRange.Cells[4, amountBefore] = specificDay;
                                        /*xlWorksheet.Range[xlWorksheet.Cells[4, (letter + amountBefore)], xlWorksheet.Cells[4, (letter + amountBefore + aux.CantidadDeClasesPorDia)]].Merge();
                                        */
                                        amountBefore += cantDias;
                                    }
                                }

                                int countAlumnos = 1;
                                int place = countAlumnos + 4;

                                foreach (var alumno in auxClase.Alumnos)
                                {
                                    xlRange.Cells[place, "A"] = countAlumnos.ToString();
                                    xlRange.Cells[place, "B"] = alumno;
                                    place++;
                                    countAlumnos++;
                                }

                                xlRange.Cells[place + 5, "A"] = "Cantidad Total de Alumnos";
                                xlRange.Cells[place + 6, "A"] = "Firma del Profesor";

                                xlWorksheet.Range[xlWorksheet.Cells[4, "C"], xlWorksheet.Cells[4, "G"]].Merge();
                                xlWorksheet.Range[xlWorksheet.Cells[place + 5, "A"], xlWorksheet.Cells[place + 5, "G"]].Merge();
                                xlWorksheet.Range[xlWorksheet.Cells[place + 6, "A"], xlWorksheet.Cells[place + 6, "G"]].Merge();

                            xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[3, "B"]].Merge();
                            xlWorksheet.Range[xlWorksheet.Cells[1, "C"], xlWorksheet.Cells[3, "G"]].Merge();


                            xlWorksheet.Columns[2].ColumnWidth = 20;
                            for (var i = 3; i < 35; i++)
                            {
                                if (i < 8)
                                {
                                    xlWorksheet.Columns[i].ColumnWidth = 5;
                                }
                                else
                                {
                                    xlWorksheet.Columns[i].ColumnWidth = 3.5;
                                }
                            }


                                

                                /*
                                xlWorksheet.Range[xlWorksheet.Cells[place + 5, "A"], xlWorksheet.Cells[3, "G"]].Merge();
                                xlWorksheet.Range[xlWorksheet.Cells[place + 6, "A"], xlWorksheet.Cells[3, "G"]].Merge();*/



                                /*xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[1, 8 + resp.getTotalDays()]].Merge();
                                xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[1, 8 + resp.getTotalDays()]].Font.Bold = true;
                                xlWorksheet.Range[xlWorksheet.Cells[2, "C"], xlWorksheet.Cells[2, "G"]].Merge();

                                xlWorksheet.Range[xlWorksheet.Cells[2, "C"], xlWorksheet.Cells[2, "D"]].Merge();
                                xlWorksheet.Range[xlWorksheet.Cells[4, "A"], xlWorksheet.Cells[place + 6, resp.getTotalDays()]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                                xlWorksheet.Range[xlWorksheet.Cells[1, "H"], xlWorksheet.Cells[place + 6, resp.getTotalDays()]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                                */

                                xlWorkbook.SaveAs(direccion + "\\" + save + ".xlsx");
                                xlWorkbook.Close();
                                xlApp.Quit();

                                Marshal.ReleaseComObject(xlWorksheet);
                                Marshal.ReleaseComObject(xlWorkbook);
                                Marshal.ReleaseComObject(xlApp);
                            }
                        }
                    }
                }           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Ver_Listas_Clases_Load(object sender, EventArgs e)
        {

        }
    }
}
