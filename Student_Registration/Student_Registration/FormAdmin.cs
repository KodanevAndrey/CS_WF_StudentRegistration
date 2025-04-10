﻿using ConnectSQLite_KodanevAndrey;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Student_Registration
{
    public partial class FormAdmin : Form
    {
        private readonly IAccountManager AM = new AccountManager();
        private Dictionary<string, string> UserData = new Dictionary<string, string>();
        private bool IsDataChanged = false;
        private bool IsAdding = false;
        private bool IsNoCorrect = false;
        private Color colorChanged = Color.Yellow;
        private Color colorNoCorrect = Color.Orange;

        private FormSelectedOpenTable form;
        public readonly IDBHelper db = new DBHelper();
        private string DBName = null;
        private string TableName = null;
        private string AdminPassword;
        private List<string> listColumns = new List<string>();

        public FormAdmin()
        {
            InitializeComponent();

            btnResetPassword.Enabled = false;
            AM.ConnectDB(lbStatusAM,"Admin.sqlite");
            AdminPassword = AM.ReadOneValue(lbStatusAM, "AdminTable", "password", "login", "Admin");
            txtAdminPassword.Text = AdminPassword;
            this.StartPosition = FormStartPosition.CenterParent;
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
                form = new FormSelectedOpenTable(db, dgvViewer);
                form.Show();
                EnabledAllButtonToConnectDB(true);
            }
        }

        private void btnConnectDB_Click(object sender, EventArgs e) => Connect();
        private void btnReadDB_Click(object sender, EventArgs e) => db.ReadDB(lbStatusText,dgvViewer);
        private void btnAddDB_Click(object sender, EventArgs e) => db.AddDB(lbStatusText,lbCommand,dgvViewer);
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
            db.SelectCellInTable(lbStatusText, dgvViewer);
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
            if (IsDataChanged && !IsAdding)
            {
                btnAddOrUpdateUser.Enabled = true;
                btnAddOrUpdateUser.Text = "Измненить";
            }
            else if (!IsDataChanged && !IsAdding)
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
        }

        private void CheckTextElementClolr(Color color,ref bool changeable)
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

            if (color == colorChanged)
            {
                if (cbUchebnayaDistsiplina.BackColor == color) changeable = true;
                if (cbCity.BackColor == color) changeable = true;
                if (cbStreet.BackColor == color) changeable = true;
                CheckIsDataChanged();
            }
            if(color == colorNoCorrect) CheckIsNoCorrect();
        }

        private void ReturnTextElementsColorToDefault()
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
            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                UserData = AM.ReadSelectedOnlyRow(lbStatusText, "NULL", surname);
                cbUchebnayaDistsiplina.SelectedItem = UserData["disciplina_name"];
                cbUchebnayaDistsiplina.Text = UserData["disciplina_name"];
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
            foreach (string item in AM.GetNamesAllGroups(lbStatusAM)) cbSelectGroup.Items.Add(item);
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
            ReturnTextElementsColorToDefault();

            if (cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                AM.ConnectDB(lbStatusAM, "TeacherAccounts.sqlite");
                ClearAllTextElements();
                ClearAllComboBoxElements();
                EnabledAllTextElementsToAM(false);
                btnDeleteGroup.Enabled = false;
                cbSelectGroup.SelectedItem = "";
                cbSelectGroup.Text = "";
                cbSelectGroup.Enabled = false;
                cbSelectUser.Enabled = true;
                ReturnTextElementsColorToDefault();
                label6.Text = "учитель";
                label10.Text = "дисциплина";
                ReloadCBSelectUser();
                AM.LoadAllSecondaryItemsInComboBox(cbUchebnayaDistsiplina, "DisciplinesTable", "disciplina_name");
                AM.LoadAllSecondaryItemsInComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllSecondaryItemsInComboBox(cbStreet, "StreetTable", "street_name");
            }
            else if (cbUserType.SelectedItem.ToString() == "студент")
            {
                AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
                ClearAllTextElements();
                ClearAllComboBoxElements();
                EnabledAllTextElementsToAM(false);
                cbSelectGroup.Enabled = true;
                btnDeleteGroup.Enabled = false;
                cbSelectUser.Text = "";
                ReturnTextElementsColorToDefault();
                label6.Text = "студент";
                label10.Text = "группа";
                ReloadCBSelectGroup();
                AM.LoadAllSecondaryItemsInComboBox(cbUchebnayaDistsiplina, "GroupsTable", "group_name");
                AM.LoadAllSecondaryItemsInComboBox(cbCity, "CityTable", "city_name");
                AM.LoadAllSecondaryItemsInComboBox(cbStreet, "StreetTable", "street_name");
            }
        }

        private void cbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TableName = "NULL";

            if (cbSelectUser.SelectedIndex == 0)
            {
                IsAdding = true;
                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();
                btnAddOrUpdateUser.Enabled = true;
                btnDeleteUser.Enabled = false;

                if (cbUserType.SelectedItem.ToString() == "студент")
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

                EnabledAllTextElementsToAM(true);
                ClearAllComboBoxElements();
                ClearAllTextElements();

                ReloadAllUserDataElements("NULL");

                if(cbUserType.SelectedItem.ToString() == "студент")
                {
                    cbUchebnayaDistsiplina.SelectedItem = cbSelectGroup.SelectedItem;
                    cbUchebnayaDistsiplina.Text = cbSelectGroup.SelectedItem.ToString();
                    cbUchebnayaDistsiplina.Enabled = false;
                }
            }
            ReturnTextElementsColorToDefault();
        }


        private void cbSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                AM.LoadAllSecondaryItemsInComboBox(cbUchebnayaDistsiplina, "GroupsTable", "group_name");
                ReturnTextElementsColorToDefault();
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
            ReturnTextElementsColorToDefault();
        }

        private void cbUchebnayaDistsiplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUchebnayaDistsiplina.SelectedItem.ToString() == "добавить дисциплину")
            {
                FormAddingSecondaryInformation form;
                form = new FormAddingSecondaryInformation(lbStatusAM, cbUchebnayaDistsiplina, AM, "DisciplinesTable", "disciplina_name", "дисциплину");
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
                    if (cbUchebnayaDistsiplina.SelectedItem.ToString() == UserData["disciplina_name"]) cbUchebnayaDistsiplina.BackColor = Color.White;
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
                CheckTextElementClolr(colorChanged, ref IsDataChanged);
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
                if (cbCity.SelectedItem.ToString() == UserData["city_name"]) cbCity.BackColor = Color.White;
                else cbCity.BackColor = colorChanged; 
                CheckTextElementClolr(colorChanged, ref IsDataChanged);
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
                CheckTextElementClolr(colorChanged, ref IsDataChanged);
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
                }
                else textBox.BackColor = Color.White;
            }
            else
            {
                if (AM.CheckForValidity(lbStatusAM, textBox.Text, TypeCheck)) textBox.BackColor = Color.White;
                else textBox.BackColor = colorNoCorrect;
            }
            CheckTextElementClolr(colorNoCorrect, ref IsNoCorrect);
            CheckTextElementClolr(colorChanged, ref IsDataChanged);
        }

        private void LoginTextElement(TextBox textBox, string ColumnName, string TypeCheck)
        {
            if (cbUserType.SelectedItem.ToString() == "перподаватель" && AM.ReadOneValue(lbStatus, "AccountsTable", "login", "login", textBox.Text) != "NOT FOUND!")
            {
                textBox.BackColor = colorNoCorrect;
                lbStatusAM.Text = "Такой логин уже существует!";
            }
            else if (cbUserType.SelectedItem.ToString() == "студент" && AM.ReadAllGroups(lbStatus, "login", "login", textBox.Text) != "NOT FOUND!")
            {
                textBox.BackColor = colorNoCorrect;
                lbStatusAM.Text = "Такой логин уже существует!";
            }
            else
            {
                textBox.BackColor = Color.White;               
                TextElement(textBox, ColumnName, TypeCheck);
            }

            CheckTextElementClolr(colorNoCorrect, ref IsNoCorrect);
            CheckTextElementClolr(colorChanged, ref IsDataChanged);
        }

        private void txtName_TextChanged(object sender, EventArgs e) => TextElement(txtName, "name", "name");
        private void txtSurname_TextChanged(object sender, EventArgs e) => TextElement(txtSurname, "surname", "name");
        private void txtPatronymic_TextChanged(object sender, EventArgs e) => TextElement(txtPatronymic, "patronymic", "name");
        private void txtEmail_TextChanged(object sender, EventArgs e) => TextElement(txtEmail, "email", "email");
        private void txtLogin_TextChanged(object sender, EventArgs e) => LoginTextElement(txtLogin, "login", "login");
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
                if (cbUserType.SelectedItem.ToString() == "перподаватель")
                    _data.Add(AM.GetID(
                        "DisciplinesTable",
                        "AltName",
                        AM.ReadOneValue(lbStatusAM, "DisciplinesTable", "AltName", "disciplina_name", cbUchebnayaDistsiplina.SelectedItem.ToString())
                        ));
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
                        _columns = AM.GetColumnsNames(lbStatusAM, "AccountsTable");
                        AM.AddNewUser(lbStatusAM, "AccountsTable", _columns, _data);
                    }
                    else if (cbUserType.SelectedItem.ToString() == "студент")
                    {
                        _columns = AM.GetColumnsNames(lbStatusAM, cbSelectGroup.SelectedItem.ToString());
                        AM.AddNewUser(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns, _data);
                        AM.ConnectDB(lbStatusAM, "Magazine_" + cbSelectGroup.SelectedItem.ToString() + ".sqlite");
                        _columns.Clear();
                        _columns = AM.GetColumnsNames(lbStatusAM, "BaseInfo");

                        _data.Clear();
                        _data.Add(txtName.Text);
                        _data.Add(txtSurname.Text);
                        _data.Add(txtPatronymic.Text);
                        AM.AddNewUser(lbStatusAM, "BaseInfo", _columns, _data);

                        AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
                    }
                    ReloadCBSelectUser();
                    btnAddOrUpdateUser.Enabled = false;
                    btnAddOrUpdateUser.Text = "Чтенеие";
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

                    if (cbUserType.SelectedItem.ToString() == "перподаватель") _columns = AM.GetColumnsNames(lbStatusAM, "AccountsTable");
                    else if (cbUserType.SelectedItem.ToString() == "студент") _columns = AM.GetColumnsNames(lbStatusAM, cbSelectGroup.SelectedItem.ToString());

                    if (_columns.Count == _data.Count)
                        for (int i = 0;i < _columns.Count; i++)
                        {
                            if (cbUserType.SelectedItem.ToString() == "перподаватель")
                            {
                                AM.UpdateUserData(lbStatusAM, "AccountsTable", _columns[i], _data[i], AM.GetID("AccountsTable", "id", UserData["id"]));
                                cbSelectUser.Items.Clear();
                            }
                            else if (cbUserType.SelectedItem.ToString() == "студент")
                            {
                                AM.UpdateUserData(lbStatusAM, cbSelectGroup.SelectedItem.ToString(), _columns[i], _data[i], AM.GetID(cbSelectGroup.SelectedItem.ToString(), "id", UserData["id"]));
                                cbSelectUser.Items.Clear();
                            }
                        }
                    ReloadCBSelectUser();
                    ReturnTextElementsColorToDefault();
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
                ReturnTextElementsColorToDefault();
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
                ReturnTextElementsColorToDefault();
                cbSelectUser.Enabled = true;
            }
        }

        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {   
            if(txtAdminPassword.Text == AdminPassword)
            {
                txtAdminPassword.BackColor = Color.White;
                btnResetPassword.Enabled = false;
            }
            else
            {
                txtAdminPassword.BackColor = colorChanged;
                if (AM.CheckForValidity(lbStatusAM, txtAdminPassword.Text, "onlyInt"))
                {
                    txtAdminPassword.BackColor = colorChanged;
                    btnResetPassword.Enabled = true;
                }
                else
                {
                    txtAdminPassword.BackColor = colorNoCorrect;
                    btnResetPassword.Enabled = false;
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            AM.ConnectDB(lbStatusText, "Admin.sqlite");
            AM.ResetAdminPassword(lbStatusAM,txtAdminPassword);
            txtAdminPassword.BackColor = Color.White;
            btnResetPassword.Enabled = false;

            if ( cbUserType.SelectedItem?.ToString() == "перподаватель")
                AM.ConnectDB(lbStatusAM, "TeacherAccounts.sqlite");
            else if (cbUserType.SelectedItem?.ToString() == "студент") 
                AM.ConnectDB(lbStatusAM, "StudentsAccounts.sqlite");
        }
    }
}