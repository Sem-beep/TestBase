using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBase.Database1DataSetTableAdapters;


namespace TestBase
{

    public partial class Form2 : Form
    {
        public static string connectStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database1.mdb";
        OleDbConnection connect;
       
        public Form2()
        {
            InitializeComponent();
            connect = new OleDbConnection(connectStr);
            connect.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbparentid_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string Name = tbName.Text.Trim();
            int Price = Convert.ToInt32(tbPrice.Text.Trim());
            int ParentID = Convert.ToInt32(tbParentID.Text.Trim());         
            int Kol = Convert.ToInt32(tbKol.Text.Trim());
            if ((Name != "") && (Price != 0) && (ParentID > 0))
            {
                string query = "INSERT INTO [Nomenklature] ([Names], [Prices]) VALUES ("+Name+","+ Price + ")";
                OleDbCommand cmd = new OleDbCommand(query, connect);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Price", Price);                                                 // внесение нового продукта в конец основного списка
                    cmd.ExecuteNonQuery();
                if (ParentID != 0)
                {
                   query = "SELECT TOP 1 ID FROM [Nomenklature] ORDER BY [ID] DESC";
                    cmd = new OleDbCommand(query, connect);
                    OleDbDataReader reader = cmd.ExecuteReader();                                                 // последний добавленный
                    int result = 0;
                         while (reader.Read())
                         {
                           result = Convert.ToInt32(reader[0]);
                         }

                   query = "INSERT INTO [Links] ([NomenklatureID], [Kol], [ParentID]) values ("+ result + ", "+ Kol + ","+ ParentID + ");";
                         cmd = new OleDbCommand(query, connect);
                         cmd.Parameters.AddWithValue("@result", result);
                         cmd.Parameters.AddWithValue("@Kol", Kol);
                         cmd.Parameters.AddWithValue("@ParentID", ParentID);
                         cmd.ExecuteNonQuery();
                    MessageBox.Show("Position added");
                }
                
               
            }
            else MessageBox.Show("Error");
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
