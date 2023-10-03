using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TestBase.Database1DataSetTableAdapters;

namespace TestBase
{
    public partial class Form1 : Form
    {
        public static string connectStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database1.mdb";
       
        private OleDbConnection myConnect;
        
        
        public Form1()
        {
            InitializeComponent();
            //  connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\User\Desktop\DataBase\TestBase\TestBase\Database1.mdb");
            myConnect = new OleDbConnection(connectStr);

            myConnect.Open();


        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Nomenklature". При необходимости она может быть перемещена или удалена.
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Nomenklature". При необходимости она может быть перемещена или удалена.
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Nomenklature". При необходимости она может быть перемещена или удалена.
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
        }

        private void nomenklatureBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nomenklatureBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void nomenklatureBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.nomenklatureBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnect.Close();
        }
        private void nomenklatureDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NomenklatureDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        { 
        Refresh();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
               Form2 frm2 = new Form2();
            frm2.ShowDialog();
          
        }

        private void updButton_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Update();
            Form1.ActiveForm.Refresh();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);


        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
  