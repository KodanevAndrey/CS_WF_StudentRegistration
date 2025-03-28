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

        private readonly IAccountManager AM;
        private readonly IMagazinesManager MM = new MagazinesManager();

        private Dictionary<string,string> TeacherProfile = new Dictionary<string, string>();
        private string Login;

        public FormTeacher(string login, AccountManager manager)
        {
            InitializeComponent();
            this.Login = login;
            this.AM = manager;
            LoadProfile();
            LoadGroupNames();
            txtDistsiplina.Enabled = false;
            btnCreateNewMagazine.Enabled = false;
            EnabledAllButtonToConnectDB(false);
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
            txtDistsiplina.Text = TeacherProfile["uchebnaya_distsiplina_name"];
        }

        private void LoadGroupNames()
        {
            AM.ConnectDB(lbStatusText, "StudentsAccounts.sqlite");
            cbSelectGroup.Text = "";
            cbSelectGroup.SelectedItem = "";
            cbSelectGroup.Items.Clear();
            foreach (string item in AM.GetNameAllGroups(lbStatusText)) cbSelectGroup.Items.Add(item);
        }

        private void btnCreateNewMagazine_Click(object sender, EventArgs e)
        {
            string MagazineName = "Magazine_" + cbSelectGroup.SelectedItem;
            List<string> StudentsSNP = AM.GetAllUsersSNP(cbSelectGroup.SelectedItem.ToString(), "forDB");
            MM.ConnectDB(lbStatusText, "TeacherAccounts.sqlite");
            string altNameDistsiplina = MM.GetDistsiplinaAltName(TeacherProfile["uchebnaya_distsiplina_name"]);
            MM.CreateNewTableInMagazine(lbStatusText, MagazineName, altNameDistsiplina, StudentsSNP);
            btnCreateNewMagazine.Enabled = false;
        }

        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            MM.ConnectDB(lbSatusProfile, "TeacherAccounts.sqlite");
            string altNameDistsiplina = MM.GetDistsiplinaAltName(TeacherProfile["uchebnaya_distsiplina_name"]);

        
            if (MM.ConnectDB(lbSatusProfile, "Magazine_" + cbSelectGroup.SelectedItem.ToString() + ".sqlite"))
            {
                if (MM.CheckTableExistence(lbStatusText, altNameDistsiplina))
                {
                    btnCreateNewMagazine.Enabled = false;
                    MM.SelectedTable(altNameDistsiplina);
                    MM.GetTableInfo(lbStatusText);
                    MM.LoadTableInfo(lbStatusText, dgvViewer, altNameDistsiplina);
                    MM.ReadDB(lbStatusText, dgvViewer);
                    EnabledAllButtonToConnectDB(true);
                }
                else
                {
                    btnCreateNewMagazine.Enabled = true;
                }
            }
        }

        private void EnabledAllButtonToConnectDB(bool IsActive)
        {
            btnReadDB.Enabled = IsActive;
            btnAddDB.Enabled = IsActive;
            btnResetDB.Enabled = IsActive;
            btnDeleteDB.Enabled = IsActive;
            btnDeleteAllDB.Enabled = IsActive;
        }

        private void btnReadDB_Click(object sender, EventArgs e) => MM.ReadDB(lbStatusText, dgvViewer);
        private void btnAddDB_Click(object sender, EventArgs e) => MM.AddDB(lbStatusText, lbCommand, dgvViewer);
        private void btnResetDB_Click(object sender, EventArgs e) => MM.ResetDB(lbStatusText, lbCommand, dgvViewer);
        private void btnDeleteDB_Click(object sender, EventArgs e) => MM.DeleteDB(lbStatusText, lbCommand, dgvViewer);
        private void btnDeleteAllDB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("вы уверены что хотите удалить ВСЕ данные таблицы?", "Удаление всех данных", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MM.DeleteAllDB(lbStatusText);
                MM.ReadDB(lbStatusText, dgvViewer);
            }
        }

        private void dgvViewer_Click(object sender, EventArgs e)
        {
            MM.SelectCellToTable(lbStatusText, dgvViewer);
        }

    }
}
