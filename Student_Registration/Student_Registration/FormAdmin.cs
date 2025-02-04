using ConnectSQLite_KodanevAndrey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Student_Registration
{
    public partial class FormAdmin : Form
    {
        private AccountManager AM = new AccountManager();
        private Dictionary<string, string> UserData = new Dictionary<string, string>();
        private bool IsDataChanged = false;
        private bool IsAdding = false;
        private bool IsNoCorrect = false;
        private Color colorChanged = Color.Yellow;
        private Color colorNoCorrect = Color.Orange;

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
            btnDeleteGroup.Enabled = false;
        }

        public void Connect()
        {
            if (db.ConnectDB(lbStatusText))
            {
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
            btnDeleteUser.Enabled = IsActive;

            txtName.Enabled = IsActive;
            txtSurname.Enabled = IsActive;
            txtPatronymic.Enabled = IsActive;
            cbUchebnayaDistsiplina.Enabled = IsActive;
            txtEmail.Enabled = IsActive;
            txtLogin.Enabled = IsActive;
            txtPassword.Enabled = IsActive;
            txtPhone.Enabled = IsActive;
            cbCity.Enabled = IsActive;
            cbStreet.Enabled = IsActive;
            txtHouseNumber.Enabled = IsActive;
            txtApartmentNumber.Enabled = IsActive;
        }

        private void CheckIsDataChanged()
        {
            if (IsDataChanged)
            {
                btnAddOrUpdateUser.Enabled = true;
                btnAddOrUpdateUser.Text = "Измненить";
            }
            else
            {
                btnAddOrUpdateUser.Enabled = false;
                btnAddOrUpdateUser.Text = "Чтенеие";
            }
        }

        private void CheckIsNoCorrect()
        {
            if (IsNoCorrect)
            {
                btnAddOrUpdateUser.Enabled = false;
                btnAddOrUpdateUser.Text = "Некорректный ввод!";
            }
            else if (!IsNoCorrect && IsAdding)
            {
                btnAddOrUpdateUser.Enabled = true;
                btnAddOrUpdateUser.Text = "Добавить";
            }
            else CheckIsDataChanged();
        }

        private void CheckTextElementClolr(Color color,out bool changeable)
        {
            changeable = false;

            if (txtName.BackColor == color) changeable = true;
            if (txtSurname.BackColor == color) changeable = true;
            if (txtPatronymic.BackColor == color) changeable = true;
            if (txtEmail.BackColor == color) changeable = true;
            if (txtLogin.BackColor == color) changeable = true;
            if (txtPassword.BackColor == color) changeable = true;
            if (txtPhone.BackColor == color) changeable = true;
            if (txtHouseNumber.BackColor == color) changeable = true;
            if (txtApartmentNumber.BackColor == color) changeable = true;

            if (cbUchebnayaDistsiplina.BackColor == color) changeable = true;
            if (cbCity.BackColor == color) changeable = true;
            if (cbStreet.BackColor == color) changeable = true;

            CheckIsNoCorrect();
        }

        private void ReturnTextElementsSettingsToDefault()
        {
            Color localColor = Color.White;

            IsDataChanged = false;
            IsNoCorrect = false;

            btnAddOrUpdateUser.Enabled = false;
            btnAddOrUpdateUser.Text = "Чтение!";
            txtName.BackColor = localColor;
            txtSurname.BackColor = localColor;
            txtPatronymic.BackColor = localColor;
            txtEmail.BackColor = localColor;
            txtLogin.BackColor = localColor;
            txtPassword.BackColor = localColor;
            txtPhone.BackColor = localColor;
            txtHouseNumber.BackColor = localColor;
            txtApartmentNumber.BackColor = localColor;

            cbUchebnayaDistsiplina.BackColor = localColor;
            cbCity.BackColor = localColor;
            cbStreet.BackColor = localColor;
        }

        private bool CheckAllTextElementsToFilled()
        {
            bool NoFilled = false;

            if (txtName.Text == "") NoFilled = true;
            if (txtSurname.Text == "") NoFilled = true;
            if (txtPatronymic.Text == "") NoFilled = true;
            if (txtEmail.Text == "") NoFilled = true;
            if (txtLogin.Text == "") NoFilled = true;
            if (txtPassword.Text == "") NoFilled = true;
            if (txtPhone.Text == "") NoFilled = true;
            if (txtHouseNumber.Text == "") NoFilled = true;
            if (txtApartmentNumber.Text == "") NoFilled = true;

            if (cbUchebnayaDistsiplina.Text == "") NoFilled = true;
            if (cbCity.Text == "") NoFilled = true;
            if (cbStreet.Text == "") NoFilled = true;

            if (NoFilled)
            {
                return false;
            }
            else return true;
        }

        private void ClearAllComboBoxElements()
        {
            cbUchebnayaDistsiplina.Text = "";
            cbUchebnayaDistsiplina.SelectedItem = "";
            cbCity.Text = "";
            cbCity.SelectedItem = "";
            cbStreet.Text = "";
            cbStreet.SelectedItem = "";
        }

        private void ClearAllTextElements()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtPatronymic.Text = "";
            txtEmail.Text = "";
            txtLogin.Text = "";
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

        private void ReloadAllUserDataElements( string surname)
        {
            string str = cbSelectUser.Text;
            if (surname == "NULL")
            {
                surname = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ') break;
                    surname += str[i];
                }
            }
            //data = AM.ReadSelectedOnlyRow(lbStatusText, surname, );
            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                UserData = AM.ReadSelectedOnlyRow(lbStatusText, "NULL", surname);
                cbUchebnayaDistsiplina.SelectedItem = UserData["uchebnaya_distsiplina_name"];
                cbUchebnayaDistsiplina.Text = UserData["uchebnaya_distsiplina_name"];
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                UserData = AM.ReadSelectedOnlyRow(lbStatusText,cbSelectGroup.SelectedItem.ToString(), surname);
                cbUchebnayaDistsiplina.SelectedItem = UserData["group_name"];
                cbUchebnayaDistsiplina.Text = UserData["group_name"];
            }

            txtName.Text = UserData["name"].ToString();
            txtSurname.Text = UserData["surname"].ToString();
            txtPatronymic.Text = UserData["patronymic"].ToString();
            txtEmail.Text = UserData["email"].ToString();
            txtLogin.Text = UserData["login"].ToString();
            txtPassword.Text = UserData["password"].ToString();
            txtPhone.Text = UserData["phone_number"].ToString();
            cbCity.SelectedItem = UserData["city_name"];
            cbCity.Text = UserData["city_name"];
            cbStreet.SelectedItem = UserData["street_name"];
            cbStreet.Text = UserData["street_name"];
            txtHouseNumber.Text = UserData["house_number"].ToString();
            txtApartmentNumber.Text = UserData["apartment_number"].ToString();
            IsAdding = false;
        }

        private void ReloadCBSelectGroup()
        {
            cbSelectGroup.Text = "";
            cbSelectGroup.SelectedItem = "";
            cbSelectGroup.Items.Clear();
            cbSelectGroup.Items.Add("добавить группу");
            foreach (string item in AM.GetNameAllGroups(lbStatusAM)) cbSelectGroup.Items.Add(item);
        }

        private void ReloadCBSelectUser()
        {
            cbSelectUser.Text = "";
            cbSelectUser.SelectedItem = "";
            cbSelectUser.Items.Clear();
            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                cbSelectUser.Items.Add("добавить учителя");
                foreach (string item in AM.GetAllUsersSNP("AccountsTable", "forUser")) cbSelectUser.Items.Add(item);
            }

            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                cbSelectUser.Items.Add("добавить студента");
                foreach (string item in AM.GetAllUsersSNP(cbSelectGroup.SelectedItem.ToString(), "forUser")) cbSelectUser.Items.Add(item);
            }
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
                btnDeleteGroup.Enabled = false;

                cbSelectUser.Enabled = true;

                ReturnTextElementsSettingsToDefault();

                label6.Text = "учитель";
                label10.Text = "дисциплина";
                AM.ConnectDB(lbStatusAM, "TeacherAccounts.sqlite");
                ReloadCBSelectUser();
                //AM.ReadAllName(lbStatusAM, cbSelectUser, "AccountsTable");
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
                btnDeleteGroup.Enabled = false;

                cbSelectUser.Text = "";

                ReturnTextElementsSettingsToDefault();


                label6.Text = "студент";
                label10.Text = "группа";
                AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
                ReloadCBSelectGroup();
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
                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();
                btnAddOrUpdateUser.Enabled = true;
                //btnAddOrUpdateUser.Text = "Add";
                btnDeleteUser.Enabled = false;
                ReturnTextElementsSettingsToDefault();

                if(cbUserType.SelectedItem.ToString() == "студент")
                {
                    cbUchebnayaDistsiplina.SelectedItem = cbSelectGroup.SelectedItem;
                    cbUchebnayaDistsiplina.Text = cbSelectGroup.SelectedItem.ToString();
                    cbUchebnayaDistsiplina.Enabled = false;
                }
            }
            else
            {
                if (cbSelectGroup.Enabled == true)
                    TableName = cbSelectGroup.SelectedItem.ToString();

                ReturnTextElementsSettingsToDefault();
                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();

                ReloadAllUserDataElements("NULL");
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
                btnDeleteGroup.Enabled = false;
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbSelectGroup, AM, "GroupsTable", "group_name", "группу");
                form.Show();
                ReloadCBSelectGroup();
                AM.LoadAllItemsForComboBox(cbUchebnayaDistsiplina, "GroupsTable", "group_name");
                ReturnTextElementsSettingsToDefault();
            }
            else
            {
                btnDeleteGroup.Enabled = true;
                cbSelectUser.Enabled = true;
                cbSelectUser.Items.Clear();
                cbSelectUser.Items.Add("добавить");
                ReloadCBSelectUser();
                btnDeleteGroup.Enabled = true;
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
                    if (cbUchebnayaDistsiplina.SelectedItem.ToString() == UserData["uchebnaya_distsiplina_name"]) cbUchebnayaDistsiplina.BackColor = Color.White;
                    else { cbUchebnayaDistsiplina.BackColor = colorChanged; }
                }
                else if (cbUserType.SelectedItem.ToString() == "студент")
                {
                    if(UserData.Keys.Count > 0)
                    {
                        if (cbUchebnayaDistsiplina.SelectedItem.ToString() == UserData["group_name"]) cbUchebnayaDistsiplina.BackColor = Color.White;
                        else { cbUchebnayaDistsiplina.BackColor = colorChanged; }
                    }
                }
                CheckTextElementClolr(colorChanged, out IsDataChanged);
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
                if (cbCity.SelectedItem.ToString() == UserData["city_name"]) 
                {
                    cbCity.BackColor = Color.White;
                } 
                else 
                { 
                    cbCity.BackColor = colorChanged; 
                }
                CheckTextElementClolr(colorChanged, out IsDataChanged);
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
                if (cbStreet.SelectedItem.ToString() == UserData["street_name"]) cbStreet.BackColor = Color.White;
                else { cbStreet.BackColor = colorChanged; }
                CheckTextElementClolr(colorChanged, out IsDataChanged);
            }
        }

        private void TextElement(TextBox textBox, string ColumnName, string TypeCheck)
        {
            if (!IsAdding)
            {
                if (textBox.Text != UserData[ColumnName]) 
                {
                    textBox.BackColor = colorChanged;
                    if (AM.CheckForValidity(lbStatusAM, textBox.Text, TypeCheck)) textBox.BackColor = colorChanged;
                    else textBox.BackColor = colorNoCorrect;
                    CheckTextElementClolr(colorNoCorrect, out IsNoCorrect);
                }
                else textBox.BackColor = Color.White;
                CheckTextElementClolr(colorChanged, out IsDataChanged);
            }
            else
            {
                if (AM.CheckForValidity(lbStatusAM, textBox.Text, TypeCheck)) textBox.BackColor = Color.White;
                else textBox.BackColor = colorNoCorrect;
                CheckTextElementClolr(colorNoCorrect, out IsNoCorrect);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e) => TextElement(txtName, "name", "name");
        private void txtSurname_TextChanged(object sender, EventArgs e) => TextElement(txtSurname, "surname", "name");
        private void txtPatronymic_TextChanged(object sender, EventArgs e) => TextElement(txtPatronymic, "patronymic", "name");
        private void txtEmail_TextChanged(object sender, EventArgs e) => TextElement(txtEmail, "email", "email");
        private void txtLogin_TextChanged(object sender, EventArgs e) => TextElement(txtLogin, "login", "name");
        private void txtPassword_TextChanged(object sender, EventArgs e) => TextElement(txtPassword, "password", "onlyInt");
        private void txtPhone_TextChanged(object sender, EventArgs e) => TextElement(txtPhone, "phone_number", "onlyInt");
        private void txtHouseNumber_TextChanged(object sender, EventArgs e) => TextElement(txtHouseNumber, "house_number", "onlyInt");
        private void txtApartmentNumber_TextChanged(object sender, EventArgs e) => TextElement(txtApartmentNumber, "apartment_number", "onlyInt");

        private void btnAddOrUpdateUser_Click(object sender, EventArgs e)
        {
            if (IsNoCorrect == false && CheckAllTextElementsToFilled())
            {
                List<string> _columns = new List<string>();
                List<string> _data = new List<string>();

                _data.Add(txtName.Text);
                _data.Add(txtSurname.Text);
                _data.Add(txtPatronymic.Text);
                if(cbUserType.SelectedItem.ToString() == "перподаватель") 
                    _data.Add(AM.GetID("UchebnayaDistsiplinaTable", "uchebnaya_distsiplina_name", cbUchebnayaDistsiplina.SelectedItem.ToString()));
                else if (cbUserType.SelectedItem.ToString() == "студент")
                    _data.Add(AM.GetID("GroupsTable", "group_name", cbSelectGroup.SelectedItem.ToString()));
                _data.Add(txtEmail.Text);
                _data.Add(txtLogin.Text);
                _data.Add(txtPassword.Text);
                _data.Add(txtPhone.Text);
                _data.Add(AM.GetID("CityTable", "city_name", cbCity.SelectedItem.ToString()));
                _data.Add(AM.GetID("StreetTable", "street_name", cbStreet.SelectedItem.ToString()));
                _data.Add(txtHouseNumber.Text);
                _data.Add(txtApartmentNumber.Text);

                if (IsAdding && !IsDataChanged)
                {
                    if (cbUserType.SelectedItem.ToString() == "перподаватель")
                    {
                        _columns = AM.GetTableInfo(lbStatusAM, "AccountsTable");
                        AM.AddNewUserDB(lbStatusAM, "AccountsTable", _columns, _data);
                    }
                    else if (cbUserType.SelectedItem.ToString() == "студент")
                    {
                        _columns = AM.GetTableInfo(lbStatusAM, cbSelectGroup.SelectedItem.ToString());
                        AM.AddNewUserDB(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns, _data);
                    }
                    ReloadCBSelectUser();
                }
                else if(!IsAdding && IsDataChanged)
                {
                    string str = cbSelectUser.Text;
                    string surname = null;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == ' ') break;
                        surname += str[i];
                    }

                    if (cbUserType.SelectedItem.ToString() == "перподаватель") _columns = AM.GetTableInfo(lbStatusAM, "AccountsTable");
                    else if (cbUserType.SelectedItem.ToString() == "студент") _columns = AM.GetTableInfo(lbStatusAM, cbSelectGroup.SelectedItem.ToString());

                    if (_columns.Count == _data.Count)
                        for (int i = 0;i < _columns.Count; i++)
                        {
                            if (cbUserType.SelectedItem.ToString() == "перподаватель")
                            {
                                //AM.Reset(lbStatusAM, "AccountsTable", _columns[i], _data[i], AM.GetID("AccountsTable", "surname", surname));
                                AM.Reset(lbStatusAM, "AccountsTable", _columns[i], _data[i], AM.GetID("AccountsTable", "id", UserData["id"]));
                                cbSelectUser.Items.Clear();
                            }
                            else if (cbUserType.SelectedItem.ToString() == "студент")
                            {
                                //AM.Reset(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns[i], _data[i], AM.GetID(cbSelectGroup.SelectedItem.ToString(), "surname", surname));
                                AM.Reset(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns[i], _data[i], AM.GetID(cbSelectGroup.SelectedItem.ToString(), "id", UserData["id"]));
                                cbSelectUser.Items.Clear();
                            }
                        }
                    ReloadCBSelectUser();
                    ReturnTextElementsSettingsToDefault();
                    ReloadAllUserDataElements(txtSurname.Text);
                }
            }
            else
            {
                lbStatusAM.Text = "ЗАПОЛНИТЕ ВСЕ СТРОКИ!";
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            string TableName = cbSelectGroup.SelectedItem.ToString();
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить группу " + TableName + "?", "Удаление группы", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AM.DeleteTable(lbStatusAM, TableName);
                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";
                ReloadCBSelectGroup();
                cbSelectUser.Text = "";
                cbSelectUser.SelectedItem = "";
                cbSelectUser.Items.Clear();
                cbSelectUser.Enabled = false;
                ReturnTextElementsSettingsToDefault();
                EnabledAllTextElementsToAM(false);
                ClearAllComboBoxElements();
                ClearAllTextElements();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string str = cbSelectUser.Text;
            string surname = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ') break;
                surname += str[i];
            }
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить ползователя " + cbSelectUser.Text + "?", "Удаление пользователя", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (cbUserType.SelectedItem.ToString() == "перподаватель")
                {
                    AM.DeleteUser(lbStatusAM, "AccountsTable", "surname", surname);
                }
                else if (cbUserType.SelectedItem.ToString() == "студент")
                {
                    AM.DeleteUser(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), "surname", surname);
                }

                cbSelectUser.SelectedItem = "";
                cbSelectUser.Text = "";
                ReloadCBSelectUser();
                ClearAllTextElements();
                ClearAllComboBoxElements();
                EnabledAllTextElementsToAM(false);
                ReturnTextElementsSettingsToDefault();
                cbSelectUser.Enabled = true;
            }
        }

    }
}