namespace WindowsFormsApp7
{
    partial class ComprobantesAlumnos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.NumeroComprobante = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Fecha = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Nombre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(544, 408);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(128, 61);
            this.Volver.TabIndex = 4;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
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
            this.objectListView1.Location = new System.Drawing.Point(17, 62);
            this.objectListView1.MenuLabelSortAscending = "Sort descending by \'{0}\'";
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(655, 299);
            this.objectListView1.TabIndex = 27;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.objectListView1_CellToolTipShowing);
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged_1);
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // NumeroComprobante
            // 
            this.NumeroComprobante.AspectName = "NumeroComprobante";
            this.NumeroComprobante.Text = "Comprobante";
            this.NumeroComprobante.Width = 133;
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
            this.Nombre.Width = 123;
            // 
            // ComprobantesAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 480);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComprobantesAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.ComprobantesAlumnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Volver;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn NumeroComprobante;
        private BrightIdeasSoftware.OLVColumn Fecha;
        private BrightIdeasSoftware.OLVColumn Nombre;
    }
}