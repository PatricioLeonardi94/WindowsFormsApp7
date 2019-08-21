namespace WindowsFormsApp7
{
    partial class Main_Comprobantes
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
            this.ComprAlum = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.ComprCanc = new System.Windows.Forms.Button();
            this.ComprDest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Cierres = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.ComprAlum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Volver, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComprCanc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComprDest, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cierres, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 446);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // ComprAlum
            // 
            this.ComprAlum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComprAlum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComprAlum.Location = new System.Drawing.Point(36, 73);
            this.ComprAlum.Name = "ComprAlum";
            this.ComprAlum.Size = new System.Drawing.Size(193, 76);
            this.ComprAlum.TabIndex = 0;
            this.ComprAlum.Text = "Comprobantes Alumnos";
            this.ComprAlum.UseVisualStyleBackColor = true;
            this.ComprAlum.Click += new System.EventHandler(this.ComprAlum_Click);
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(570, 296);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(193, 76);
            this.Volver.TabIndex = 4;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // ComprCanc
            // 
            this.ComprCanc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComprCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComprCanc.Location = new System.Drawing.Point(36, 296);
            this.ComprCanc.Name = "ComprCanc";
            this.ComprCanc.Size = new System.Drawing.Size(193, 76);
            this.ComprCanc.TabIndex = 1;
            this.ComprCanc.Text = "Ver \r\nComprobante";
            this.ComprCanc.UseVisualStyleBackColor = true;
            this.ComprCanc.Click += new System.EventHandler(this.ComprCanc_Click);
            // 
            // ComprDest
            // 
            this.ComprDest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ComprDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComprDest.Location = new System.Drawing.Point(303, 296);
            this.ComprDest.Name = "ComprDest";
            this.ComprDest.Size = new System.Drawing.Size(193, 76);
            this.ComprDest.TabIndex = 2;
            this.ComprDest.Text = "Destino Comprobantes";
            this.ComprDest.UseVisualStyleBackColor = true;
            this.ComprDest.Click += new System.EventHandler(this.ComprDest_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(303, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 76);
            this.button1.TabIndex = 1;
            this.button1.Text = "Compobantes\r\nCursos\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cierres
            // 
            this.Cierres.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cierres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cierres.Location = new System.Drawing.Point(570, 73);
            this.Cierres.Name = "Cierres";
            this.Cierres.Size = new System.Drawing.Size(193, 76);
            this.Cierres.TabIndex = 3;
            this.Cierres.Text = "Cierres";
            this.Cierres.UseVisualStyleBackColor = true;
            this.Cierres.Click += new System.EventHandler(this.Cierres_Click);
            // 
            // Main_Comprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main_Comprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Comprobantes";
            this.Load += new System.EventHandler(this.Main_Comprobantes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ComprAlum;
        private System.Windows.Forms.Button ComprCanc;
        private System.Windows.Forms.Button ComprDest;
        private System.Windows.Forms.Button Cierres;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button button1;
    }
}