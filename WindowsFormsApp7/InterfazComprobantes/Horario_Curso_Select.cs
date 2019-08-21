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
    public partial class Horario_Curso_Select : Form
    {
        List<string> Horarios = new List<string>();
        public List<string> HorarioSelect = new List<string>();

        public Horario_Curso_Select(List<string> recibeHorarios)
        {
            InitializeComponent();
            this.Horarios = recibeHorarios;
            FirstLoad();
        }

        private void Horario_Curso_Select_Load(object sender, EventArgs e)
        {
            
        }

        private void FirstLoad()
        {
            foreach (var horario in this.Horarios)
            {
                checkedListBox1.Items.Add(horario);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aux = checkedListBox1.CheckedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString());
            if (string.IsNullOrEmpty(aux))
            {
                MessageBox.Show("Debe Seleccionar una opcion");
            }
            else
            {
                this.HorarioSelect.Add(aux);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);
        }
    }
}
