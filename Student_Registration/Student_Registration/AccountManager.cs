using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
namespace Student_Registration
{
    public class AccountManager : IAccountManager
    {
        protected string dbFileName;
        protected SQLiteConnection m_dbConn = new SQLiteConnection();
        protected SQLiteCommand m_sqlCmd = new SQLiteCommand();

        public virtual void ConnectDB(Label lbStatusText ,string fileName)
        {
            dbFileName = fileName;
            if (!File.Exists(dbFileName))
                MessageBox.Show("База данных: "+ dbFileName +" отсутствует!");
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                lbStatusText.Text = "Connected: " + dbFileName;
                lbStatusText.ForeColor = Color.Green;
            }
            catch (SQLiteException ex)
            {
                lbStatusText.Text = "Disconnected";
                lbStatusText.ForeColor = Color.Red;
                MessageBox.Show("ConnectDB ERROR:" + ex + "\nCOMMAND: " + m_dbConn);
            }
        }

        protected virtual void CreateAccountsTableFromTeacherDB(Label status)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            string query = @"
                        CREATE TABLE AccountsTable ( " +
                        "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                        "name TEXT NOT NULL, " +
                        "surname TEXT NOT NULL, " +
                        "patronymic TEXT NOT NULL, " +
                        "disciplina INTEGER NOT NULL, " +
                        "email TEXT NOT NULL, " +
                        "login TEXT NOT NULL, " +
                        "password TEXT NOT NULL, " +
                        "phone_number INTEGER NOT NULL, " +
                        "city INTEGER NOT NULL, " +
                        "street INTEGER NOT NULL, " +
                        "house_number INTEGER NOT NULL, " +
                        "apartment_number INTEGER NOT NULL, " +
                        "CONSTRAINT AccountsTable_CityTable_FK FOREIGN KEY (city) REFERENCES CityTable(id), " +
                        "CONSTRAINT AccountsTable_DisciplinesTable_FK FOREIGN KEY (disciplina) REFERENCES DisciplinesTable(id), " +
                        "CONSTRAINT AccountsTable_StreetTable_FK FOREIGN KEY (street) REFERENCES StreetTable(id))" +
                        "; ";
            try
            {
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                status.Text += " Таблица учителей создана!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("CreateAccountsTable ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        protected virtual void CreateSecondaryTablesFromTeacherDB(Label status)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            string query = @"
                        CREATE TABLE DisciplinesTable (
	                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                    AltName TEXT NOT NULL, 
                        disciplina_name TEXT NOT NULL
                        );
                         CREATE TABLE StreetTable (
	                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                    street_name TEXT NOT NULL
                        );
                         CREATE TABLE CityTable (
	                    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                    city_name TEXT NOT NULL
                        );
                        ";
            try
            {
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                status.Text += " Таблица учителей создана!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("CreateSecondaryTablesFromTeacherDB ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void CreateTeacherAccounts(Label status)
        {
            dbFileName = "TeacherAccounts.sqlite";
            SQLiteConnection.CreateFile(dbFileName);
            m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            CreateSecondaryTablesFromTeacherDB(status);
            CreateAccountsTableFromTeacherDB(status);
        }

        public virtual int GetCountRowsInTable(Label lbStatusText, string tableName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = "SELECT count(*) FROM "+ tableName +";";
                using (var command = new SQLiteCommand(query, m_dbConn))
                {
                    int tableCount = Convert.ToInt32(command.ExecuteScalar());
                    lbStatusText.Text = "Количество таблиц в базе данных: " + tableCount;
                    return tableCount;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetCountRowsInTable ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
                return 0;
            }
        }

        public virtual List<string> GetNameAllGroups(Label lbStatusText)
        {
            List<string> _namesOfAllGroups = new List<string>();
            bool correct = true;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            List<string> DontReadTables = new List<string>();
            DontReadTables.Add("sqlite_sequence");
            DontReadTables.Add("GroupsTable");
            DontReadTables.Add("CityTable");
            DontReadTables.Add("StreetTable");

            try
            {
                string query = "SELECT count(*) FROM sqlite_master WHERE type='table';";
                using (var command = new SQLiteCommand(query, m_dbConn))
                {
                    int tableCount = Convert.ToInt32(command.ExecuteScalar());
                    lbStatusText.Text = "Количество таблиц в базе данных: " + tableCount;
                }
                query = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";

                using (var command = new SQLiteCommand(query, m_dbConn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            correct = true;
                            foreach (string row in DontReadTables) {
                                if (reader["name"].ToString() == row)
                                 correct = false;
                            }
                            if(correct == true)
                                _namesOfAllGroups.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetNameAllGroups ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return _namesOfAllGroups;
        }

        public virtual void CreateNewGroup(Label status, string tableName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                string query = @"
                        CREATE TABLE "+ tableName +" ( " +
                        "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                        "name TEXT NOT NULL, " +
                        "surname TEXT NOT NULL, " +
                        "patronymic TEXT NOT NULL, " +
                        "group_name INTEGER NOT NULL, " +
                        "email TEXT NOT NULL, " +
                        "login TEXT NOT NULL, " +
                        "password TEXT NOT NULL, " +
                        "phone_number INTEGER NOT NULL, " +
                        "city INTEGER NOT NULL, " +
                        "street INTEGER NOT NULL, " +
                        "house_number INTEGER NOT NULL, " +
                        "apartment_number INTEGER NOT NULL, " +
                        "CONSTRAINT " + tableName + "_CityTable_FK FOREIGN KEY (city) REFERENCES CityTable(id), " +
                        "CONSTRAINT "+ tableName +"_GroupsTable_FK FOREIGN KEY (group_name) REFERENCES GroupsTable(id), " +
                        "CONSTRAINT "+ tableName +"_StreetTable_FK FOREIGN KEY (street) REFERENCES StreetTable(id))" +
                        "; " +
                        "INSERT INTO GroupsTable (group_name) VALUES ('" + tableName + "');";

                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                status.Text += " Группа создана и добавлена в список!";
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show("CreateNewGroup ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual List<string> GetAllUsersSNP(string TableName, string ResultType)
        {
            List<string> result = new List<string>();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = @" SELECT name, surname, patronymic FROM "+ TableName +" ;";

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string userName = reader["surname"].ToString();
                            string patronymic = reader["patronymic"].ToString();
                            if (ResultType == "forUser") result.Add(userName + " " + name[0] + "." + patronymic[0] + ".");
                            else if (ResultType == "forDB") result.Add(userName + name[0] + patronymic[0]);
                        }
                    }
                }
            }
            catch (SQLiteException ex) 
            {
                MessageBox.Show("GetAllUsersSNP ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return result;
        }

        public virtual Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, string tableName, string surname)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            string query = "";
            try
            {

                if (tableName == "NULL")
                {
                     query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.login, a.password, a.phone_number, a.house_number, a.apartment_number, b.disciplina_name, c.city_name, d.street_name
                        AS AccountsTable, b.disciplina_name, c.city_name, d.street_name
                        FROM AccountsTable a " +
                        "JOIN DisciplinesTable b ON a.disciplina = b.id " +
                        "JOIN CityTable c ON a.city = c.id " +
                        "JOIN StreetTable d ON a.street = d.id " +
                        "WHERE a.surname = '" + surname + "' " +
                        ";";
                }
                else
                {
                     query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.login, a.password, a.phone_number, a.house_number, a.apartment_number, b.group_name, c.city_name, d.street_name " +
                        "AS " + tableName + ", b.group_name, c.city_name, d.street_name " +
                        "FROM " + tableName +" a " +
                        "JOIN GroupsTable b ON a.group_name = b.id " +
                        "JOIN CityTable c ON a.city = c.id " +
                        "JOIN StreetTable d ON a.street = d.id " +
                        "WHERE a.surname = '" + surname + "'" +
                        ";";
                }
                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        int count = reader.FieldCount;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!data.ContainsKey(reader.GetName(i)))
                                data.Add(reader.GetName(i), reader[i].ToString());
                        }
                    }
                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show("ReadSelectedOnlyRow ERROR:" + ex + "\nCOMMAND: " + query);
            }
            return data;
        }

        public virtual void LoadAllItemsForComboBox(ComboBox comboBox, string TableName, string ColumName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            comboBox.Items.Clear();
            switch (TableName)
            {
                case "CityTable": comboBox.Items.Add("добавить город"); break;
                case "StreetTable": comboBox.Items.Add("добавить улицу"); break;
                case "GroupsTable": comboBox.Items.Add("добавить группу"); break;
                case "DisciplinesTable": comboBox.Items.Add("добавить дисциплину"); break;
            }
            try
            {
                string query = @"SELECT "+ ColumName +" FROM " + TableName + ";";

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader[ColumName].ToString());
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("LoadAllItemsForComboBox ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void AddSecondaryInfo(Label statusText, TextBox textBox, in string TableName, in string ColumnName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = "INSERT INTO "+ TableName +" ("+ ColumnName +") VALUES ('" + textBox.Text + "');";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "запись добавлена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("AddSecondaryInfo ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void AddDistsiplina(Label statusText, string distsiplinaName, string AltName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = "INSERT INTO DisciplinesTable ( disciplina_name, AltName ) VALUES ('" + distsiplinaName +"','"+ AltName +"');";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "Дисциплина добавлена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("AddDistsiplina ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void AddNewUserDB(Label status, string TableName, List<string> columns, List<string> data)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                string query = @"INSERT INTO " + TableName + " (";
                for (int i = 0; i < columns.Count; i++)
                {
                    query += columns[i];
                    if (i != columns.Count - 1) query += ", ";
                }
                query += ") VALUES (";
                for (int i = 0; i < data.Count; i++)
                {
                    query += "'" + data[i] + "'";
                    if (i != data.Count - 1) query += ", ";
                }
                query += ");";

                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                status.Text += "пользователь добавлен!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("AddNewUserDB ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual string GetID(in string tableNameDB, in string ColumnName, in string Value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            string query = @"SELECT id FROM " + tableNameDB + " WHERE "+ ColumnName +" = '" + Value + "';";
            try
            {

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader["id"].ToString();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetID ERROR:" + ex + "\nCOMMAND: " + query);
                return "NULL";
            }
        }

        public virtual List<string> GetTableInfo(Label lbStatusText, in string tableNameDB)
        {
            lbStatusText.Text = "";
            List<string> columns = new List<string>();
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                m_sqlCmd.CommandText = "pragma table_info ('" + tableNameDB + "');";
                SQLiteDataReader sqlite_datareader = m_sqlCmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    if(sqlite_datareader.GetString(1) != "id")
                        columns.Add(sqlite_datareader.GetString(1));
                }
                sqlite_datareader.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetTableInfo ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return columns;
        }


        public virtual void DeleteUser(Label statusText, in string tableNameDB, in string columnName, in string Value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = @"DELETE FROM " + tableNameDB + " WHERE " + columnName + " = '" + Value + "';";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "Запись Удалена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("DeleteUser ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void DeleteTable(Label statusText, in string tableNameDB)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = @"DROP TABLE " + tableNameDB + "; "+
                    "DELETE FROM GroupsTable WHERE group_name = '" + tableNameDB + "';";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "Таблица Удалена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("DeleteTable ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public virtual void Reset(Label status, string TableName, string column, string value, string id)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                string query = @"UPDATE " + TableName + " SET " + column + " = '"+ value +"' WHERE id = '"+ id +"';";

                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                status.Text = "Данные пользовантеля обновлены!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Reset ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }
        public virtual bool CheckForValidity(Label statusText, in string EnterText, in string CheckType )
        {
            bool IsCorrect = true;
            string pattern;
            if (EnterText == "") { statusText.Text = "\nстока пуста!"; return false; }
            switch (CheckType)
            {
                case "login":
                    pattern = @"^[a-zA-Z0-9]+$";
                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "логин должен содержать только латинские буквы без посторонних символов!";
                        return false;
                    }
                    break;

                case "email":
                    pattern = @"^[a-zA-Z]";
                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "начало строки дожно содержать одну или более латинских букв!";
                        return false;
                    }
                    pattern = @"\@mail.ru|\@gmail.com";
                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "обязательно наличие слова '@mail.ru' или @gmail.com'!";
                        return false;
                    }
                    break;
                case "name":
                    pattern = @"^[А-ЯЁ][а-яё]*$";
                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "символы кроме первой русской заглавной буквы должны быть русскими буквами без пробелов!";
                        return false;
                    }
                    break;
                case "onlyInt":
                    pattern = @"^\d+$";

                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "в поле должны быть только цифры!";
                        return false;
                    }
                    break;
                case "onlyEngl":
                    pattern = @"^[a-zA-Z]+$";
                    if (!Regex.IsMatch(EnterText, pattern))
                    {
                        statusText.Text = "в поле должны быть только латинские буквы!";
                        return false;
                    }
                    break;
                default: statusText.Text = "\n неопределён тип проверки на валидацию вводимых данных!"; return false;
            }
            if(IsCorrect) statusText.Text = "\nстрока: " + EnterText + " валидна!";
            return IsCorrect;
        }

        public virtual string ReadOneValue(Label lbStatus, string tableName, string column, string whereColumn, string value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            string query = @"SELECT " + column + " FROM " + tableName + " WHERE " + whereColumn + " = '"+ value + "';";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        if(reader.HasRows == true) return reader[column].ToString();
                        else return "NOT FOUND!";
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("ReadOneValue ERROR:" + ex + "\nCOMMAND: " + query);
                return "ReadOneValue ERROR:" + ex + "\nCOMMAND: " + query;
            }
        }

        public virtual string ReadAllGroups(Label status, string column, string whereColumn, string value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            bool isFound = false;
            string result = "";
            string query = "";
            try
            {
                List<string> groups = GetNameAllGroups(status);
                for (int i = 0; i < groups.Count; i++)
                {
                    query = @"SELECT " + column + " FROM " + groups[i] + " WHERE " + whereColumn + " = '" + value + "';";

                    using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                result = reader[column].ToString();
                                isFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("ReadAllGroups ERROR:" + ex + "\nCOMMAND: " + query);
            }
            if(isFound) return result;
            else return "NOT FOUND!";
        }

        public virtual string GetGroupName(Label status, string column, string whereColumn, string value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            bool isFound = false;
            string result = "";
            string query = "";
            try
            {
                List<string> groups = GetNameAllGroups(status);
                for (int i = 0; i < groups.Count; i++)
                {
                    query = @"SELECT " + column + " FROM " + groups[i] + " WHERE " + whereColumn + " = '" + value + "';";

                    using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                result = ReadOneValue(status, "GroupsTable", "group_name", "id", reader[column].ToString());
                                isFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetGroupName ERROR:" + ex + "\nCOMMAND: " + query);
            }
            if (isFound) return result;
            else return "NOT FOUND!";
        }

        public virtual void ResetAdminPassword(Label lbStatusText, TextBox txtAdminPassword)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                lbStatusText.Text = "Open connection with database";
                return;
            }
            string query = @"UPDATE AdminTable SET password = '"+ txtAdminPassword.Text + "' WHERE login = 'Admin';";
            try 
            {
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                lbStatusText.Text = "Пароль администратора изменён!";

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error ResetDB: " + ex.Message);
            }
        }
    }
}
