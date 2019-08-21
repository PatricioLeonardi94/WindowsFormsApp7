namespace WindowsFormsApp7
{
    partial class Cierres
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
            this.CierresGenerar = new System.Windows.Forms.Button();
            this.CierresVer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CierresGenerar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CierresVer, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(275, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 123);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ver Ultimos Cierres";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CierresGenerar
            // 
            this.CierresGenerar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CierresGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CierresGenerar.Location = new System.Drawing.Point(10, 113);
            this.CierresGenerar.Name = "CierresGenerar";
            this.CierresGenerar.Size = new System.Drawing.Size(245, 123);
            this.CierresGenerar.TabIndex = 0;
            this.CierresGenerar.Text = "Interfaz de Cierres";
            this.CierresGenerar.UseVisualStyleBackColor = true;
            this.CierresGenerar.Click += new System.EventHandler(this.CierresGenerar_Click);
            // 
            // CierresVer
            // 
            this.CierresVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CierresVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CierresVer.Location = new System.Drawing.Point(541, 113);
            this.CierresVer.Name = "CierresVer";
            this.CierresVer.Size = new System.Drawing.Size(245, 123);
            this.CierresVer.TabIndex = 1;
            this.CierresVer.Text = "Volver";
            this.CierresVer.UseVisualStyleBackColor = true;
            this.CierresVer.Click += new System.EventHandler(this.CierresVer_Click);
            // 
            // Cierres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 373);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Cierres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierres";
            this.Load += new System.EventHandler(this.Cierres_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CierresGenerar;
        private System.Windows.Forms.Button CierresVer;
        private System.Windows.Forms.Button button1;
    }
}