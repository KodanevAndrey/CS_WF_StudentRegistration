using ConnectSQLite_KodanevAndrey;
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
    public partial class FormAdmin : Form
    {
        private FormSelectedOpenTable form;
        public DBHelper db = new DBHelper();
        private AccountManager AM = new AccountManager();

        private string DBName = null;
        private string TableName = null;
        private List<string> listColumns = new List<string>();

        public FormAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 300);
            this.MaximizeBox = false;
            CBColumnType.SelectedItem = "INTEGER";
            EnabledAllTextElementsToAM(false);
            EnabledAllButtonToConnectDB(false);
            cbSelectGroup.Enabled = false;
            cbSelectUser.Enabled = false;

            txtNewGroup.Enabled = false;
            btnCreateNewGroup.Enabled = false;
        }

        public void Connect()
        {
            if (db.ConnectDB(lbStatusText))
            {
                //db.LoadCountTables(lbStatusText);
                form = new FormSelectedOpenTable(db);
                form.ShowDialog();
                db.GetTableInfo(lbStatusText);
                db.LoadTableInfo(lbStatusText, dgvViewer);
                db.ReadDB(lbStatusText, dgvViewer);
                EnabledAllButtonToConnectDB(true);
            }
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnReadDB_Click(object sender, EventArgs e)
        {
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            db.AddDB(lbStatusText,lbCommand,dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnAddImageDB_Click(object sender, EventArgs e)
        {
            db.AddImageToDB(lbStatusText, lbCommand, dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnResetDB_Click(object sender, EventArgs e)
        {
            db.ResetDB(lbStatusText,lbCommand,dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            db.DeleteDB(lbStatusText, lbCommand);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnDeleteAllDB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("вы уверены что хотите удалить ВСЕ данные таблицы?", "Удаление всех данных", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db.DeleteAllDB(lbStatusText);
                db.ReadDB(lbStatusText, dgvViewer);
            }
        }

        private void dgvViewer_Click(object sender, EventArgs e)
        {
            db.SelectCellToTable(lbStatusText, dgvViewer);
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            lbStatus.ForeColor = Color.Red;
            if (txtDBName.Text != "")
            {
                DBName = txtDBName.Text;
                if (txtTableName.Text != "")
                {
                    TableName = txtTableName.Text;
                    if (listColumns.Count > 0)
                    {
                        //listColumns.Add("_time TEXT");
                        db.CreateNewDB(lbStatus, DBName, TableName, listColumns);
                        listColumns.Clear();
                        txtDBName.Clear();
                        txtTableName.Clear();
                        txtColumnName.Clear();
                        CBColumnType.SelectedItem = "INTEGER";
                    }
                    else lbStatus.Text = "создайте столбцы в таблице!";
                }
                else lbStatus.Text = "введите имя для таблицы!";
            }
            else lbStatus.Text = "введите имя для новой базы данных!";
        }

        private void EnabledAllButtonToConnectDB(bool IsActive)
        {
            btnReadDB.Enabled = IsActive;
            btnAddDB.Enabled = IsActive;
            btnAddImageDB.Enabled = IsActive;
            btnResetDB.Enabled = IsActive;
            btnDeleteDB.Enabled = IsActive;
            btnDeleteAllDB.Enabled = IsActive;
        }

        private void EnabledAllTextElementsToAM(bool IsActive)
        {
            txtName.Enabled = IsActive;
            txtSurname.Enabled = IsActive;
            txtPatronymic.Enabled = IsActive;
            cbUchebnayaDistsiplina.Enabled = IsActive;
            txtEmail.Enabled = IsActive;
            txtPassword.Enabled = IsActive;
            txtPhone.Enabled = IsActive;
            cbCity.Enabled = IsActive;
            cbStreet.Enabled = IsActive;
            txtHouseNumber.Enabled = IsActive;
            txtapArtmentNumber.Enabled = IsActive;
        }

        private void ClearAllTextElements()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtPatronymic.Text = "";
            cbUchebnayaDistsiplina.SelectedItem = null;
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            cbCity.SelectedItem = null;
            cbStreet.SelectedItem = null;
            txtHouseNumber.Text = "";
            txtapArtmentNumber.Text = "";
        }

        private void btnAddColum_Click(object sender, EventArgs e)
        {
            if (txtColumnName.Text != "")
            {
                listStringColums.Items.Add(txtColumnName.Text + " " + CBColumnType.SelectedItem.ToString());
                listColumns.Add(txtColumnName.Text + " " + CBColumnType.SelectedItem.ToString());
                txtColumnName.Text = "";
            }
            else lbStatus.Text = "введите имя для создания столбца в таблицые!";
        }

        private void btnDeleteColum_Click(object sender, EventArgs e)
        {
            bool IsError = true;
            for (int i = 0; i < listStringColums.Items.Count; i++)
            {
                if (listStringColums.SelectedItem == listStringColums.Items[i])
                {
                    IsError = false;
                    listColumns.Remove(listColumns[i]);
                }
            }
            if (IsError) MessageBox.Show("выберите пункт в списке чтобы удалить столбец!");
            else listStringColums.Items.Remove(listStringColums.SelectedItem);
        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                ClearAllTextElements();
                EnabledAllTextElementsToAM(false);
                cbSelectGroup.Items.Clear();
                cbSelectGroup.SelectedItem = null;
                cbSelectGroup.Enabled = false;

                label6.Text = "учитель";
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Add("добавить");
                AM.ConnectDB(lbStatusAM, "TeacherAccounts.sqlite");
                AM.ReadAllName(lbStatusAM, cbSelectUser);
                AM.LoadAllItemsForComboBox(cbUchebnayaDistsiplina, "UchebnayaDistsiplinaTable", "uchebnaya_distsiplina_name");
                AM.LoadAllItemsForComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllItemsForComboBox(cbStreet, "StreetTable", "street_name");
            }
            if (cbUserType.SelectedItem.ToString() == "студент")
            {
                ClearAllTextElements();
                EnabledAllTextElementsToAM(false);
                cbSelectUser.SelectedItem = null;
                cbSelectUser.Items.Clear();

                label6.Text = "студент";
                cbSelectGroup.Enabled = true;
                cbSelectUser.Enabled = true;
                btnCreateNewGroup.Enabled = true;
                txtNewGroup.Enabled = true;
                cbSelectGroup.Items.Add("добавить группу");
                cbSelectUser.Items.Add("добавить");
                AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
                //
                //
                AM.LoadAllItemsForComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllItemsForComboBox(cbStreet, "StreetTable", "street_name");
            }
        }

        private void cbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSelectUser.SelectedItem.ToString() == "добавить")
            {
                EnabledAllTextElementsToAM(true);
                ClearAllTextElements();
            }
            else
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                data = AM.ReadSelectedRecord(lbStatusText, cbSelectUser.SelectedIndex);

                EnabledAllTextElementsToAM(true);

                txtName.Text = data["name"].ToString();
                txtSurname.Text = data["surname"].ToString();
                txtPatronymic.Text = data["patronymic"].ToString();

                cbUchebnayaDistsiplina.SelectedItem = data["uchebnaya_distsiplina_name"];

                txtEmail.Text = data["email"].ToString();
                txtPassword.Text = data["password"].ToString();
                txtPhone.Text = data["phone_number"].ToString();

                cbCity.SelectedItem = data["city_name"];

                cbStreet.SelectedItem = data["street_name"];

                txtHouseNumber.Text = data["house_number"].ToString();
                txtapArtmentNumber.Text = data["apartment_number"].ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AM.CreateNewTable(lbStatusAM, txtNewGroup.Text);
        }
    }
}
