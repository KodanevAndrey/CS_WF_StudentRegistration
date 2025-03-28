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
    public partial class FormSelectedOpenTable : Form
    {
        private readonly IDBHelper db;
        private DataGridView dgvViewer;
        public FormSelectedOpenTable(in IDBHelper db, in DataGridView dgvViewer)
        {
            InitializeComponent();
            this.db = db;
            this.dgvViewer = dgvViewer;
            this.db.ReadCountTables(lbStatus, listBox1);
        }
        private void btnOpenTable_Click(object sender, EventArgs e)
        {
            this.db.SelectedTable(listBox1);
            this.db.LoadTableInfo(lbStatus, dgvViewer);
            this.db.ReadDB(lbStatus, dgvViewer);
            this.db.GetTableInfo(lbStatus);
            this.Close();
        }
    }
}
