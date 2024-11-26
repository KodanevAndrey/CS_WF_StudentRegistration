namespace Student_Registration
{
    partial class FormCreateDB
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
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listStringColums = new System.Windows.Forms.ListBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.btnAddColum = new System.Windows.Forms.Button();
            this.checkListColumnType = new System.Windows.Forms.CheckedListBox();
            this.btnDeleteColum = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(110, 9);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(192, 20);
            this.txtDBName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DataBase Name";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(110, 35);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(192, 20);
            this.txtTableName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table Name";
            // 
            // listStringColums
            // 
            this.listStringColums.FormattingEnabled = true;
            this.listStringColums.Location = new System.Drawing.Point(12, 185);
            this.listStringColums.Name = "listStringColums";
            this.listStringColums.Size = new System.Drawing.Size(333, 186);
            this.listStringColums.TabIndex = 6;
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(110, 61);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(192, 20);
            this.txtColumnName.TabIndex = 7;
            // 
            // btnAddColum
            // 
            this.btnAddColum.Location = new System.Drawing.Point(12, 157);
            this.btnAddColum.Name = "btnAddColum";
            this.btnAddColum.Size = new System.Drawing.Size(77, 22);
            this.btnAddColum.TabIndex = 8;
            this.btnAddColum.Text = "Add Column";
            this.btnAddColum.UseVisualStyleBackColor = true;
            this.btnAddColum.Click += new System.EventHandler(this.btnAddColum_Click);
            // 
            // checkListColumnType
            // 
            this.checkListColumnType.FormattingEnabled = true;
            this.checkListColumnType.Items.AddRange(new object[] {
            "INTEGER",
            "TEXT",
            "BLOB"});
            this.checkListColumnType.Location = new System.Drawing.Point(110, 87);
            this.checkListColumnType.Name = "checkListColumnType";
            this.checkListColumnType.Size = new System.Drawing.Size(192, 64);
            this.checkListColumnType.TabIndex = 9;
            this.checkListColumnType.Click += new System.EventHandler(this.checkListColumnType_Click);
            // 
            // btnDeleteColum
            // 
            this.btnDeleteColum.Location = new System.Drawing.Point(95, 157);
            this.btnDeleteColum.Name = "btnDeleteColum";
            this.btnDeleteColum.Size = new System.Drawing.Size(89, 22);
            this.btnDeleteColum.TabIndex = 10;
            this.btnDeleteColum.Text = "Delete Column";
            this.btnDeleteColum.UseVisualStyleBackColor = true;
            this.btnDeleteColum.Click += new System.EventHandler(this.btnDeleteColum_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Column Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Column Type";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(9, 431);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 13;
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(126, 377);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(100, 33);
            this.btnCreateDB.TabIndex = 4;
            this.btnCreateDB.Text = "Create Database";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // FormCreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(357, 453);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeleteColum);
            this.Controls.Add(this.checkListColumnType);
            this.Controls.Add(this.btnAddColum);
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.listStringColums);
            this.Controls.Add(this.btnCreateDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDBName);
            this.Name = "FormCreateDB";
            this.Text = "FormCreateDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listStringColums;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.CheckedListBox checkListColumnType;
        private System.Windows.Forms.Button btnAddColum;
        private System.Windows.Forms.Button btnDeleteColum;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbStatus;
    }
}