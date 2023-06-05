using MySql.Data.MySqlClient;
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
    public partial class outdoorInfo : Form
    {
        connection con = new connection();
        string cno;
        public string outid;
        public outdoorInfo()
        {
            InitializeComponent();
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.CustomFormat = "HH:mm";

            textBox2.Enabled = false;
            comboBox1.Enabled = false;
        }

        public string ReturnValue1 { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            con.connectdb.Open();
            string sql = "SELECT * FROM `costomer` WHERE `phone` = '" + textBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox2.Text = reader["cname"].ToString();
                comboBox1.Text = reader["cgender"].ToString();
                cno = reader["cno"].ToString();
                textBox2.Enabled = false;
                comboBox1.Enabled = false;

            }
            else
            {
                textBox2.Enabled = true;
                comboBox1.Enabled = true;

            }
            button3.Visible = false;
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            DateTime dateTime;
            string sql;
            dateTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
            string date = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (textBox2.Enabled)
            {
                sql = "SELECT COUNT(*) FROM `costomer`";
                cmd = new MySqlCommand(sql, con.connectdb);
                reader = cmd.ExecuteReader();
                reader.Read();
                int num = Convert.ToInt32(reader[0].ToString());
                reader.Close();
                sql = "INSERT INTO `costomer_account`(`account`, `password`) VALUES ('" + textBox1.Text + "','" + textBox1.Text + "')";
                cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                sql = "INSERT INTO `costomer`(`cno`,`cname`, `phone`, `cgender`, `account`) VALUES ('" + num + "','" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "')";
                cmd = new MySqlCommand(sql, con.connectdb);
                cmd.ExecuteNonQuery();
                cno = num.ToString();
                MessageBox.Show("帳密預設為電話號碼");
            }

            sql = "SELECT COUNT(*) FROM `outdoor`";
            cmd = new MySqlCommand(sql, con.connectdb);
            reader = cmd.ExecuteReader();
            reader.Read();
            outid = reader[0].ToString();
            this.ReturnValue1 = outid;
            reader.Close();
            sql = "INSERT INTO `outdoor` VALUES ('" + outid + "','" + date + "','" + "未取餐" + "','" + cno + "')";
            cmd = new MySqlCommand(sql, con.connectdb);
            cmd.ExecuteNonQuery();
            con.connectdb.Close();
            Close();
        }
    }
}
