using ConnectSQLite_KodanevAndrey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormAdmin : Form
    {
        private FormSelectedOpenTable form;
        public DBHelper db = new DBHelper();
        public FormAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(500, 300);
            this.MaximizeBox = false;
        }

        public void Connect()
        {
            if (db.ConnectDB(lbStatusText))
            {
                //db.LoadCountTables(lbStatusText);
                form = new FormSelectedOpenTable(db);
                form.ShowDialog();

                db.GetTableInfo(lbStatusText);
                db.LoadTableInfo(lbStatusText, dgvViewer);
                db.ReadDB(lbStatusText, dgvViewer);
            }
        }


        private void btnCreateNewDB_Click(object sender, EventArgs e)
        {
            FormCreateDB FCDB = new FormCreateDB();
            FCDB.Show();
        }

        private void btnReadDB_Click(object sender, EventArgs e)
        {
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            db.AddDB(lbStatusText,lbCommand,dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnAddImageDB_Click(object sender, EventArgs e)
        {
            db.AddImageToDB(lbStatusText, lbCommand, dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnResetDB_Click(object sender, EventArgs e)
        {
            db.ResetDB(lbStatusText, lbCommand, dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            db.DeleteDB(lbStatusText);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnDeleteAllDB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("вы уверены что хотите удалить ВСЕ данные таблицы?", "Удаление всех данных", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db.DeleteAllDB(lbStatusText);
                db.ReadDB(lbStatusText, dgvViewer);
            }
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void dgvViewer_Click(object sender, EventArgs e)
        {
            db.SelectCellToTable(lbStatusText, dgvViewer);
        }
    }
}
