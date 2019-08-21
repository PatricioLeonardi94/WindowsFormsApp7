namespace WindowsFormsApp7
{
    partial class NewUser
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
            this.w = new System.Windows.Forms.Label();
            this.q = new System.Windows.Forms.Label();
            this.NewUserName = new System.Windows.Forms.TextBox();
            this.NewUserPas = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Volver = new System.Windows.Forms.Button();
            this.Crear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.w, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.q, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NewUserName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewUserPas, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(58, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // w
            // 
            this.w.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.w.AutoSize = true;
            this.w.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.w.Location = new System.Drawing.Point(91, 23);
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(113, 20);
            this.w.TabIndex = 1;
            this.w.Text = "Nuevo Usuario";
            // 
            // q
            // 
            this.q.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.q.AutoSize = true;
            this.q.Location = new System.Drawing.Point(101, 157);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(92, 20);
            this.q.TabIndex = 2;
            this.q.Text = "Contraseña";
            // 
            // NewUserName
            // 
            this.NewUserName.Location = new System.Drawing.Point(3, 70);
            this.NewUserName.Name = "NewUserName";
            this.NewUserName.Size = new System.Drawing.Size(289, 26);
            this.NewUserName.TabIndex = 3;
            this.NewUserName.TextChanged += new System.EventHandler(this.NewUserName_TextChanged);
            // 
            // NewUserPas
            // 
            this.NewUserPas.Location = new System.Drawing.Point(3, 204);
            this.NewUserPas.Name = "NewUserPas";
            this.NewUserPas.PasswordChar = '*';
            this.NewUserPas.Size = new System.Drawing.Size(289, 26);
            this.NewUserPas.TabIndex = 4;
            this.NewUserPas.TextChanged += new System.EventHandler(this.NewUserPas_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Volver, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Crear, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(61, 391);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(295, 65);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(3, 3);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(141, 59);
            this.Volver.TabIndex = 0;
            this.Volver.Text = "Voler";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Crear
            // 
            this.Crear.Location = new System.Drawing.Point(150, 3);
            this.Crear.Name = "Crear";
            this.Crear.Size = new System.Drawing.Size(142, 59);
            this.Crear.TabIndex = 1;
            this.Crear.Text = "Crear";
            this.Crear.UseVisualStyleBackColor = true;
            this.Crear.Click += new System.EventHandler(this.Crear_Click);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 468);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewUser";
            this.Load += new System.EventHandler(this.NewUser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label w;
        private System.Windows.Forms.Label q;
        private System.Windows.Forms.TextBox NewUserName;
        private System.Windows.Forms.TextBox NewUserPas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Button Crear;
    }
}