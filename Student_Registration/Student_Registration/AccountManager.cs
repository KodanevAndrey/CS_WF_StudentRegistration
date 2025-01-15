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
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

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
                /*
                string query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.password, a.phone_number, a.house_number, a.apartment_number, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        AS AccountsTable, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        FROM AccountsTable a
                        JOIN UchebnayaDistsiplinaTable b ON a.uchebnaya_distsiplina = b.id
                        JOIN CityTable c ON a.city = c.id
                        JOIN StreetTable d ON a.street = d.id
                        ;";
                */

                string query = @" SELECT name, surname, patronymic FROM "+ TableName +" ;";

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string userID = reader["id"].ToString();
                            string name = reader["name"].ToString();
                            string userName = reader["surname"].ToString();
                            string patronymic = reader["patronymic"].ToString();
                            //string password = reader["password"].ToString();
                            comboBox.Items.Add(userName + " " + name[0] + "." + patronymic[0] + ".");
                        }
                    }
                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show("ERROR:" + ex);
            }
        }

        public Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, int ID, string tableName)
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
                        "WHERE a.id = ' " + ID + " ' " +
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
                        "WHERE a.id = ' " + ID + " ' " +
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
    }
}
