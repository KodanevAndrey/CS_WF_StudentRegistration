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

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = true;
            txtLogin.Text = "";
            txtPassword.Text = "";
            if (cbUserType.SelectedItem.ToString() == "преподаватель")
            {
                AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite");
                Login = AM.ReadOneValue(lbStatus, "AccountsTable", "login", "surname", txtLogin.Text);
                Password = AM.ReadOneValue(lbStatus, "AccountsTable", "password", "surname", txtLogin.Text);
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
            }
            else if (cbUserType.SelectedItem.ToString() == "администратор")
            {
                AM.ConnectDB(lbStatus, "Admin.sqlite");
                Login = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
                Password = AM.ReadOneValue(lbStatus, "AdminTable", "password", "login", "Admin");
                txtLogin.Text = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
                txtLogin.Enabled = false;
            }
        }

        private void btnSimgIn_Click(object sender, EventArgs e)
        {
            //AM.ConnectDB(lbStatus,"Admin.sqlite");

             if (Login == txtLogin.Text && Password == txtPassword.Text)
                switch (cbUserType.SelectedItem.ToString())
                {
                    case "администратор": OpenForm(new FormAdmin()); break;
                    case "преподаватель":
                        break;
                    case "студент":
                        //AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
                        //Login = AM.ReadOneValue(lbStatus, cbSelectGroup.SelectedItem.ToString(), "password", "surname", txtLogin.Text);
                        //Password = AM.ReadOneValue(lbStatus, cbSelectGroup.SelectedItem.ToString(), "password", "surname", txtLogin.Text);
                        //txtPassword.Text = AM.ReadOneValue(lbStatus, cbSelectGroup.SelectedItem.ToString(), "password", "surname", txtLogin.Text);
                        break;
                    default: lbStatus.Text = "Неопределён тип ползователя!"; break;
                }
        }

        private void OpenForm(Form form)
        {
            form.Show();
            //btnSimgIn.Enabled = false;
        }
    }
}
