namespace WindowsFormsApp7
{
    partial class Main_ClasesyCursos
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
            this.button1 = new System.Windows.Forms.Button();
            this.Cursos = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cursos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Volver, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 293);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(83, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clases";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cursos
            // 
            this.Cursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cursos.Location = new System.Drawing.Point(422, 40);
            this.Cursos.Name = "Cursos";
            this.Cursos.Size = new System.Drawing.Size(173, 65);
            this.Cursos.TabIndex = 1;
            this.Cursos.Text = "Cursos";
            this.Cursos.UseVisualStyleBackColor = true;
            this.Cursos.Click += new System.EventHandler(this.Cursos_Click);
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(422, 187);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(173, 65);
            this.Volver.TabIndex = 2;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Main_ClasesyCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 318);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main_ClasesyCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_ClasesyCursos";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Cursos;
        private System.Windows.Forms.Button Volver;
    }
}