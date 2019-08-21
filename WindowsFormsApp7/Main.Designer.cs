namespace WindowsFormsApp7
{
    partial class Main
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
            this.Comprobantes = new System.Windows.Forms.Button();
            this.Alumnos = new System.Windows.Forms.Button();
            this.Libros = new System.Windows.Forms.Button();
            this.Clasesycursos = new System.Windows.Forms.Button();
            this.Usuarios = new System.Windows.Forms.Button();
            this.Profesoresycursos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Comprobantes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Alumnos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Libros, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Clasesycursos, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Usuarios, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Profesoresycursos, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(39, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 78);
            this.button1.TabIndex = 5;
            this.button1.Text = "Interfaz\r\n Listas Clases\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Comprobantes
            // 
            this.Comprobantes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Comprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comprobantes.Location = new System.Drawing.Point(39, 87);
            this.Comprobantes.Name = "Comprobantes";
            this.Comprobantes.Size = new System.Drawing.Size(218, 78);
            this.Comprobantes.TabIndex = 0;
            this.Comprobantes.Text = "Interfaz Comprobantes";
            this.Comprobantes.UseVisualStyleBackColor = true;
            this.Comprobantes.Click += new System.EventHandler(this.Comprobantes_Click);
            // 
            // Alumnos
            // 
            this.Alumnos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Alumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alumnos.Location = new System.Drawing.Point(335, 87);
            this.Alumnos.Name = "Alumnos";
            this.Alumnos.Size = new System.Drawing.Size(218, 78);
            this.Alumnos.TabIndex = 1;
            this.Alumnos.Text = "Interfaz Alumnos";
            this.Alumnos.UseVisualStyleBackColor = true;
            this.Alumnos.Click += new System.EventHandler(this.Alumnos_Click);
            // 
            // Libros
            // 
            this.Libros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Libros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Libros.Location = new System.Drawing.Point(335, 341);
            this.Libros.Name = "Libros";
            this.Libros.Size = new System.Drawing.Size(218, 78);
            this.Libros.TabIndex = 3;
            this.Libros.Text = "Interfaz Libros";
            this.Libros.UseVisualStyleBackColor = true;
            this.Libros.Click += new System.EventHandler(this.Libros_Click);
            // 
            // Clasesycursos
            // 
            this.Clasesycursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Clasesycursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clasesycursos.Location = new System.Drawing.Point(927, 341);
            this.Clasesycursos.Name = "Clasesycursos";
            this.Clasesycursos.Size = new System.Drawing.Size(218, 78);
            this.Clasesycursos.TabIndex = 4;
            this.Clasesycursos.Text = "Cerrar";
            this.Clasesycursos.UseVisualStyleBackColor = true;
            this.Clasesycursos.Click += new System.EventHandler(this.Clasesycursos_Click);
            // 
            // Usuarios
            // 
            this.Usuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuarios.Location = new System.Drawing.Point(927, 87);
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(218, 78);
            this.Usuarios.TabIndex = 2;
            this.Usuarios.Text = "Interfaz Usuarios";
            this.Usuarios.UseVisualStyleBackColor = true;
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // Profesoresycursos
            // 
            this.Profesoresycursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Profesoresycursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profesoresycursos.Location = new System.Drawing.Point(628, 69);
            this.Profesoresycursos.Name = "Profesoresycursos";
            this.Profesoresycursos.Size = new System.Drawing.Size(223, 114);
            this.Profesoresycursos.TabIndex = 6;
            this.Profesoresycursos.Text = "Interfaz\r\nProfesores y Cursos";
            this.Profesoresycursos.UseVisualStyleBackColor = true;
            this.Profesoresycursos.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Comprobantes;
        private System.Windows.Forms.Button Alumnos;
        private System.Windows.Forms.Button Libros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Clasesycursos;
        private System.Windows.Forms.Button Usuarios;
        private System.Windows.Forms.Button Profesoresycursos;
    }
}