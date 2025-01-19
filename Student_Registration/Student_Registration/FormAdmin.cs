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
        private AccountManager AM = new AccountManager();
        private Dictionary<string, string> data = new Dictionary<string, string>();
        private bool IsDataChanged = false;
        private bool IsAdding = false;
        private Color color = Color.Yellow;

        private FormSelectedOpenTable form;
        public DBHelper db = new DBHelper();
        private string DBName = null;
        private string TableName = null;
        private List<string> listColumns = new List<string>();

        public FormAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 200);
            this.MaximizeBox = false;
            CBColumnType.SelectedItem = "INTEGER";
            EnabledAllTextElementsToAM(false);
            EnabledAllButtonToConnectDB(false);
            cbSelectGroup.Enabled = false;
            btnAddOrUpdateUser.Enabled = false;
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

        private void btnConnectDB_Click(object sender, EventArgs e) => Connect();
        private void btnReadDB_Click(object sender, EventArgs e) => db.ReadDB(lbStatusText,dgvViewer);
        private void btnAddDB_Click(object sender, EventArgs e) => db.AddDB(lbStatusText,lbCommand,dgvViewer);
        private void btnAddImageDB_Click(object sender, EventArgs e) => db.AddImageToDB(lbStatusText, lbCommand, dgvViewer);
        private void btnResetDB_Click(object sender, EventArgs e) => db.ResetDB(lbStatusText, lbCommand, dgvViewer);
        private void btnDeleteDB_Click(object sender, EventArgs e) => db.DeleteDB(lbStatusText, lbCommand, dgvViewer);
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
            cbSelectUser.Enabled = IsActive;

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
            txtApartmentNumber.Enabled = IsActive;
        }

        private void CheckTextElementClolr()
        {
            IsDataChanged = false;

            if (txtName.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtSurname.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtPatronymic.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtEmail.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtPassword.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtPhone.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtHouseNumber.BackColor == Color.Yellow) IsDataChanged = true;
            if (txtApartmentNumber.BackColor == Color.Yellow) IsDataChanged = true;

            if (cbUchebnayaDistsiplina.BackColor == Color.Yellow) IsDataChanged = true;
            if (cbCity.BackColor == Color.Yellow) IsDataChanged = true;
            if (cbStreet.BackColor == Color.Yellow) IsDataChanged = true;

            if (IsDataChanged)
            {
                btnAddOrUpdateUser.Enabled = true;
                btnAddOrUpdateUser.Text = "ИЗМЕНЕНИЕ!";
            }
            else
            {
                btnAddOrUpdateUser.Enabled = false;
                btnAddOrUpdateUser.Text = "норм))";
            }
        }

        private void ReturnTextElementsSettingsToDefault()
        {
            Color localColor = Color.White;

            IsDataChanged = false;
            btnAddOrUpdateUser.Enabled = false;
            btnAddOrUpdateUser.Text = "норм))";
            txtName.BackColor = localColor;
            txtSurname.BackColor = localColor;
            txtPatronymic.BackColor = localColor;
            txtEmail.BackColor = localColor;
            txtPassword.BackColor = localColor;
            txtPhone.BackColor = localColor;
            txtHouseNumber.BackColor = localColor;
            txtApartmentNumber.BackColor = localColor;

            cbUchebnayaDistsiplina.BackColor = localColor;
            cbCity.BackColor = localColor;
            cbStreet.BackColor = localColor;
        }

        private void ClearAllComboBoxElements()
        {
            cbUchebnayaDistsiplina.Text = "";
            cbCity.Text = "";
            cbStreet.Text = "";
        }

        private void ClearAllTextElements()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtPatronymic.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtHouseNumber.Text = "";
            txtApartmentNumber.Text = "";
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
            ReturnTextElementsSettingsToDefault();

            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                ClearAllTextElements();
                ClearAllComboBoxElements();
                EnabledAllTextElementsToAM(false);
                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";
                cbSelectGroup.Enabled = false;

                cbSelectUser.Text = "";
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Clear();
                cbSelectUser.Items.Add("добавить");

                ReturnTextElementsSettingsToDefault();

                label6.Text = "учитель";
                label10.Text = "дисциплина";
                AM.ConnectDB(lbStatusAM, "TeacherAccounts.sqlite");
                AM.ReadAllName(lbStatusAM, cbSelectUser, "AccountsTable");
                AM.LoadAllItemsForComboBox(cbUchebnayaDistsiplina, "UchebnayaDistsiplinaTable", "uchebnaya_distsiplina_name");
                AM.LoadAllItemsForComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllItemsForComboBox(cbStreet, "StreetTable", "street_name");
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                ClearAllTextElements();
                ClearAllComboBoxElements();
                EnabledAllTextElementsToAM(false);
                cbSelectGroup.Enabled = true;

                cbSelectUser.Text = "";
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Clear();
                cbSelectUser.Items.Add("добавить");

                ReturnTextElementsSettingsToDefault();

                label6.Text = "студент";
                label10.Text = "группа";
                AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
                AM.ReadCountTables(lbStatusAM, cbSelectGroup);
                AM.LoadAllItemsForComboBox(cbUchebnayaDistsiplina, "GroupsTable", "group_name");
                AM.LoadAllItemsForComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllItemsForComboBox(cbStreet, "StreetTable", "street_name");
            }
        }

        private void cbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TableName = "NULL";

            if (cbSelectUser.SelectedItem.ToString() == "добавить")
            {
                IsAdding = true;
                ReturnTextElementsSettingsToDefault();
                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();
                btnAddOrUpdateUser.Enabled = true;
                btnAddOrUpdateUser.Text = "Add";
            }
            else
            {
                if(cbSelectGroup.Enabled == true)
                    TableName = cbSelectGroup.SelectedItem.ToString();

                string str = cbSelectUser.Text;
                string surname = null;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ') break;
                    surname += str[i];
                }
                //MessageBox.Show("фамилия = " + surname);
                data = AM.ReadSelectedOnlyRow(lbStatusText, surname, TableName);
                ReturnTextElementsSettingsToDefault();
                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();

                if (cbUserType.SelectedItem.ToString() == "перподаватель")
                {
                    cbUchebnayaDistsiplina.SelectedItem = data["uchebnaya_distsiplina_name"];
                    cbUchebnayaDistsiplina.Text = data["uchebnaya_distsiplina_name"];
                }
                else if (cbUserType.SelectedItem.ToString() == "студент") 
                {
                    cbUchebnayaDistsiplina.SelectedItem = data["group_name"];
                    cbUchebnayaDistsiplina.Text = data["group_name"];
                }

                txtName.Text = data["name"].ToString();
                txtSurname.Text = data["surname"].ToString();
                txtPatronymic.Text = data["patronymic"].ToString();
                txtEmail.Text = data["email"].ToString();
                txtPassword.Text = data["password"].ToString();
                txtPhone.Text = data["phone_number"].ToString();
                cbCity.SelectedItem = data["city_name"];
                cbCity.Text = data["city_name"];
                cbStreet.SelectedItem = data["street_name"];
                cbStreet.Text = data["street_name"];
                txtHouseNumber.Text = data["house_number"].ToString();
                txtApartmentNumber.Text = data["apartment_number"].ToString();
                IsAdding = false;
            }
        }


        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReturnTextElementsSettingsToDefault();
            EnabledAllTextElementsToAM(false);
            ClearAllComboBoxElements();
            ClearAllTextElements();
            cbSelectUser.Text = "";

            if (cbSelectGroup.SelectedItem.ToString() == "добавить группу")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbSelectGroup, AM, "GroupsTable", "group_name", "группу");
                form.Show();
            }
            else
            {
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Clear();
                cbSelectUser.Items.Add("добавить");
                AM.ReadAllName(lbStatusAM,cbSelectUser,cbSelectGroup.SelectedItem.ToString());
            }
        }

        private void cbUchebnayaDistsiplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUchebnayaDistsiplina.SelectedItem.ToString() == "добавить дисциплину")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbUchebnayaDistsiplina, AM, "UchebnayaDistsiplinaTable", "uchebnaya_distsiplina_name", "дисциплину");
                form.Show();
            }
            if (cbUchebnayaDistsiplina.SelectedItem.ToString() == "добавить группу")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbUchebnayaDistsiplina, AM, "GroupsTable", "group_name", "группу");
                form.Show();
            }
            if (!IsAdding)
            {
                if (cbUserType.SelectedItem.ToString() == "перподаватель")
                {
                    if (cbUchebnayaDistsiplina.SelectedItem.ToString() == data["uchebnaya_distsiplina_name"]) cbUchebnayaDistsiplina.BackColor = Color.White;
                    else { cbUchebnayaDistsiplina.BackColor = color; }
                }
                else if (cbUserType.SelectedItem.ToString() == "студент")
                {
                    if (cbUchebnayaDistsiplina.SelectedItem.ToString() == data["group_name"]) cbUchebnayaDistsiplina.BackColor = Color.White;
                    else { cbUchebnayaDistsiplina.BackColor = color; }
                }
                CheckTextElementClolr();
            }
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCity.SelectedItem.ToString() == "добавить город")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbCity, AM, "CityTable", "city_name", "город");
                form.Show();
            }
            if (!IsAdding)
            {
                if (cbCity.SelectedItem.ToString() == data["city_name"]) cbCity.BackColor = Color.White;
                else { cbCity.BackColor = color; }
                CheckTextElementClolr();
            }
        }

        private void cbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStreet.SelectedItem.ToString() == "добавить улицу")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbStreet, AM, "StreetTable", "street_name", "улицу");
                form.Show();
            }
            if (!IsAdding)
            {
                if (cbStreet.SelectedItem.ToString() == data["street_name"]) cbStreet.BackColor = Color.White;
                else { cbStreet.BackColor = color; }
                CheckTextElementClolr();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtName.Text))
            if (!IsAdding)
            {
                if (txtName.Text != data["name"]) txtName.BackColor = color;
                else txtName.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtSurname.Text != data["surname"]) txtSurname.BackColor = color;
                else txtSurname.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtPatronymic_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtPatronymic.Text != data["patronymic"]) txtPatronymic.BackColor = color;
                else txtPatronymic.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtEmail.Text != data["email"]) txtEmail.BackColor = color;
                else txtEmail.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtPassword.Text != data["password"]) txtPassword.BackColor = color;
                else txtPassword.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtPhone.Text != data["phone_number"]) txtPhone.BackColor = color;
                else txtPhone.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtHouseNumber_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtHouseNumber.Text != data["house_number"]) txtHouseNumber.BackColor = color;
                else txtHouseNumber.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void txtApartmentNumber_TextChanged(object sender, EventArgs e)
        {
            if (!IsAdding)
            {
                if (txtApartmentNumber.Text != data["apartment_number"]) txtApartmentNumber.BackColor = color;
                else txtApartmentNumber.BackColor = Color.White;
                CheckTextElementClolr();
            }
        }

        private void btnAddOrUpdateUser_Click(object sender, EventArgs e)
        {
            if (IsAdding)
            {
                List<string> _columns = new List<string>();
                List<string> _data = new List<string>();

                if(AM.CheckForValidity(lbStatusAM, txtName.Text, "name")) _data.Add(txtName.Text);
                if (AM.CheckForValidity(lbStatusAM, txtSurname.Text, "name")) _data.Add(txtSurname.Text);
                if (AM.CheckForValidity(lbStatusAM, txtPatronymic.Text, "name")) _data.Add(txtPatronymic.Text);
                if(AM.CheckForValidity(lbStatusAM, cbUchebnayaDistsiplina.Text, "onlyInt"))_data.Add(cbUchebnayaDistsiplina.SelectedIndex.ToString());
                if(AM.CheckForValidity(lbStatusAM, txtEmail.Text, "noInt"))_data.Add(txtEmail.Text);
                _data.Add(txtPassword.Text);
                if(AM.CheckForValidity(lbStatusAM, txtPhone.Text, "onlyInt"))_data.Add(txtPhone.Text);
                if(AM.CheckForValidity(lbStatusAM, cbCity.Text, "onlyInt"))_data.Add(cbCity.SelectedIndex.ToString());
                if(AM.CheckForValidity(lbStatusAM, cbStreet.Text, "onlyInt"))_data.Add(cbStreet.SelectedIndex.ToString());
                if(AM.CheckForValidity(lbStatusAM, txtHouseNumber.Text, "onlyInt"))_data.Add(txtHouseNumber.Text);
                if (AM.CheckForValidity(lbStatusAM, txtApartmentNumber.Text, "onlyInt")) _data.Add(txtApartmentNumber.Text);

                /*
                if (cbUserType.SelectedItem.ToString() == "перподаватель")
                {
                    _columns = AM.GetTableInfo(lbStatusAM, "AccountsTable");
                    AM.AddNewUserDB(lbStatusAM, "AccountsTable", _columns, _data);
                }
                else if(cbUserType.SelectedItem.ToString() == "студент")
                {
                    _columns = AM.GetTableInfo(lbStatusAM, cbSelectGroup.SelectedItem.ToString());
                    AM.AddNewUserDB(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns, _data);
                }
                */
            }

        }
    }
}