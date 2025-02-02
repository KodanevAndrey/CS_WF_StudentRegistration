using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormMain : Form
    {
        AccountManager AM = new AccountManager();
        private string Login;
        private string Password;
        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(750,350);
            this.MaximizeBox = false;
        }

        private void LoadLoginAndPassword()
        {
            if (cbUserType.SelectedItem.ToString() == "преподаватель")
            {
                AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite");
                Login = AM.ReadOneValue(lbStatus, "AccountsTable", "login", "login", txtLogin.Text);
                Password = AM.ReadOneValue(lbStatus, "AccountsTable", "password", "login", txtLogin.Text);
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
                Login = AM.ReadAllGroups(lbStatus, "login", "login", txtLogin.Text);
                Password = AM.ReadAllGroups(lbStatus, "password", "login", txtLogin.Text);
            }
            else if (cbUserType.SelectedItem.ToString() == "администратор")
            {
                //AM.ConnectDB(lbStatus, "Admin.sqlite");
                Login = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
                Password = AM.ReadOneValue(lbStatus, "AdminTable", "password", "login", "Admin");
            }
        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = true;
            txtLogin.Text = "";
            txtPassword.Text = "";
            //LoadLoginAndPassword();
            if (cbUserType.SelectedItem.ToString() == "администратор") 
            {
                txtLogin.Enabled = false;
                AM.ConnectDB(lbStatus, "Admin.sqlite");
                txtLogin.Text = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
            }

        }

        private void btnSimgIn_Click(object sender, EventArgs e)
        {
            //AM.ConnectDB(lbStatus,"Admin.sqlite");
            LoadLoginAndPassword();

            if (Login == txtLogin.Text && Password == txtPassword.Text)
                switch (cbUserType.SelectedItem.ToString())
                {
                    case "администратор": OpenForm(new FormAdmin()); break;
                    case "преподаватель": OpenForm(new FormTeacher()); break;
                    case "студент": OpenForm(new FormStudent()); break;
                    default: lbStatus.Text = "Неопределён тип ползователя!"; break;
                }
            else if (Login == txtLogin.Text && Password != txtPassword.Text)
            {
                lbStatus.Text = "Введён неверный пароль!";
            }
        }

        private void OpenForm(Form form)
        {
            form.Show();
            //btnSimgIn.Enabled = false;
        }
    }
}
