using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using v2.myclass;//呼叫namespace

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace v2
{
    public partial class Table1 : Form
    {
        connection con = new connection();
        public Table1()
        {
            InitializeComponent();
            try
            {
                con.connectdb.Open();
                //MessageBox.Show("is connect!!\r\n");
                con.connectdb.Close();
            }
            catch
            {
                MessageBox.Show("not connect!!\r\n");
            }
            show();
            label1.Visible = false;
        }
        void show()
        {
  
            listView1.Clear();
            //----------------------
            con.connectdb.Open();

            //查詢 test_table 資料表的全部資料
            string sql = "SELECT * FROM tables";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);

            MySqlDataReader data = cmd.ExecuteReader();
            //如果有查到資料為 true 否則為 false
            //label1.Text = "是否查到資料:" + data.HasRows + " " + "欄位數:" + data.FieldCount;
            
            //https://www.cnblogs.com/jiangyunfeng/p/10616835.html#:~:text=this.listView1.Columns.Add%20%28ch%29%3B%20%2F%2F%E5%B0%86%E5%88%97%E5%A4%B4%E6%B7%BB%E5%8A%A0%E5%88%B0ListView%E6%8E%A7%E4%BB%B6%E3%80%82%20ColumnHeader%20ch%3D%20new,ColumnHeader%20%28%29%3B%20ch.Text%20%3D%20%22%E5%88%97%E6%A0%87%E9%A2%981%22%3B%20%2F%2F%E8%AE%BE%E7%BD%AE%E5%88%97%E6%A0%87%E9%A2%98
            listView1.Columns.Add("桌位編號", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("桌位可坐人數",150, HorizontalAlignment.Left);
            listView1.Columns.Add("桌位使用狀態", 150, HorizontalAlignment.Left);
            

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

                listView1.Items[i].ForeColor = Color.Black;
                listView1.Items[i].BackColor = Color.White;
                //listView1.Items[i].Font = new Font("微軟正黑體", 10f);

                listView1.OwnerDraw = true;
                i++;
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
    }
}
