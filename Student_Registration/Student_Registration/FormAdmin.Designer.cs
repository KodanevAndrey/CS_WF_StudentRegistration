namespace Student_Registration
{
    partial class FormAdmin
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
            this.tabCreateDB = new System.Windows.Forms.TabPage();
            this.tabConnectDB = new System.Windows.Forms.TabPage();
            this.lbStatusText = new System.Windows.Forms.Label();
            this.lbCommand = new System.Windows.Forms.Label();
            this.btnDeleteAllDB = new System.Windows.Forms.Button();
            this.btnDeleteDB = new System.Windows.Forms.Button();
            this.btnResetDB = new System.Windows.Forms.Button();
            this.btnAddImageDB = new System.Windows.Forms.Button();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.dgvViewer = new System.Windows.Forms.DataGridView();
            this.btnReadDB = new System.Windows.Forms.Button();
            this.tabAccountManager = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBColumnType = new System.Windows.Forms.ComboBox();
            this.btnAddColum = new System.Windows.Forms.Button();
            this.btnDeleteColum = new System.Windows.Forms.Button();
            this.listStringColums = new System.Windows.Forms.ListBox();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabCreateDB.SuspendLayout();
            this.tabConnectDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).BeginInit();
            this.tabAccountManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCreateDB);
            this.tabControl1.Controls.Add(this.tabConnectDB);
            this.tabControl1.Controls.Add(this.tabAccountManager);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(937, 587);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCreateDB
            // 
            this.tabCreateDB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabCreateDB.Controls.Add(this.lbStatus);
            this.tabCreateDB.Controls.Add(this.btnCreateDB);
            this.tabCreateDB.Controls.Add(this.listStringColums);
            this.tabCreateDB.Controls.Add(this.btnDeleteColum);
            this.tabCreateDB.Controls.Add(this.btnAddColum);
            this.tabCreateDB.Controls.Add(this.CBColumnType);
            this.tabCreateDB.Controls.Add(this.label4);
            this.tabCreateDB.Controls.Add(this.txtColumnName);
            this.tabCreateDB.Controls.Add(this.label3);
            this.tabCreateDB.Controls.Add(this.txtTableName);
            this.tabCreateDB.Controls.Add(this.label2);
            this.tabCreateDB.Controls.Add(this.txtDBName);
            this.tabCreateDB.Controls.Add(this.label1);
            this.tabCreateDB.Location = new System.Drawing.Point(4, 22);
            this.tabCreateDB.Name = "tabCreateDB";
            this.tabCreateDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateDB.Size = new System.Drawing.Size(929, 561);
            this.tabCreateDB.TabIndex = 0;
            this.tabCreateDB.Text = "Create new DB";
            // 
            // tabConnectDB
            // 
            this.tabConnectDB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabConnectDB.Controls.Add(this.lbStatusText);
            this.tabConnectDB.Controls.Add(this.lbCommand);
            this.tabConnectDB.Controls.Add(this.btnDeleteAllDB);
            this.tabConnectDB.Controls.Add(this.btnDeleteDB);
            this.tabConnectDB.Controls.Add(this.btnResetDB);
            this.tabConnectDB.Controls.Add(this.btnAddImageDB);
            this.tabConnectDB.Controls.Add(this.btnAddDB);
            this.tabConnectDB.Controls.Add(this.btnConnectDB);
            this.tabConnectDB.Controls.Add(this.dgvViewer);
            this.tabConnectDB.Controls.Add(this.btnReadDB);
            this.tabConnectDB.Location = new System.Drawing.Point(4, 22);
            this.tabConnectDB.Name = "tabConnectDB";
            this.tabConnectDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectDB.Size = new System.Drawing.Size(929, 561);
            this.tabConnectDB.TabIndex = 1;
            this.tabConnectDB.Text = "Connect DB";
            // 
            // lbStatusText
            // 
            this.lbStatusText.AutoSize = true;
            this.lbStatusText.Location = new System.Drawing.Point(6, 522);
            this.lbStatusText.Name = "lbStatusText";
            this.lbStatusText.Size = new System.Drawing.Size(36, 13);
            this.lbStatusText.TabIndex = 24;
            this.lbStatusText.Text = "isError";
            // 
            // lbCommand
            // 
            this.lbCommand.AutoSize = true;
            this.lbCommand.Location = new System.Drawing.Point(6, 497);
            this.lbCommand.Name = "lbCommand";
            this.lbCommand.Size = new System.Drawing.Size(54, 13);
            this.lbCommand.TabIndex = 23;
            this.lbCommand.Text = "Command";
            // 
            // btnDeleteAllDB
            // 
            this.btnDeleteAllDB.Location = new System.Drawing.Point(532, 6);
            this.btnDeleteAllDB.Name = "btnDeleteAllDB";
            this.btnDeleteAllDB.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAllDB.TabIndex = 22;
            this.btnDeleteAllDB.Text = "Delete All";
            this.btnDeleteAllDB.UseVisualStyleBackColor = true;
            this.btnDeleteAllDB.Click += new System.EventHandler(this.btnDeleteAllDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.Location = new System.Drawing.Point(451, 6);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDB.TabIndex = 21;
            this.btnDeleteDB.Text = "Delete";
            this.btnDeleteDB.UseVisualStyleBackColor = true;
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // btnResetDB
            // 
            this.btnResetDB.Location = new System.Drawing.Point(370, 6);
            this.btnResetDB.Name = "btnResetDB";
            this.btnResetDB.Size = new System.Drawing.Size(75, 23);
            this.btnResetDB.TabIndex = 20;
            this.btnResetDB.Text = "Reset";
            this.btnResetDB.UseVisualStyleBackColor = true;
            this.btnResetDB.Click += new System.EventHandler(this.btnResetDB_Click);
            // 
            // btnAddImageDB
            // 
            this.btnAddImageDB.Location = new System.Drawing.Point(289, 6);
            this.btnAddImageDB.Name = "btnAddImageDB";
            this.btnAddImageDB.Size = new System.Drawing.Size(75, 23);
            this.btnAddImageDB.TabIndex = 19;
            this.btnAddImageDB.Text = "Add Image";
            this.btnAddImageDB.UseVisualStyleBackColor = true;
            this.btnAddImageDB.Click += new System.EventHandler(this.btnAddImageDB_Click);
            // 
            // btnAddDB
            // 
            this.btnAddDB.Location = new System.Drawing.Point(208, 6);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(75, 23);
            this.btnAddDB.TabIndex = 7;
            this.btnAddDB.Text = "Add";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(6, 6);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(115, 23);
            this.btnConnectDB.TabIndex = 6;
            this.btnConnectDB.Text = "подключение к БД";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // dgvViewer
            // 
            this.dgvViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewer.Location = new System.Drawing.Point(0, 35);
            this.dgvViewer.Name = "dgvViewer";
            this.dgvViewer.Size = new System.Drawing.Size(915, 459);
            this.dgvViewer.TabIndex = 5;
            this.dgvViewer.Click += new System.EventHandler(this.dgvViewer_Click);
            // 
            // btnReadDB
            // 
            this.btnReadDB.Location = new System.Drawing.Point(127, 6);
            this.btnReadDB.Name = "btnReadDB";
            this.btnReadDB.Size = new System.Drawing.Size(75, 23);
            this.btnReadDB.TabIndex = 1;
            this.btnReadDB.Text = "Read";
            this.btnReadDB.UseVisualStyleBackColor = true;
            this.btnReadDB.Click += new System.EventHandler(this.btnReadDB_Click);
            // 
            // tabAccountManager
            // 
            this.tabAccountManager.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabAccountManager.Controls.Add(this.btnAddStudent);
            this.tabAccountManager.Controls.Add(this.btnAddTeacher);
            this.tabAccountManager.Controls.Add(this.btnResetPassword);
            this.tabAccountManager.Location = new System.Drawing.Point(4, 22);
            this.tabAccountManager.Name = "tabAccountManager";
            this.tabAccountManager.Size = new System.Drawing.Size(929, 561);
            this.tabAccountManager.TabIndex = 2;
            this.tabAccountManager.Text = "AccountManager";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DataBase Name";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(97, 10);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(192, 20);
            this.txtDBName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Table Name";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(97, 36);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(192, 20);
            this.txtTableName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Column Name";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(97, 62);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(192, 20);
            this.txtColumnName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Column Type";
            // 
            // CBColumnType
            // 
            this.CBColumnType.FormattingEnabled = true;
            this.CBColumnType.Items.AddRange(new object[] {
            "INTEGER",
            "TEXT",
            "BLOB"});
            this.CBColumnType.Location = new System.Drawing.Point(97, 88);
            this.CBColumnType.Name = "CBColumnType";
            this.CBColumnType.Size = new System.Drawing.Size(121, 21);
            this.CBColumnType.TabIndex = 15;
            // 
            // btnAddColum
            // 
            this.btnAddColum.Location = new System.Drawing.Point(6, 140);
            this.btnAddColum.Name = "btnAddColum";
            this.btnAddColum.Size = new System.Drawing.Size(77, 22);
            this.btnAddColum.TabIndex = 16;
            this.btnAddColum.Text = "Add Column";
            this.btnAddColum.UseVisualStyleBackColor = true;
            this.btnAddColum.Click += new System.EventHandler(this.btnAddColum_Click);
            // 
            // btnDeleteColum
            // 
            this.btnDeleteColum.Location = new System.Drawing.Point(89, 140);
            this.btnDeleteColum.Name = "btnDeleteColum";
            this.btnDeleteColum.Size = new System.Drawing.Size(89, 22);
            this.btnDeleteColum.TabIndex = 17;
            this.btnDeleteColum.Text = "Delete Column";
            this.btnDeleteColum.UseVisualStyleBackColor = true;
            this.btnDeleteColum.Click += new System.EventHandler(this.btnDeleteColum_Click);
            // 
            // listStringColums
            // 
            this.listStringColums.FormattingEnabled = true;
            this.listStringColums.Location = new System.Drawing.Point(9, 168);
            this.listStringColums.Name = "listStringColums";
            this.listStringColums.Size = new System.Drawing.Size(333, 329);
            this.listStringColums.TabIndex = 18;
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(3, 505);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(100, 33);
            this.btnCreateDB.TabIndex = 19;
            this.btnCreateDB.Text = "Create Database";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(6, 541);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(35, 13);
            this.lbStatus.TabIndex = 20;
            this.lbStatus.Text = "status";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(6, 3);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(209, 23);
            this.btnResetPassword.TabIndex = 0;
            this.btnResetPassword.Text = "Изменить пароль администратора";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(6, 32);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(209, 23);
            this.btnAddTeacher.TabIndex = 1;
            this.btnAddTeacher.Text = "добавить учителя";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(6, 61);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(209, 23);
            this.btnAddStudent.TabIndex = 2;
            this.btnAddStudent.Text = "Добавить ученика";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(936, 585);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.tabControl1.ResumeLayout(false);
            this.tabCreateDB.ResumeLayout(false);
            this.tabCreateDB.PerformLayout();
            this.tabConnectDB.ResumeLayout(false);
            this.tabConnectDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).EndInit();
            this.tabAccountManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCreateDB;
        private System.Windows.Forms.TabPage tabConnectDB;
        private System.Windows.Forms.TabPage tabAccountManager;
        private System.Windows.Forms.Button btnReadDB;
        private System.Windows.Forms.DataGridView dgvViewer;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Button btnAddDB;
        private System.Windows.Forms.Button btnAddImageDB;
        private System.Windows.Forms.Button btnResetDB;
        private System.Windows.Forms.Button btnDeleteDB;
        private System.Windows.Forms.Button btnDeleteAllDB;
        private System.Windows.Forms.Label lbCommand;
        private System.Windows.Forms.Label lbStatusText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBColumnType;
        private System.Windows.Forms.Button btnAddColum;
        private System.Windows.Forms.Button btnDeleteColum;
        private System.Windows.Forms.ListBox listStringColums;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnAddTeacher;
    }
}