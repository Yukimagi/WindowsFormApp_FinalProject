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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

//表單切換
//https://lillylovecode.medium.com/c-%E5%AD%90%E6%AF%8D%E8%A1%A8%E5%96%AE-windows-form-app-e38e1610fba6
namespace v2
{
    public partial class Form1 : Form
    {
        connection con = new connection(); 
        public Form1()
        {
            InitializeComponent();
            label_header.Text = "日日香🍚DAY PUN BAR";

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
            ask();
        }
        string account, password;
        bool start = true;
       
        void ask()
        {
            DialogResult result;//MessageBox回傳值
            result = DialogResult.OK;
            while (start&&result.ToString()!="Cancel")
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
                    result=MessageBox.Show("登入失敗!", "確認繼續或取消登入",MessageBoxButtons.OKCancel);                   
                }
                con.connectdb.Close();
            }
            while(result.ToString() == "Cancel")
            {
                Close();
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; 
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnPromo_Click(object sender, EventArgs e)
        {
            openChildForm(new Promo1());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            openChildForm(new Table1());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            openChildForm(new Food1());
        }

        private void order_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new Order());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new book());
        }

        private void c_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new customer());
        }

        private void sales_btn_Click(object sender, EventArgs e)
        {
            openChildForm(new menu());
        }

        private void btnEmplyee_Click(object sender, EventArgs e)
        {
            openChildForm(new Employee1());
        }
    }
}
