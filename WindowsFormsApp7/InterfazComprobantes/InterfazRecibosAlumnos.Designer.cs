namespace WindowsFormsApp7
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AgregarComprobantes = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.NumeroComprobante = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Fecha = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Nombre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.objectListView2 = new BrightIdeasSoftware.ObjectListView();
            this.Telefono = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Mail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.eliminaultimo = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(37, 39);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(317, 354);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck_1);
            this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.SizeChanged += new System.EventHandler(this.checkedListBox1_SizeChanged);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "xClase",
            "4xmes",
            "6xmes",
            "8xmes",
            "paselibre"});
            this.checkedListBox2.Location = new System.Drawing.Point(407, 39);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(140, 354);
            this.checkedListBox2.TabIndex = 1;
            this.checkedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox2_ItemCheck);
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(93, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 55);
            this.button2.TabIndex = 6;
            this.button2.Text = "Confirmar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 26);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre de Persona";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 41);
            this.button3.TabIndex = 12;
            this.button3.Text = "Añadir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Cerrar
            // 
            this.Cerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cerrar.Location = new System.Drawing.Point(1589, 27);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(153, 52);
            this.Cerrar.TabIndex = 17;
            this.Cerrar.Text = "Volver";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(478, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 52);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cursos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AgregarComprobantes
            // 
            this.AgregarComprobantes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgregarComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarComprobantes.Location = new System.Drawing.Point(19, 46);
            this.AgregarComprobantes.Name = "AgregarComprobantes";
            this.AgregarComprobantes.Size = new System.Drawing.Size(110, 107);
            this.AgregarComprobantes.TabIndex = 21;
            this.AgregarComprobantes.Text = "Agregar";
            this.AgregarComprobantes.UseVisualStyleBackColor = true;
            this.AgregarComprobantes.Click += new System.EventHandler(this.AgregarComprobantes_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.NumeroComprobante);
            this.objectListView1.AllColumns.Add(this.Fecha);
            this.objectListView1.AllColumns.Add(this.Nombre);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NumeroComprobante,
            this.Fecha,
            this.Nombre});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(3, 26);
            this.objectListView1.MenuLabelSortAscending = "Sort descending by \'{0}\'";
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(955, 191);
            this.objectListView1.TabIndex = 26;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objectListView1_CellClick);
            this.objectListView1.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.objectListView1_CellToolTipShowing);
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // NumeroComprobante
            // 
            this.NumeroComprobante.AspectName = "NumeroComprobante";
            this.NumeroComprobante.Text = "Comprobante";
            this.NumeroComprobante.Width = 120;
            // 
            // Fecha
            // 
            this.Fecha.AspectName = "Fecha";
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 119;
            // 
            // Nombre
            // 
            this.Nombre.AspectName = "Nombre";
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 185;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ultimos Comprobante";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.61111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.38889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.78378F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.21622F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(829, 74);
            this.tableLayoutPanel1.TabIndex = 29;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(634, 27);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 41);
            this.button7.TabIndex = 13;
            this.button7.Text = "Editar Nombre";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.22964F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.77036F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.objectListView1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.objectListView2, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 107);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.45455F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.54546F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1854, 220);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1119, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Datos";
            // 
            // objectListView2
            // 
            this.objectListView2.AllColumns.Add(this.Telefono);
            this.objectListView2.AllColumns.Add(this.Mail);
            this.objectListView2.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways;
            this.objectListView2.CellEditEnterChangesRows = true;
            this.objectListView2.CellEditTabChangesRows = true;
            this.objectListView2.CellEditUseWholeCell = false;
            this.objectListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Telefono,
            this.Mail});
            this.objectListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView2.Location = new System.Drawing.Point(1119, 26);
            this.objectListView2.Name = "objectListView2";
            this.objectListView2.Size = new System.Drawing.Size(473, 191);
            this.objectListView2.TabIndex = 29;
            this.objectListView2.UseCompatibleStateImageBehavior = false;
            this.objectListView2.View = System.Windows.Forms.View.Details;
            this.objectListView2.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView2_CellEditFinishing);
            this.objectListView2.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.objectListView2_CellEditStarting);
            this.objectListView2.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objectListView2_CellClick);
            this.objectListView2.SelectedIndexChanged += new System.EventHandler(this.objectListView2_SelectedIndexChanged);
            // 
            // Telefono
            // 
            this.Telefono.AspectName = "Telefono";
            this.Telefono.Tag = "";
            this.Telefono.Text = "Telefono";
            this.Telefono.Width = 108;
            // 
            // Mail
            // 
            this.Mail.AspectName = "Mail";
            this.Mail.Tag = "";
            this.Mail.Text = "Mail";
            this.Mail.Width = 196;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.89958F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99163F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82009F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.2887F));
            this.tableLayoutPanel3.Controls.Add(this.checkedListBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkedListBox2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkedListBox4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkedListBox3, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 333);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 364F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(958, 398);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox4.CheckOnClick = true;
            this.checkedListBox4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.checkedListBox4.Location = new System.Drawing.Point(578, 41);
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(83, 349);
            this.checkedListBox4.TabIndex = 3;
            this.checkedListBox4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox4_ItemCheck);
            this.checkedListBox4.SelectedIndexChanged += new System.EventHandler(this.checkedListBox4_SelectedIndexChanged);
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox3.CheckOnClick = true;
            this.checkedListBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(713, 41);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(207, 349);
            this.checkedListBox3.TabIndex = 2;
            this.checkedListBox3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox3_ItemCheck);
            this.checkedListBox3.SelectedIndexChanged += new System.EventHandler(this.checkedListBox3_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Profesor";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Clases";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cantidad";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(764, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tipo de Clase";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.Cerrar, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button6, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.button4, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 815);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.83871F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.16129F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1851, 194);
            this.tableLayoutPanel4.TabIndex = 32;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(79, 123);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(212, 54);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "Recibo Pago\r\npara Mes Proximo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1203, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 71);
            this.button6.TabIndex = 26;
            this.button6.Text = "Historial de Recibos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(824, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 79);
            this.button4.TabIndex = 28;
            this.button4.Text = "Casos\r\nExcepcionales";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // eliminaultimo
            // 
            this.eliminaultimo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eliminaultimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminaultimo.Location = new System.Drawing.Point(11, 240);
            this.eliminaultimo.Name = "eliminaultimo";
            this.eliminaultimo.Size = new System.Drawing.Size(127, 116);
            this.eliminaultimo.TabIndex = 24;
            this.eliminaultimo.Text = "Eliminar Ultimo";
            this.eliminaultimo.UseVisualStyleBackColor = true;
            this.eliminaultimo.Click += new System.EventHandler(this.eliminaultimo_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(1131, 330);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(735, 465);
            this.listView1.TabIndex = 34;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(12, 737);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(958, 58);
            this.tableLayoutPanel5.TabIndex = 38;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(181, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Uniforme";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown1.Location = new System.Drawing.Point(658, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.AgregarComprobantes, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.eliminaultimo, 0, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(976, 333);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(149, 398);
            this.tableLayoutPanel6.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1878, 1039);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobantes Alumnos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView2)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AgregarComprobantes;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn NumeroComprobante;
        private BrightIdeasSoftware.OLVColumn Fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private BrightIdeasSoftware.ObjectListView objectListView2;
        private BrightIdeasSoftware.OLVColumn Mail;
        public BrightIdeasSoftware.OLVColumn Telefono;
        private System.Windows.Forms.CheckedListBox checkedListBox4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button eliminaultimo;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button button6;
        private BrightIdeasSoftware.OLVColumn Nombre;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button4;
    }
}

