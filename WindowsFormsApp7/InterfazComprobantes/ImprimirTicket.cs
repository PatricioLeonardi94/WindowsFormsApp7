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
    public partial class ImprimirTicket : Form
    {
        bool IsForNext;
        DateTime lastDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 10);
        DateTime today = DateTime.Today;
        int Valor = 0;

        List <Clase> ClasesListFiniShed = new List<Clase>();
        List<Clase> ClasesListFiniShedAuxiliar = new List<Clase>();
        string name = String.Empty;
        Global Global = new Global();
        string fmt = "0000000.##";
        DatoExcel ClaseParaExcel = new DatoExcel();
        Usuario Usuario = new Usuario();
        string printer;
        Clase claseaux = new Clase();
        string SelectedPathTest = string.Empty;

        public ImprimirTicket()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        private void ImprimirTicket_Load(object sender, EventArgs e)
        {

        }


        public ImprimirTicket(List<Clase> ClasesList, string nombre, bool nexMonth)
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            Valor = DateTime.Compare(today, lastDay);
            
            ClasesListFiniShed = ClasesList;
            ClasesListFiniShedAuxiliar = ClasesList;
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("No Selecciono Persona");
            }
            name = nombre;
            label1.Text = nombre;
            IsForNext = nexMonth;

            ChangeTotalAfter10(Valor, nexMonth);
            

            FormGrid();
            CargarDeposito(ClasesList);
            label3.Text = getTotal(ClasesListFiniShed);
            SelectedPathTest = Global.getDireTest();
            
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            ClasesListFiniShed.Clear();
            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void FormGrid()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Profesor", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Cantidad por Mes", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Precio", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Cantidad", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Horario", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Total", 75, HorizontalAlignment.Left);

        }

        private void CargarDeposito(List<Clase> Clases)
        {
            foreach (var doc in Clases)
            {
                listView1.Items.Add(new MyOwnListViewItem(doc));
            }
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
                string aux = String.Empty;
                this.SubItems.Clear();
                this.Text = clase.Profesor; //for first detailed column

                this.SubItems.Add(new ListViewSubItem(this, clase.CantidadClases.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, clase.Precio.ToString()));//for second can be more
                this.SubItems.Add(new ListViewSubItem(this, clase.cantidadElegidos.ToString()));
                this.SubItems.Add(new ListViewSubItem(this, clase.ClasesTomar.ToString()));
                if ((clase.Horarios != null) && (clase.Horarios.Any()))
                {
                    foreach (var hola in clase.Horarios)
                    {
                        aux += hola;
                    }
                }               
                this.SubItems.Add(new ListViewSubItem(this, aux));
                this.SubItems.Add(new ListViewSubItem(this, clase.Total.ToString()));
            }
            /*
             *  public string Nombre { get; set; }
            public int PrecioPeso { get; set; }
            public int PrecioDolar { get; set; }
            public int Cantidad { get; set; }
            */
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {

            bool flag2 = true;
            bool flag = true;
            string descripcion = String.Empty;
            if (MessageBox.Show("Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                string carpeta = Global.getDire();
                printer = Global.getImpresora();
                // genera las carpetas a guardar
                string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
                string savedia = nombreExceldia + ".xlsx";
                string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
                string savemes = nombreExcelmes + ".xlsx";

                Clase claseaux2 = new Clase();
                var number = claseaux2.LastNumberServerRecibos();
                claseaux.IncrementServerRecibosNumber();
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");
                CreaTicket Ticket1 = new CreaTicket();
                //CREA EL PRIMER TICKET
               

                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda("Nro Comprobante: " + number.ToString(fmt));
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(name);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();

               
                foreach (var clase in ClasesListFiniShed)
                {
                    if (!(string.IsNullOrEmpty(clase.Diferencia_Comprobante_Numero)))
                    {
                        claseaux.Diferencia_Comprobante_Numero = clase.Diferencia_Comprobante_Numero;
                        flag2 = false;
                    }
                    else
                    {
                        claseaux.Diferencia_Comprobante_Numero = string.Empty;
                    }

                                      

                    makeRecipeByClase(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1, flag);

                    string resp = string.Empty;
                    if (IsForNext)
                    {
                        DateTime date = DateTime.Now;
                        DateTime aux = date.AddMonths(1);
                        if (!(aux.ToString("MMMM") == "enero"))
                        {
                            resp = aux.ToString("yyyy MMMM");
                        }
                        else
                        {
                            DateTime aux2 = aux.AddYears(1);
                            resp = aux2.ToString("yyyy MMMM");
                        }
                    }
                    else
                    {
                        resp = (DateTime.Now).ToString("yyyy MMMM");
                    }

                    clase.InsertMonthListRegular(resp, name);
                    claseaux.Profesor += clase.Profesor + " ";
                }
    
                Ticket1.TextoExtremos("Total", claseaux.Total);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Las clases abonadas vencen");
                Ticket1.TextoCentro("el dia " + creaTextoFinal());
                Ticket1.AgregaLinea(2);
                try
                {
                    Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                }
                catch { }
                Ticket1.CortaTicket();

                flag = false;

                //CREA EL PRIMER TICKET


                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda("Nro Comprobante: " + number.ToString(fmt));
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(name);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();

                foreach (var clase in ClasesListFiniShed)
                {
                    makeRecipeByClase(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1, flag);            
                }              
       
                Ticket1.TextoExtremos("Total", claseaux.Total);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Las clases abonadas vencen");
                Ticket1.TextoCentro("el dia " + creaTextoFinal());
                Ticket1.AgregaLinea(2);
                try
                {
                    string Usuarioaux = Usuario.getUsuarioActual();
                    claseaux.Usuario = Usuarioaux;
                    Ticket1.TextoIzquierda(UppercaseFirst(Usuarioaux));
                }
                catch { }
               
                Ticket1.CortaTicket();


                claseaux.CargaExcelDia(nombreExceldia, Global, savedia, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.CargaExcelMes(nombreExcelmes, Global, savemes, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.addComprobante(ClasesListFiniShed, name, number.ToString(fmt), DateTime.Now.ToString("dd/MM/yyyy"));
                if (flag2 == false)
                {
                    claseaux.addComprobanteDiferencia(number.ToString(fmt));
                }
                ClasesListFiniShed.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void makeRecipeByClase(Clase clase, string fecha, CreaTicket ticket, bool flag)
        {
            

            string carpeta = Global.getDire();
            string printer = Global.getImpresora();
            // genera las carpetas a guardar
            string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
            string savedia = nombreExceldia + ".xlsx";
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
            string savemes = nombreExcelmes + ".xlsx";
            string nombreExcelProfesor = @carpeta + "\\Liquidaciones\\" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MMMM") + clase.Profesor;
            string saveProfesor = nombreExcelProfesor + ".xlsx";

            var number = claseaux.LastNumberServerRecibos();

            /*if (flag == true)
            {
                claseaux.Descripcion += clase.Descripcion + ", ";
                claseaux.Profesor += clase.Profesor + ", ";
                claseaux.ClasesTomar += clase.ClasesTomar + ", ";
                claseaux.CantidadClases += clase.CantidadClases + ", ";
            }*/
               


            ticket.TextoIzquierda(clase.cantidadElegidos + "x");
            
            if(!(clase.Descripcion == "Generico"))
            {
                ticket.TextoIzquierda(clase.Descripcion);
            }
                       
            ticket.TextoIzquierda(clase.Profesor);
            if(clase.CantidadClases == "xClase")
            {
                clase.CantidadClases = "Clase";
            }
            ticket.TextoExtremos("Cantidad: " + clase.CantidadClases, clase.Precio);
            if ((clase.Horarios != null) && (clase.Horarios.Any()))
            {
                ticket.TextoIzquierda("Horario");
                foreach (var horario in clase.Horarios)
                {
                    ticket.TextoIzquierda(horario);
                }
            }
                       
            ticket.LineasTotales(); // imprime linea 

            //Recargo Luego del 10
            if (clase.tiene_recargo() == true)
            {            
                int recargo = Convert.ToInt32(clase.Total) - Convert.ToInt32(clase.Precio);
                ticket.TextoExtremos("Recargo Administrativo", recargo.ToString());
            }

            ticket.TextoExtremos("Importe", clase.Total);
            ticket.AgregaLinea(1);
     

           if(flag == true)
            {
                clase.CargarExcelProfesor(nombreExcelProfesor, Global, saveProfesor, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
            }
        }

        private string creaTextoFinal()
        {
            string respuesta = string.Empty;
            if (IsForNext == true)
            {
                DateTime aux = DateTime.Today;
                string mes = aux.AddMonths(1).ToString("MMMM");
                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                respuesta = DateTime.DaysInMonth(DateTime.Now.Year, aux.AddMonths(1).Month) + " de " + mes;
            }
            else
            {
                string mes = DateTime.Now.ToString("MMMM"); 
                mes = char.ToUpper(mes[0]) + mes.Substring(1);
                respuesta = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + " de " + mes;
            }
          
            return respuesta;
        }


        private string getTotal(List<Clase> clases)
        {
            int total = 0;
            foreach(var clase in clases)
            {
                total += Convert.ToInt32(clase.Total);
            }
            return total.ToString(); 
        }


        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Global.setImpresora(printDialog1.PrinterSettings.PrinterName);
                printer = (printDialog1.PrinterSettings.PrinterName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        static bool IsOpened(string wbook)
        {
            bool isOpened = true;
            Excel.Application exApp;
            exApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            try
            {
                exApp.Workbooks.get_Item(wbook);
            }
            catch (Exception)
            {
                isOpened = false;
            }
            return isOpened;
        }

        private void ChangeTotalAfter10(int valor, bool nexmonth)
        {
          
            int total = 0;
            int totalsin = 0;
            foreach(var clase in ClasesListFiniShed)
            {
                if ((clase.CantidadClases == "4xmes" || clase.CantidadClases == "6xmes" || clase.CantidadClases == "8xmes" || clase.CantidadClases == "paselibre") && valor > 0 && clase.EsDiferencia == false)
                {
                    var auxValor = (numberRound(Convert.ToInt32(Convert.ToDouble(clase.Total) * 1.1)));
                    if(nexmonth == false)
                    {
                        clase.Total = auxValor.ToString();
                    }

                    clase.change_recargo();
                   
                    total += auxValor;
                    totalsin += Convert.ToInt32(clase.Total);
                }
                else
                {
                    total += Convert.ToInt32(clase.Total);
                    totalsin += Convert.ToInt32(clase.Total);
                }

                if (clase.Profesor == "Yoga para Niños")
                {
                    clase.Profesor = "Profesora Susana Piccolo";
                    if (clase.CantidadClases == "xClase")
                    {
                        clase.CantidadClases = "Clase de Prueba";
                    }
                    else
                    {
                        clase.CantidadClases = "Mensual";
                    }

                }
            }

            if (valor > 0 && IsForNext == false)
            {
                label3.Text = total.ToString();
                claseaux.Total = total.ToString();
                claseaux.Precio = total.ToString();

            }
            else
            {
                label3.Text = totalsin.ToString();
                claseaux.Total = totalsin.ToString();
                claseaux.Precio = totalsin.ToString();

            }
         
        }


        //Updating change after 10 to better performance

        private void ChangeTotalAfter10_2(int valor, bool nexmonth)
        {
            int totalClase = 0;
            foreach (var clase in ClasesListFiniShed)
            {
                if ((clase.CantidadClases == "4xmes" || clase.CantidadClases == "6xmes" || clase.CantidadClases == "8xmes" || clase.CantidadClases == "paselibre") && valor > 0 && nexmonth == false)
                {
                    var auxValor = (numberRound(Convert.ToInt32(Convert.ToDouble(clase.Total) * 1.1)));
 
                    clase.Total = auxValor.ToString();
                    
                    clase.change_recargo();
                }

                if (clase.Profesor == "Yoga para Niños")
                {
                    clase.Profesor = "Profesora Susana Piccolo";
                    if (clase.CantidadClases == "xClase")
                    {
                        clase.CantidadClases = "Clase de Prueba";
                    }
                    else
                    {
                        clase.CantidadClases = "Mensual";
                    }
    
                }
               
                totalClase += Convert.ToInt32(clase.Total);
            }
            claseaux.Precio = totalClase.ToString();
            claseaux.Total = totalClase.ToString();
            label3.Text = totalClase.ToString();
        }

        int numberRound(int value)
        {
            int resp = 0;
            for (var i = value; i >= 10; i = i - 10)
            {
                resp = resp + 10;
            }
            return resp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(System.Environment.MachineName);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            string carpeta = Global.getDire();
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
            string savemes = nombreExcelmes + ".xlsx";


            var number = ClaseParaExcel.LastNumber(nombreExcelmes, savemes);

            MessageBox.Show(number.ToString(fmt));
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            MessageBox.Show(Global.getImpresora());
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            foreach (var clase in ClasesListFiniShed)
            {
                if (!(clase.Horarios.Any()))
                {
                    clase.Horarios.Add("No posee Horario");
                    MessageBox.Show("no posee hroario");
                    MessageBox.Show(clase.Horarios.First());
                }
            }
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            foreach(var clase in ClasesListFiniShed)
            {
                if ((clase.Horarios != null) && (!clase.Horarios.Any()))
                {
                    MessageBox.Show("tiene clase");
                }
                else
                {
                    MessageBox.Show("no tiene clase");
                }
            }
            
        }

        private void button1_Click_7(object sender, EventArgs e)
        {
            string carpeta = Global.getDire();
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
            string savemes = nombreExcelmes + ".xlsx";


            var number = ClaseParaExcel.LastNumber(nombreExcelmes, savemes);
            MessageBox.Show(number.ToString());
        }

        private void button1_Click_8(object sender, EventArgs e)
        {
            foreach(var alumno in ClasesListFiniShedAuxiliar)
            {
                MessageBox.Show(alumno.Profesor);
            }
            /*
            string descripcion = String.Empty;
            if (MessageBox.Show("Desea Re Imprimir el ultimo comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                string carpeta = Global.getDire();
                printer = Global.getImpresora();
                // genera las carpetas a guardar
                string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
                string savedia = nombreExceldia + ".xlsx";
                string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
                string savemes = nombreExcelmes + ".xlsx";


                var number = ClaseParaExcel.LastNumber(nombreExcelmes, savemes);
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");
                CreaTicket Ticket1 = new CreaTicket();
                //CREA EL PRIMER TICKET


                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda("Nro Comprobante: " + number.ToString(fmt));
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(name);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();

                foreach (var clase in ClasesListFiniShedAuxiliar)
                {


                    makeRecipeByClase(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1);

                    string resp = string.Empty;
                    if (checkBox2.Checked)
                    {
                        DateTime date = DateTime.Now;
                        DateTime aux = date.AddMonths(1);
                        if (!(aux.ToString("MMMM") == "enero"))
                        {
                            resp = aux.ToString("yyyy MMMM");
                        }
                        else
                        {
                            DateTime aux2 = aux.AddYears(1);
                            resp = aux2.ToString("yyyy MMMM");
                        }
                    }
                    else
                    {
                        resp = (DateTime.Now).ToString("yyyy MMMM");
                    }

                    clase.InsertMonthListRegular(resp, name);

                }
                claseaux.Total = getTotal(ClasesListFiniShedAuxiliar);
                claseaux.Precio += getTotal(ClasesListFiniShedAuxiliar);
                if (checkBox1.Checked)
                {
                    claseaux.Total = (Convert.ToInt32(claseaux.Total) * 1.1).ToString();
                }
                Ticket1.TextoExtremos("Total", claseaux.Total);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Las clases abonadas vencen");
                Ticket1.TextoCentro("el dia " + creaTextoFinal());
                Ticket1.AgregaLinea(2);
                Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                Ticket1.CortaTicket();


                claseaux.CargaExcelDia(nombreExceldia, Global, savedia, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.CargaExcelMes(nombreExcelmes, Global, savemes, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.addComprobante(name, number.ToString(fmt), DateTime.Now.ToString("dd/MM/yyyy"));
                ClasesListFiniShedAuxiliar.Clear();
                this.DialogResult = DialogResult.OK;
            }*/
        }

        private void button1_Click_9(object sender, EventArgs e)
        {
            Clase clase = new Clase();
            clase.IncrementServerRecibosNumber();
            var anser = clase.LastNumberServerRecibos();
            MessageBox.Show(anser.ToString());
        }

        private void button1_Click_10(object sender, EventArgs e)
        {
            var number = claseaux.LastNumberServerRecibos();

            MessageBox.Show(number.ToString(fmt));

        }

        private void button1_Click_11(object sender, EventArgs e)
        {
            MessageBox.Show(Global.getImpresora());
        }

        private void button1_Click_12(object sender, EventArgs e)
        {
            bool flag = true;
            bool flag2 = true;

            string descripcion = String.Empty;
            if (MessageBox.Show("Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                string carpeta = Global.getDire();
                printer = Global.getImpresora();
                // genera las carpetas a guardar
                string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
                string savedia = nombreExceldia + ".xlsx";
                string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
                string savemes = nombreExcelmes + ".xlsx";


                Clase claseaux2 = new Clase();
                var number = claseaux2.LastNumberServerRecibos();
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");
                CreaTicket Ticket1 = new CreaTicket();
                //CREA EL PRIMER TICKET


                string Usuarioaux = Usuario.getUsuarioActual();
                claseaux.Usuario = Usuarioaux;


                foreach (var clase in ClasesListFiniShed)
                {
                    if (!(string.IsNullOrEmpty(clase.Diferencia_Comprobante_Numero)))
                    {
                        claseaux.Diferencia_Comprobante_Numero = clase.Diferencia_Comprobante_Numero;
                        flag2 = false;
                    }
                    else
                    {
                        claseaux.Diferencia_Comprobante_Numero = string.Empty;
                    }

                    makeRecipeByClaseAux(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1, flag);

                    string resp = string.Empty;
                    if (IsForNext)
                    {
                        DateTime date = DateTime.Now;
                        DateTime aux = date.AddMonths(1);
                        if (!(aux.ToString("MMMM") == "enero"))
                        {
                            resp = aux.ToString("yyyy MMMM");
                        }
                        else
                        {
                            DateTime aux2 = aux.AddYears(1);
                            resp = aux2.ToString("yyyy MMMM");
                        }
                    }
                    else
                    {
                        resp = (DateTime.Now).ToString("yyyy MMMM");
                    }

                    clase.InsertMonthListRegular(resp, name);

                }
               


                claseaux.CargaExcelDia(nombreExceldia, Global, savedia, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.CargaExcelMes(nombreExcelmes, Global, savemes, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.addComprobante(ClasesListFiniShed, name, number.ToString(fmt), DateTime.Now.ToString("dd/MM/yyyy"));
                if (flag2 == false)
                {
                    claseaux.addComprobanteDiferencia(number.ToString(fmt));
                }
                claseaux.IncrementServerRecibosNumber();
                ClasesListFiniShed.Clear();
                this.DialogResult = DialogResult.OK;
                //string name, string price, string teacher, string amount, string clasesTotal)
                /*
                Form1 frm4 = new Form1();
                frm4.Show();*/
            }
        }



        private void makeRecipeByClaseAux(Clase clase, string fecha, CreaTicket ticket, bool flag)
        {
            string carpeta = Global.getDire();
            string printer = Global.getImpresora();
            // genera las carpetas a guardar
            string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
            string savedia = nombreExceldia + ".xlsx";
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
            string savemes = nombreExcelmes + ".xlsx";
            string nombreExcelProfesor = @carpeta + "\\Liquidaciones\\" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MMMM") + clase.Profesor;
            string saveProfesor = nombreExcelProfesor + ".xlsx";

            var number = claseaux.LastNumberServerRecibos();

            /*if (flag == true)
            {
                claseaux.Descripcion += clase.Descripcion + ", ";
                claseaux.Profesor += clase.Profesor + ", ";
                claseaux.ClasesTomar += clase.ClasesTomar + ", ";
                claseaux.CantidadClases += clase.CantidadClases + ", ";
            }*/

            if (clase.CantidadClases == "xClase")
            {
                clase.CantidadClases = "Clase";
            }
            /*
            if ((clase.Horarios != null) && (clase.Horarios.Any()))
            {
                ticket.TextoIzquierda("Horario");
                foreach (var horario in clase.Horarios)
                {
                    ticket.TextoIzquierda(horario);
                }
            }*/

            if (flag == true)
            {
                clase.CargarExcelProfesor(nombreExcelProfesor, Global, saveProfesor, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                Global.setDireTest(folderBrowser.SelectedPath);
                string aux = folderBrowser.SelectedPath + "\\Diario\\";
                string aux1 = folderBrowser.SelectedPath + "\\Mensual\\";
                string aux2 = folderBrowser.SelectedPath + "\\Liquidaciones\\";
                string aux3 = folderBrowser.SelectedPath + "\\LiquidacionesLibros\\";
                Directory.CreateDirectory(aux);
                Directory.CreateDirectory(aux1);
                Directory.CreateDirectory(aux2);
                Directory.CreateDirectory(aux3);
            }

            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void makeRecipeByClaseAux2(Clase clase, string fecha, CreaTicket ticket, bool flag)
        {
            string carpeta = Global.getDire();
            string printer = Global.getImpresora();
            // genera las carpetas a guardar
            string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd") + "Test";
            string savedia = nombreExceldia + ".xlsx";
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM") + "Test";
            string savemes = nombreExcelmes + ".xlsx";
            string nombreExcelProfesor = @carpeta + "\\Liquidaciones\\" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MMMM") + clase.Profesor + "Test";
            string saveProfesor = nombreExcelProfesor + ".xlsx";

            var number = claseaux.LastNumberServerRecibos();

            if (flag == true)
            {
                claseaux.Descripcion += clase.Descripcion + ", ";
                claseaux.Profesor += clase.Profesor + ", ";
                claseaux.ClasesTomar += clase.ClasesTomar + ", ";
                claseaux.CantidadClases += clase.CantidadClases + ", ";
            }

            if (clase.CantidadClases == "xClase")
            {
                clase.CantidadClases = "Clase";
            }
            
            if ((clase.Horarios != null) && (clase.Horarios.Any()))
            {
                ticket.TextoIzquierda("Horario");
                foreach (var horario in clase.Horarios)
                {
                    ticket.TextoIzquierda(horario);
                }
            }


            if (flag == true)
            {
                clase.CargarExcelProfesor(nombreExcelProfesor, Global, saveProfesor, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string descripcion = String.Empty;
            if (MessageBox.Show("Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                string carpeta = Global.getDireTest();
                printer = Global.getImpresora();
                // genera las carpetas a guardar
                string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd") + "Test";
                string savedia = nombreExceldia + ".xlsx";
                string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM") + "Test";
                string savemes = nombreExcelmes + ".xlsx";

                Clase claseaux2 = new Clase();
                var number = claseaux2.LastNumberServerRecibos();
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");
                CreaTicket Ticket1 = new CreaTicket();
                //CREA EL PRIMER TICKET


                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda("Nro Comprobante: " + number.ToString(fmt));
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(name);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();

                foreach (var clase in ClasesListFiniShed)
                {


                    makeRecipeByClaseAux(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1, flag);

                    string resp = string.Empty;
                    if (IsForNext)
                    {
                        DateTime date = DateTime.Now;
                        DateTime aux = date.AddMonths(1);
                        if (!(aux.ToString("MMMM") == "enero"))
                        {
                            resp = aux.ToString("yyyy MMMM");
                        }
                        else
                        {
                            DateTime aux2 = aux.AddYears(1);
                            resp = aux2.ToString("yyyy MMMM");
                        }
                    }
                    else
                    {
                        resp = (DateTime.Now).ToString("yyyy MMMM");
                    }

                    clase.InsertMonthListRegular(resp, name);

                }
                claseaux.Total = getTotal(ClasesListFiniShed);
                claseaux.Precio += getTotal(ClasesListFiniShed);
               
                Ticket1.TextoExtremos("Total", claseaux.Total);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Las clases abonadas vencen");
                Ticket1.TextoCentro("el dia " + creaTextoFinal());
                Ticket1.AgregaLinea(2);
                Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                Ticket1.CortaTicket();

                flag = false;

                claseaux.CargaExcelDia(nombreExceldia, Global, savedia, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.CargaExcelMes(nombreExcelmes, Global, savemes, DateTime.Now.ToString("dd/MM/yyyy"), number.ToString(fmt), name);
                claseaux.addComprobante(ClasesListFiniShed, name, number.ToString(fmt), DateTime.Now.ToString("dd/MM/yyyy"));
                claseaux.IncrementServerRecibosNumber();
                ClasesListFiniShed.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        
       /* private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(name);
            foreach(var clase in ClasesListFiniShed)
            {
                MessageBox.Show(clase.Profesor);
            }
        }*/

        private void button3_Click_2(object sender, EventArgs e)
        {
            Usuario aux = new Usuario();
            
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            MessageBox.Show(Usuario.getUsuarioActual());
        }

        private void button3_Click_5(object sender, EventArgs e)
        {
            bool flag2 = true;
            bool flag = true;
            string descripcion = String.Empty;
            if (MessageBox.Show("Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string carpeta = Global.getDire();
                printer = Global.getImpresora();
                // genera las carpetas a guardar
                string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
                string savedia = nombreExceldia + ".xlsx";
                string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
                string savemes = nombreExcelmes + ".xlsx";

                Clase claseaux2 = new Clase();
                var number = claseaux2.LastNumberServerRecibos();
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");
                CreaTicket Ticket1 = new CreaTicket();
                //CREA EL PRIMER TICKET


                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(name);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();


                foreach (var clase in ClasesListFiniShed)
                {
                    if (!(string.IsNullOrEmpty(clase.Diferencia_Comprobante_Numero)))
                    {
                        claseaux.Diferencia_Comprobante_Numero = clase.Diferencia_Comprobante_Numero;
                        flag2 = false;
                    }
                    else
                    {
                        claseaux.Diferencia_Comprobante_Numero = string.Empty;
                    }



                    AuxMakeRec(clase, dateTimePicker1.Value.ToString("yyyy/MM/dd"), Ticket1, flag);

                    

                }

                Ticket1.TextoExtremos("Total", claseaux.Total);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Las clases abonadas vencen");
                Ticket1.TextoCentro("el dia " + creaTextoFinal());
                Ticket1.AgregaLinea(2);
                try
                {
                    Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                }
                catch { }
                Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                Ticket1.CortaTicket();

                flag = false;

            }
        }

        private void AuxMakeRec(Clase clase, string fecha, CreaTicket ticket, bool flag)
        {


            string carpeta = Global.getDire();
            string printer = Global.getImpresora();
            // genera las carpetas a guardar
            string nombreExceldia = @carpeta + "\\Diario\\" + dateTimePicker1.Value.ToString("yyyyMMdd");
            string savedia = nombreExceldia + ".xlsx";
            string nombreExcelmes = @carpeta + "\\Mensual\\" + dateTimePicker1.Value.ToString("yyyyMMMM");
            string savemes = nombreExcelmes + ".xlsx";
            string nombreExcelProfesor = @carpeta + "\\Liquidaciones\\" + DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MMMM") + clase.Profesor;
            string saveProfesor = nombreExcelProfesor + ".xlsx";

            /*if (flag == true)
            {
                claseaux.Descripcion += clase.Descripcion + ", ";
                claseaux.Profesor += clase.Profesor + ", ";
                claseaux.ClasesTomar += clase.ClasesTomar + ", ";
                claseaux.CantidadClases += clase.CantidadClases + ", ";
            }*/
        


        ticket.TextoIzquierda(clase.cantidadElegidos + "x");

        if (!(clase.Descripcion == "Generico"))
        {
            ticket.TextoIzquierda(clase.Descripcion);
        }

        ticket.TextoIzquierda(clase.Profesor);
        if (clase.CantidadClases == "xClase")
        {
            clase.CantidadClases = "Clase";
        }
        ticket.TextoExtremos("Cantidad: " + clase.CantidadClases, clase.Precio);
        if ((clase.Horarios != null) && (clase.Horarios.Any()))
        {
            ticket.TextoIzquierda("Horario");
            foreach (var horario in clase.Horarios)
            {
                ticket.TextoIzquierda(horario);
            }
        }

        ticket.LineasTotales(); // imprime linea 

            if (clase.tiene_recargo() == true)
            {
                int recargo = Convert.ToInt32(clase.Total) - Convert.ToInt32(clase.Precio);
                ticket.TextoExtremos("Recargo Administrativo", recargo.ToString());
            }

            ticket.TextoExtremos("Importe", clase.Total);
        ticket.AgregaLinea(1);

    }

       
    }
}

