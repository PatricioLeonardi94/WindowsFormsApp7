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
    public partial class EditarProfesor : Form
    {
        private Profesores all_Profesores = new Profesores();

        public EditarProfesor()
        {
            this.BackgroundImage = Properties.Resources.templo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
            FirstLoad();
        }

        private void EditarProfesor_Load(object sender, EventArgs e)
        {

        }

        //primer funcion para traer las clases y los profesores
        private void FirstLoad()
        {
            foreach(var profesor in all_Profesores.profesores.Keys)
            {
                comboBox1.Items.Add(profesor);
            }
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dictionary<string, string> specs = new Dictionary<string, string>();
                var profeName = comboBox1.Text;
                Profesor pre_profesor = all_Profesores.profesores[profeName];
                if(pre_profesor.xClase != textBox1.Text)
                {
                    specs["xClase"] = textBox1.Text;
                }
                if (pre_profesor.cuatroxmes != textBox2.Text)
                {
                    specs["4xmes"] = textBox2.Text;
                }
                if (pre_profesor.seisxmes != textBox3.Text)
                {
                    specs["6xmes"] = textBox3.Text;
                }
                if (pre_profesor.ochoxmes != textBox4.Text)
                {
                    specs["8xmes"] = textBox4.Text;
                }
                if (pre_profesor.paselibre != textBox5.Text)
                {
                    specs["paselibre"] = textBox5.Text;
                }
                if (pre_profesor.porcentaje != textBox6.Text)
                {
                    specs["porcentaje"] = textBox6.Text;
                }

                if (specs.Count != 0)
                {
                    pre_profesor.modificar_profesor(specs);
                }

                MessageBox.Show("Se realizo el cambio");
            }
        }

            private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                Profesor auxProfesor = all_Profesores.profesores[comboBox1.Text];
                textBox1.Text = auxProfesor.xClase;
                textBox2.Text = auxProfesor.cuatroxmes;
                textBox3.Text = auxProfesor.seisxmes;
                textBox4.Text = auxProfesor.ochoxmes;
                textBox5.Text = auxProfesor.paselibre;
                textBox6.Text = auxProfesor.porcentaje;
                auxProfesor.clases.ForEach(p => checkedListBox1.Items.Add(p));          
            }
            catch
            {

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //clase
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //4 clase
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //6 clase
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //8 clase
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //paselibre
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //porcentaje
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //revisar que no funciona
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var profeName = comboBox1.Text;
                    var clase_seleccionada = checkedListBox1.SelectedItem.ToString();
                    Profesor pre_profesor = all_Profesores.profesores[profeName];
                    pre_profesor.clases.Remove(clase_seleccionada);
                    pre_profesor.modify_clases(pre_profesor.clases);
                }
                catch
                {

                }
            }
        }

        //agregar clases
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //string name, string price, string teacher, string amount, string clasesTotal)

            this.Show();             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Agregar al Profesor " + comboBox1.Text + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var profeName = comboBox1.Text;
                Profesor pre_profesor = new Profesor();
                pre_profesor.name = "Profesor " + profeName;
                pre_profesor.xClase = textBox1.Text;
                pre_profesor.cuatroxmes = textBox2.Text;
                pre_profesor.seisxmes = textBox3.Text;
                pre_profesor.ochoxmes = textBox4.Text;
                pre_profesor.paselibre = textBox5.Text;

                pre_profesor.agregar_profesor();


                MessageBox.Show("Se realizo el cambio");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
