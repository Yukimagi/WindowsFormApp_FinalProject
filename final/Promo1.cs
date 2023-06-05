using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using v2.myclass;//呼叫namespace

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using System.Security.Principal;

namespace v2
{
    public partial class Promo1 : Form
    {
        connection con = new connection();
        public Promo1()
        {
            InitializeComponent();
            try
            {
                con.connectdb.Open();
                label3.Visible= false;
                //label3.Text="is connect!!\r\n";
                con.connectdb.Close();
            }
            catch
            {
                MessageBox.Show ( "not connect!!\r\n");
            }
           
            label3.Enabled = false;
            listView1.Enabled= false;
            label3.Visible= false;
            listView1.Visible= false;

            label1.Enabled = false;
            label2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button4.Visible = false;

            button1.Text = "新增活動";
            button2.Text = "修改活動";
            button3.Text = "刪除活動";

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            show();
        }
        void show()
        {
            label1.Enabled = false;
            label2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button4.Visible = false;

            listView1.Clear();

            label3.Enabled = true;
            listView1.Enabled = true;
            label3.Visible = false;
            listView1.Visible = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            //----------------------
            con.connectdb.Open();
            
            //查詢 test_table 資料表的全部資料
            string sql = "SELECT * FROM promo WHERE promo != '無'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();

            //如果有查到資料為 true 否則為 false
           // label3.Text="是否查到資料:" + data.HasRows +" "+ "欄位數:" + data.FieldCount;

            //https://www.cnblogs.com/jiangyunfeng/p/10616835.html#:~:text=this.listView1.Columns.Add%20%28ch%29%3B%20%2F%2F%E5%B0%86%E5%88%97%E5%A4%B4%E6%B7%BB%E5%8A%A0%E5%88%B0ListView%E6%8E%A7%E4%BB%B6%E3%80%82%20ColumnHeader%20ch%3D%20new,ColumnHeader%20%28%29%3B%20ch.Text%20%3D%20%22%E5%88%97%E6%A0%87%E9%A2%981%22%3B%20%2F%2F%E8%AE%BE%E7%BD%AE%E5%88%97%E6%A0%87%E9%A2%98
            listView1.Columns.Add("活動名稱", 150,HorizontalAlignment.Left);
            listView1.Columns.Add("詳細資訊", 480, HorizontalAlignment.Left);
            

            //列出查詢到的資料
            int i = 0;
            while (data.Read())
            {

                //以欄位名稱取得資料並列出
                //textBox1.AppendText("id={0} , name={1}", data["id"], data["name"]);

                //以欄位順序取得資料並列出
                listView1.Items.Add(data[0] + "\r\n");
                listView1.Items[i].SubItems.Add(data[1] + "\r\n");
                
                listView1.Items[i].ForeColor= Color.Black;
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
        string account, password;
        bool ask()
        {
            con.connectdb.Open();
            account = Interaction.InputBox("輸入帳號", "登入", "", 50, 50);//50,50視窗座標位置
            password = Interaction.InputBox("輸入密碼", "登入", "", -1, -1);

            string sql = "SELECT * FROM employee_account WHERE eaccount= '" + account + "' AND epassword='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                MessageBox.Show("登入成功!");
                return true;
            }
            else
            {
                MessageBox.Show("登入失敗!");
                return false;
            }
            con.connectdb.Close();
        }
        bool add = false;
        bool change = false;
        bool delete = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ask())
            {
                label3.Enabled = false;
                listView1.Enabled = false;
                label3.Visible = false;
                listView1.Visible = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                label1.Enabled = true;
                label2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button4.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button4.Visible = true;

                label1.Text = "新增活動名稱";
                label2.Text = "新增活動內容";
                button4.Text= "確認送出";
                add= true;
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            string content = textBox2.Text.ToString();
            if (add == true)
            { 
                con.connectdb.Open();
                string sql = "INSERT INTO promo VALUES ('" + name + "','" + content + "')";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                int n = cmd.ExecuteNonQuery();
                label3.Enabled = true;
                label3.Visible = true;
                //列出新增的筆數
                label3.Text = "共新增" + n + "筆資料";
                Thread.Sleep(1000);
                con.connectdb.Close();
                add = false;
                show();
            }
            else if (change == true) { 
                con.connectdb.Open();
                string sql = "UPDATE promo SET content='"+content+"' WHERE promo='"+name+"'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                int n = cmd.ExecuteNonQuery();
                label3.Enabled = true;
                label3.Visible = true;
                //列出修改的筆數
                label3.Text = "共修改" + n + "筆資料";
                Thread.Sleep(1000);
                con.connectdb.Close();
                change = false;
                show();
            }
            else if (delete == true) {
                con.connectdb.Open();
                string sql = "DELETE FROM promo WHERE promo='" + name + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
                int n = cmd.ExecuteNonQuery();
                label3.Enabled = true;
                label3.Visible = true;
                //列出修改的筆數
                label3.Text = "共修改" + n + "筆資料";
                Thread.Sleep(1000);
                con.connectdb.Close();
                delete = false;
                show();
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (ask())
            {
                change= true;
                label3.Enabled = false;
                listView1.Enabled = false;
                label3.Visible = false;
                listView1.Visible = false;

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;

                label1.Enabled = true;
                label2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button4.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button4.Visible = true;

                label1.Text = "活動名稱";
                label2.Text = "修改的活動內容";
                button4.Text = "確認送出";
                change = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete = true;
            label3.Enabled = false;
            listView1.Enabled = false;
            label3.Visible = false;
            listView1.Visible = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            label1.Enabled = true;
            label2.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            button4.Enabled = true;
            label1.Visible = true;
            label2.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            button4.Visible = true;

            label1.Text = "刪除的活動名稱";
            button4.Text = "確認送出";
            delete = true;
        }
    }
}
