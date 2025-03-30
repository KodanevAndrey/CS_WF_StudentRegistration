using System;
using System.IO;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            CheckToExistsFiles();
        }

        private void CheckToExistsFiles()
        {
            if (!File.Exists("TeacherAccounts.sqlite")) 
            {
                MessageBox.Show("TeacherAccounts.sqlite not exist!");
                AM.CreateTeacherAccounts(lbStatus); 
            }
        }

        private void LoadLoginAndPassword()
        {
            if (cbUserType.SelectedItem != null)
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
                    Login = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
                    Password = AM.ReadOneValue(lbStatus, "AdminTable", "password", "login", "Admin");
                }
            }
            else lbStatus.Text = "выберите тип пользователя!";
        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLogin.Enabled = true;
            txtLogin.Text = "";
            txtPassword.Text = "";
            if (cbUserType.SelectedItem.ToString() == "администратор")
            {
                txtLogin.Enabled = false;
                AM.ConnectDB(lbStatus, "Admin.sqlite");
                txtLogin.Text = AM.ReadOneValue(lbStatus, "AdminTable", "login", "login", "Admin");
            }
        }

        private void btnSimgIn_Click(object sender, EventArgs e)
        {
            LoadLoginAndPassword();

            if (Login == txtLogin.Text && Password == txtPassword.Text)
                switch (cbUserType.SelectedItem.ToString())
                {
                    case "администратор": OpenForm(new FormAdmin()); break;
                    case "преподаватель": OpenForm(new FormTeacher(Login,AM)); break;
                    case "студент": OpenForm(new FormStudent(Login,AM)); break;
                    default: lbStatus.Text = "Неопределён тип ползователя!"; break;
                }
            else if (Login == txtLogin.Text && Password != txtPassword.Text)
            {
                lbStatus.Text = "Введён неверный пароль!";
            }
        }

        private void OpenForm(Form form) => form.Show();
    }
}
