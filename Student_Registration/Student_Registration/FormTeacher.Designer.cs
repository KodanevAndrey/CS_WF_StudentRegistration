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
            this.lbSatusProfile = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Diarist = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistsiplina = new System.Windows.Forms.TextBox();
            this.btnCreateNewMagazine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbStatusDiarist = new System.Windows.Forms.Label();
            this.cbSelectGroup = new System.Windows.Forms.ComboBox();
            this.dgvViewer = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Profile.SuspendLayout();
            this.Diarist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).BeginInit();
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
            this.Profile.Controls.Add(this.lbSatusProfile);
            this.Profile.Controls.Add(this.richTextBox1);
            this.Profile.Location = new System.Drawing.Point(4, 22);
            this.Profile.Name = "Profile";
            this.Profile.Padding = new System.Windows.Forms.Padding(3);
            this.Profile.Size = new System.Drawing.Size(927, 569);
            this.Profile.TabIndex = 0;
            this.Profile.Text = "Profile";
            // 
            // lbSatusProfile
            // 
            this.lbSatusProfile.AutoSize = true;
            this.lbSatusProfile.Location = new System.Drawing.Point(9, 548);
            this.lbSatusProfile.Name = "lbSatusProfile";
            this.lbSatusProfile.Size = new System.Drawing.Size(12, 13);
            this.lbSatusProfile.TabIndex = 1;
            this.lbSatusProfile.Text = "s";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(313, 266);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Diarist
            // 
            this.Diarist.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Diarist.Controls.Add(this.dgvViewer);
            this.Diarist.Controls.Add(this.label2);
            this.Diarist.Controls.Add(this.txtDistsiplina);
            this.Diarist.Controls.Add(this.btnCreateNewMagazine);
            this.Diarist.Controls.Add(this.label1);
            this.Diarist.Controls.Add(this.lbStatusDiarist);
            this.Diarist.Controls.Add(this.cbSelectGroup);
            this.Diarist.Location = new System.Drawing.Point(4, 22);
            this.Diarist.Name = "Diarist";
            this.Diarist.Padding = new System.Windows.Forms.Padding(3);
            this.Diarist.Size = new System.Drawing.Size(927, 569);
            this.Diarist.TabIndex = 1;
            this.Diarist.Text = "Diarist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "дисциплина";
            // 
            // txtDistsiplina
            // 
            this.txtDistsiplina.Location = new System.Drawing.Point(98, 31);
            this.txtDistsiplina.Name = "txtDistsiplina";
            this.txtDistsiplina.Size = new System.Drawing.Size(121, 20);
            this.txtDistsiplina.TabIndex = 4;
            // 
            // btnCreateNewMagazine
            // 
            this.btnCreateNewMagazine.Location = new System.Drawing.Point(98, 57);
            this.btnCreateNewMagazine.Name = "btnCreateNewMagazine";
            this.btnCreateNewMagazine.Size = new System.Drawing.Size(121, 23);
            this.btnCreateNewMagazine.TabIndex = 3;
            this.btnCreateNewMagazine.Text = "Вписать дисциплину";
            this.btnCreateNewMagazine.UseVisualStyleBackColor = true;
            this.btnCreateNewMagazine.Click += new System.EventHandler(this.btnCreateNewMagazine_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Журнал группы";
            // 
            // lbStatusDiarist
            // 
            this.lbStatusDiarist.AutoSize = true;
            this.lbStatusDiarist.Location = new System.Drawing.Point(9, 548);
            this.lbStatusDiarist.Name = "lbStatusDiarist";
            this.lbStatusDiarist.Size = new System.Drawing.Size(35, 13);
            this.lbStatusDiarist.TabIndex = 1;
            this.lbStatusDiarist.Text = "label1";
            // 
            // cbSelectGroup
            // 
            this.cbSelectGroup.FormattingEnabled = true;
            this.cbSelectGroup.Location = new System.Drawing.Point(98, 4);
            this.cbSelectGroup.Name = "cbSelectGroup";
            this.cbSelectGroup.Size = new System.Drawing.Size(121, 21);
            this.cbSelectGroup.TabIndex = 0;
            this.cbSelectGroup.SelectedIndexChanged += new System.EventHandler(this.cbSelectGroup_SelectedIndexChanged);
            // 
            // dgvViewer
            // 
            this.dgvViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewer.Location = new System.Drawing.Point(6, 86);
            this.dgvViewer.Name = "dgvViewer";
            this.dgvViewer.Size = new System.Drawing.Size(893, 459);
            this.dgvViewer.TabIndex = 6;
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
            this.Diarist.ResumeLayout(false);
            this.Diarist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Profile;
        private System.Windows.Forms.TabPage Diarist;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbSatusProfile;
        private System.Windows.Forms.ComboBox cbSelectGroup;
        private System.Windows.Forms.Label lbStatusDiarist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateNewMagazine;
        private System.Windows.Forms.TextBox txtDistsiplina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvViewer;
    }
}