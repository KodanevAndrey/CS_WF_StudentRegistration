using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_Registration
{
    internal interface IStudent 
    {
        /// <summary>
        /// функция для создания подключения к базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns>подключение в БД прошло успешно</returns>
        bool ConnectDB(Label lbStatusText, string fileName);
        /// <summary>
        /// фунуция для составления списка названий всех существующих дисциплин в базе данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <returns> список названий всех существующих дисциплин в базе данных</returns>
        List<string> GetNamesAllDisciplines(Label lbStatusText);
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
        /// метод для чтения данных из таблицы базы данных
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void ReadDB(Label lbStatusText, DataGridView dgvViewer);
        /// <summary>
        /// метод для загрузки столбцов из таблицы базы данных в DataGridView 
        /// </summary>
        /// <param name="lbStatusText">Label для логирования</param>
        /// <param name="dgvViewer">элемент управления для представления сетки данных</param>
        void LoadTableInfo(Label lbStatusText, DataGridView dgvViewer, string TableName);
    }
}
