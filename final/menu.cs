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
    public partial class menu : Form
    {
        connection con = new connection();
        public menu()
        {
            InitializeComponent();
            con.connectdb.Open();
            showAll();

        }

        private void showAll()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("編號", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("名稱", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("價格", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("成本", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("銷售量", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("進貨量", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("菜色所得",100, HorizontalAlignment.Left);
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            string sql = "SELECT * FROM `menu` ORDER BY `mno`";

            MySqlCommand cmd = new MySqlCommand(sql,con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listView1.Items.Add(reader["mno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["mid"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["price"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["cost"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["stock"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["input"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(reader["sales"].ToString());
            }

            reader.Close();

            for(int i = 0;i < listView1.Items.Count; i++)
            {
                sql = "SELECT SUM(`amount`) FROM `system` WHERE `mid` =  '" + listView1.Items[i].SubItems[1].Text.ToString() + "'";
                cmd = new MySqlCommand(sql,con.connectdb);
                reader = cmd.ExecuteReader();
                reader.Read();
                string saleNum = reader[0].ToString();
                if(saleNum == "")
                {
                    saleNum = "0";
                }
                listView1.Items[i].SubItems[4].Text = saleNum;
                listView1.Items[i].SubItems[6].Text = ((Convert.ToInt32(listView1.Items[i].SubItems[2].Text.ToString()) - Convert.ToInt32(listView1.Items[i].SubItems[3].Text.ToString())) * Convert.ToInt32(saleNum)).ToString();
                reader.Close();
                //sql = "UPDATE `menu` set ";
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM `menu` where `mno` = '" + listView1.SelectedItems[0].Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql,con.connectdb);
            cmd.ExecuteNonQuery();
            showAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            menu_add menu_Add = new menu_add();
            menu_Add.ShowDialog();
            showAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            menu_edit menu_Edit = new menu_edit(listView1.SelectedItems[0].SubItems[0].Text);
            menu_Edit.ShowDialog();
            showAll();
        }
    }
}
