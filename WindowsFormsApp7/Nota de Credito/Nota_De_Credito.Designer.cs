namespace WindowsFormsApp7
{
    partial class Nota_De_Credito
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Imprimir = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.Profesor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ClasesTomar = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Descripcion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cantidadElegidos = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CantidadClases = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Precio = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Total = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Imprimir, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.volver, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(339, 371);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 92);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Imprimir
            // 
            this.Imprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Imprimir.Location = new System.Drawing.Point(60, 17);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(150, 58);
            this.Imprimir.TabIndex = 2;
            this.Imprimir.Text = "Confirmar";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // volver
            // 
            this.volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.volver.Location = new System.Drawing.Point(330, 17);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(150, 58);
            this.volver.TabIndex = 1;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.Profesor);
            this.objectListView1.AllColumns.Add(this.ClasesTomar);
            this.objectListView1.AllColumns.Add(this.Descripcion);
            this.objectListView1.AllColumns.Add(this.cantidadElegidos);
            this.objectListView1.AllColumns.Add(this.CantidadClases);
            this.objectListView1.AllColumns.Add(this.Precio);
            this.objectListView1.AllColumns.Add(this.Total);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.CheckBoxes = true;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Profesor,
            this.ClasesTomar,
            this.Descripcion,
            this.cantidadElegidos,
            this.CantidadClases,
            this.Precio,
            this.Total});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Location = new System.Drawing.Point(15, 32);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(864, 176);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged_1);
            // 
            // Profesor
            // 
            this.Profesor.AspectName = "Profesor";
            this.Profesor.Text = "Profesor";
            this.Profesor.Width = 100;
            // 
            // ClasesTomar
            // 
            this.ClasesTomar.AspectName = "ClasesTomar";
            this.ClasesTomar.Text = "Clase";
            this.ClasesTomar.Width = 93;
            // 
            // Descripcion
            // 
            this.Descripcion.AspectName = "Descripcion";
            this.Descripcion.Tag = "Descripcion";
            this.Descripcion.Text = "Descripcion";
            this.Descripcion.Width = 233;
            // 
            // cantidadElegidos
            // 
            this.cantidadElegidos.AspectName = "cantidadElegidos";
            this.cantidadElegidos.Text = "Cantidad";
            this.cantidadElegidos.Width = 98;
            // 
            // CantidadClases
            // 
            this.CantidadClases.AspectName = "CantidadClases";
            this.CantidadClases.Text = "TipoElegido";
            this.CantidadClases.Width = 114;
            // 
            // Precio
            // 
            this.Precio.AspectName = "Precio";
            this.Precio.Text = "Precio";
            this.Precio.Width = 92;
            // 
            // Total
            // 
            this.Total.AspectName = "Total";
            this.Total.Text = "Total";
            this.Total.Width = 93;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 215);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 73);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor a Descontar\r\n(ingresarlo sin el negativo)";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(329, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Nota_De_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 475);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Nota_De_Credito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota_De_Credito";
            this.Load += new System.EventHandler(this.Nota_De_Credito_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Button volver;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private BrightIdeasSoftware.OLVColumn Profesor;
        private BrightIdeasSoftware.OLVColumn ClasesTomar;
        private BrightIdeasSoftware.OLVColumn Descripcion;
        private BrightIdeasSoftware.OLVColumn cantidadElegidos;
        private BrightIdeasSoftware.OLVColumn CantidadClases;
        private BrightIdeasSoftware.OLVColumn Precio;
        private BrightIdeasSoftware.OLVColumn Total;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}