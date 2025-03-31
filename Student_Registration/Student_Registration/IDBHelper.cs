using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public interface IDBHelper
    {
        /// <summary>
        /// метод для создания новой базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="DBName">имя новой базы данных</param>
        /// <param name="TableName">имя новой таблицы</param>
        /// <param name="listColumns">список создаваемых столбцов в таблице</param>
        void CreateNewDB(Label lbStatusText, string DBName, string TableName, List<string> listColumns);
        /// <summary>
        /// метод для создания подключения к базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns></returns>
        bool ConnectDB(Label lbStatusText);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbStatusText"></param>
        /// <param name="listBox"></param>
        void ReadCountTables(Label lbStatusText, ListBox listBox);
        void SelectedTable(ListBox listBox);
        void GetTableInfo(Label lbStatusText);
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer);
        void SelectCellToTable(Label lbStatusText, DataGridView dgvViewer);
        void ReadDB(Label lbStatusText, DataGridView dgvViewer);
        void AddDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        void DeleteDB(Label lbStatusText, Label lbCommandText, DataGridView dgvViewer);
        void ResetDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        void DeleteAllDB(Label lbStatusText);
        bool CheckToInt(in object cell);
    }
}
