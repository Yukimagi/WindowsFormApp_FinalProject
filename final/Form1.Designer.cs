namespace v2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.btnPromo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTable = new System.Windows.Forms.Button();
            this.label_header = new System.Windows.Forms.Label();
            this.btnEmplyee = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.order_btn = new System.Windows.Forms.Button();
            this.c_btn = new System.Windows.Forms.Button();
            this.sales_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(72, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(8, 8);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnPromo
            // 
            this.btnPromo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPromo.Location = new System.Drawing.Point(21, 64);
            this.btnPromo.Name = "btnPromo";
            this.btnPromo.Size = new System.Drawing.Size(111, 58);
            this.btnPromo.TabIndex = 3;
            this.btnPromo.Text = "門市活動";
            this.btnPromo.UseVisualStyleBackColor = true;
            this.btnPromo.Click += new System.EventHandler(this.btnPromo_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(148, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 645);
            this.panel1.TabIndex = 4;
            // 
            // btnTable
            // 
            this.btnTable.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTable.Location = new System.Drawing.Point(21, 128);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(111, 58);
            this.btnTable.TabIndex = 5;
            this.btnTable.Text = "桌位動態";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // label_header
            // 
            this.label_header.AutoSize = true;
            this.label_header.Font = new System.Drawing.Font("微軟正黑體", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_header.ForeColor = System.Drawing.Color.White;
            this.label_header.Location = new System.Drawing.Point(490, 6);
            this.label_header.Name = "label_header";
            this.label_header.Size = new System.Drawing.Size(506, 55);
            this.label_header.TabIndex = 6;
            this.label_header.Text = "日日香🍚DAY PUN BAR";
            // 
            // btnEmplyee
            // 
            this.btnEmplyee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEmplyee.ForeColor = System.Drawing.Color.Black;
            this.btnEmplyee.Location = new System.Drawing.Point(21, 192);
            this.btnEmplyee.Name = "btnEmplyee";
            this.btnEmplyee.Size = new System.Drawing.Size(111, 56);
            this.btnEmplyee.TabIndex = 7;
            this.btnEmplyee.Text = "員工管理";
            this.btnEmplyee.UseVisualStyleBackColor = true;
            this.btnEmplyee.Click += new System.EventHandler(this.btnEmplyee_Click);
            // 
            // btnFood
            // 
            this.btnFood.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFood.Location = new System.Drawing.Point(21, 254);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(111, 56);
            this.btnFood.TabIndex = 8;
            this.btnFood.Text = "餐點管理";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // order_btn
            // 
            this.order_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_btn.Location = new System.Drawing.Point(21, 316);
            this.order_btn.Name = "order_btn";
            this.order_btn.Size = new System.Drawing.Size(111, 56);
            this.order_btn.TabIndex = 9;
            this.order_btn.Text = "訂餐";
            this.order_btn.UseVisualStyleBackColor = true;
            this.order_btn.Click += new System.EventHandler(this.order_btn_Click);
            // 
            // c_btn
            // 
            this.c_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.c_btn.Location = new System.Drawing.Point(21, 440);
            this.c_btn.Name = "c_btn";
            this.c_btn.Size = new System.Drawing.Size(111, 56);
            this.c_btn.TabIndex = 10;
            this.c_btn.Text = "顧客管理";
            this.c_btn.UseVisualStyleBackColor = true;
            this.c_btn.Click += new System.EventHandler(this.c_btn_Click);
            // 
            // sales_btn
            // 
            this.sales_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sales_btn.Location = new System.Drawing.Point(21, 502);
            this.sales_btn.Name = "sales_btn";
            this.sales_btn.Size = new System.Drawing.Size(111, 56);
            this.sales_btn.TabIndex = 11;
            this.sales_btn.Text = "銷售管理";
            this.sales_btn.UseVisualStyleBackColor = true;
            this.sales_btn.Click += new System.EventHandler(this.sales_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(21, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 56);
            this.button1.TabIndex = 12;
            this.button1.Text = "訂位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1390, 731);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sales_btn);
            this.Controls.Add(this.c_btn);
            this.Controls.Add(this.order_btn);
            this.Controls.Add(this.btnFood);
            this.Controls.Add(this.btnEmplyee);
            this.Controls.Add(this.label_header);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPromo);
            this.Controls.Add(this.button3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnPromo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Label label_header;
        private System.Windows.Forms.Button btnEmplyee;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button order_btn;
        private System.Windows.Forms.Button c_btn;
        private System.Windows.Forms.Button sales_btn;
        private System.Windows.Forms.Button button1;
    }
}

