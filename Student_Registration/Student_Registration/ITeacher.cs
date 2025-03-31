using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    internal interface ITeacher
    {
        bool ConnectDB(Label lbStatusText, string fileName);
        void CreateNewTableInMagazine(Label lbStatusText, string MagazineName, string TableName, List<string> listColumns);
        string GetDistsiplinaAltName(string DistsiplinaName);
        bool CheckTableExistence(Label lbStatusText, string TableName);
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName);
        void SelectedTable(string tableName);
        void GetTableInfo(Label lbStatusText);
        void SelectCellToTable(Label lbStatusText, DataGridView dgvViewer);
        void ReadDB(Label lbStatusText, DataGridView dgvViewer);
        void AddDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        void DeleteDB(Label lbStatusText, Label lbCommandText, DataGridView dgvViewer);
        void ResetDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        void DeleteAllDB(Label lbStatusText);
    }
}
