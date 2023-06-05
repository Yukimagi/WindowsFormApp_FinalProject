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

namespace v2
{
    public partial class Employee1 : Form
    {
        connection con = new connection();
        public Employee1()
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
            ask();
            Thread.Sleep(100);
            if (error)
            {
                listView1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                button4.Enabled = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                button4.Visible = false;
            }
            else
            {
                show();
            }
        }
        void invisible()
        {
            
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            button4.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            button4.Visible = false;
        }
        string account, password;
        bool start = true;
        bool error = false;
        void ask()
        {
            
            while (start)
            {
                con.connectdb.Open();
                //Eroot0
                //51468
                account = Interaction.InputBox("輸入帳號", "登入", "", 50, 50);//50,50視窗座標位置
                password = Interaction.InputBox("輸入密碼", "登入", "", -1, -1);

                string sql = "SELECT * FROM employee_account WHERE eaccount= '" + account + "' AND epassword='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

                MySqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    MessageBox.Show("登入成功!");
                    start = false;
                }
                else
                {
                    MessageBox.Show("登入失敗!");
                    start = false;
                    error= true;
                }
                con.connectdb.Close();
            }
            
        }
        bool master = false;
        void power()
        {
            con.connectdb.Open();
            //listView1.Clear();
            string sql = "SELECT * FROM employee WHERE eaccount= '"+account+"'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                if (data[1].ToString() == "店長" || data[1].ToString() == "副店長")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    master = true;
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                }
            }
            con.connectdb.Close();
        }
        void show()
        {

            listView1.Clear();

            listView1.Enabled = true;
            listView1.Visible = true;

            invisible();

            power();
            //------------------------------
            con.connectdb.Open();
            //查詢 test_table 資料表的全部資料
            string sql = "SELECT * FROM employee";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();

            //如果有查到資料為 true 否則為 false
            MessageBox.Show("是否查到資料:" + data.HasRows +" "+ "欄位數:" + data.FieldCount);

            //https://www.cnblogs.com/jiangyunfeng/p/10616835.html#:~:text=this.listView1.Columns.Add%20%28ch%29%3B%20%2F%2F%E5%B0%86%E5%88%97%E5%A4%B4%E6%B7%BB%E5%8A%A0%E5%88%B0ListView%E6%8E%A7%E4%BB%B6%E3%80%82%20ColumnHeader%20ch%3D%20new,ColumnHeader%20%28%29%3B%20ch.Text%20%3D%20%22%E5%88%97%E6%A0%87%E9%A2%981%22%3B%20%2F%2F%E8%AE%BE%E7%BD%AE%E5%88%97%E6%A0%87%E9%A2%98
            listView1.Columns.Add("編號", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("姓名", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("職位", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("生日", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("聯絡電話", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("住家地址", 360, HorizontalAlignment.Left);


            //列出查詢到的資料
            int i = 0;
            while (data.Read())
            {

                //以欄位名稱取得資料並列出
                //textBox1.AppendText("id={0} , name={1}", data["id"], data["name"]);

                //以欄位順序取得資料並列出
                listView1.Items.Add(data[0] + "\r\n");
                listView1.Items[i].SubItems.Add(data[1] + "\r\n");
                listView1.Items[i].SubItems.Add(data[2] + "\r\n");
                listView1.Items[i].SubItems.Add(data[3] + "\r\n");
                listView1.Items[i].SubItems.Add(data[4] + "\r\n");
                listView1.Items[i].SubItems.Add(data[5] + "\r\n");

                listView1.Items[i].ForeColor = Color.Black;
                //listView1.Items[i].Font = new Font("微軟正黑體",10f);
                i++;
                listView1.OwnerDraw = true;
            }
            con.connectdb.Close();
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            e.DrawBackground();
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);   //設定背景顏色
            Font font = new Font("微軟正黑體", 14, FontStyle.Bold);      //設定字體大小
            e.Graphics.DrawString(e.Header.Text, font, Brushes.White, e.Bounds, format); //設定字體顏色
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText();
        }
        bool add = false;
        bool change = false;
        bool delete = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (master) {
                
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            else {
                textBox7.Text = account;
                textBox8.Text = password;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
            }
            listView1.Enabled = false;
            listView1.Visible = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            
            button4.Enabled = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            button4.Visible = true;
            
            change = true;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (master)
            {
                listView1.Enabled = false;
                listView1.Visible = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                label7.Visible = true;
                label8.Visible = true;

                textBox7.Enabled = true;
                textBox8.Enabled = true;

                textBox7.Visible = true;
                textBox8.Visible = true;

                button4.Visible = true;
                button4.Enabled = true;
                delete = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string no = textBox1.Text.ToString();
            string name = textBox2.Text.ToString();
            string position = textBox3.Text.ToString();
            string birth = textBox4.Text.ToString();
            string tel = textBox5.Text.ToString();
            string addr = textBox6.Text.ToString();
            string ac = textBox7.Text.ToString();
            string pswd = textBox8.Text.ToString();
            if (add == true)
            {
                con.connectdb.Open();

                string sql2 = "INSERT INTO employee_account VALUES ('" + ac + "','" + pswd + "')";
                MySqlCommand cmd2 = new MySqlCommand(sql2, con.connectdb);
                int n2 = cmd2.ExecuteNonQuery();

                string sql = "INSERT INTO employee VALUES ('" + no + "','"  + position + "','" + name +  "','" + birth + "','" + tel + "','" + addr + "','" + ac + "')";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                
                int n = cmd.ExecuteNonQuery();
                
                //label3.Enabled = true;
                //label3.Visible = true;
                //列出新增的筆數
                MessageBox.Show("共新增" + n + "筆資料於員工資料");
                MessageBox.Show("共新增" + n2 + "筆資料於員工帳號");
                Thread.Sleep(1000);
                con.connectdb.Close();
                add = false;
                show();
            }
            else if (change == true)
            {
                con.connectdb.Open();
                string sql = "DELETE FROM employee WHERE eid='" + name + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                int n = cmd.ExecuteNonQuery();

                string sql2 = "DELETE FROM employee_account WHERE eaccount='" + ac + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, con.connectdb);
                int n2 = cmd2.ExecuteNonQuery();

                string sql2_1 = "INSERT INTO employee_account VALUES ('" + ac + "','" + pswd + "')";
                MySqlCommand cmd2_1 = new MySqlCommand(sql2_1, con.connectdb);
                int n2_1 = cmd2_1.ExecuteNonQuery();

                string sql1_1 = "INSERT INTO employee VALUES ('" + no + "','" + position + "','" + name + "','" + birth + "','" + tel + "','" + addr + "','" + ac + "')";
                MySqlCommand cmd1_1 = new MySqlCommand(sql1_1, con.connectdb);
                int n1_1 = cmd1_1.ExecuteNonQuery();

                //列出修改的筆數
                MessageBox.Show("共修改" + n1_1 + "筆資料於員工資料");
                //MessageBox.Show("共新增" + n2 + "筆資料於員工帳號");
                Thread.Sleep(1000);
                con.connectdb.Close();
                change = false;
                show();
            }
            else if (delete == true)
            {
                con.connectdb.Open();
                string sql = "DELETE FROM employee WHERE eaccount='" + ac + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                int n = cmd.ExecuteNonQuery();

                string sql2 = "DELETE FROM employee_account WHERE eaccount='" + ac + "'";
                MySqlCommand cmd2 = new MySqlCommand(sql2, con.connectdb);
                int n2 = cmd2.ExecuteNonQuery();

                //列出刪除的筆數
                MessageBox.Show("共刪除" + n + "筆資料於員工資料");
                MessageBox.Show("共刪除" + n2 + "筆資料於員工帳號");
                Thread.Sleep(1000);
                con.connectdb.Close();
                delete = false;
                show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (master)
            {
                
                listView1.Enabled = false;
                listView1.Visible = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                button4.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                button4.Visible = true;

                add = true;
            }
        }
    }
}
