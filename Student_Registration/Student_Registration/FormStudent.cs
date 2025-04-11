using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormStudent : Form
    {
        private readonly IAccountManager AM;
        private readonly IStudent IS = new MagazinesManager();

        private Dictionary<string, string> StudentProfile = new Dictionary<string, string>();
        private string Login;

        public FormStudent(string login, AccountManager manager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.Login = login;
            this.AM = manager;
            LoadProfile();
            LoadDisciplines();
            txtDistsiplina.Enabled = false;
            btnReadDB.Enabled = false;
        }

        private void LoadProfile()
        {
            AM.ConnectDB(lbSatusProfile, "StudentsAccounts.sqlite");
            string studentSurname = AM.ReadAllGroups(lbStatusText, "surname", "login", Login);
            string GroupName = AM.GetGroupName(lbStatusText, "group_name", "login", Login);
            StudentProfile = AM.ReadSelectedOnlyRow(lbSatusProfile, GroupName, studentSurname);
            foreach (string key in StudentProfile.Keys)
            {
                richTextBox1.Text += String.Format("{0,-20}{1,20}\n", key, StudentProfile[key]);
            }
            txtDistsiplina.Text = StudentProfile["group_name"];
        }

        private void LoadDisciplines()
        {
            IS.ConnectDB(lbSatusProfile, "Magazine_" + StudentProfile["group_name"] + ".sqlite");
            cbSelectDiscipline.Text = "";
            cbSelectDiscipline.SelectedItem = "";
            cbSelectDiscipline.Items.Clear();
            foreach (string item in IS.GetNamesAllDisciplines(lbStatusText)) cbSelectDiscipline.Items.Add(item);
        }

        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            IS.СhosenTable(cbSelectDiscipline.SelectedItem.ToString());
            IS.GetTableInfo(lbStatusText);
            IS.LoadTableInfo(lbStatusText, dgvViewer, cbSelectDiscipline.SelectedItem.ToString());
            IS.ReadDB(lbStatusText, dgvViewer);
            btnReadDB.Enabled = true;
        }

        private void btnReadDB_Click(object sender, EventArgs e) => IS.ReadDB(lbStatusText, dgvViewer);
    }
}
