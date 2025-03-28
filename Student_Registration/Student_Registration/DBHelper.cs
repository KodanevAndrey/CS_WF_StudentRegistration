using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Student_Registration;



namespace ConnectSQLite_KodanevAndrey
{
    public class DBHelper : IDBHelper
    {
        protected string dbFileName;
        protected string TableNameDB;
        protected string FileLocation;
        protected SQLiteConnection m_dbConn = new SQLiteConnection();
        protected SQLiteCommand m_sqlCmd = new SQLiteCommand();
        protected SQLiteDataAdapter adapter;
        protected string NameSelectedColumn;
        protected string NameSelectedCell;
        protected int SelectedRowIndex;
        protected int SelectedColumnIndex;
        protected List<int> DBTableColumnsTypeBlob = new List<int>();
        protected List<int> DBTableColumnsTypeText = new List<int>();
        protected List<int> DBTableColumnsTypeInt = new List<int>();
        protected List<int> DBTableColumnsTypeNotBlob = new List<int>();

        public virtual void CreateNewDB(Label lbStatusText, string DBName, string TableName, List<string> listColumns)
        {
            if (DBName != "")
            {
                SQLiteConnection.CreateFile(DBName + ".sqlite");
                try
                {
                    dbFileName = DBName + ".sqlite";
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                    m_dbConn.Open();
                    m_sqlCmd.Connection = m_dbConn;
                    m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TableName + "(";
                    for (int i = 0; i < listColumns.Count; i++)
                    {
                        m_sqlCmd.CommandText += listColumns[i];
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
                    lbStatusText.Text = "Disconnected";
                    lbStatusText.ForeColor = Color.Red;
                    MessageBox.Show("Error CreateDB: " + ex.Message);
                }
            }
            else lbStatusText.Text = "введите имя для новой базы данных!";
        }

        public virtual bool ConnectDB(Label lbStatusText)
        {
            DBTableColumnsTypeInt.Clear();
            DBTableColumnsTypeText.Clear();
            DBTableColumnsTypeBlob.Clear();
            DBTableColumnsTypeNotBlob.Clear();
            bool Conected = false;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C\\";
            dlg.RestoreDirectory = true;
            dlg.Filter = "DataBase Files (*.mdb; *.sqlite)|*.mdb; *.sqlite";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileLocation = dlg.FileName;
                if (!File.Exists(FileLocation))
                    MessageBox.Show("ConnectDB: Please, create DB and blank table (Push \"Create\" button)");
                else
                    try
                    {
                        m_dbConn = new SQLiteConnection("Data Source=" + FileLocation + ";Version=3;");
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
            }
            return Conected;
        }

        public virtual void ReadCountTables(Label lbStatusText, ListBox listBox)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                string query = "SELECT count(*) FROM sqlite_master WHERE type='table';";
                using (var command = new SQLiteCommand(query, m_dbConn))
                {
                    int tableCount = Convert.ToInt32(command.ExecuteScalar());
                    lbStatusText.Text = "Количество таблиц в базе данных: " + tableCount;
                }
                int i = 0;
                query = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";

                using (var command = new SQLiteCommand(query, m_dbConn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox.Items.Add(reader["name"].ToString());
                            i++;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error LoadCountTables: " + ex.Message);
            }
        }

        public virtual void SelectedTable(ListBox listBox)
        {
            TableNameDB = listBox.SelectedItem.ToString();
            DataTable dTable = new DataTable();
            string sqlQuery = "SELECT * FROM " + TableNameDB + " ";
            adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
            adapter.Fill(dTable);
        }

        public virtual void GetTableInfo(Label lbStatusText)
        {
            lbStatusText.Text = "";
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                int index;
                m_sqlCmd.CommandText = "pragma table_info('" + TableNameDB + "');";
                SQLiteDataReader sqlite_datareader = m_sqlCmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    index = sqlite_datareader.GetInt32(0);
                    if (sqlite_datareader.GetString(2) == "BLOB") DBTableColumnsTypeBlob.Add(index);
                    if (sqlite_datareader.GetString(2) == "TEXT") DBTableColumnsTypeText.Add(index);
                    if (sqlite_datareader.GetString(2) == "INTEGER") DBTableColumnsTypeInt.Add(index);
                    if (sqlite_datareader.GetString(2) == "INTEGER" || sqlite_datareader.GetString(2) == "TEXT") DBTableColumnsTypeNotBlob.Add(index);
                }
                sqlite_datareader.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error LoadTable: " + ex.Message);
            }
        }

        public virtual void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer)
        {
            if (dgvViewer.Columns.Count != 0) { dgvViewer.Columns.Clear(); }
            DataTable dTable = new DataTable();

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                m_sqlCmd.CommandText = "select * from " + TableNameDB;
                SQLiteDataReader dr = m_sqlCmd.ExecuteReader();
                lbStatusText.Text = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetDataTypeName(i) == "BLOB") { dgvViewer.Columns.Add(new DataGridViewTextBoxColumn() { Name = dr.GetName(i), HeaderText = dr.GetName(i), Width = 100, ReadOnly = true }); }
                    else { dgvViewer.Columns.Add(new DataGridViewTextBoxColumn() { Name = dr.GetName(i), HeaderText = dr.GetName(i), Width = 100 }); }
                }
                dr.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error LoadTable: " + ex.Message);
            }
        }

        public virtual void SelectCellToTable(Label lbStatusText, DataGridView dgvViewer)
        {
            int selectedRowCount = dgvViewer.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    NameSelectedColumn = dgvViewer.SelectedCells[i].OwningColumn.Name.ToString();
                    SelectedRowIndex = dgvViewer.SelectedCells[i].RowIndex;
                    SelectedColumnIndex = dgvViewer.SelectedCells[i].ColumnIndex;
                    sb.Append("Row: " + SelectedRowIndex);
                    sb.Append(", Column: " + NameSelectedColumn);
                    if (dgvViewer.SelectedCells[i].Value != null) { NameSelectedCell = dgvViewer.SelectedCells[i].Value.ToString(); sb.Append(" Cell: " + NameSelectedCell); }
                    else { sb.Append(" Cell: NULL"); }
                    sb.Append(Environment.NewLine);
                }
                sb.Append("Total: " + selectedRowCount.ToString());
                lbStatusText.Text = "столбец Name = " + NameSelectedColumn + "столбец Index = " + SelectedColumnIndex + "\nстрочка = " + SelectedRowIndex + "\nячейка = " + NameSelectedCell;
            }
        }

        public virtual void ReadDB(Label lbStatusText, DataGridView dgvViewer)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            try
            {
                sqlQuery = "SELECT * FROM " + TableNameDB + " ";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dgvViewer.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                        dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
                }
                else { dgvViewer.Rows.Clear(); lbStatusText.Text = "Database is empty"; lbStatusText.ForeColor = Color.Red; }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error ReadDB: " + ex.Message);
            }
        }

        public virtual void AddDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer)
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }
            string status = "";
            bool IsActive = true;
            DataTable dTable = new DataTable();
            adapter.Fill(dTable);
            int RowCount = dTable.Rows.Count;
            status += " количество записей в дазе данных: " + dTable.Rows.Count.ToString();
            try
            {
                for (int i = 0; i < DBTableColumnsTypeNotBlob.Count; i++)
                {
                    status += dgvViewer.Rows[RowCount].Cells[DBTableColumnsTypeNotBlob[i]].Value + " | ";
                    status += dgvViewer.Rows[RowCount].Cells[DBTableColumnsTypeNotBlob[i]].Value + " | ";
                    if (dgvViewer.Rows[RowCount].Cells[DBTableColumnsTypeNotBlob[i]].Value == null)
                    {
                        IsActive = false;
                        status += "ячейка под столбцом " + dgvViewer.Columns[i].Name + " не заполнена!";
                        return;
                    }
                    foreach (int IndexColumnsTypeInt in DBTableColumnsTypeInt)
                    {
                        if (DBTableColumnsTypeNotBlob[i] == IndexColumnsTypeInt)
                        {
                            if (!CheckToInt(dgvViewer.Rows[RowCount].Cells[DBTableColumnsTypeNotBlob[i]].Value))
                            {
                                IsActive = false;
                                status = "введено некорректное значение: ячейка под столбцом " + dgvViewer.Columns[i].Name + " имеет числовой тип!";
                            }
                        }
                    }
                }
                if (IsActive == true)
                {
                    m_sqlCmd.CommandText = "INSERT INTO " + TableNameDB + " (";
                    for (int i = 0; i < DBTableColumnsTypeNotBlob.Count; i++)
                    {
                        m_sqlCmd.CommandText += " '" + dgvViewer.Columns[i].Name + "'";
                        if (i != DBTableColumnsTypeNotBlob.Count - 1) m_sqlCmd.CommandText += ", ";
                    }
                    m_sqlCmd.CommandText += ") values (";
                    for (int i = 0; i < DBTableColumnsTypeNotBlob.Count; i++)
                    {
                        m_sqlCmd.CommandText += " '" + dgvViewer.Rows[RowCount].Cells[DBTableColumnsTypeNotBlob[i]].Value + "'";
                        if (i != DBTableColumnsTypeNotBlob.Count - 1) m_sqlCmd.CommandText += ", ";
                    }
                    m_sqlCmd.CommandText += ")";
                    m_sqlCmd.ExecuteNonQuery();
                    lbCommand.Text = m_sqlCmd.CommandText;
                    status += "ЗАПИСЬ ВЫПОЛНЕНА!";
                    ReadDB(lbStatusText, dgvViewer);
                }
                else { lbStatusText.ForeColor = Color.Red; }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error AddDB: " + ex.Message);
            }
            lbStatusText.Text = status;
            lbCommand.Text = m_sqlCmd.CommandText;
        }

        public virtual void DeleteDB(Label lbStatusText, Label lbCommandText, DataGridView dgvViewer)
        {
            
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить запись", "Удаление записи", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (m_dbConn.State != ConnectionState.Open)
                {
                    lbStatusText.Text = "Open connection with database";
                    lbStatusText.ForeColor = Color.Red;
                    return;
                }
                try
                {
                    m_sqlCmd.CommandText = "DELETE FROM " + TableNameDB + " WHERE " + NameSelectedColumn + " = '" + NameSelectedCell + "' ";
                    lbStatusText.Text = m_sqlCmd.CommandText;
                    m_sqlCmd.ExecuteNonQuery();
                    lbStatusText.Text = "удаление выполнено! '" + NameSelectedColumn + "' = " + NameSelectedCell.ToString();
                    lbStatusText.ForeColor = Color.Green;
                    ReadDB(lbStatusText, dgvViewer);
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error DeleteDB: " + ex.Message);
                }
                lbCommandText.Text = m_sqlCmd.CommandText;
            }
        }

        public virtual void ResetDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer)
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
                foreach(int IndexColumnsTypeInt in DBTableColumnsTypeInt)
                {
                    if (SelectedColumnIndex == IndexColumnsTypeInt)
                        if (!CheckToInt(dgvViewer.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value))
                        {
                            IsActive = false;
                            status = "введено некорректное значение: ячейка под столбцом " + dgvViewer.Columns[SelectedColumnIndex].Name + " имеет числовой тип!";
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

        public virtual void DeleteAllDB(Label lbStatusText)
        {

            if (m_dbConn.State != ConnectionState.Open)
            {
                lbStatusText.Text = "Open connection with database";
                return;
            }

            try
            {
                m_sqlCmd.CommandText = "DELETE FROM " + TableNameDB;
                m_sqlCmd.ExecuteNonQuery();
                lbStatusText.Text = "удаление выполнено!";
                lbStatusText.ForeColor = Color.Green;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error DeleteAllDB: " + ex.Message);
            }
        }

        protected virtual Image LoadImage()
        {
            Image image = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"C:\\";
            dlg.Title = "Select Image File";
            dlg.RestoreDirectory = true;
            dlg.Filter = "Image Files  (*.jpg ; *.jpeg ; *.png ; *.gif ; *.tiff ; *.nef) | *.jpg; *.jpeg; *.png; *.gif; *.tiff; *.nef";
            this.FileLocation = dlg.FileName;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileLocation = dlg.FileName;
                var fileStream = dlg.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    image = Image.FromFile(FileLocation);
                }
            }
            return image;
        }

        public virtual void AddImageToDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer)
        {
            lbStatusText.Text = "";
            string status = "";
            Image image = LoadImage();
            string SelectName = null;
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }


            if (image != null && NameSelectedColumn != null)
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (int ColumnIndex in DBTableColumnsTypeBlob)
                {
                    if (NameSelectedColumn == dataTable.Columns[ColumnIndex].ColumnName)
                    {
                        SelectName = dataTable.Columns[ColumnIndex].ColumnName;
                    }
                }
                try
                {
                    m_sqlCmd.CommandText = "UPDATE " + TableNameDB + " SET " + SelectName + " = '" + image + "' WHERE " + NameSelectedColumn + " = ";
                    if (NameSelectedCell != "NULL")
                    {
                        m_sqlCmd.CommandText += "'" + NameSelectedCell + "'";
                        lbCommand.Text = m_sqlCmd.CommandText;
                        lbStatusText.Text += "SelectColumName = " + SelectName;
                        m_sqlCmd.ExecuteNonQuery();
                        status += "ЗАПИСЬ ВЫПОЛНЕНА!";
                    }
                    else { status = "выберите ячейту для изменения!"; }
                    lbStatusText.Text += "изображение загружено";
                    lbStatusText.ForeColor = Color.Green;
                    ReadDB(lbStatusText,dgvViewer);
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error AddImageToDB: " + ex.Message);
                }
            }
            else { lbStatusText.Text = "выберите изображение!"; lbStatusText.ForeColor = Color.Red; }
        }

        public virtual bool CheckToInt(in object cell)
        {
            if (cell == null) 
            {
                MessageBox.Show("Выберите ячейку!");
                return false; 
            }
            int CountTypeInt = 0;
            string Value = cell.ToString();
            for (int i = 0; i < Value.Length; i++)
            {
                for (char j = '0'; j <= '9'; j++)
                {
                    if (Value[i] == j) { CountTypeInt++; break; }
                }
            }
            if (CountTypeInt == Value.Length) return true;
            else return false;
        }
    }
}
