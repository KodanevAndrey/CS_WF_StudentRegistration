using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System;
using ConnectSQLite_KodanevAndrey;

namespace Student_Registration
{
    internal class MagazinesManager : DBHelper
    {
        private string dbFileName;
        private SQLiteConnection m_dbConn = new SQLiteConnection();
        private SQLiteCommand m_sqlCmd = new SQLiteCommand();

        public bool ConnectDB(Label lbStatusText, string fileName)
        {
            dbFileName = fileName;
            if (!File.Exists(dbFileName))
                MessageBox.Show("База данных: " + dbFileName + " отсутствует!");
            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                lbStatusText.Text = "Connected: " + dbFileName;
                lbStatusText.ForeColor = Color.Green;
                return true;
            }
            catch (SQLiteException ex)
            {
                lbStatusText.Text = "Disconnected";
                lbStatusText.ForeColor = Color.Red;
                MessageBox.Show("ConnectDB ERROR:" + ex + "\nCOMMAND: " + m_dbConn);
                return false;
            }
        }

        public void CreateNewTableInMagazine(Label lbStatusText, string MagazineName, string TableName, List<string> Students)
        {
            CreateNewDB(lbStatusText,MagazineName,TableName,Students);
        }

        private void CreateNewDB(Label lbStatusText, string DBName, string TableName, List<string> listColumns)
        {
            if (DBName != "")
            {
                try
                {
                    dbFileName = DBName + ".sqlite";
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.CommandText = @"CREATE TABLE " + TableName + " (";
                    m_sqlCmd.CommandText += "exerciseNumber INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
                    m_sqlCmd.CommandText += "description TEXT NOT NULL,";
                    for (int i = 0; i < listColumns.Count; i++)
                    {
                        m_sqlCmd.CommandText += listColumns[i];
                        m_sqlCmd.CommandText += " INTEGER NOT NULL";
                        if (i != listColumns.Count - 1) m_sqlCmd.CommandText += ", ";
                    }
                    m_sqlCmd.CommandText += ")";
                    lbStatusText.Text = m_sqlCmd.CommandText;
                    m_sqlCmd.ExecuteNonQuery();
                    lbStatusText.Text += " База данных создана!";
                    lbStatusText.Text += " Connected";
                    lbStatusText.ForeColor = Color.Green;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("CreateNewDB ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
                }
            }
            else lbStatusText.Text = "введите имя для новой базы данных!";
        }

        public string GetDistsiplinaAltName(string DistsiplinaName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }
            string query = @"SELECT AltName FROM UchebnayaDistsiplinaTable WHERE uchebnaya_distsiplina_name = '" + DistsiplinaName + "';";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader["AltName"].ToString();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("GetDistsiplinaAltName ERROR:" + ex + "\nCOMMAND: " + query);
                return "GetDistsiplinaAltName ERROR:" + ex + "\nCOMMAND: " + query;
            }
        }

        public bool CheckTableExistence(Label lbStatusText, string TableName)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }

            string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='"+ TableName + "'";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, m_dbConn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.HasRows;
                    }
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("CheckTableExistence ERROR:" + ex + "\nCOMMAND: " + query);
                return false;
            }
        }

        public void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName)
        {
            TableNameDB = TableName;
            LoadTableInfo(lbStatusText, dgvViewer);
        }
    }
}
