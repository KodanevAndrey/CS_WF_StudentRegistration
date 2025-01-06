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

        public AccountManager(string fileName)
        {
            this.dbFileName = fileName;
        }

        public bool ConnectDB(Label lbStatusText)
        {
            bool Conected = false;
            if (!File.Exists(dbFileName))
                MessageBox.Show("База данных: "+ dbFileName +" отсутствует!");
            else
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    lbStatusText.Text = "Connected";
                    lbStatusText.ForeColor = Color.Green;
                    Conected = true;
                }
                catch (SQLiteException ex)
                {
                    lbStatusText.Text = "Disconnected";
                    lbStatusText.ForeColor = Color.Red;
                    MessageBox.Show("Error ConnectDB: " + ex.Message);
                }
            return Conected;
        }

        public void ReadAllName(Label lbStatusText, ComboBox comboBox)
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

                string query = @"
                        SELECT name, surname, patronymic 
                        FROM AccountsTable 
                        ;";

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

        public void ReadSelectedRecord(Label lbStatusText, int ID, TextBox textName, TextBox textSurname, TextBox textPatronymic)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                string query = @"
                        SELECT a.id, a.name, a.surname, a.patronymic, a.email, a.password, a.phone_number, a.house_number, a.apartment_number, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        AS AccountsTable, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        FROM AccountsTable a " +
                        "JOIN UchebnayaDistsiplinaTable b ON a.uchebnaya_distsiplina = b.id " +
                        "JOIN CityTable c ON a.city = c.id " +
                        "JOIN StreetTable d ON a.street = d.id " +
                        "WHERE a.id = ' "+ ID +" ' " +
                        ";";

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                         reader.Read();
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        //string userID = reader["id"].ToString();
                        textName.Text = reader["name"].ToString();
                        textSurname.Text = reader["surname"].ToString();
                        textPatronymic.Text = reader["patronymic"].ToString();
                        //string password = reader["password"].ToString();
                    }
                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show("ERROR:" + ex);
            }
        }
    }
}
