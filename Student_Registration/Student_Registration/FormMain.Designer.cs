namespace Student_Registration
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //#region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUserType = new System.Windows.Forms.ComboBox();
            this.cbSelectUser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSimgIn = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cbSelectGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вход как:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 175);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(166, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "пароль";
            // 
            // cbUserType
            // 
            this.cbUserType.FormattingEnabled = true;
            this.cbUserType.Items.AddRange(new object[] {
            "администратор",
            "препадователь",
            "студент"});
            this.cbUserType.Location = new System.Drawing.Point(38, 25);
            this.cbUserType.Name = "cbUserType";
            this.cbUserType.Size = new System.Drawing.Size(121, 21);
            this.cbUserType.TabIndex = 6;
            this.cbUserType.SelectedIndexChanged += new System.EventHandler(this.cbUserType_SelectedIndexChanged);
            // 
            // cbSelectUser
            // 
            this.cbSelectUser.FormattingEnabled = true;
            this.cbSelectUser.Location = new System.Drawing.Point(38, 122);
            this.cbSelectUser.Name = "cbSelectUser";
            this.cbSelectUser.Size = new System.Drawing.Size(121, 21);
            this.cbSelectUser.TabIndex = 7;
            this.cbSelectUser.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пользователь";
            // 
            // btnSimgIn
            // 
            this.btnSimgIn.Location = new System.Drawing.Point(59, 201);
            this.btnSimgIn.Name = "btnSimgIn";
            this.btnSimgIn.Size = new System.Drawing.Size(75, 23);
            this.btnSimgIn.TabIndex = 9;
            this.btnSimgIn.Text = "Войти";
            this.btnSimgIn.UseVisualStyleBackColor = true;
            this.btnSimgIn.Click += new System.EventHandler(this.btnSimgIn_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 242);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(35, 13);
            this.lbStatus.TabIndex = 10;
            this.lbStatus.Text = "status";
            // 
            // cbSelectGroup
            // 
            this.cbSelectGroup.FormattingEnabled = true;
            this.cbSelectGroup.Location = new System.Drawing.Point(38, 82);
            this.cbSelectGroup.Name = "cbSelectGroup";
            this.cbSelectGroup.Size = new System.Drawing.Size(121, 21);
            this.cbSelectGroup.TabIndex = 12;
            this.cbSelectGroup.SelectedIndexChanged += new System.EventHandler(this.cbSelectGroup_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Группа";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(190, 264);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSelectGroup);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnSimgIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSelectUser);
            this.Controls.Add(this.cbUserType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //#endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUserType;
        private System.Windows.Forms.ComboBox cbSelectUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSimgIn;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cbSelectGroup;
        private System.Windows.Forms.Label label4;
    }
}

