namespace WindowsFormsApp7
{
    partial class Cursos
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Imprimir = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.imprimirCurso = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.45614F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.54386F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkedListBox3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.22633F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.61679F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.204968F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.95191F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 445);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(31, 171);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(233, 256);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Curso";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Valor por Mes";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(318, 171);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(224, 256);
            this.checkedListBox2.TabIndex = 3;
            this.checkedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox2_ItemCheck_1);
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkedListBox3.CheckOnClick = true;
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.checkedListBox3.Location = new System.Drawing.Point(586, 171);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(194, 256);
            this.checkedListBox3.TabIndex = 6;
            this.checkedListBox3.SelectedIndexChanged += new System.EventHandler(this.checkedListBox3_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(635, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad ";
            // 
            // Imprimir
            // 
            this.Imprimir.Location = new System.Drawing.Point(493, 464);
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(147, 59);
            this.Imprimir.TabIndex = 2;
            this.Imprimir.Text = "Agregar";
            this.Imprimir.UseVisualStyleBackColor = true;
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(317, 464);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(147, 59);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // imprimirCurso
            // 
            this.imprimirCurso.Location = new System.Drawing.Point(665, 465);
            this.imprimirCurso.Name = "imprimirCurso";
            this.imprimirCurso.Size = new System.Drawing.Size(147, 59);
            this.imprimirCurso.TabIndex = 4;
            this.imprimirCurso.Text = "Imprimir";
            this.imprimirCurso.UseVisualStyleBackColor = true;
            this.imprimirCurso.Click += new System.EventHandler(this.imprimirCurso_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(133, 482);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Es Seña";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 536);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.imprimirCurso);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.Imprimir);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Cursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursos";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button Imprimir;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button imprimirCurso;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}