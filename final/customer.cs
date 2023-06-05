using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using v2.myclass;
using MySql.Data.MySqlClient;


namespace v2
{
    public partial class customer : Form
    {
        connection con = new connection();

        public customer()
        {
            InitializeComponent();
            con.connectdb.Open();
            showAllData();
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            customer_add add = new customer_add();
            add.ShowDialog();
            showAllData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            showAllData();
        }

        private void showAllData()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("姓名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("電話", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("性別", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("帳號", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("密碼", 100, HorizontalAlignment.Left);
            string sql = "SELECT * FROM `costomer`";

            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listView1.Items.Add(reader["cname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["phone"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["cgender"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["account"].ToString());
            }


            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sql = "SELECT * FROM `costomer_account` WHERE `account` = '" + listView1.Items[i].SubItems[3].Text + "'";
                reader.Close();
                cmd = new MySqlCommand(sql, con.connectdb);
                reader = cmd.ExecuteReader();
                reader.Read();
                listView1.Items[i].SubItems.Add(reader["password"].ToString());
            }
            reader.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = 0;
                foreach (int no in listView1.SelectedIndices)
                {
                    string sql = "SELECT 'cno' FROM `costomer` WHERE `cname` = '" + listView1.Items[no - i].SubItems[0].Text + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string cno = reader["cno"].ToString();
                    reader.Close();
                    sql = "DELETE FROM `costomer` WHERE `cno` = '" + cno + "'";
                    cmd = new MySqlCommand(sql, con.connectdb);
                    cmd.ExecuteNonQuery();
                    sql = "DELETE FROM `costomer_account` WHERE `account` = '" + listView1.Items[no - i].SubItems[3].Text + "'";
                    cmd = new MySqlCommand(sql, con.connectdb);
                    cmd.ExecuteNonQuery();
                    listView1.Items.RemoveAt(no - i);
                    i++;
                }
            }
            else
            {
                MessageBox.Show("無選擇項目");
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //get seleted item cno
            string sql = "SELECT `cno` FROM `costomer` WHERE `cname` = '" + listView1.SelectedItems[0].SubItems[0].Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string cno = reader["cno"].ToString();
            customer_edit edit = new customer_edit(cno);
            reader.Close();
            edit.ShowDialog();
            showAllData();
        }
    }
}
