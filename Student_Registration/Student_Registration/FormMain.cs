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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {

                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";
                cbSelectGroup.Enabled = false;

                cbSelectUser.Enabled = true;

                AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite");
                AM.ReadAllName(lbStatus, cbSelectUser, "AccountsTable");
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                cbSelectGroup.Enabled = true;

                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";

                cbSelectUser.Text = "";

                AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
                AM.ReadCountTables(lbStatus, cbSelectGroup);
            }
            else if (cbUserType.SelectedItem.ToString() == "администратор")
            {
                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";
                cbSelectGroup.Enabled = false;

                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";

                cbSelectUser.Text = "";

                AM.ConnectDB(lbStatus, "Admin.sqlite");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSimgIn_Click(object sender, EventArgs e)
        {
            //AM.ConnectDB(lbStatus,"Admin.sqlite");

            string str = cbSelectUser.Text;
            string surname = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') break;
                surname += str[i];
            }

            string password;
            switch (cbUserType.SelectedItem.ToString())
            {
                case "администратор":
                    //AM.ConnectDB(lbStatus, "Admin.sqlite"); 
                    password = AM.ReadPassword(lbStatus, "AdminTable", "password", "login", "Admin");
                    txtPassword.Text = AM.ReadPassword(lbStatus,"AdminTable","password", "login", "Admin"); 
                    break;
                case "препадователь":
                    //AM.ConnectDB(lbStatus, "TeacherAccounts.sqlite"); 
                    password = AM.ReadPassword(lbStatus, "AccountsTable", "password", "surname", surname);
                    txtPassword.Text = AM.ReadPassword(lbStatus, "AccountsTable", "password", "surname", surname); 
                    break;
                case "студент": 
                    //AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
                    password = AM.ReadPassword(lbStatus, "AdminTable", "password");
                    txtPassword.Text = AM.ReadPassword(lbStatus, "AdminTable", "password");
                    break;
                default: lbStatus.Text = "Неопределён тип ползователя!"; break;
            }

        }

        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSelectUser.Text = "";

            if (cbSelectGroup.SelectedItem.ToString() == "добавить группу")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatus, cbSelectGroup, AM, "GroupsTable", "group_name", "группу");
                form.Show();
            }
            else
            {
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Clear();
                cbSelectUser.Items.Add("добавить");
                AM.ReadAllName(lbStatus, cbSelectUser, cbSelectGroup.SelectedItem.ToString());
            }
        }
    }
}
