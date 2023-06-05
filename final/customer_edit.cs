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
    public partial class customer_edit : Form
    {
        connection con = new connection();
        string cno;
        public customer_edit(string no)
        {
            cno = no;
            InitializeComponent();
            string sql  = "SELECT * FROM `costomer` WHERE `cno` = '" + cno + "'";
            con.connectdb.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox1.Text = reader["cname"].ToString();
            textBox2.Text = reader["phone"].ToString();
            textBox3.Text = reader["account"].ToString();
            switch (reader["cgender"].ToString())
            {
                case "男":
                    comboBox1.SelectedIndex = 0;
                    break;
                case "女":
                    comboBox1.SelectedIndex = 1;
                    break;
                case "不透露":
                    comboBox1.SelectedIndex = 2;
                    break;
            }
            sql = "SELECT * FROM `costomer_account` WHERE `account` = '" + reader["account"].ToString() + "'";
            cmd = new MySqlCommand(sql, con.connectdb);
            reader.Close();
            reader = cmd.ExecuteReader();
            reader.Read();
            textBox4.Text = reader["password"].ToString();
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("請輸入完整資料");
            }
            else
            {
                string sql = "UPDATE `costomer` SET `cname`='" + textBox1.Text + "',`phone`='" + textBox2.Text + "',`cgender`='" + comboBox1.SelectedItem.ToString() + "',`account`='" + textBox3.Text + "' WHERE `cno` = '" + cno + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                sql = "UPDATE `costomer_account` SET `password`='" + textBox4.Text + "' WHERE `account` = '" + textBox3.Text + "'";
                cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                con.connectdb.Close();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
