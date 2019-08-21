namespace WindowsFormsApp7
{
    partial class Main_Alumno
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
            this.Alumnos = new System.Windows.Forms.Button();
            this.AlumnosCompr = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.Alumnos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AlumnosCompr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Volver, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Alumnos
            // 
            this.Alumnos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Alumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alumnos.Location = new System.Drawing.Point(98, 76);
            this.Alumnos.Name = "Alumnos";
            this.Alumnos.Size = new System.Drawing.Size(192, 61);
            this.Alumnos.TabIndex = 0;
            this.Alumnos.Text = "Alumnos";
            this.Alumnos.UseVisualStyleBackColor = true;
            this.Alumnos.Click += new System.EventHandler(this.Alumnos_Click);
            // 
            // AlumnosCompr
            // 
            this.AlumnosCompr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AlumnosCompr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlumnosCompr.Location = new System.Drawing.Point(486, 76);
            this.AlumnosCompr.Name = "AlumnosCompr";
            this.AlumnosCompr.Size = new System.Drawing.Size(192, 61);
            this.AlumnosCompr.TabIndex = 1;
            this.AlumnosCompr.Text = "Añadir Alumno";
            this.AlumnosCompr.UseVisualStyleBackColor = true;
            this.AlumnosCompr.Click += new System.EventHandler(this.AlumnosCompr_Click);
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(486, 289);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(192, 61);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Main_Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main_Alumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Alumno";
            this.Load += new System.EventHandler(this.Main_Alumno_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Alumnos;
        private System.Windows.Forms.Button AlumnosCompr;
        private System.Windows.Forms.Button Volver;
    }
}