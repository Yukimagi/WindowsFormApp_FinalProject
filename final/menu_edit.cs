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
    public partial class menu_edit : Form
    {
        string mno;
        connection con = new connection();
        public menu_edit(string no)
        {
            InitializeComponent();
            mno = no;
            textBox1.Text = mno;
            textBox1.Enabled = false;
            string sql = "SELECT * FROM `menu` WHERE `mno` = '" + mno + "'";
            con.connectdb.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            textBox2.Text = reader["mid"].ToString();
            textBox3.Text = reader["price"].ToString();
            textBox4.Text = reader["cost"].ToString();
            textBox5.Text = reader["input"].ToString();
            textBox6.Text = reader["img_url"].ToString();
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE `menu` SET `mid`='" + textBox2.Text + "',`price`='" + textBox3.Text + "',`cost`='" + textBox4.Text + "',`input`='" + textBox5.Text + "',`img_url`='" + textBox6.Text + "' WHERE `mno` = '" + mno + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            cmd.ExecuteNonQuery();
            Close();
        }
    }
}
