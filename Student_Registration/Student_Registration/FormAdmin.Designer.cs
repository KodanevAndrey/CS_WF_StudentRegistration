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
            this.button1 = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnReadDB = new System.Windows.Forms.Button();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.btnDeleteDB = new System.Windows.Forms.Button();
            this.btnResetDB = new System.Windows.Forms.Button();
            this.lbStatusText = new System.Windows.Forms.Label();
            this.btnDeleteAllDB = new System.Windows.Forms.Button();
            this.btnAddImageDB = new System.Windows.Forms.Button();
            this.btnCreateNewDB = new System.Windows.Forms.Button();
            this.lbCommand = new System.Windows.Forms.Label();
            this.dgvViewer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Изменение пароля администратора";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(632, 11);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(115, 23);
            this.btnConnectDB.TabIndex = 1;
            this.btnConnectDB.Text = "подключение к БД";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(225, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(219, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Добавление новых пользователей";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(450, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Насторйка пользователей";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnReadDB
            // 
            this.btnReadDB.Location = new System.Drawing.Point(165, 40);
            this.btnReadDB.Name = "btnReadDB";
            this.btnReadDB.Size = new System.Drawing.Size(75, 23);
            this.btnReadDB.TabIndex = 0;
            this.btnReadDB.Text = "Read";
            this.btnReadDB.UseVisualStyleBackColor = true;
            this.btnReadDB.Click += new System.EventHandler(this.btnReadDB_Click);
            // 
            // btnAddDB
            // 
            this.btnAddDB.Location = new System.Drawing.Point(246, 40);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(75, 23);
            this.btnAddDB.TabIndex = 1;
            this.btnAddDB.Text = "Add";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.Location = new System.Drawing.Point(489, 40);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDB.TabIndex = 2;
            this.btnDeleteDB.Text = "Delete";
            this.btnDeleteDB.UseVisualStyleBackColor = true;
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // btnResetDB
            // 
            this.btnResetDB.Location = new System.Drawing.Point(408, 40);
            this.btnResetDB.Name = "btnResetDB";
            this.btnResetDB.Size = new System.Drawing.Size(75, 23);
            this.btnResetDB.TabIndex = 3;
            this.btnResetDB.Text = "Reset";
            this.btnResetDB.UseVisualStyleBackColor = true;
            this.btnResetDB.Click += new System.EventHandler(this.btnResetDB_Click);
            // 
            // lbStatusText
            // 
            this.lbStatusText.AutoSize = true;
            this.lbStatusText.Location = new System.Drawing.Point(13, 557);
            this.lbStatusText.Name = "lbStatusText";
            this.lbStatusText.Size = new System.Drawing.Size(36, 13);
            this.lbStatusText.TabIndex = 5;
            this.lbStatusText.Text = "isError";
            // 
            // btnDeleteAllDB
            // 
            this.btnDeleteAllDB.Location = new System.Drawing.Point(570, 40);
            this.btnDeleteAllDB.Name = "btnDeleteAllDB";
            this.btnDeleteAllDB.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAllDB.TabIndex = 17;
            this.btnDeleteAllDB.Text = "Delete All";
            this.btnDeleteAllDB.UseVisualStyleBackColor = true;
            this.btnDeleteAllDB.Click += new System.EventHandler(this.btnDeleteAllDB_Click);
            // 
            // btnAddImageDB
            // 
            this.btnAddImageDB.Location = new System.Drawing.Point(327, 40);
            this.btnAddImageDB.Name = "btnAddImageDB";
            this.btnAddImageDB.Size = new System.Drawing.Size(75, 23);
            this.btnAddImageDB.TabIndex = 18;
            this.btnAddImageDB.Text = "Add Image";
            this.btnAddImageDB.UseVisualStyleBackColor = true;
            this.btnAddImageDB.Click += new System.EventHandler(this.btnAddImageDB_Click);
            // 
            // btnCreateNewDB
            // 
            this.btnCreateNewDB.Location = new System.Drawing.Point(12, 40);
            this.btnCreateNewDB.Name = "btnCreateNewDB";
            this.btnCreateNewDB.Size = new System.Drawing.Size(147, 23);
            this.btnCreateNewDB.TabIndex = 20;
            this.btnCreateNewDB.Text = "Create New DB";
            this.btnCreateNewDB.UseVisualStyleBackColor = true;
            this.btnCreateNewDB.Click += new System.EventHandler(this.btnCreateNewDB_Click);
            // 
            // lbCommand
            // 
            this.lbCommand.AutoSize = true;
            this.lbCommand.Location = new System.Drawing.Point(12, 531);
            this.lbCommand.Name = "lbCommand";
            this.lbCommand.Size = new System.Drawing.Size(54, 13);
            this.lbCommand.TabIndex = 21;
            this.lbCommand.Text = "Command";
            // 
            // dgvViewer
            // 
            this.dgvViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewer.Location = new System.Drawing.Point(12, 90);
            this.dgvViewer.Name = "dgvViewer";
            this.dgvViewer.Size = new System.Drawing.Size(891, 438);
            this.dgvViewer.TabIndex = 4;
            this.dgvViewer.Click += new System.EventHandler(this.dgvViewer_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(915, 579);
            this.Controls.Add(this.dgvViewer);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnConnectDB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbCommand);
            this.Controls.Add(this.btnCreateNewDB);
            this.Controls.Add(this.btnAddImageDB);
            this.Controls.Add(this.btnDeleteAllDB);
            this.Controls.Add(this.lbStatusText);
            this.Controls.Add(this.btnResetDB);
            this.Controls.Add(this.btnDeleteDB);
            this.Controls.Add(this.btnAddDB);
            this.Controls.Add(this.btnReadDB);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvViewer;
        private System.Windows.Forms.Button btnReadDB;
        private System.Windows.Forms.Button btnAddDB;
        private System.Windows.Forms.Button btnDeleteDB;
        private System.Windows.Forms.Button btnResetDB;
        private System.Windows.Forms.Label lbStatusText;
        private System.Windows.Forms.Button btnDeleteAllDB;
        private System.Windows.Forms.Button btnAddImageDB;
        private System.Windows.Forms.Button btnCreateNewDB;
        private System.Windows.Forms.Label lbCommand;
    }
}