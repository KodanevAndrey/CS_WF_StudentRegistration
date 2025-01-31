﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Registration
{
    public partial class FormAddingSecondaryInformation : Form
    {
        private string TableName;
        private string ColumnName;
        private AccountManager AM;
        private Label labelS;
        private ComboBox comboBox1;

        public FormAddingSecondaryInformation(Label lbSatus, ComboBox comboBox, AccountManager accountManager, in string tableName, in string columnName, in string RankAdded)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 350);
            this.MaximizeBox = false;
            this.AM = accountManager;
            this.labelS = lbSatus;
            this.comboBox1 = comboBox;
            this.TableName = tableName;
            this.ColumnName = columnName;
            this.btnAdd.Text = "добввить " + RankAdded;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TableName == "GroupsTable") AM.CreateNewGroup(labelS, txtEnter.Text);
            else AM.AddSecondaryInfo(labelS, txtEnter, TableName, ColumnName);
            AM.LoadAllItemsForComboBox(comboBox1, TableName, ColumnName);
            comboBox1.SelectedItem = txtEnter.Text;
            comboBox1.Text = txtEnter.Text;
            this.Close();
        }
    }
}
