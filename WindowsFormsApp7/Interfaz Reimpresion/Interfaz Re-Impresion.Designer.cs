namespace WindowsFormsApp7
{
    partial class Interfaz_Re_Impresion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.Fecha = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NumeroComprobante = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Nombre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.Fecha);
            this.objectListView1.AllColumns.Add(this.NumeroComprobante);
            this.objectListView1.AllColumns.Add(this.Nombre);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.NumeroComprobante,
            this.Nombre});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.Location = new System.Drawing.Point(504, 18);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(568, 445);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.objectListView1_CellClick);
            this.objectListView1.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.objectListView1_CellToolTipShowing);
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // Fecha
            // 
            this.Fecha.AspectName = "Fecha";
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 108;
            // 
            // NumeroComprobante
            // 
            this.NumeroComprobante.AspectName = "NumeroComprobante";
            this.NumeroComprobante.Text = "Comprobante";
            this.NumeroComprobante.Width = 146;
            // 
            // Nombre
            // 
            this.Nombre.AspectName = "Nombre";
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 205;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(348, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 252);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(23, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.volver, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 282);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(479, 181);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // volver
            // 
            this.volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.volver.Location = new System.Drawing.Point(275, 111);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(167, 49);
            this.volver.TabIndex = 3;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Interfaz_Re_Impresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 483);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.objectListView1);
            this.Name = "Interfaz_Re_Impresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interfaz_Re_Impresion";
            this.Load += new System.EventHandler(this.Interfaz_Re_Impresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button volver;
        private BrightIdeasSoftware.OLVColumn Fecha;
        private BrightIdeasSoftware.OLVColumn NumeroComprobante;
        private BrightIdeasSoftware.OLVColumn Nombre;
    }
}