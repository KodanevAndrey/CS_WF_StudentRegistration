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
        void CreateNewDB(Label lbStatusText, in string DBName, in string TableName, in List<string> listColumns);
        /// <summary>
        /// функция для создания подключения к базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns>подключение в БД прошло успешно</returns>
        bool ConnectDB(Label lbStatusText);
        /// <summary>
        /// метод для загрузки имён всех таблиц забы данных в listBox выбора для открытия конкретной таблицы
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="listBox">listBox выбора для открытия конкретной таблицы</param>
        void ReadCountTables(Label lbStatusText, ListBox listBox);
        /// <summary>
        /// метод для открытия контретной таблицы базы данных
        /// </summary>
        /// <param name="listBox">ListBox из которого выберается название открываемой таблицы</param>
        void СhosenTable(ListBox listBox);
        /// <summary>
        /// метод для загрузки информации о типах данных столбцов в таблице базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        void GetTableInfo(Label lbStatusText);
        /// <summary>
        /// метод для загрузки столбцов из таблицы базы данных в DataGridView 
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer);
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
        void DeleteDB(Label lbStatusText, Label lbCommand, DataGridView dgvViewer);
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
        /// <summary>
        /// фунцкия проверки на целое число
        /// </summary>
        /// <param name="cell">проверяемые данные из ячейки DataGridView</param>
        /// <returns>является целым числом</returns>
        bool CheckToInt(in object cell);
    }
}
