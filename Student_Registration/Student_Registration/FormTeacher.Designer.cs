namespace Student_Registration
{
    partial class FormTeacher
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Profile = new System.Windows.Forms.TabPage();
            this.lbSatus = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Diarist = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.Profile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Profile);
            this.tabControl1.Controls.Add(this.Diarist);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 595);
            this.tabControl1.TabIndex = 0;
            // 
            // Profile
            // 
            this.Profile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Profile.Controls.Add(this.lbSatus);
            this.Profile.Controls.Add(this.richTextBox1);
            this.Profile.Location = new System.Drawing.Point(4, 22);
            this.Profile.Name = "Profile";
            this.Profile.Padding = new System.Windows.Forms.Padding(3);
            this.Profile.Size = new System.Drawing.Size(927, 569);
            this.Profile.TabIndex = 0;
            this.Profile.Text = "Profile";
            // 
            // lbSatus
            // 
            this.lbSatus.AutoSize = true;
            this.lbSatus.Location = new System.Drawing.Point(9, 548);
            this.lbSatus.Name = "lbSatus";
            this.lbSatus.Size = new System.Drawing.Size(12, 13);
            this.lbSatus.TabIndex = 1;
            this.lbSatus.Text = "s";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(514, 351);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Diarist
            // 
            this.Diarist.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Diarist.Location = new System.Drawing.Point(4, 22);
            this.Diarist.Name = "Diarist";
            this.Diarist.Padding = new System.Windows.Forms.Padding(3);
            this.Diarist.Size = new System.Drawing.Size(927, 569);
            this.Diarist.TabIndex = 1;
            this.Diarist.Text = "Diarist";
            // 
            // FormTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(931, 592);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormTeacher";
            this.Text = "FormTeacher";
            this.tabControl1.ResumeLayout(false);
            this.Profile.ResumeLayout(false);
            this.Profile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Profile;
        private System.Windows.Forms.TabPage Diarist;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbSatus;
    }
}