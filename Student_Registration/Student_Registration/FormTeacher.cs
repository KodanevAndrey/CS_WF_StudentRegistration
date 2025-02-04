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
        private MagazinesManager MM = new MagazinesManager();

        private Dictionary<string,string> TeacherProfile = new Dictionary<string, string>();
        private string Login;

        public FormTeacher(string login, AccountManager manager)
        {
            InitializeComponent();
            this.Login = login;
            this.AM = manager;
            LoadProfile();
            LoadGroupNames();
        }

        private void LoadProfile()
        {
            AM.ConnectDB(lbSatusProfile, "TeacherAccounts.sqlite");
            string _surname = AM.ReadOneValue(lbSatusProfile, "AccountsTable","surname","login",Login);
            TeacherProfile = AM.ReadSelectedOnlyRow(lbSatusProfile,"NULL", _surname);
            foreach (string key in TeacherProfile.Keys)
            {
                richTextBox1.Text += key + " | " + TeacherProfile[key] + "\n";
            }
        }

        private void LoadGroupNames()
        {
            AM.ConnectDB(lbStatusDiarist, "StudentsAccounts.sqlite");
            cbSelectGroup.Text = "";
            cbSelectGroup.SelectedItem = "";
            cbSelectGroup.Items.Clear();
            foreach (string item in AM.GetNameAllGroups(lbStatusDiarist)) cbSelectGroup.Items.Add(item);
        }

        private void btnCreateNewMagazine_Click(object sender, EventArgs e)
        {
            if(cbSelectGroup.SelectedItem != null)
            {
                string MagazineName = "Magazine_" + cbSelectGroup.SelectedItem;
                List<string> StudentsSNP = AM.GetAllUsersSNP(cbSelectGroup.SelectedItem.ToString(), "forDB");
                MM.ConnectDB(lbStatusDiarist,"TeacherAccounts.sqlite");
                string altNameDistsiplina = MM.GetDistsiplinaAltName(TeacherProfile["uchebnaya_distsiplina_name"]);
                MM.CreateNewMagazine(lbStatusDiarist, MagazineName, altNameDistsiplina , StudentsSNP);
            }
            else
            {
                lbStatusDiarist.Text = "Выберите группу для которой будет создан журнал!";
            }
        }
    }
}
