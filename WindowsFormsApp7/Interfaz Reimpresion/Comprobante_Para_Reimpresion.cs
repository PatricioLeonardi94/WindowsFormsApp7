using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Comprobante_Para_Reimpresion : Form
    {
        List<Clase> ClasesList = new List<Clase>();
        Clase AuxClase = new Clase();

        MinComprobante comprobante = new MinComprobante();
        Global Global = new Global();
        Usuario Usuario = new Usuario();

        MinComprobante aux = new MinComprobante();

        string Numero_Comprobante = string.Empty;

        public Comprobante_Para_Reimpresion()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        public Comprobante_Para_Reimpresion(MinComprobante compr)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            this.comprobante = compr;
            label1.Text = compr.Nombre;
            label2.Text = compr.Fecha;
            Numero_Comprobante = compr.NumeroComprobante;
            label3.Text = "N°: " + compr.NumeroComprobante;
            label5.Text = compr.getTotal();
            InitializeListView();

            if (string.IsNullOrWhiteSpace(this.comprobante.Diferencia_Comprobante_Numero))
            {
                label6.Text = null;
            }
            else
            {
                label6.Text = "Posee Diferencia N°:" +this.comprobante.Diferencia_Comprobante_Numero;
            }
        }

        private void Comprobante_Para_Reimpresion_Load(object sender, EventArgs e)
        {

        }

        private void reimprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Re Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CreaTicket Ticket1 = new CreaTicket();

                string printer = Global.getImpresora();
                string fecha = "Fecha " + DateTime.Today.ToString("d");
                string hora = "Hora " + DateTime.Now.ToString("HH:mm");

                Ticket1.impresora = printer;
                Ticket1.AgregaLinea(2);
                Ticket1.TextoExtremos(fecha, hora);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda("Nro Comprobante: " + comprobante.NumeroComprobante);
                Ticket1.AgregaLinea(1);
                Ticket1.TextoIzquierda(comprobante.Nombre);
                Ticket1.AgregaLinea(1);
                Ticket1.LineasGuion();
                foreach(var clase in comprobante.comprobantes)
                {
                    Ticket1.TextoIzquierda(clase.cantidadElegidos + "x");

                    Ticket1.TextoIzquierda(clase.Descripcion);



                    Ticket1.TextoIzquierda(clase.Profesor);
                    if (clase.CantidadClases == "xClase")
                    {
                        clase.CantidadClases = "Clase";
                    }
                    Ticket1.TextoExtremos("Cantidad: " + clase.CantidadClases, clase.Precio);

                    Ticket1.LineasTotales(); // imprime linea 


                    if (clase.Total == clase.Precio)
                    {
                        int recargo = Convert.ToInt32(clase.Total) - Convert.ToInt32(clase.Precio);
                        Ticket1.TextoExtremos("Recargo Administrativo", recargo.ToString());
                    }

                    Ticket1.TextoExtremos("Importe", clase.Total);
                }


                Ticket1.TextoExtremos("Total", comprobante.getTotal());
                Ticket1.AgregaLinea(1);
                Ticket1.LineasAsterisco();
                Ticket1.AgregaLinea(2);
                Ticket1.TextoCentro("Comprobante Emitido el dia");
                Ticket1.TextoCentro(comprobante.Fecha);
                Ticket1.AgregaLinea(2);
                Ticket1.TextoIzquierda(UppercaseFirst(Usuario.getUsuarioActual()));
                Ticket1.CortaTicket();


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

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeListView()
        {
            this.objectListView1.SetObjects(comprobante.comprobantes);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comprobantemin auxClase = (Comprobantemin)objectListView1.CheckedObject;
            MinComprobante resp = new MinComprobante();
            resp = this.comprobante;
            resp.Diferencia_Comprobante_Numero = Numero_Comprobante;
            resp.comprobantes.Clear();
            resp.comprobantes.Add(auxClase);

            if(auxClase == null)
            {
                MessageBox.Show("No Selecciono una clase para generar la diferencia");
            }
            else
            {
                this.Hide();
                //string name, string price, string teacher, string amount, string clasesTotal)
                Diferencia_Recibos frm3 = new Diferencia_Recibos(resp, comprobante.Nombre);
                frm3.ShowDialog();
                this.Show();
            }  
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            MinComprobante comprobante = new MinComprobante();

            if (MessageBox.Show("Abrir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                comprobante.Nombre = label1.Text;
                comprobante.NumeroComprobante = this.comprobante.Diferencia_Comprobante_Numero;
                comprobante.retriveComprobante();
                this.Hide();
                //string name, string price, string teacher, string amount, string clasesTotal)
                Comprobante_Para_Reimpresion frm3 = new Comprobante_Para_Reimpresion(comprobante);
                frm3.ShowDialog();
                this.Show();
            }
        }

        private void nota_de_credito_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Contraseña_Nota_De_Credito frm3 = new Contraseña_Nota_De_Credito(this.comprobante);
            frm3.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)
            Confirmar_Cancelar_Comprobante frm3 = new Confirmar_Cancelar_Comprobante(this.comprobante);
            frm3.ShowDialog();
            this.Show();
        }
    }
}
