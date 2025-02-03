using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormTeacher : Form
    {
        private AccountManager AM;

        private Dictionary<string,string> TeacherProfile = new Dictionary<string, string>();
        private string Login;

        public FormTeacher(string login, AccountManager manager)
        {
            InitializeComponent();
            this.Login = login;
            this.AM = manager;
            LoadProfile();
        }

        private void LoadProfile()
        {
            string _surname = AM.ReadOneValue(lbSatus, "AccountsTable","surname","login",Login);
            TeacherProfile = AM.ReadSelectedOnlyRow(lbSatus,"NULL", _surname);
            foreach (string key in TeacherProfile.Keys)
            {
                richTextBox1.Text += key + " | \t" + TeacherProfile[key] + "\n";
            }
        }
    }
}
