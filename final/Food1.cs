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
using v2.myclass;//呼叫namespace

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using System.Security.Principal;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Threading;
using System.Net.Mail;

namespace v2
{
    public partial class Food1 : Form
    {
        connection con = new connection();
        public Food1()
        {
            InitializeComponent();
            try
            {
                con.connectdb.Open();
                //label3.Visible = false;
                //label3.Text="is connect!!\r\n";
                con.connectdb.Close();
            }
            catch
            {
                MessageBox.Show("not connect!!\r\n");
            }
            //StretchImage:圖片自動調整和圖片一樣大小
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label2.Text = "無";
            label5.Text = "1";
            Find();
        }
        string name;
        string tip;
        string num;
        void Find()
        {

            con.connectdb.Open();
            //SELECT * FROM table_name ORDER BY column_name LIMIT 1;
            string sql = "SELECT * FROM system LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();

            //如果有查到資料為 true 否則為 false
            //MessageBox.Show("是否查到資料:" + data.HasRows + " " + "欄位數:" + data.FieldCount);

            //https://www.cnblogs.com/jiangyunfeng/p/10616835.html#:~:text=this.listView1.Columns.Add%20%28ch%29%3B%20%2F%2F%E5%B0%86%E5%88%97%E5%A4%B4%E6%B7%BB%E5%8A%A0%E5%88%B0ListView%E6%8E%A7%E4%BB%B6%E3%80%82%20ColumnHeader%20ch%3D%20new,ColumnHeader%20%28%29%3B%20ch.Text%20%3D%20%22%E5%88%97%E6%A0%87%E9%A2%981%22%3B%20%2F%2F%E8%AE%BE%E7%BD%AE%E5%88%97%E6%A0%87%E9%A2%98
            
            //列出查詢到的資料

            while (data.Read())
            {
                name = data[1]+"";
                tip = data[3] + "";
                num = data[2] + "";
                label2.Text = tip;
                label5.Text = num;
                
            }
            con.connectdb.Close();
            show();
        }
        void show()
        {
            con.connectdb.Open();
            //SELECT * FROM table_name ORDER BY column_name LIMIT 1;
            string sql = "SELECT * FROM menu WHERE mid='" + name + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();

            //如果有查到資料為 true 否則為 false
            //MessageBox.Show("是否查到資料:" + data.HasRows + " " + "欄位數:" + data.FieldCount);

            //https://www.cnblogs.com/jiangyunfeng/p/10616835.html#:~:text=this.listView1.Columns.Add%20%28ch%29%3B%20%2F%2F%E5%B0%86%E5%88%97%E5%A4%B4%E6%B7%BB%E5%8A%A0%E5%88%B0ListView%E6%8E%A7%E4%BB%B6%E3%80%82%20ColumnHeader%20ch%3D%20new,ColumnHeader%20%28%29%3B%20ch.Text%20%3D%20%22%E5%88%97%E6%A0%87%E9%A2%981%22%3B%20%2F%2F%E8%AE%BE%E7%BD%AE%E5%88%97%E6%A0%87%E9%A2%98

            //列出查詢到的資料

            while (data.Read())
            {
                textBox1.Text = data[7] + "\r\n";
                pictureBox1.Image = imageList1.Images[name+".jpg"];
            }
            con.connectdb.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.connectdb.Open();
            string sql = "DELETE FROM system WHERE mid='" + name + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            int n = cmd.ExecuteNonQuery();
            con.connectdb.Close();
            Find();
        }
    }
}
