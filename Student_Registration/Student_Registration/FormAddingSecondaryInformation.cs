using System;
using System.Drawing;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormAddingSecondaryInformation : Form
    {
        private string TableName;
        private string ColumnName;
        private IAccountManager AM;
        private MagazinesManager MM;
        private Label labelS;
        private ComboBox comboBox1;

        public FormAddingSecondaryInformation(Label lbSatus, ComboBox comboBox, IAccountManager accountManager, in string tableName, in string columnName, in string RankAdded)
        {
            InitializeComponent();
            MM = new MagazinesManager();
            txtEnglName.Enabled = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 350);
            this.MaximizeBox = false;
            this.AM = accountManager;
            this.labelS = lbSatus;
            this.comboBox1 = comboBox;
            this.TableName = tableName;
            this.ColumnName = columnName;
            this.btnAdd.Text = "добввить " + RankAdded;
            if (TableName == "DisciplinesTable") txtEnglName.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TableName == "GroupsTable")
            {
                AM.CreateNewGroup(lbStatus, txtEnter.Text);
                CreateMagazine();
            }
            else if (TableName == "DisciplinesTable")
            {
                AM.AddDistsiplina(lbStatus, txtEnter.Text, txtEnglName.Text);
            }
            else
            {
                AM.AddSecondaryInfo(labelS, txtEnter, TableName, ColumnName);
            }

            if (TableName == "GroupsTable") AM.ConnectDB(lbStatus, "StudentsAccounts.sqlite");
            AM.LoadAllSecondaryItemsInComboBox(comboBox1, TableName, ColumnName);
            comboBox1.SelectedItem = txtEnter.Text;
            comboBox1.Text = txtEnter.Text;
            this.Close();
        }

        private void CreateMagazine()
        {
            MM.CreateNewMagazine(lbStatus, txtEnter.Text, "BaseInfo");
        }

        private void txtEnter_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEnter.Text))
                txtEnter.BackColor = Color.White;
            else
                txtEnter.BackColor = Color.Orange;
            CheckTextBoxesForCompleteness();
        }

        private void txtEnglName_TextChanged(object sender, EventArgs e)
        {
            if (AM.CheckForValidity(lbStatus, txtEnglName.Text, "onlyEngl"))
                txtEnglName.BackColor = Color.White;
            else
                txtEnglName.BackColor = Color.Orange;
            CheckTextBoxesForCompleteness();
        }

        private void CheckTextBoxesForCompleteness()
        {
            if (TableName == "DisciplinesTable")
            {
                if (string.IsNullOrEmpty(txtEnter.Text) || string.IsNullOrEmpty(txtEnglName.Text))
                {
                    lbStatus.Text = "Заполните оба текстового поля!";
                    btnAdd.Enabled = false;
                }
                else if (txtEnter.BackColor == Color.Orange || txtEnglName.BackColor == Color.Orange)
                    btnAdd.Enabled = false;
                else
                    btnAdd.Enabled = true;
            }
            else 
            {
                if (string.IsNullOrEmpty(txtEnter.Text) || txtEnter.BackColor == Color.Orange)
                    btnAdd.Enabled = false;
                else
                    btnAdd.Enabled = true;
            }
        }
    }
}
