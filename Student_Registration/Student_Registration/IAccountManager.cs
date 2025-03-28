using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public interface IAccountManager
    {
        void ConnectDB(Label lbStatusText, string fileName);
        void CreateAccountsTable(Label status);
        int GetCountRowsInTable(Label lbStatusText, string tableName);
        List<string> GetNameAllGroups(Label lbStatusText);
        void CreateNewGroup(Label status, string tableName);
        List<string> GetAllUsersSNP(string TableName, string ResultType);
        Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, string tableName, string surname);
        void LoadAllItemsForComboBox(ComboBox comboBox, string TableName, string ColumName);
        void AddSecondaryInfo(Label statusText, TextBox textBox, in string TableName, in string ColumnName);
        void AddUchebnayaDistsiplina(Label statusText, string distsiplinaName, string AltName);
        void AddNewUserDB(Label status, string TableName, List<string> columns, List<string> data);
        string GetID(in string tableNameDB, in string ColumnName, in string Value);
        List<string> GetTableInfo(Label lbStatusText, in string tableNameDB);
        void DeleteUser(Label statusText, in string tableNameDB, in string columnName, in string Value);
        void DeleteTable(Label statusText, in string tableNameDB);
        void Reset(Label status, string TableName, string column, string value, string id);
        bool CheckForValidity(Label statusText, in string EnterText, in string CheckType);
        string ReadOneValue(Label lbStatus, string tableName, string column, string whereColumn, string value);
        string ReadAllGroups(Label status, string column, string whereColumn, string value);
        string GetGroupName(Label status, string column, string whereColumn, string value);
        void ResetAdminPassword(Label lbStatusText, TextBox txtAdminPassword);
    }
}
