using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data;
using ConnectSQLite_KodanevAndrey;
using System;

namespace Student_Registration
{
    public class MagazinesManager : DBHelper, IMagazinesManager
    {
        public virtual void CreateNewMagazine(Label lbStatusText, string MagazineName, string TableName)
        {
            if (MagazineName != "")
            {
                try
                {
                    dbFileName = "Magazine_" + MagazineName + ".sqlite";
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TableName + " ( " +
                        "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                        "name TEXT NOT NULL, " +
                        "surname TEXT NOT NULL, " +
                        "patronymic TEXT NOT NULL);";

                    lbStatusText.Text = m_sqlCmd.CommandText;
                    m_sqlCmd.ExecuteNonQuery();
                    lbStatusText.Text = "журнал создан!";
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("CreateNewMagazine ERROR:" + ex + "\nCOMMAND: " + m_sqlCmd.CommandText);
                }
            }
            else lbStatusText.Text = "введите имя для новой базы данных!";
        }

        public virtual bool ConnectDB(Label lbStatusText, string fileName)
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

        public virtual void CreateNewTableInMagazine(Label lbStatusText, string MagazineName, string TableName, List<string> listColumns)
        {
            if (MagazineName != "")
            {
                try
                {
                    dbFileName = MagazineName + ".sqlite";
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

        public virtual string GetDistsiplinaAltName(string DistsiplinaName)
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

        public virtual bool CheckTableExistence(Label lbStatusText, string TableName)
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

        public virtual void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName)
        {
            TableNameDB = TableName;
            LoadTableInfo(lbStatusText, dgvViewer);
        }

        public virtual void SelectedTable(string tableName)
        {
            TableNameDB = tableName;
            DataTable dTable = new DataTable();
            string sqlQuery = "SELECT * FROM " + TableNameDB + " ";
            adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
            adapter.Fill(dTable);
        }

        public override void ResetDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                lbStatusText.Text = "Open connection with database";
                return;
            }
            string status = "";
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);
            int RowCount = dTable.Rows.Count;
            bool IsActive = true;
            try
            {
                foreach (int IndexColumnsTypeInt in DBTableColumnsTypeInt)
                {
                    if (SelectedColumnIndex == IndexColumnsTypeInt)
                        if (!CheckToInt(dgvViewer.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value))
                        {
                            IsActive = false;
                            status = "введено некорректное значение: ячейка под столбцом " + dgvViewer.Columns[SelectedRowIndex].Name + " имеет числовой тип!";
                        }
                        else if ( Convert.ToInt32(dgvViewer.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value) > 5 || Convert.ToInt32(dgvViewer.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value) < 2)
                        {
                            IsActive = false;
                            status = "введено некорректное значение: значение под столбцом " + dgvViewer.Columns[SelectedRowIndex].Name + " должна быть не меньше 2 и не больше 5!";
                        }
                }

                if (IsActive == true)
                {
                    m_sqlCmd.CommandText = "UPDATE " + TableNameDB + " SET ";
                    m_sqlCmd.CommandText += NameSelectedColumn + " = ";
                    for (int j = 0; j < dgvViewer.Columns.Count; j++)
                    {
                        if (NameSelectedColumn == dgvViewer.Columns[j].Name)
                        {
                            lbStatusText.Text = "новое значение выбранной ячейки сейчас = " + dgvViewer.Rows[SelectedRowIndex].Cells[j].Value;
                            lbStatusText.Text += "\nПри выполнении операции было выбрано:" + "\nстолбец = " + NameSelectedColumn + "\nстрочка = " + SelectedRowIndex + "\nячейка = " + NameSelectedCell;
                            m_sqlCmd.CommandText += "'" + dgvViewer.Rows[SelectedRowIndex].Cells[j].Value + "'";
                        }
                    }
                    m_sqlCmd.CommandText += " WHERE " + NameSelectedColumn + " = ";
                    if (NameSelectedCell != "NULL")
                    {
                        m_sqlCmd.CommandText += "'" + NameSelectedCell + "'";
                        m_sqlCmd.ExecuteNonQuery();
                        status += "ЗАПИСЬ ВЫПОЛНЕНА!";
                        ReadDB(lbStatusText, dgvViewer);
                    }
                    else { status += "выберите ячейту для изменения!"; }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error ResetDB: " + ex.Message);
            }
            lbStatusText.Text = status;
            lbCommand.Text = m_sqlCmd.CommandText;
        }

        public virtual List<string> GetNamesAllDisciplines(Label lbStatusText)
        {
            List<string> _namesOfAllGroups = new List<string>();
            bool correct = true;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
            }

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
                            if (reader["name"].ToString() == "BaseInfo" || reader["name"].ToString() == "sqlite_sequence")
                                correct = false;

                            if (correct == true)
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
    }
}
