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
    public partial class menu_add : Form
    {
        connection con = new connection();

        public menu_add()
        {
            InitializeComponent();
            con.connectdb.Open();
            string sql = "SELECT COUNT(*) FROM `menu`";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string count = reader[0].ToString();
            reader.Close();
            textBox1.Text = (int.Parse(count)+1).ToString();
            textBox1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO `menu`(`mno`, `mid`, `price`, `cost`, `input`, `img_url`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            cmd.ExecuteNonQuery();
            Close();
        }
    }
}
