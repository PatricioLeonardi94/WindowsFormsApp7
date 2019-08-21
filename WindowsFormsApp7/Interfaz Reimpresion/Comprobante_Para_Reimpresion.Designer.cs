namespace WindowsFormsApp7
{
    partial class Comprobante_Para_Reimpresion
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
            this.button2 = new System.Windows.Forms.Button();
            this.nota_de_credito = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.reimprimir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.90177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.09823F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nota_de_credito, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Volver, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.reimprimir, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 343);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(352, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar Recibo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nota_de_credito
            // 
            this.nota_de_credito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nota_de_credito.Location = new System.Drawing.Point(68, 202);
            this.nota_de_credito.Name = "nota_de_credito";
            this.nota_de_credito.Size = new System.Drawing.Size(152, 50);
            this.nota_de_credito.TabIndex = 6;
            this.nota_de_credito.Text = "Nota De Credito";
            this.nota_de_credito.UseVisualStyleBackColor = true;
            this.nota_de_credito.Click += new System.EventHandler(this.nota_de_credito_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(658, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 45);
            this.label5.TabIndex = 3;
            this.label5.Text = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(392, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 33);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(109, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.DoubleClick += new System.EventHandler(this.label6_DoubleClick);
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Volver.Location = new System.Drawing.Point(645, 202);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(152, 50);
            this.Volver.TabIndex = 1;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // reimprimir
            // 
            this.reimprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reimprimir.Location = new System.Drawing.Point(68, 114);
            this.reimprimir.Name = "reimprimir";
            this.reimprimir.Size = new System.Drawing.Size(152, 50);
            this.reimprimir.TabIndex = 0;
            this.reimprimir.Text = "Re - Imprimir";
            this.reimprimir.UseVisualStyleBackColor = true;
            this.reimprimir.Click += new System.EventHandler(this.reimprimir_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(357, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Diferencia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.objectListView1.Location = new System.Drawing.Point(12, 80);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(864, 257);
            this.objectListView1.TabIndex = 1;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // Profesor
            // 
            this.Profesor.AspectName = "Profesor";
            this.Profesor.Text = "Profesor";
            this.Profesor.Width = 92;
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
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.82155F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.17845F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(864, 61);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(584, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Comprobante_Para_Reimpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 624);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Comprobante_Para_Reimpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante_Para_Reimpresion";
            this.Load += new System.EventHandler(this.Comprobante_Para_Reimpresion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button reimprimir;
        private System.Windows.Forms.Button Volver;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BrightIdeasSoftware.OLVColumn Profesor;
        private BrightIdeasSoftware.OLVColumn ClasesTomar;
        private BrightIdeasSoftware.OLVColumn cantidadElegidos;
        private BrightIdeasSoftware.OLVColumn CantidadClases;
        private BrightIdeasSoftware.OLVColumn Precio;
        private BrightIdeasSoftware.OLVColumn Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private BrightIdeasSoftware.OLVColumn Descripcion;
        private System.Windows.Forms.Button nota_de_credito;
        private System.Windows.Forms.Button button2;
    }
}