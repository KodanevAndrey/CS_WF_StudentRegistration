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

namespace Student_Registration
{
    public class AccountManager
    {
        private string dbFileName;
        private string TableNameDB;
        private SQLiteConnection m_dbConn = new SQLiteConnection();
        private SQLiteCommand m_sqlCmd = new SQLiteCommand();
        private SQLiteDataAdapter adapter;
        private string fileLocation = string.Empty;

        public void ConnectDB(Label lbStatusText ,string fileName)
        {
            dbFileName = fileName;
            if (!File.Exists(dbFileName))
                MessageBox.Show("База данных: "+ dbFileName +" отсутствует!");
            else
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
                    MessageBox.Show("Error ConnectDB: " + ex.Message);
                }
        }

        public void ReadCountTables(Label lbStatusText, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            bool correct = true;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            comboBox.Items.Clear();
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
                        comboBox.Items.Add("добавить группу");
                        while (reader.Read())
                        {
                            correct = true;
                            foreach (string row in DontReadTables) {
                                if (reader["name"].ToString() == row)
                                 correct = false;
                            }
                            if(correct == true)
                                comboBox.Items.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error LoadCountTables: " + ex.Message);
            }
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
                MessageBox.Show("ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }       
        }

        public void ReadAllName(Label lbStatusText, ComboBox comboBox, string TableName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
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
                            comboBox.Items.Add(userName + " " + name[0] + "." + patronymic[0] + ".");
                        }
                    }
                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show("ERROR:" + ex);
            }
        }

        public Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, string Surname, string tableName)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            try
            {
                string query = "";

                if (tableName == "NULL")
                {
                     query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.password, a.phone_number, a.house_number, a.apartment_number, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        AS AccountsTable, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        FROM AccountsTable a " +
                        "JOIN UchebnayaDistsiplinaTable b ON a.uchebnaya_distsiplina = b.id " +
                        "JOIN CityTable c ON a.city = c.id " +
                        "JOIN StreetTable d ON a.street = d.id " +
                        "WHERE a.surname = '" + Surname + "' " +
                        ";";
                }
                else
                {
                     query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.password, a.phone_number, a.house_number, a.apartment_number, b.group_name, c.city_name, d.street_name " +
                        "AS " + tableName + ", b.group_name, c.city_name, d.street_name " +
                        "FROM " + tableName +" a " +
                        "JOIN GroupsTable b ON a.group_student = b.id " +
                        "JOIN CityTable c ON a.city = c.id " +
                        "JOIN StreetTable d ON a.street = d.id " +
                        "WHERE a.surname = '" + Surname + "'" +
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
                MessageBox.Show("ERROR:" + ex);
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
                MessageBox.Show("ERROR:" + ex);
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
                MessageBox.Show("ERROR:" + ex);
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
                MessageBox.Show("ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
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
                MessageBox.Show("ERROR:" + ex + "\nCOMMAND: " + query);
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
                MessageBox.Show("Error LoadTable: " + ex.Message +"\nCOMMAND: " + m_sqlCmd.CommandText);
            }
            return columns;
        }

        public bool CheckForValidity(Label statusText, in string EnterText, in string CheckType )
        {
            bool IsCorrect = true;
            if(EnterText == "") { statusText.Text = "\nстока пуста!"; return false; }
            switch (CheckType)
            {
                case "noInt":
                    foreach(char c in EnterText)
                    {
                        for(int i = 48; i <= 57; i++)
                        {
                            if (c == i)
                            {
                                IsCorrect = false;
                                statusText.Text = "в строке: " + EnterText + " не должно быть цисел!";
                            }
                        }
                    }
                    break;
                case "name":
                    bool IsCapitalLetter = false;
                    for (int i = 1040; i <= 1071; i++)
                    {
                        if (EnterText[0] == i) IsCapitalLetter = true;
                    }
                    if (!IsCapitalLetter)
                    {
                        IsCorrect = false;
                        statusText.Text = "\nв строке: " + EnterText + " должна быть заглавная буква!";
                    }
                    foreach (char c in EnterText)
                    {
                        for (int i = 48; i <= 57; i++)
                        {
                            if (c == i)
                            {
                                IsCorrect = false;
                                statusText.Text = "\nв строке: " + EnterText + " не должно быть цисел!";
                            }
                        }
                    }
                    break;
                case "onlyInt":
                    foreach(char c in EnterText)
                    {
                        for (int i = 1040; i <= 1102; i++)
                        {
                            if (c == i)
                            {
                                IsCorrect = false;
                                statusText.Text = "\nв строке: " + EnterText + " не должно быть букв!";
                            }
                        }
                    }
                    break;
                default: statusText.Text = "\n неопределён тип проверки на валидацию вводимых данных!"; return false;
            }
            if(IsCorrect) statusText.Text = "\nстрока: " + EnterText + " валидна!";
            return IsCorrect;
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
                MessageBox.Show("Error LoadTable: " + ex.Message + "\nCOMMAND: " + m_sqlCmd.CommandText);
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
                string query = @"DROP TABLE" + tableNameDB + ";";
                m_sqlCmd.CommandText = query;
                m_sqlCmd.ExecuteNonQuery();
                statusText.Text = "Таблица Удалена!";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error LoadTable: " + ex.Message + "\nCOMMAND: " + m_sqlCmd.CommandText);
            }
        }
    }
}
