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
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.listStringColums = new System.Windows.Forms.ListBox();
            this.btnDeleteColum = new System.Windows.Forms.Button();
            this.btnAddColum = new System.Windows.Forms.Button();
            this.CBColumnType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabConnectDB = new System.Windows.Forms.TabPage();
            this.lbStatusText = new System.Windows.Forms.Label();
            this.lbCommand = new System.Windows.Forms.Label();
            this.btnDeleteAllDB = new System.Windows.Forms.Button();
            this.btnDeleteDB = new System.Windows.Forms.Button();
            this.btnResetDB = new System.Windows.Forms.Button();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.dgvViewer = new System.Windows.Forms.DataGridView();
            this.btnReadDB = new System.Windows.Forms.Button();
            this.tabAccountManager = new System.Windows.Forms.TabPage();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddOrUpdateUser = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cbSelectGroup = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtApartmentNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtHouseNumber = new System.Windows.Forms.TextBox();
            this.cbStreet = new System.Windows.Forms.ComboBox();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbUchebnayaDistsiplina = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbSelectUser = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUserType = new System.Windows.Forms.ComboBox();
            this.lbStatusAM = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
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
            this.tabCreateDB.Text = "Создание БД";
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
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(9, 503);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(141, 33);
            this.btnCreateDB.TabIndex = 19;
            this.btnCreateDB.Text = "создать базу данных";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // listStringColums
            // 
            this.listStringColums.FormattingEnabled = true;
            this.listStringColums.Location = new System.Drawing.Point(9, 168);
            this.listStringColums.Name = "listStringColums";
            this.listStringColums.Size = new System.Drawing.Size(333, 329);
            this.listStringColums.TabIndex = 18;
            // 
            // btnDeleteColum
            // 
            this.btnDeleteColum.Location = new System.Drawing.Point(127, 140);
            this.btnDeleteColum.Name = "btnDeleteColum";
            this.btnDeleteColum.Size = new System.Drawing.Size(110, 22);
            this.btnDeleteColum.TabIndex = 17;
            this.btnDeleteColum.Text = "удалить столбец";
            this.btnDeleteColum.UseVisualStyleBackColor = true;
            this.btnDeleteColum.Click += new System.EventHandler(this.btnDeleteColum_Click);
            // 
            // btnAddColum
            // 
            this.btnAddColum.Location = new System.Drawing.Point(9, 140);
            this.btnAddColum.Name = "btnAddColum";
            this.btnAddColum.Size = new System.Drawing.Size(112, 22);
            this.btnAddColum.TabIndex = 16;
            this.btnAddColum.Text = "добавить столбец";
            this.btnAddColum.UseVisualStyleBackColor = true;
            this.btnAddColum.Click += new System.EventHandler(this.btnAddColum_Click);
            // 
            // CBColumnType
            // 
            this.CBColumnType.FormattingEnabled = true;
            this.CBColumnType.Items.AddRange(new object[] {
            "INTEGER",
            "TEXT",
            "BLOB"});
            this.CBColumnType.Location = new System.Drawing.Point(117, 92);
            this.CBColumnType.Name = "CBColumnType";
            this.CBColumnType.Size = new System.Drawing.Size(117, 21);
            this.CBColumnType.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "тип данных столбца";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(117, 66);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(192, 20);
            this.txtColumnName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "название столбца";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(117, 40);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(192, 20);
            this.txtTableName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "название таблицы";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(117, 14);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(192, 20);
            this.txtDBName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "название БД";
            // 
            // tabConnectDB
            // 
            this.tabConnectDB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabConnectDB.Controls.Add(this.lbStatusText);
            this.tabConnectDB.Controls.Add(this.lbCommand);
            this.tabConnectDB.Controls.Add(this.btnDeleteAllDB);
            this.tabConnectDB.Controls.Add(this.btnDeleteDB);
            this.tabConnectDB.Controls.Add(this.btnResetDB);
            this.tabConnectDB.Controls.Add(this.btnAddDB);
            this.tabConnectDB.Controls.Add(this.btnConnectDB);
            this.tabConnectDB.Controls.Add(this.dgvViewer);
            this.tabConnectDB.Controls.Add(this.btnReadDB);
            this.tabConnectDB.Location = new System.Drawing.Point(4, 22);
            this.tabConnectDB.Name = "tabConnectDB";
            this.tabConnectDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectDB.Size = new System.Drawing.Size(929, 561);
            this.tabConnectDB.TabIndex = 1;
            this.tabConnectDB.Text = "Подключение";
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
            this.btnDeleteAllDB.Location = new System.Drawing.Point(599, 6);
            this.btnDeleteAllDB.Name = "btnDeleteAllDB";
            this.btnDeleteAllDB.Size = new System.Drawing.Size(128, 23);
            this.btnDeleteAllDB.TabIndex = 22;
            this.btnDeleteAllDB.Text = "удалить все данные";
            this.btnDeleteAllDB.UseVisualStyleBackColor = true;
            this.btnDeleteAllDB.Click += new System.EventHandler(this.btnDeleteAllDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.Location = new System.Drawing.Point(499, 6);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteDB.TabIndex = 21;
            this.btnDeleteDB.Text = "удалить запись";
            this.btnDeleteDB.UseVisualStyleBackColor = true;
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // btnResetDB
            // 
            this.btnResetDB.Location = new System.Drawing.Point(388, 6);
            this.btnResetDB.Name = "btnResetDB";
            this.btnResetDB.Size = new System.Drawing.Size(105, 23);
            this.btnResetDB.TabIndex = 20;
            this.btnResetDB.Text = "изменить запись";
            this.btnResetDB.UseVisualStyleBackColor = true;
            this.btnResetDB.Click += new System.EventHandler(this.btnResetDB_Click);
            // 
            // btnAddDB
            // 
            this.btnAddDB.Location = new System.Drawing.Point(279, 6);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(103, 23);
            this.btnAddDB.TabIndex = 7;
            this.btnAddDB.Text = "добавить запись";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(6, 6);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(115, 23);
            this.btnConnectDB.TabIndex = 6;
            this.btnConnectDB.Text = "подключиться к БД";
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
            this.btnReadDB.Size = new System.Drawing.Size(146, 23);
            this.btnReadDB.TabIndex = 1;
            this.btnReadDB.Text = "перезагрузить таблицу";
            this.btnReadDB.UseVisualStyleBackColor = true;
            this.btnReadDB.Click += new System.EventHandler(this.btnReadDB_Click);
            // 
            // tabAccountManager
            // 
            this.tabAccountManager.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabAccountManager.Controls.Add(this.txtAdminPassword);
            this.tabAccountManager.Controls.Add(this.label19);
            this.tabAccountManager.Controls.Add(this.txtLogin);
            this.tabAccountManager.Controls.Add(this.btnDeleteGroup);
            this.tabAccountManager.Controls.Add(this.btnDeleteUser);
            this.tabAccountManager.Controls.Add(this.btnAddOrUpdateUser);
            this.tabAccountManager.Controls.Add(this.label18);
            this.tabAccountManager.Controls.Add(this.cbSelectGroup);
            this.tabAccountManager.Controls.Add(this.label17);
            this.tabAccountManager.Controls.Add(this.txtApartmentNumber);
            this.tabAccountManager.Controls.Add(this.label16);
            this.tabAccountManager.Controls.Add(this.txtHouseNumber);
            this.tabAccountManager.Controls.Add(this.cbStreet);
            this.tabAccountManager.Controls.Add(this.cbCity);
            this.tabAccountManager.Controls.Add(this.label15);
            this.tabAccountManager.Controls.Add(this.label14);
            this.tabAccountManager.Controls.Add(this.txtPhone);
            this.tabAccountManager.Controls.Add(this.label13);
            this.tabAccountManager.Controls.Add(this.label12);
            this.tabAccountManager.Controls.Add(this.txtPassword);
            this.tabAccountManager.Controls.Add(this.label11);
            this.tabAccountManager.Controls.Add(this.txtEmail);
            this.tabAccountManager.Controls.Add(this.label10);
            this.tabAccountManager.Controls.Add(this.cbUchebnayaDistsiplina);
            this.tabAccountManager.Controls.Add(this.label9);
            this.tabAccountManager.Controls.Add(this.txtPatronymic);
            this.tabAccountManager.Controls.Add(this.label8);
            this.tabAccountManager.Controls.Add(this.txtSurname);
            this.tabAccountManager.Controls.Add(this.label7);
            this.tabAccountManager.Controls.Add(this.txtName);
            this.tabAccountManager.Controls.Add(this.cbSelectUser);
            this.tabAccountManager.Controls.Add(this.label6);
            this.tabAccountManager.Controls.Add(this.label5);
            this.tabAccountManager.Controls.Add(this.cbUserType);
            this.tabAccountManager.Controls.Add(this.lbStatusAM);
            this.tabAccountManager.Controls.Add(this.btnResetPassword);
            this.tabAccountManager.Location = new System.Drawing.Point(4, 22);
            this.tabAccountManager.Name = "tabAccountManager";
            this.tabAccountManager.Size = new System.Drawing.Size(929, 561);
            this.tabAccountManager.TabIndex = 2;
            this.tabAccountManager.Text = "Управление аккаунтами";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(648, 12);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(209, 20);
            this.txtAdminPassword.TabIndex = 39;
            this.txtAdminPassword.TextChanged += new System.EventHandler(this.txtAdminPassword_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(66, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(103, 237);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(199, 20);
            this.txtLogin.TabIndex = 37;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(242, 34);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteGroup.TabIndex = 36;
            this.btnDeleteGroup.Text = "Удалить группу";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(242, 61);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteUser.TabIndex = 35;
            this.btnDeleteUser.Text = "Удалить пользователя";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddOrUpdateUser
            // 
            this.btnAddOrUpdateUser.Location = new System.Drawing.Point(103, 421);
            this.btnAddOrUpdateUser.Name = "btnAddOrUpdateUser";
            this.btnAddOrUpdateUser.Size = new System.Drawing.Size(199, 23);
            this.btnAddOrUpdateUser.TabIndex = 34;
            this.btnAddOrUpdateUser.Text = "добавить пользователя";
            this.btnAddOrUpdateUser.UseVisualStyleBackColor = true;
            this.btnAddOrUpdateUser.Click += new System.EventHandler(this.btnAddOrUpdateUser_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(68, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "группа";
            // 
            // cbSelectGroup
            // 
            this.cbSelectGroup.FormattingEnabled = true;
            this.cbSelectGroup.Location = new System.Drawing.Point(115, 36);
            this.cbSelectGroup.Name = "cbSelectGroup";
            this.cbSelectGroup.Size = new System.Drawing.Size(121, 21);
            this.cbSelectGroup.TabIndex = 32;
            this.cbSelectGroup.SelectedIndexChanged += new System.EventHandler(this.cbSelectGroup_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 398);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "номер квартиры";
            // 
            // txtApartmentNumber
            // 
            this.txtApartmentNumber.Location = new System.Drawing.Point(103, 395);
            this.txtApartmentNumber.Name = "txtApartmentNumber";
            this.txtApartmentNumber.Size = new System.Drawing.Size(199, 20);
            this.txtApartmentNumber.TabIndex = 28;
            this.txtApartmentNumber.TextChanged += new System.EventHandler(this.txtApartmentNumber_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 372);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "номер дома";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.Location = new System.Drawing.Point(103, 369);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.Size = new System.Drawing.Size(199, 20);
            this.txtHouseNumber.TabIndex = 26;
            this.txtHouseNumber.TextChanged += new System.EventHandler(this.txtHouseNumber_TextChanged);
            // 
            // cbStreet
            // 
            this.cbStreet.FormattingEnabled = true;
            this.cbStreet.Location = new System.Drawing.Point(103, 342);
            this.cbStreet.Name = "cbStreet";
            this.cbStreet.Size = new System.Drawing.Size(199, 21);
            this.cbStreet.TabIndex = 31;
            this.cbStreet.SelectedIndexChanged += new System.EventHandler(this.cbStreet_SelectedIndexChanged);
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(103, 315);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(199, 21);
            this.cbCity.TabIndex = 30;
            this.cbCity.SelectedIndexChanged += new System.EventHandler(this.cbCity_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(64, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "улица";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 318);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "город";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(103, 289);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(199, 20);
            this.txtPhone.TabIndex = 21;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 292);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "номер телефона";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "пароль";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(103, 263);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 20);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(103, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 20);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "дисциплина";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUchebnayaDistsiplina
            // 
            this.cbUchebnayaDistsiplina.FormattingEnabled = true;
            this.cbUchebnayaDistsiplina.Location = new System.Drawing.Point(103, 183);
            this.cbUchebnayaDistsiplina.Name = "cbUchebnayaDistsiplina";
            this.cbUchebnayaDistsiplina.Size = new System.Drawing.Size(199, 21);
            this.cbUchebnayaDistsiplina.TabIndex = 14;
            this.cbUchebnayaDistsiplina.SelectedIndexChanged += new System.EventHandler(this.cbUchebnayaDistsiplina_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "отчество";
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Location = new System.Drawing.Point(103, 157);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(199, 20);
            this.txtPatronymic.TabIndex = 12;
            this.txtPatronymic.TextChanged += new System.EventHandler(this.txtPatronymic_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "фамилия";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(103, 106);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(199, 20);
            this.txtSurname.TabIndex = 10;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "имя";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 131);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 20);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cbSelectUser
            // 
            this.cbSelectUser.FormattingEnabled = true;
            this.cbSelectUser.Location = new System.Drawing.Point(115, 63);
            this.cbSelectUser.Name = "cbSelectUser";
            this.cbSelectUser.Size = new System.Drawing.Size(121, 21);
            this.cbSelectUser.TabIndex = 7;
            this.cbSelectUser.SelectedIndexChanged += new System.EventHandler(this.cbSelectUser_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "пользователь";
            // 
            // cbUserType
            // 
            this.cbUserType.FormattingEnabled = true;
            this.cbUserType.Items.AddRange(new object[] {
            "перподаватель",
            "студент"});
            this.cbUserType.Location = new System.Drawing.Point(115, 12);
            this.cbUserType.Name = "cbUserType";
            this.cbUserType.Size = new System.Drawing.Size(121, 21);
            this.cbUserType.TabIndex = 4;
            this.cbUserType.SelectedIndexChanged += new System.EventHandler(this.cbUserType_SelectedIndexChanged);
            // 
            // lbStatusAM
            // 
            this.lbStatusAM.AutoSize = true;
            this.lbStatusAM.Location = new System.Drawing.Point(8, 445);
            this.lbStatusAM.Name = "lbStatusAM";
            this.lbStatusAM.Size = new System.Drawing.Size(35, 13);
            this.lbStatusAM.TabIndex = 3;
            this.lbStatusAM.Text = "status";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(648, 36);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(209, 23);
            this.btnResetPassword.TabIndex = 0;
            this.btnResetPassword.Text = "Изменить пароль администратора";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
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
            this.tabAccountManager.PerformLayout();
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
        private System.Windows.Forms.Label lbStatusAM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUserType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSelectUser;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbUchebnayaDistsiplina;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbStreet;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtHouseNumber;
        private System.Windows.Forms.TextBox txtApartmentNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbSelectGroup;
        private System.Windows.Forms.Button btnAddOrUpdateUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAdminPassword;
    }
}