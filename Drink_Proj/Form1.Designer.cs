namespace Drink_Proj
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnGreenTea = new Common.NewButton();
            this.btnBlackTea = new Common.NewButton();
            this.烏龍茶 = new Common.NewButton();
            this.烏龍綠茶 = new Common.NewButton();
            this.清茶 = new Common.NewButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.清茶);
            this.groupBox1.Controls.Add(this.烏龍綠茶);
            this.groupBox1.Controls.Add(this.烏龍茶);
            this.groupBox1.Controls.Add(this.btnGreenTea);
            this.groupBox1.Controls.Add(this.btnBlackTea);
            this.groupBox1.Location = new System.Drawing.Point(33, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 358);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "純茶類";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1420, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(522, 849);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "數量";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "價錢";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(1134, 781);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(262, 36);
            this.txtTotalPrice.TabIndex = 5;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(939, 758);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(122, 76);
            this.btnBuy.TabIndex = 6;
            this.btnBuy.Text = "送出";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // btnGreenTea
            // 
            this.btnGreenTea.Location = new System.Drawing.Point(235, 77);
            this.btnGreenTea.Name = "btnGreenTea";
            this.btnGreenTea.Size = new System.Drawing.Size(153, 78);
            this.btnGreenTea.TabIndex = 1;
            this.btnGreenTea.Text = "綠茶";
            this.btnGreenTea.UseVisualStyleBackColor = true;
            // 
            // btnBlackTea
            // 
            this.btnBlackTea.Location = new System.Drawing.Point(41, 77);
            this.btnBlackTea.Name = "btnBlackTea";
            this.btnBlackTea.Size = new System.Drawing.Size(153, 78);
            this.btnBlackTea.TabIndex = 0;
            this.btnBlackTea.Text = "紅茶";
            this.btnBlackTea.UseVisualStyleBackColor = true;
            // 
            // 烏龍茶
            // 
            this.烏龍茶.Location = new System.Drawing.Point(441, 77);
            this.烏龍茶.Name = "烏龍茶";
            this.烏龍茶.Size = new System.Drawing.Size(153, 78);
            this.烏龍茶.TabIndex = 2;
            this.烏龍茶.Text = "烏龍茶";
            this.烏龍茶.UseVisualStyleBackColor = true;
            // 
            // 烏龍綠茶
            // 
            this.烏龍綠茶.Location = new System.Drawing.Point(41, 192);
            this.烏龍綠茶.Name = "烏龍綠茶";
            this.烏龍綠茶.Size = new System.Drawing.Size(153, 78);
            this.烏龍綠茶.TabIndex = 3;
            this.烏龍綠茶.Text = "烏龍綠茶";
            this.烏龍綠茶.UseVisualStyleBackColor = true;
            // 
            // 清茶
            // 
            this.清茶.Location = new System.Drawing.Point(235, 192);
            this.清茶.Name = "清茶";
            this.清茶.Size = new System.Drawing.Size(153, 78);
            this.清茶.TabIndex = 4;
            this.清茶.Text = "清茶";
            this.清茶.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1995, 900);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.NewButton btnBlackTea;
        private System.Windows.Forms.ListView listView1;
        private Common.NewButton btnGreenTea;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnBuy;
        private Common.NewButton 清茶;
        private Common.NewButton 烏龍綠茶;
        private Common.NewButton 烏龍茶;
    }
}

