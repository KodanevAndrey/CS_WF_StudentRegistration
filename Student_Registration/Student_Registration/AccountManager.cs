using ConnectSQLite_KodanevAndrey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
namespace Student_Registration
{
    public class AccountManager
    {
        private string dbFileName;
        private SQLiteConnection m_dbConn = new SQLiteConnection();
        private SQLiteCommand m_sqlCmd = new SQLiteCommand();

        public void ConnectDB(Label lbStatusText ,string fileName)
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

        public void CreateAccountsTable(Label status)
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
                        "uchebnaya_distsiplina INTEGER NOT NULL, " +
                        "email TEXT NOT NULL, " +
                        "login TEXT NOT NULL, " +
                        "password TEXT NOT NULL, " +
                        "phone_number INTEGER NOT NULL, " +
                        "city INTEGER NOT NULL, " +
                        "street INTEGER NOT NULL, " +
                        "house_number INTEGER NOT NULL, " +
                        "apartment_number INTEGER NOT NULL, " +
                        "CONSTRAINT AccountsTable_CityTable_FK FOREIGN KEY (city) REFERENCES CityTable(id), " +
                        "CONSTRAINT AccountsTable_UchebnayaDistsiplinaTable_FK FOREIGN KEY (uchebnaya_distsiplina) REFERENCES UchebnayaDistsiplinaTable(id), " +
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

        public List<string> GetNameAllGroups(Label lbStatusText)
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
                MessageBox.Show("ReadCountTables ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return _namesOfAllGroups;
        }

        public void CreateNewGroup(Label status, string tableName)
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
                        "group_student INTEGER NOT NULL, " +
                        "email TEXT NOT NULL, " +
                        "login TEXT NOT NULL, " +
                        "password TEXT NOT NULL, " +
                        "phone_number INTEGER NOT NULL, " +
                        "city INTEGER NOT NULL, " +
                        "street INTEGER NOT NULL, " +
                        "house_number INTEGER NOT NULL, " +
                        "apartment_number INTEGER NOT NULL, " +
                        "CONSTRAINT " + tableName + "_CityTable_FK FOREIGN KEY (city) REFERENCES CityTable(id), " +
                        "CONSTRAINT "+ tableName +"_GroupsTable_FK FOREIGN KEY (group_student) REFERENCES GroupsTable(id), " +
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

        public List<string> GetAllUsersSNP(string TableName, string ResultType)
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
                MessageBox.Show("ReadAllName ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return result;
        }

        public Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, string tableName, string surname)
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
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.login, a.password, a.phone_number, a.house_number, a.apartment_number, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        AS AccountsTable, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        FROM AccountsTable a " +
                        "JOIN UchebnayaDistsiplinaTable b ON a.uchebnaya_distsiplina = b.id " +
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
                        "JOIN GroupsTable b ON a.group_student = b.id " +
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

        public void LoadAllItemsForComboBox(ComboBox comboBox, string TableName, string ColumName)
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
                case "UchebnayaDistsiplinaTable": comboBox.Items.Add("добавить дисциплину"); break;
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

        public void AddSecondaryInfo(Label statusText, TextBox textBox, in string TableName, in string ColumnName)
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

        public void AddUchebnayaDistsiplina(Label statusText, string distsiplinaName, string AltName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = "INSERT INTO UchebnayaDistsiplinaTable ( uchebnaya_distsiplina_name, AltName ) VALUES ('"+ distsiplinaName +"','"+ AltName +"');";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "Дисциплина добавлена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("AddUchebnayaDistsiplina ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }

        public void AddNewUserDB(Label status, string TableName, List<string> columns, List<string> data)
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

        public string GetID(in string tableNameDB, in string ColumnName, in string Value)
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

        public List<string> GetTableInfo(Label lbStatusText, in string tableNameDB)
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


        public void DeleteUser(Label statusText, in string tableNameDB, in string columnName, in string Value)
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

        public void DeleteTable(Label statusText, in string tableNameDB)
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

        public void Reset(Label status, string TableName, string column, string value, string id)
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
        public bool CheckForValidity(Label statusText, in string EnterText, in string CheckType )
        {
            bool IsCorrect = true;
            string pattern;
            if (EnterText == "") { statusText.Text = "\nстока пуста!"; return false; }
            switch (CheckType)
            {
                case "email":
                    // Проверяем, что строка не пустая
                    if (string.IsNullOrEmpty(EnterText))
                    {
                        return false;
                    }

                    // Проверяем, что первый символ не '@'
                    if (EnterText[0] == '@')
                    {
                        return false;
                    }

                    // Регулярное выражение для проверки строки
                    // ^ - начало строки
                    // [a-zA-Z]+ - одна или более латинских букв
                    // (?=.*@) - обязательно наличие символа '@'
                    // (?=.*\.) - обязательно наличие символа '.'
                    // [a-zA-Z@.]* - остальные символы могут быть латинскими буквами, '@' или '.'
                    // $ - конец строки
                    pattern = @"^[a-zA-Z]+(?=.*@)(?=.*\.)[a-zA-Z@.]*$";

                    // Проверяем соответствие строки регулярному выражению
                    IsCorrect = Regex.IsMatch(EnterText, pattern);
                    break;
                case "name":
                    // Проверяем, что строка не пустая
                    if (string.IsNullOrEmpty(EnterText))
                    {
                        return false;
                    }

                    // Регулярное выражение для проверки строки
                    // ^ - начало строки
                    // [А-ЯЁ] - первая буква должна быть заглавной русской буквой
                    // [а-яёА-ЯЁ]* - остальные символы могут быть строчными или заглавными русскими буквами
                    // $ - конец строки
                    pattern = @"^[А-ЯЁ][а-яё]*$";

                    // Проверяем соответствие строки регулярному выражению
                    IsCorrect = Regex.IsMatch(EnterText, pattern);
                    break;
                case "onlyInt":
                    // Проверяем, что строка не пустая
                    if (string.IsNullOrEmpty(EnterText))
                    {
                        return false;
                    }

                    // Регулярное выражение для проверки строки
                    // ^ - начало строки
                    // \d+ - одна или более цифр
                    // $ - конец строки
                    pattern = @"^\d+$";

                    // Проверяем соответствие строки регулярному выражению
                    IsCorrect = Regex.IsMatch(EnterText, pattern);
                    break;
                case "onlyEngl":
                    // Проверяем, что строка не пустая
                    if (string.IsNullOrEmpty(EnterText))
                    {
                        return false;
                    }

                    // Регулярное выражение для проверки строки
                    // ^ - начало строки
                    // [a-zA-Z]+ - одна или более латинских букв
                    // $ - конец строки
                    pattern = @"^[a-zA-Z]+$";

                    // Проверяем соответствие строки регулярному выражению
                    IsCorrect = Regex.IsMatch(EnterText, pattern);
                    break;
                default: statusText.Text = "\n неопределён тип проверки на валидацию вводимых данных!"; return false;
            }
            if(IsCorrect) statusText.Text = "\nстрока: " + EnterText + " валидна!";
            return IsCorrect;
        }

        public string ReadOneValue(Label lbStatus, string tableName, string column, string whereColumn, string value)
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
                        else return null;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("ReadOneValue ERROR:" + ex + "\nCOMMAND: " + query);
                return "ReadOneValue ERROR:" + ex + "\nCOMMAND: " + query;
            }
        }

        public string ReadAllGroups(Label status, string column, string whereColumn, string value)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
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
                                break;
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("ReadOneValue ERROR:" + ex + "\nCOMMAND: " + query);
            }
            return result;
        }
    }
}
