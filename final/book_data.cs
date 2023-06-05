using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using v2.myclass;

namespace v2
{
    public partial class book_data : Form
    {
        connection con = new connection();
        public book_data()
        {
            InitializeComponent();
            con.connectdb.Open();
            show_all_data();
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }

        private void show_all_data()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("顧客編號", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("電話", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("時間", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("人數", 100, HorizontalAlignment.Left);
            string sql = "SELECT * FROM `indoor`";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listView1.Items.Add(reader["cno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["cno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["cno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["time"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["amount"].ToString());
            }
            reader.Close();
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                string cno = listView1.Items[i].Text;
                //get customer data
                sql = "SELECT * FROM `costomer` WHERE `cno` = '" + cno + "'";
                cmd = new MySqlCommand (sql, con.connectdb);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listView1.Items[i].SubItems[1].Text = reader["cname"].ToString();
                    listView1.Items[i].SubItems[2].Text = reader["phone"].ToString();
                }
                reader.Close();
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            book b = new book();
            b.ShowDialog();
            show_all_data();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            show_all_data(); 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM `indoor` WHERE `cno` = '" + listView1.SelectedItems[0].Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            cmd.ExecuteNonQuery();
            show_all_data();
        }
    }

}
