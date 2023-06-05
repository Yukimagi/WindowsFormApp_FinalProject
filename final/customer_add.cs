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
    public partial class customer_add : Form
    {
        connection con = new connection();
        public customer_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("請輸入完整資料");
            }
            else
            {
                string sql = "SELECT COUNT(*) FROM `costomer`";
                con.connectdb.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int num = Convert.ToInt32(reader[0].ToString());
                reader.Close();
                sql = "INSERT INTO `costomer_account`(`account`, `password`) VALUES ('" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                sql = "INSERT INTO `costomer`(`cno`,`cname`, `phone`, `cgender`, `account`) VALUES ('" +num+"','"+ textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox3.Text + "')";
                cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                con.connectdb.Close();
                Close();
            }   
        }
    }
}
