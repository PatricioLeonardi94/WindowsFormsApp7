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
using System.Drawing.Printing;
using Humanizer;

namespace WindowsFormsApp7
{
    public partial class Horarios : Form
    {
        Clase clase = new Clase();
        List<string> horarios = new List<string>();
        string diaParticular = String.Empty;
        string horaParticular = String.Empty;
        List<string> horariosTodos = new List<string>();

        public Horarios()
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        }

        public Horarios(Clase clases)
        {
            this.BackgroundImage = Properties.Resources.templo3;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            clase = clases;
            fillListbox1();
        }

        private void Horarios_Load(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            clase.Horarios = horariosTodos;
            this.DialogResult = DialogResult.OK;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            diaParticular = checkedListBox1.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            horaParticular = checkedListBox2.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            string ArmadoHorario = diaParticular + " de " + horaParticular;
            horariosTodos.Add(ArmadoHorario);
            listView1.Clear();
            FormGrid();
            CargarDeposito(horariosTodos);
            UncheckAll();
            checkedListBox2.Items.Clear();
        }

        public void FormGrid()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Dia y Horario", 350, HorizontalAlignment.Left);
        }

        private void CargarDeposito(List<string> horarios)
        {
            foreach (var doc in horarios)
            {
                listView1.Items.Add(new MyOwnListViewItem(doc));
            }
        }

        public class MyOwnListViewItem : ListViewItem
        {
            private string clase;

            public MyOwnListViewItem(string horas)
            {
                this.clase = horas;
                Update();
            }

            public void Update()
            {
                this.SubItems.Clear();
                this.Text = clase; //for first detailed column

                
            }
        }


        private void Remover_Click(object sender, EventArgs e)
        {
            if (horariosTodos.Any()) //prevent IndexOutOfRangeException for empty list
            {
                horariosTodos.RemoveAt(horariosTodos.Count - 1);
            }

            listView1.Clear();
            FormGrid();
            CargarDeposito(horariosTodos);
            UncheckAll();
        }

        private void fillListbox1()
        {
            HashSet<string> keys = clase.getKeysDays(clase.ClasesTomar);
            foreach(var dia in keys)
            {
                checkedListBox1.Items.Add(dia);
            }

        }

    
        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void UncheckAll()
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in checkedListBox2.CheckedIndices)
            {
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);

            checkedListBox2.Items.Clear();
            string horarioParticular = checkedListBox1.SelectedItem.ToString();
            HashSet<string> keys = clase.getKeysHorarios(horarioParticular);
            foreach (var horario in keys)
            {
                checkedListBox2.Items.Add(horario);
            }
        }
    }
}
