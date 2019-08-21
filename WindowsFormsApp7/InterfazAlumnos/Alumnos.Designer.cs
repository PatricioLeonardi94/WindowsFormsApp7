namespace WindowsFormsApp7
{
    partial class Alumnos
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Mail = new System.Windows.Forms.TextBox();
            this.Telefono = new System.Windows.Forms.TextBox();
            this.CargarDatos = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Nombre Completo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(367, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(653, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 69);
            this.button2.TabIndex = 4;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.72727F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Mail, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Telefono, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 221);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Correo Electronico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Telefono";
            // 
            // Mail
            // 
            this.Mail.Location = new System.Drawing.Point(367, 157);
            this.Mail.Name = "Mail";
            this.Mail.Size = new System.Drawing.Size(318, 26);
            this.Mail.TabIndex = 6;
            this.Mail.TextChanged += new System.EventHandler(this.Mail_TextChanged);
            // 
            // Telefono
            // 
            this.Telefono.Location = new System.Drawing.Point(367, 91);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(318, 26);
            this.Telefono.TabIndex = 10;
            this.Telefono.TextChanged += new System.EventHandler(this.Telefono_TextChanged);
            // 
            // CargarDatos
            // 
            this.CargarDatos.Location = new System.Drawing.Point(161, 261);
            this.CargarDatos.Name = "CargarDatos";
            this.CargarDatos.Size = new System.Drawing.Size(189, 69);
            this.CargarDatos.TabIndex = 9;
            this.CargarDatos.Text = "Cargar Datos\r\nEn Base de Datos";
            this.CargarDatos.UseVisualStyleBackColor = true;
            this.CargarDatos.Click += new System.EventHandler(this.CargarDatos_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 69);
            this.button3.TabIndex = 10;
            this.button3.Text = "Ver Comprobantes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(356, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 69);
            this.button4.TabIndex = 11;
            this.button4.Text = "Eliminar Alumno";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 361);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CargarDatos);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Name = "Alumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Alumnos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.TextBox Telefono;
        private System.Windows.Forms.Button CargarDatos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}