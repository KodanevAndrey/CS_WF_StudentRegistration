using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public interface IDBHelper
    {
        void CreateNewDB(Label lbStatusText, string DBName, string TableName, List<string> listColumns);
        bool ConnectDB(Label lbStatusText);
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
        void AddImageToDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        bool CheckToInt(in object cell);
    }
}
