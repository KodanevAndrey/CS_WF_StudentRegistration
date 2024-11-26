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
        private DBHelper db;
        public FormSelectedOpenTable(in DBHelper db)
        {
            InitializeComponent();
            this.db = db;
            this.db.ReadCountTables(lbStatus, listBox1);
        }
        private void btnOpenTable_Click(object sender, EventArgs e)
        {
            this.db.SelectedTable(listBox1);
            this.Close();
        }
    }
}
