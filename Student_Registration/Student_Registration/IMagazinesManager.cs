using System.Collections.Generic;
using System.Windows.Forms;


namespace Student_Registration
{
    public interface IMagazinesManager : IDBHelper
    {
        void CreateNewMagazine(Label lbStatusText, string MagazineName, string TableName);
        bool ConnectDB(Label lbStatusText, string fileName);
        void CreateNewTableInMagazine(Label lbStatusText, string MagazineName, string TableName, List<string> listColumns);
        string GetDistsiplinaAltName(string DistsiplinaName);
        bool CheckTableExistence(Label lbStatusText, string TableName);
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName);
        void SelectedTable(string tableName);
        List<string> GetNamesAllDisciplines(Label lbStatusText);
    }
}
