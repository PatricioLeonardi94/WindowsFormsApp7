namespace WindowsFormsApp7
{
    partial class ChangePassword
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
            this.NewContr1 = new System.Windows.Forms.Label();
            this.NewContr2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Volver = new System.Windows.Forms.Button();
            this.Cambiar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewContr1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NewContr2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(54, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 425);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña Actual";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NewContr1
            // 
            this.NewContr1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewContr1.AutoSize = true;
            this.NewContr1.BackColor = System.Drawing.Color.Transparent;
            this.NewContr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewContr1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NewContr1.Location = new System.Drawing.Point(3, 162);
            this.NewContr1.Name = "NewContr1";
            this.NewContr1.Size = new System.Drawing.Size(209, 26);
            this.NewContr1.TabIndex = 1;
            this.NewContr1.Text = "Nueva Contraseña";
            this.NewContr1.Click += new System.EventHandler(this.NewContr1_Click);
            // 
            // NewContr2
            // 
            this.NewContr2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewContr2.AutoSize = true;
            this.NewContr2.BackColor = System.Drawing.Color.Transparent;
            this.NewContr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewContr2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NewContr2.Location = new System.Drawing.Point(3, 289);
            this.NewContr2.Name = "NewContr2";
            this.NewContr2.Size = new System.Drawing.Size(195, 52);
            this.NewContr2.TabIndex = 2;
            this.NewContr2.Text = "Repita su Nueva Contraseña";
            this.NewContr2.Click += new System.EventHandler(this.NewContr2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Location = new System.Drawing.Point(3, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(310, 26);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.Location = new System.Drawing.Point(3, 232);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(310, 26);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.Location = new System.Drawing.Point(3, 374);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(310, 26);
            this.textBox3.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.36709F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.63291F));
            this.tableLayoutPanel2.Controls.Add(this.Volver, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Cambiar, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(54, 447);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(316, 101);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Volver
            // 
            this.Volver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(3, 27);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(120, 47);
            this.Volver.TabIndex = 0;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.UseWaitCursor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Cambiar
            // 
            this.Cambiar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Cambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cambiar.Location = new System.Drawing.Point(158, 27);
            this.Cambiar.Name = "Cambiar";
            this.Cambiar.Size = new System.Drawing.Size(120, 47);
            this.Cambiar.TabIndex = 1;
            this.Cambiar.Text = "Cambiar";
            this.Cambiar.UseVisualStyleBackColor = true;
            this.Cambiar.UseWaitCursor = true;
            this.Cambiar.Click += new System.EventHandler(this.Cambiar_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 564);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario Cambiar Contraseña";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button Cambiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NewContr1;
        private System.Windows.Forms.Label NewContr2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}