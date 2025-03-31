using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    internal interface IStudent 
    {
        bool ConnectDB(Label lbStatusText, string fileName);
        List<string> GetNamesAllDisciplines(Label lbStatusText);
        void SelectedTable(string tableName);
        void GetTableInfo(Label lbStatusText);
        void ReadDB(Label lbStatusText, DataGridView dgvViewer);
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName);
    }
}
