namespace WindowsFormsApp7
{
    partial class Ver_Listas_Clases
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.18182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.81818F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.84677F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.15322F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 583);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(406, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 65);
            this.button3.TabIndex = 6;
            this.button3.Text = "Exportar Todas\r\nLas Lista";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(82, 494);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "Exportar Lista";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView2.Location = new System.Drawing.Point(371, 41);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(250, 389);
            this.listView2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView2_DragDrop);
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.Location = new System.Drawing.Point(37, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(270, 389);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(976, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView3
            // 
            this.listView3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView3.Location = new System.Drawing.Point(915, 41);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(272, 389);
            this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView3.TabIndex = 4;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            this.listView3.DoubleClick += new System.EventHandler(this.listView3_DoubleClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Location = new System.Drawing.Point(663, 222);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 26);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Ver_Listas_Clases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 622);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Ver_Listas_Clases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver_Listas_Clases";
            this.Load += new System.EventHandler(this.Ver_Listas_Clases_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}