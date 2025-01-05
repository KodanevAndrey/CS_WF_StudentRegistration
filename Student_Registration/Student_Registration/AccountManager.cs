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

        public void LoadItems(Label lbStatusText, ComboBox comboBox)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                string query = @"
                        SELECT a.id, a.name a.userName, a.patronymic, b.uchebnaya_distsiplina, a.email, a.password, a.phone_number, c.city, d.street, a.house_number, a.apartment_number
                        AS BasicTable, b.uchebnaya_distsiplina_name, c.city_name, d.street_name
                        FROM BasicTable a
                        JOIN UchebnayaDistsiplinaTable b ON a.uchebnaya_distsiplina = b.id
                        JOIN CityTable c ON a.city = c.id
                        JOIN StreetTable d ON a.street = d.id
                        ;";

                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //string userID = reader["id"].ToString();
                            string userName = reader["userName"].ToString();
                            comboBox.Items.Add(userName);
                        }
                    }
                }
            }
            catch (SQLiteException ex) {
                MessageBox.Show("ERROR:" + ex);
            }
        }
    }
}
