namespace WindowsFormsApp7
{
    partial class Main_Libro
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
            this.Stock = new System.Windows.Forms.Button();
            this.AgregarLibro = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Stock, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AgregarLibro, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Volver, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(775, 425);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Stock
            // 
            this.Stock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stock.Location = new System.Drawing.Point(106, 65);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(174, 82);
            this.Stock.TabIndex = 0;
            this.Stock.Text = "Ver Stock";
            this.Stock.UseVisualStyleBackColor = true;
            this.Stock.Click += new System.EventHandler(this.Stock_Click);
            // 
            // AgregarLibro
            // 
            this.AgregarLibro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AgregarLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarLibro.Location = new System.Drawing.Point(494, 65);
            this.AgregarLibro.Name = "AgregarLibro";
            this.AgregarLibro.Size = new System.Drawing.Size(174, 82);
            this.AgregarLibro.TabIndex = 1;
            this.AgregarLibro.Text = "Agregar Libro";
            this.AgregarLibro.UseVisualStyleBackColor = true;
            this.AgregarLibro.Click += new System.EventHandler(this.AgregarLibro_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(106, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 82);
            this.button3.TabIndex = 2;
            this.button3.Text = "Recibo Libro";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(494, 277);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(174, 82);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Main_Libro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main_Libro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Libro";
            this.Load += new System.EventHandler(this.Main_Libro_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Stock;
        private System.Windows.Forms.Button AgregarLibro;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Volver;
    }
}