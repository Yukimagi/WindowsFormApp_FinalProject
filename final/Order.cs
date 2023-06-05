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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using MySqlX.XDevAPI;
using System.IO;

namespace v2
{
    public partial class Order : Form
    {
        connection con = new connection();
        WebClient wc = new WebClient();
        product[] products;
        int[] product_index = new int[4];
        int currentPage = 1;
        int page_num;
        int lastpage_num;
        int product_num;

        class product
        {
            //public int id;
            public string name;
            public int price;
            //public int stock;
            public string img;
            public product(/*int id,*/ string name, int price/*, int stock*/, string img)
            {
                //this.id = id;
                this.name = name;
                this.price = price;
                //this.stock = stock;
                this.img = img;
            }
        }

        public Order()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
            numericUpDown3.Minimum = 1;
            numericUpDown4.Minimum = 1;
            listView1.Columns.Add("餐點", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("數量", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("單價", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("價格", 80, HorizontalAlignment.Left);
            listView1.View = View.Details;
            //listView1.View = View.SmallIcon;
            listView1.GridLines = true;
            listView1.Alignment = ListViewAlignment.Left;
            product_index[0] = 0;
            product_index[1] = 1;
            product_index[2] = 2;
            product_index[3] = 3;
            imageList_product.ImageSize = new Size(16, 16);
                    
            string sql = "SELECT COUNT(*) FROM menu";
            con.connectdb.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader data = cmd.ExecuteReader();
            data.Read();
            product_num = data.GetInt32(0);
            page_num = (int)Math.Ceiling((double)product_num / 4);

            lastpage_num = product_num % 4;
            if(lastpage_num == 0)
            {
                lastpage_num = 4;
            }
            data.Close();
            for (int j = 1; j <= page_num; j++)
            {
                comboBox1.Items.Add(j);
            }
            products = new product[product_num];
            sql = "SELECT `mid`, `price`, `img_url`  FROM `menu` ORDER BY `menu`.`mno` ASC";
            cmd = new MySqlCommand(sql, con.connectdb);
            data = cmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                byte[] image_temp = wc.DownloadData(data.GetString(2));
                Image img = Image.FromStream(new MemoryStream(image_temp));
                //pictureBox1.Load(data.GetString(2));
                //Image img = pictureBox1.Image;
                imageList_product.Images.Add(img);
                products[i] = new product(data.GetString(0), data.GetInt32(1), data.GetString(2));
                i++;
            }
            
            listView1.StateImageList = imageList_product;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            comboBox1.SelectedIndex = 0;
            data.Close();
            //pageReload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addToCart(product_index[0], (int)numericUpDown1.Value);
        }

        private void addToCart(int productIndex,int num)
        {
            if (listView1.Items.ContainsKey(products[productIndex].name))
            {
                listView1.Items[products[productIndex].name].SubItems[1].Text = (int.Parse(listView1.Items[products[productIndex].name].SubItems[1].Text) + num).ToString();
                listView1.Items[products[productIndex].name].SubItems[3].Text = (int.Parse(listView1.Items[products[productIndex].name].SubItems[1].Text) * products[productIndex].price).ToString();
                return;
            }
            listView1.Items.Add(products[productIndex].name, products[productIndex].name, productIndex);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(num.ToString());
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(products[productIndex].price.ToString());
            listView1.Items[listView1.Items.Count - 1].SubItems.Add((products[productIndex].price * num).ToString());
            
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addToCart(product_index[1], (int)numericUpDown2.Value);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentPage++;
            if(currentPage > page_num)
            {
                currentPage = 1;
            }
            comboBox1.SelectedIndex = currentPage-1;
            pageReload();
        }

        void disvisable()
        {
            pictureBox1.Visible = false;
            product1.Visible = false;
            price1.Visible = false;
            numericUpDown1.Visible = false;
            button1.Visible = false;
            pictureBox2.Visible = false;
            product2.Visible = false;
            price2.Visible = false;
            numericUpDown2.Visible = false;
            button3.Visible = false;
            pictureBox3.Visible = false;
            product3.Visible = false;
            price3.Visible = false;
            numericUpDown3.Visible = false;
            button4.Visible = false;
            pictureBox4.Visible = false;
            product4.Visible = false;
            price4.Visible = false;
            numericUpDown4.Visible = false;
            button5.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
        }
        void pageReload()
        {
            disvisable();
            product_index[0] = (currentPage - 1) * 4;
            product_index[1] = (currentPage - 1) * 4 + 1;
            product_index[2] = (currentPage - 1) * 4 + 2;
            product_index[3] = (currentPage - 1) * 4 + 3;
            pictureBox1.Load(products[product_index[0]].img);
            product1.Text = products[product_index[0]].name;
            price1.Text = "$" + products[product_index[0]].price.ToString();
            pictureBox1.Visible = true;
            product1.Visible = true;
            price1.Visible = true;
            numericUpDown1.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            if(lastpage_num < 2 && currentPage == page_num)
            {
                return;
            }
            pictureBox2.Load(products[product_index[1]].img);
            product2.Text = products[product_index[1]].name;
            price2.Text = "$" + products[product_index[1]].price.ToString();
            pictureBox2.Visible = true;
            product2.Visible = true;
            price2.Visible = true;
            numericUpDown2.Visible = true;
            button3.Visible = true;
            label4.Visible = true;
            if(lastpage_num < 3 && currentPage == page_num)
            {
                return;
            }
            pictureBox3.Load(products[product_index[2]].img);
            product3.Text = products[product_index[2]].name;
            price3.Text = "$" + products[product_index[2]].price.ToString();
            pictureBox3.Visible = true; product3.Visible = true; price3.Visible = true;
            numericUpDown3.Visible = true;
            button4.Visible = true;
            label6.Visible = true;
            if(lastpage_num < 4 && currentPage == page_num)
            {
                return;
            }
            pictureBox4.Load(products[product_index[3]].img);
            product4.Text = products[product_index[3]].name;
            price4.Text = "$" + products[product_index[3]].price.ToString();
            pictureBox4.Visible = true; product4.Visible = true;price4.Visible = true;
            numericUpDown4.Visible = true;
            button5.Visible = true;
            label8.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage < 1)
            {
                currentPage = page_num;
            }
            comboBox1.SelectedIndex = currentPage - 1;
            pageReload();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = comboBox1.SelectedIndex+1;
            pageReload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MAX(`ono`) FROM `system`";
            MySqlCommand cmd = new MySqlCommand(sql, con.connectdb);
            MySqlDataReader data = cmd.ExecuteReader();
            data.Read();
            int ono = data.GetInt32(0) + 1;
            data.Close();
            if(comboBox2.Text == "外帶")
            {
                outdoorInfo od = new outdoorInfo();
                od.ShowDialog();
                string oid = od.ReturnValue1;
                for(int i = 0; i < listView1.Items.Count; i++)
                {
                    sql = "INSERT INTO `system` (`ono`,`mid`,`amount`,`outid`,`eno`,`tab`) VALUES ('" + ono + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + oid + "','E001','無')";
                    cmd = new MySqlCommand(sql, con.connectdb);
                    cmd.ExecuteNonQuery();
                }
            }
            else if(comboBox2.Text =="內用")
            {
                for(int i = 0; i < listView1.Items.Count; i++)
                {
                    sql = "INSERT INTO `system` (`ono`,`mid`,`amount`,`tab`,`eno`) VALUES ('"+ono+"','"+ listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + comboBox3.SelectedItem.ToString() + "','E001')";
                    cmd = new MySqlCommand(sql, con.connectdb);
                    cmd.ExecuteNonQuery();

                }
                
            }
            listView1.Clear();
            listView1.Columns.Add("餐點", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("數量", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("單價", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("價格", 80, HorizontalAlignment.Left);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                comboBox3.Enabled = true;
            }
            else
            {
                comboBox3.Enabled=false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addToCart(product_index[2], (int)numericUpDown3.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addToCart(product_index[3], (int)numericUpDown4.Value);

        }
    }
}
