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
        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(750,350);
            this.MaximizeBox = false;
        }

        /*
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
        }
        */

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbUserType.SelectedItem.ToString() == "преподаватель")
            {
                AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite");
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {

                AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
            }
            else if (cbUserType.SelectedItem.ToString() == "администратор")
            {
                AM.ConnectDB(lbStatus, "Admin.sqlite");
            }
        }

        private void btnSimgIn_Click(object sender, EventArgs e)
        {
            //AM.ConnectDB(lbStatus,"Admin.sqlite");
            string login = "";
            string password = "";
            switch (cbUserType.SelectedItem.ToString())
            {
                case "администратор":
                    //AM.ConnectDB(lbStatus, "Admin.sqlite"); 
                    login = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
                    password = AM.ReadOneValue(lbStatus, "AdminTable", "password", "login", "Admin");
                    //txtPassword.Text = AM.ReadOneValue(lbStatus,"AdminTable","password", "login", "Admin");
                    if(login == txtLogin.Text && password == txtPassword.Text)
                    {
                        FormAdmin formAdmin = new FormAdmin();
                        formAdmin.Show();
                    }
                    break;
                case "преподаватель":
                    //AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite"); 
                    login = AM.ReadOneValue(lbStatus, "AccountsTable", "login", "surname", txtLogin.Text);
                    password = AM.ReadOneValue(lbStatus, "AccountsTable", "password", "surname", txtLogin.Text);
                    //txtPassword.Text = AM.ReadOneValue(lbStatus, "AccountsTable", "password", "surname", txtLogin.Text); 
                    break;
                case "студент": 
                    //AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
                    //password = AM.ReadOneValue(lbStatus, cbSelectGroup.SelectedItem.ToString(), "password", "surname", txtLogin.Text);
                    //txtPassword.Text = AM.ReadOneValue(lbStatus, cbSelectGroup.SelectedItem.ToString(), "password", "surname", txtLogin.Text);
                    break;
                default: lbStatus.Text = "Неопределён тип ползователя!"; break;
            }
        }
    }
}
