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


namespace WindowsFormsApp7
{
    public partial class ComprobanteServerParciales : Form
    {
        ComprobanteAlumno comprobante = new ComprobanteAlumno();
        public ComprobanteServerParciales(string name, string number)
        {
            this.BackgroundImage = Properties.Resources.the_iconic_big_golden;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
            InitializeComponent();
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
