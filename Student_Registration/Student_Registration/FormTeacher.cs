using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormTeacher : Form
    {

        public enum ResultTypes
        {
            forUser = 0,
            forDB = 1,
        }

        private readonly IAccountManager AM;
        private readonly ITeacher IT = new MagazinesManager();

        private Dictionary<string,string> TeacherProfile = new Dictionary<string, string>();
        private string Login;

        public FormTeacher(string login, AccountManager accauntManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.Login = login;
            this.AM = accauntManager;
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
                richTextBox1.Text += String.Format("{0,-20}{1,20}\n", key, TeacherProfile[key]);
            }
            txtDistsiplina.Text = TeacherProfile["disciplina_name"];
        }

        private void LoadGroupNames()
        {
            AM.ConnectDB(lbStatusText, "StudentsAccounts.sqlite");
            cbSelectGroup.Text = "";
            cbSelectGroup.SelectedItem = "";
            cbSelectGroup.Items.Clear();
            foreach (string item in AM.GetNamesAllGroups(lbStatusText)) cbSelectGroup.Items.Add(item);
        }

        private void btnCreateNewMagazine_Click(object sender, EventArgs e)
        {
            string MagazineName = "Magazine_" + cbSelectGroup.SelectedItem;
            List<string> StudentsSNP = AM.GetAllUsersSNP(cbSelectGroup.SelectedItem.ToString(), "forDB");
            IT.ConnectDB(lbStatusText, "TeacherAccounts.sqlite");
            string altNameDistsiplina = IT.GetDistsiplinaAltName(TeacherProfile["disciplina_name"]);
            IT.CreateNewTableInMagazine(lbStatusText, MagazineName, altNameDistsiplina, StudentsSNP);
            btnCreateNewMagazine.Enabled = false;
        }

        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            IT.ConnectDB(lbSatusProfile, "TeacherAccounts.sqlite");
            string altNameDistsiplina = IT.GetDistsiplinaAltName(TeacherProfile["disciplina_name"]);

        
            if (IT.ConnectDB(lbSatusProfile, "Magazine_" + cbSelectGroup.SelectedItem.ToString() + ".sqlite"))
            {
                if (IT.CheckTableExistence(lbStatusText, altNameDistsiplina))
                {
                    btnCreateNewMagazine.Enabled = false;
                    IT.SelectedTable(altNameDistsiplina);
                    IT.GetTableInfo(lbStatusText);
                    IT.LoadTableInfo(lbStatusText, dgvViewer, altNameDistsiplina);
                    IT.ReadDB(lbStatusText, dgvViewer);
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

        private void btnReadDB_Click(object sender, EventArgs e) => IT.ReadDB(lbStatusText, dgvViewer);
        private void btnAddDB_Click(object sender, EventArgs e) => IT.AddDB(lbStatusText, lbCommand, dgvViewer);
        private void btnResetDB_Click(object sender, EventArgs e) => IT.ResetDB(lbStatusText, lbCommand, dgvViewer);
        private void btnDeleteDB_Click(object sender, EventArgs e) => IT.DeleteDB(lbStatusText, lbCommand, dgvViewer);
        private void btnDeleteAllDB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("вы уверены что хотите удалить ВСЕ данные таблицы?", "Удаление всех данных", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                IT.DeleteAllDB(lbStatusText);
                IT.ReadDB(lbStatusText, dgvViewer);
            }
        }

        private void dgvViewer_Click(object sender, EventArgs e)
        {
            IT.SelectCellInTable(lbStatusText, dgvViewer);
        }

    }
}
