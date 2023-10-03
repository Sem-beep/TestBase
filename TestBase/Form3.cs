using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBase
{
    public partial class Form3 : Form
    {
        public static string connectStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Database1.mdb";
        private OleDbConnection connect;
        public Form3()
        {
            InitializeComponent();
            connect = new OleDbConnection(connectStr);
            connect.Open();
            
            string query = "SELECT [Names] FROM Nomenklature";
            OleDbCommand com = new OleDbCommand (query, connect);
            
            OleDbDataReader reader = com.ExecuteReader ();
            
            listBox1.Items.Clear ();
                         
                 while (reader.Read ())
                     {
                listBox1.Items.Add(reader[0].ToString () + ", ");   // перевернуть
                     }
            reader.Close ();
            connect.Close ();
            
        }

        private void close1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
