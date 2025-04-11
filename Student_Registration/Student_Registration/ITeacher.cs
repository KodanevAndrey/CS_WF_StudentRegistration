using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    internal interface ITeacher
    {
        /// <summary>
        /// функция для создания подключения к базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns>подключение в БД прошло успешно</returns>
        bool ConnectDB(Label lbStatusText, string fileName);
        /// <summary>
        /// метод для создания новой дисциплины в журнале
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="MagazineName">ниазвание журнала группы</param>
        /// <param name="TableName">название новой таблицы/дисциплины</param>
        /// <param name="listColumns">список студентов группы</param>
        void CreateNewTableInMagazine(Label lbStatusText, string MagazineName, string TableName, List<string> listColumns);
        /// <summary>
        /// функция для получения альтернативного названия дисциплины
        /// </summary>
        /// <param name="DistsiplinaName">основное (на русском) название дисциплины для поиска</param>
        /// <returns>альтернативное название дисциплины</returns>
        string GetDistsiplinaAltName(string DistsiplinaName);
        /// <summary>
        /// функция для проверки на наличие таблицы/дисциплины в журнале
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="TableName">название таблицы/дисциплины для поиска в журнале</param>
        /// <returns>таблица/дисциплина существует в данном журнале</returns>
        bool CheckTableExistence(Label lbStatusText, string TableName);
        /// <summary>
        /// метод для загрузки столбцов из таблицы базы данных в DataGridView 
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName);
        /// <summary>
        /// метод для открытия контретной таблицы базы данных
        /// </summary>
        /// <param name="tableName">название открываемой таблицы</param>
        void СhosenTable(string tableName);
        /// <summary>
        /// метод для загрузки информации о типах данных столбцов в таблице базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        void GetTableInfo(Label lbStatusText);
        /// <summary>
        /// метод для определения выбранной пользователем ячейки и столбца
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void SelectCellInTable(Label lbStatusText, DataGridView dgvViewer);
        /// <summary>
        /// метод для чтения данных из таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void ReadDB(Label lbStatusText, DataGridView dgvViewer);
        /// <summary>
        /// метод для добавления новых записей в таблицу базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="lbCommand">Label для отображения SQL запросов</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void AddDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        /// <summary>
        /// метод для удаления одной определённой записи из таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="lbCommand">Label для отображения SQL запросов</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void DeleteDB(Label lbStatusText, Label lbCommandText, DataGridView dgvViewer);
        /// <summary>
        /// метод для изменения данных в одной ячейче таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="lbCommand">Label для отображения SQL запросов</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void ResetDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
        /// <summary>
        /// метод для удаления всех данных из таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        void DeleteAllDB(Label lbStatusText);
    }
}
