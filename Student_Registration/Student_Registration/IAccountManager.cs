using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    public interface IAccountManager
    {
        /// <summary>
        /// функция для создания подключения к базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="fileName">имя файла</param>
        void ConnectDB(Label lbStatusText, string fileName);
        /// <summary>
        /// функция для создания списка имён всех групп студентов
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns>список имён всех групп студентов</returns>
        List<string> GetNamesAllGroups(Label lbStatusText);
        /// <summary>
        /// метод для создания базы данных учителей
        /// </summary>
        /// <param name="status">Label для логирования</param>
        void CreateTeacherAccounts(Label status);
        /// <summary>
        /// метод для создания новой группы студентов
        /// </summary>
        /// <param name="status">Label для логирования</param>
        /// <param name="groupName">имя создаваемой группы</param>
        void CreateNewGroup(Label status, string groupName);
        /// <summary>
        /// функция для созтавления списка имён, фамилий, отчиств всех студентов в группе
        /// (требуется создание подключения в базе данных студентов перед исполнением)
        /// </summary>
        /// <param name="TableName">Label для логирования</param>
        /// <param name="ResultType">тип выводимого результата</param>
        /// <returns>список имён, фамилий, отчиств всех студентов в группе</returns>
        List<string> GetAllUsersSNP(string TableName, string ResultType);
        /// <summary>
        /// функция для читения одной выбранной записи таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="tableName">название таблицы</param>
        /// <param name="surname">фамиоия для поиска по ней пользователя</param>
        /// <returns>список всех данных выбранного пользователя</returns>
        Dictionary<string, string> ReadSelectedOnlyRow(Label lbStatusText, string tableName, string surname);
        /// <summary>
        /// метод для загрузки второстепенной информации (дисциплины, города, улицы...) в comboBox
        /// </summary>
        /// <param name="comboBox">загружаемый comboBox</param>
        /// <param name="TableName">назваие таблицы базы данных</param>
        /// <param name="ColumName">название столбца в таблице из которого загружаются данные</param>
        void LoadAllSecondaryItemsInComboBox(ComboBox comboBox, string TableName, string ColumName);
        /// <summary>
        /// метод для добавления новой второстепенной информации (дисциплины, города, улицы...) во вторичные таблицы
        /// </summary>
        /// <param name="statusText">Label для логирования</param>
        /// <param name="textBox">textBox из которого берётся название нового/ой дисциплины, города, улицы</param>
        /// <param name="TableName">название таблицы в которую будет добавлена запись</param>
        /// <param name="ColumnName">название столбца таблицы в который будет добавлено название нового/ой дисциплины, города, улицы</param>
        void AddSecondaryInfo(Label statusText, TextBox textBox, in string TableName, in string ColumnName);
        /// <summary>
        /// метод для добавления новой дисциплины
        /// </summary>
        /// <param name="statusText">Label для логирования</param>
        /// <param name="distsiplinaName">название новой дисциплины (на русском)</param>
        /// <param name="AltName">альтенативное название дисциплиены (на английйском без пробелов)</param>
        void AddDistsiplina(Label statusText, string distsiplinaName, string AltName);
        /// <summary>
        /// метод для добавления нового поьзователя
        /// </summary>
        /// <param name="status">Label для логирования</param>
        /// <param name="TableName">название таблицы в которую будет добавлена запись</param>
        /// <param name="columns">спипсок столбцов в таблице</param>
        /// <param name="data">данные нового пользователя</param>
        void AddNewUser(Label status, string TableName, List<string> columns, List<string> data);
        /// <summary>
        /// функция для получения ID определённой записи
        /// </summary>
        /// <param name="tableName">название таблицы из которой получаем ID</param>
        /// <param name="whereColumn">название столбца по которому вводим поисковое значение</param>
        /// <param name="value">значение по которому ищем запись</param>
        /// <returns>ID опрелелённой записи</returns>
        string GetID(in string tableName, in string whereColumn, in string value);
        /// <summary>
        /// функция для получения списка имён столбцов таблицы
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="tableNameDB">название таблицы</param>
        /// <returns>список имён стольцов таблицы</returns>
        List<string> GetColumnsNames(Label lbStatusText, in string tableNameDB);
        /// <summary>
        /// метод для удаления пользователя
        /// </summary>
        /// <param name="statusText">Label для логирования</param>
        /// <param name="tableNameDB">название таблицы</param>
        /// <param name="whereColumn">название столбца по которому вводим поисковое значение</param>
        /// <param name="value">значение по которому ищем запись</param>
        void DeleteUser(Label statusText, in string tableNameDB, in string whereColumn, in string value);
        /// <summary>
        /// метод для удаления таблицы
        /// </summary>
        /// <param name="statusText">Label для логирования</param>
        /// <param name="tableNameDB">название удаляемой таблицы</param>
        void DeleteTable(Label statusText, in string tableNameDB);
        /// <summary>
        /// метод для обновления данных ползователя
        /// </summary>
        /// <param name="status">Label для логирования</param>
        /// <param name="TableName">название таблицы</param>
        /// <param name="column">название столбца изменяемого значения</param>
        /// <param name="value">обновлённое значение</param>
        /// <param name="id">поисковый ID пользователя</param>
        void UpdateUserData(Label status, string TableName, string column, string value, string id);
        /// <summary>
        /// функция для проверки вводимой строки на валидность
        /// </summary>
        /// <param name="statusText">Label для логирования</param>
        /// <param name="EnterText">проверяемая сторка</param>
        /// <param name="CheckType">тип проверки</param>
        /// <returns>проверяемая строка валидна</returns>
        bool CheckForValidity(Label statusText, in string EnterText, in string CheckType);
        /// <summary>
        /// функция для чтения одного определённого значения из базы данных
        /// </summary>
        /// <param name="lbStatus">Label для логирования</param>
        /// <param name="tableName">название таблицы в которой будет осуществляться поиск</param>
        /// <param name="column">название столбца из которого будет загружаться значение</param>
        /// <param name="whereColumn">название столбца по которому вводим поисковое значение</param>
        /// <param name="value">значение по которому ищем запись</param>
        /// <returns>поисковое значение</returns>
        string ReadOneValue(Label lbStatus, string tableName, string column, string whereColumn, string value);
        /// <summary>
        /// функция для поиска одного определённого значения в группах студентов
        /// </summary>
        /// <param name="status">Label для логирования</param>
        /// <param name="column">название столбца из которого будет загружаться значение</param>
        /// <param name="whereColumn">название столбца по которому вводим поисковое значение</param>
        /// <param name="value">значение по которому ищем запись</param>
        /// <returns>поисковое значение</returns>
        string ReadAllGroups(Label status, string column, string whereColumn, string value);
        /// <summary>
        /// функция для поиска имени группы студентов по оперделённому значению
        /// </summary>
        /// <param name="status">Label для логирования</param>
        /// <param name="column">название столбца из которого будет загружаться значение</param>
        /// <param name="whereColumn">название столбца по которому вводим поисковое значение</param>
        /// <param name="value">значение по которому ищем запись</param>
        /// <returns>имя группы студентов</returns>
        string GetGroupName(Label status, string column, string whereColumn, string value);
        /// <summary>
        /// метод для изменения пароля администратора
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="txtAdminPassword">TextBox из которого берётся новое значение для изменеиня пароля</param>
        void ResetAdminPassword(Label lbStatusText, TextBox txtAdminPassword);
    }
}
