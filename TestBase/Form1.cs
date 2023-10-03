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
        private OleDbConnection connect;
        public Form1()
        {
            InitializeComponent();
            //  connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\User\Desktop\DataBase\TestBase\TestBase\Database1.mdb");
            connect = new OleDbConnection(connectStr);
            connect.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Nomenklature". При необходимости она может быть перемещена или удалена.
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connect.Close();
        }
      
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
        }
        private void MainForm_Activated(object sender, EventArgs e)
        {
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void updButton_Click(object sender, EventArgs e)
        {
             this.tableAdapterManager.UpdateAll(this.database1DataSet);
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);


        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

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


        private void nomenklatureDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delButton_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Nomenklature WHERE [ID] = " + key;
            OleDbCommand cmd = new OleDbCommand(query, connect);
            cmd.ExecuteNonQuery();
                string query2 = "DELETE FROM Links WHERE [nomenklatureid] = " + key;
                OleDbCommand cmd2 = new OleDbCommand(query2, connect);
                cmd2.ExecuteNonQuery();
            MessageBox.Show("Продукт удален");
            this.nomenklatureTableAdapter.Fill(this.database1DataSet.Nomenklature);

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
  