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

        private AccountManager AM;

        private string DBName = null;
        private string TableName = null;
        private List<string> listColumns = new List<string>();

        public FormAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300, 300);
            this.MaximizeBox = false;
            CBColumnType.SelectedItem = "INTEGER";
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

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            Connect();
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
            db.ResetDB(lbStatusText,lbCommand,dgvViewer);
            db.ReadDB(lbStatusText, dgvViewer);
        }

        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            db.DeleteDB(lbStatusText, lbCommand);
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

        private void dgvViewer_Click(object sender, EventArgs e)
        {
            db.SelectCellToTable(lbStatusText, dgvViewer);
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            lbStatus.ForeColor = Color.Red;
            if (txtDBName.Text != "")
            {
                DBName = txtDBName.Text;
                if (txtTableName.Text != "")
                {
                    TableName = txtTableName.Text;
                    if (listColumns.Count > 0)
                    {
                        //listColumns.Add("_time TEXT");
                        db.CreateNewDB(lbStatus, DBName, TableName, listColumns);
                        listColumns.Clear();
                        txtDBName.Clear();
                        txtTableName.Clear();
                        txtColumnName.Clear();
                        CBColumnType.SelectedItem = "INTEGER";
                    }
                    else lbStatus.Text = "создайте столбцы в таблице!";
                }
                else lbStatus.Text = "введите имя для таблицы!";
            }
            else lbStatus.Text = "введите имя для новой базы данных!";
        }

        private void btnAddColum_Click(object sender, EventArgs e)
        {
            if (txtColumnName.Text != "")
            {
                listStringColums.Items.Add(txtColumnName.Text + " " + CBColumnType.SelectedItem.ToString());
                listColumns.Add(txtColumnName.Text + " " + CBColumnType.SelectedItem.ToString());
                txtColumnName.Text = "";
            }
            else lbStatus.Text = "введите имя для создания столбца в таблицые!";
        }

        private void btnDeleteColum_Click(object sender, EventArgs e)
        {
            bool IsError = true;
            for (int i = 0; i < listStringColums.Items.Count; i++)
            {
                if (listStringColums.SelectedItem == listStringColums.Items[i])
                {
                    IsError = false;
                    listColumns.Remove(listColumns[i]);
                }
            }
            if (IsError) MessageBox.Show("выберите пункт в списке чтобы удалить столбец!");
            else listStringColums.Items.Remove(listStringColums.SelectedItem);
        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbUserType.SelectedItem.ToString() == "перподаватель")
            {
                label6.Text = "учитель";
                cbSelectUser.Items.Add("добавить");
                AM  = new AccountManager("TeacherAccounts.sqlite");
                AM.ConnectDB(lbStatusAM);
                AM.ReadAllName(lbStatusAM, cbSelectUser);
            }
            if (cbUserType.SelectedItem.ToString() == "студент")
            {
                label6.Text = "группа";
                cbSelectUser.Items.Add("добавить");
                //AM.
            }
        }

        private void cbSelectUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSelectUser.SelectedItem.ToString() == "добавить")
            {

            }
            else
            {
                AM.ReadSelectedRecord(lbStatusText, cbSelectUser.SelectedIndex, txtName, txtSurname, txtPatronymic);

            }
        }
    }
}
