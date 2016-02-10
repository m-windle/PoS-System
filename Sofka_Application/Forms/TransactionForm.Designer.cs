namespace Sofka_Application
{
    partial class transFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProductNameLbl = new System.Windows.Forms.Label();
            this.QuantityLbl = new System.Windows.Forms.Label();
            this.CostLbl = new System.Windows.Forms.Label();
            this.DiscountLbl = new System.Windows.Forms.Label();
            this.TotalLbl = new System.Windows.Forms.Label();
            this.transBtn = new System.Windows.Forms.Button();
            this.discountTxtBx = new System.Windows.Forms.TextBox();
            this.costTxtBx = new System.Windows.Forms.TextBox();
            this.totalTxtBx = new System.Windows.Forms.TextBox();
            this.exclusiveDsctChckBx = new System.Windows.Forms.CheckBox();
            this.dateLbl = new System.Windows.Forms.Label();
            this.employeeIdLbl = new System.Windows.Forms.Label();
            this.employeeIdTxtBx = new System.Windows.Forms.TextBox();
            this.qtyBx = new System.Windows.Forms.NumericUpDown();
            this.transaction = new System.Windows.Forms.GroupBox();
            this.productsCmbBx = new System.Windows.Forms.ComboBox();
            this.currentTimer = new System.Windows.Forms.Timer(this.components);
            this.currentDateLbl = new System.Windows.Forms.Label();
            this.transactionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.clearTrnsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qtyBx)).BeginInit();
            this.transaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductNameLbl
            // 
            this.ProductNameLbl.AutoSize = true;
            this.ProductNameLbl.Location = new System.Drawing.Point(15, 22);
            this.ProductNameLbl.Name = "ProductNameLbl";
            this.ProductNameLbl.Size = new System.Drawing.Size(78, 13);
            this.ProductNameLbl.TabIndex = 1;
            this.ProductNameLbl.Text = "Product Name:";
            // 
            // QuantityLbl
            // 
            this.QuantityLbl.AutoSize = true;
            this.QuantityLbl.Location = new System.Drawing.Point(15, 48);
            this.QuantityLbl.Name = "QuantityLbl";
            this.QuantityLbl.Size = new System.Drawing.Size(49, 13);
            this.QuantityLbl.TabIndex = 3;
            this.QuantityLbl.Text = "Quantity:";
            // 
            // CostLbl
            // 
            this.CostLbl.AutoSize = true;
            this.CostLbl.Location = new System.Drawing.Point(15, 74);
            this.CostLbl.Name = "CostLbl";
            this.CostLbl.Size = new System.Drawing.Size(31, 13);
            this.CostLbl.TabIndex = 4;
            this.CostLbl.Text = "Cost:";
            // 
            // DiscountLbl
            // 
            this.DiscountLbl.AutoSize = true;
            this.DiscountLbl.Location = new System.Drawing.Point(15, 100);
            this.DiscountLbl.Name = "DiscountLbl";
            this.DiscountLbl.Size = new System.Drawing.Size(52, 13);
            this.DiscountLbl.TabIndex = 5;
            this.DiscountLbl.Text = "Discount:";
            // 
            // TotalLbl
            // 
            this.TotalLbl.AutoSize = true;
            this.TotalLbl.Location = new System.Drawing.Point(15, 151);
            this.TotalLbl.Name = "TotalLbl";
            this.TotalLbl.Size = new System.Drawing.Size(34, 13);
            this.TotalLbl.TabIndex = 7;
            this.TotalLbl.Text = "Total:";
            // 
            // transBtn
            // 
            this.transBtn.Location = new System.Drawing.Point(99, 174);
            this.transBtn.Name = "transBtn";
            this.transBtn.Size = new System.Drawing.Size(145, 28);
            this.transBtn.TabIndex = 8;
            this.transBtn.Text = "Process Transaction";
            this.transBtn.UseVisualStyleBackColor = true;
            this.transBtn.Click += new System.EventHandler(this.transBtn_Click);
            // 
            // discountTxtBx
            // 
            this.discountTxtBx.Location = new System.Drawing.Point(99, 97);
            this.discountTxtBx.Name = "discountTxtBx";
            this.discountTxtBx.Size = new System.Drawing.Size(145, 20);
            this.discountTxtBx.TabIndex = 9;
            this.discountTxtBx.TextChanged += new System.EventHandler(this.discountTxtBx_TextChanged);
            this.discountTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.discountTxtBx_KeyPress);
            // 
            // costTxtBx
            // 
            this.costTxtBx.Enabled = false;
            this.costTxtBx.Location = new System.Drawing.Point(99, 71);
            this.costTxtBx.Name = "costTxtBx";
            this.costTxtBx.ReadOnly = true;
            this.costTxtBx.Size = new System.Drawing.Size(145, 20);
            this.costTxtBx.TabIndex = 9;
            this.costTxtBx.TextChanged += new System.EventHandler(this.costTxtBx_TextChanged);
            // 
            // totalTxtBx
            // 
            this.totalTxtBx.Location = new System.Drawing.Point(99, 148);
            this.totalTxtBx.Name = "totalTxtBx";
            this.totalTxtBx.ReadOnly = true;
            this.totalTxtBx.Size = new System.Drawing.Size(145, 20);
            this.totalTxtBx.TabIndex = 9;
            this.totalTxtBx.TextChanged += new System.EventHandler(this.totalTxtBx_TextChanged);
            // 
            // exclusiveDsctChckBx
            // 
            this.exclusiveDsctChckBx.AutoSize = true;
            this.exclusiveDsctChckBx.Location = new System.Drawing.Point(18, 125);
            this.exclusiveDsctChckBx.Name = "exclusiveDsctChckBx";
            this.exclusiveDsctChckBx.Size = new System.Drawing.Size(116, 17);
            this.exclusiveDsctChckBx.TabIndex = 11;
            this.exclusiveDsctChckBx.Text = "Exclusive Discount";
            this.exclusiveDsctChckBx.UseVisualStyleBackColor = true;
            this.exclusiveDsctChckBx.CheckedChanged += new System.EventHandler(this.exclusiveDsctChckBx_CheckedChanged);
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(426, 18);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(33, 13);
            this.dateLbl.TabIndex = 12;
            this.dateLbl.Text = "Date:";
            // 
            // employeeIdLbl
            // 
            this.employeeIdLbl.AutoSize = true;
            this.employeeIdLbl.Location = new System.Drawing.Point(426, 40);
            this.employeeIdLbl.Name = "employeeIdLbl";
            this.employeeIdLbl.Size = new System.Drawing.Size(87, 13);
            this.employeeIdLbl.TabIndex = 13;
            this.employeeIdLbl.Text = "Employee Name:";
            // 
            // employeeIdTxtBx
            // 
            this.employeeIdTxtBx.Location = new System.Drawing.Point(519, 37);
            this.employeeIdTxtBx.Name = "employeeIdTxtBx";
            this.employeeIdTxtBx.Size = new System.Drawing.Size(82, 20);
            this.employeeIdTxtBx.TabIndex = 14;
            // 
            // qtyBx
            // 
            this.qtyBx.Location = new System.Drawing.Point(99, 46);
            this.qtyBx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtyBx.Name = "qtyBx";
            this.qtyBx.Size = new System.Drawing.Size(145, 20);
            this.qtyBx.TabIndex = 38;
            this.qtyBx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtyBx.ValueChanged += new System.EventHandler(this.qtyBx_ValueChanged);
            // 
            // transaction
            // 
            this.transaction.Controls.Add(this.productsCmbBx);
            this.transaction.Controls.Add(this.qtyBx);
            this.transaction.Controls.Add(this.exclusiveDsctChckBx);
            this.transaction.Controls.Add(this.totalTxtBx);
            this.transaction.Controls.Add(this.costTxtBx);
            this.transaction.Controls.Add(this.discountTxtBx);
            this.transaction.Controls.Add(this.transBtn);
            this.transaction.Controls.Add(this.TotalLbl);
            this.transaction.Controls.Add(this.DiscountLbl);
            this.transaction.Controls.Add(this.CostLbl);
            this.transaction.Controls.Add(this.QuantityLbl);
            this.transaction.Controls.Add(this.ProductNameLbl);
            this.transaction.Location = new System.Drawing.Point(12, 60);
            this.transaction.Name = "transaction";
            this.transaction.Size = new System.Drawing.Size(257, 209);
            this.transaction.TabIndex = 39;
            this.transaction.TabStop = false;
            this.transaction.Text = "Transaction Information";
            // 
            // productsCmbBx
            // 
            this.productsCmbBx.FormattingEnabled = true;
            this.productsCmbBx.Location = new System.Drawing.Point(99, 22);
            this.productsCmbBx.Name = "productsCmbBx";
            this.productsCmbBx.Size = new System.Drawing.Size(145, 21);
            this.productsCmbBx.TabIndex = 39;
            this.productsCmbBx.SelectedIndexChanged += new System.EventHandler(this.productsCmbBx_SelectedIndexChanged);
            this.productsCmbBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.productsCmbBx_KeyPress);
            // 
            // currentTimer
            // 
            this.currentTimer.Enabled = true;
            this.currentTimer.Interval = 1000;
            this.currentTimer.Tick += new System.EventHandler(this.currentTimer_Tick);
            // 
            // currentDateLbl
            // 
            this.currentDateLbl.AutoSize = true;
            this.currentDateLbl.Location = new System.Drawing.Point(466, 17);
            this.currentDateLbl.Name = "currentDateLbl";
            this.currentDateLbl.Size = new System.Drawing.Size(13, 13);
            this.currentDateLbl.TabIndex = 40;
            this.currentDateLbl.Text = "0";
            // 
            // transactionList
            // 
            this.transactionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.transactionList.Location = new System.Drawing.Point(275, 63);
            this.transactionList.Name = "transactionList";
            this.transactionList.Size = new System.Drawing.Size(326, 199);
            this.transactionList.TabIndex = 41;
            this.transactionList.UseCompatibleStateImageBehavior = false;
            this.transactionList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 61;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Discount";
            this.columnHeader3.Width = 78;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Total Cost: $0.00";
            // 
            // clearTrnsBtn
            // 
            this.clearTrnsBtn.Location = new System.Drawing.Point(467, 268);
            this.clearTrnsBtn.Name = "clearTrnsBtn";
            this.clearTrnsBtn.Size = new System.Drawing.Size(134, 27);
            this.clearTrnsBtn.TabIndex = 40;
            this.clearTrnsBtn.Text = "Complete Transactions";
            this.clearTrnsBtn.UseVisualStyleBackColor = true;
            this.clearTrnsBtn.Click += new System.EventHandler(this.clearTrnsBtn_Click);
            // 
            // transFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 316);
            this.Controls.Add(this.clearTrnsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.transactionList);
            this.Controls.Add(this.currentDateLbl);
            this.Controls.Add(this.transaction);
            this.Controls.Add(this.employeeIdTxtBx);
            this.Controls.Add(this.employeeIdLbl);
            this.Controls.Add(this.dateLbl);
            this.Name = "transFrm";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qtyBx)).EndInit();
            this.transaction.ResumeLayout(false);
            this.transaction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProductNameLbl;
        private System.Windows.Forms.Label QuantityLbl;
        private System.Windows.Forms.Label CostLbl;
        private System.Windows.Forms.Label DiscountLbl;
        private System.Windows.Forms.Label TotalLbl;
        private System.Windows.Forms.Button transBtn;
        private System.Windows.Forms.TextBox discountTxtBx;
        private System.Windows.Forms.TextBox costTxtBx;
        private System.Windows.Forms.TextBox totalTxtBx;
        private System.Windows.Forms.CheckBox exclusiveDsctChckBx;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label employeeIdLbl;
        private System.Windows.Forms.TextBox employeeIdTxtBx;
        private System.Windows.Forms.NumericUpDown qtyBx;
        private System.Windows.Forms.GroupBox transaction;
        private System.Windows.Forms.Timer currentTimer;
        private System.Windows.Forms.Label currentDateLbl;
        private System.Windows.Forms.ComboBox productsCmbBx;
        private System.Windows.Forms.ListView transactionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearTrnsBtn;
    }
}

