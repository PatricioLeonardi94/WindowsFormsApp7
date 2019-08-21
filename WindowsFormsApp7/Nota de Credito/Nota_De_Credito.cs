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
    public partial class Nota_De_Credito : Form
    {
        MinComprobante Comprobante = new MinComprobante();

        public Nota_De_Credito(MinComprobante compr)
        {
            InitializeComponent();
            Comprobante = compr;
            InitializeListView();
        }



        private void Nota_De_Credito_Load(object sender, EventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Comprobantemin auxComprobantemin = (Comprobantemin)objectListView1.CheckedObject;
                Clase auxClase = auxComprobantemin.trasforToClase();
                auxClase.Descripcion = "Nota de Credito Recibo Numero: " + Comprobante.NumeroComprobante;
                auxClase.Total = "-" + textBox1.Text;
                auxClase.Precio = "-" + textBox1.Text;
                auxClase.CantidadClases = "Nota de Credito Recibo Numero: " + Comprobante.NumeroComprobante;
                List<Clase> listToSend = new List<Clase>();
                listToSend.Add(auxClase);

                this.Hide();
                //string name, string price, string teacher, string amount, string clasesTotal)
                ImprimirTicket frm3 = new ImprimirTicket(listToSend, Comprobante.Nombre, false);
                frm3.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("No selecciono la clase");
            }
        }


        private void InitializeListView()
        {
            this.objectListView1.SetObjects(Comprobante.comprobantes);
        }

        private void objectListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
