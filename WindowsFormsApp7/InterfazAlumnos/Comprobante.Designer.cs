namespace WindowsFormsApp7
{
    partial class ComprobanteServerParciales
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
            this.Volver = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(734, 165);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(154, 60);
            this.Volver.TabIndex = 0;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(876, 126);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ComprobanteServerParciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 248);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Volver);
            this.Name = "ComprobanteServerParciales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.ListView listView1;
    }
}