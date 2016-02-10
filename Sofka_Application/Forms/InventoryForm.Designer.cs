namespace Sofka_Application
{
    partial class InventoryFrm
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
            this.employeeIdLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.currentDateLbl = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lstInventory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.lblUpdateQuantity = new System.Windows.Forms.Label();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.nudUpdateQuantity = new System.Windows.Forms.NumericUpDown();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeIdLbl
            // 
            this.employeeIdLbl.AutoSize = true;
            this.employeeIdLbl.Location = new System.Drawing.Point(9, 36);
            this.employeeIdLbl.Name = "employeeIdLbl";
            this.employeeIdLbl.Size = new System.Drawing.Size(70, 13);
            this.employeeIdLbl.TabIndex = 16;
            this.employeeIdLbl.Text = "Employee ID:";
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(12, 76);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(33, 13);
            this.dateLbl.TabIndex = 15;
            this.dateLbl.Text = "Date:";
            // 
            // currentDateLbl
            // 
            this.currentDateLbl.AutoSize = true;
            this.currentDateLbl.Location = new System.Drawing.Point(66, 76);
            this.currentDateLbl.Name = "currentDateLbl";
            this.currentDateLbl.Size = new System.Drawing.Size(0, 13);
            this.currentDateLbl.TabIndex = 30;
            this.currentDateLbl.Click += new System.EventHandler(this.currentDateLbl_Click);
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(213, 76);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(0, 13);
            this.lblEmpName.TabIndex = 34;
            // 
            // lstInventory
            // 
            this.lstInventory.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstInventory.FullRowSelect = true;
            this.lstInventory.HideSelection = false;
            this.lstInventory.Location = new System.Drawing.Point(12, 92);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(542, 240);
            this.lstInventory.TabIndex = 35;
            this.lstInventory.UseCompatibleStateImageBehavior = false;
            this.lstInventory.View = System.Windows.Forms.View.Details;
            this.lstInventory.SelectedIndexChanged += new System.EventHandler(this.lstInventory_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Name";
            this.columnHeader1.Width = 207;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price per Bottle";
            this.columnHeader3.Width = 133;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.Location = new System.Drawing.Point(321, 30);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Size = new System.Drawing.Size(141, 23);
            this.btnNewTransaction.TabIndex = 36;
            this.btnNewTransaction.Text = "Start new Transaction";
            this.btnNewTransaction.UseVisualStyleBackColor = true;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // lblUpdateQuantity
            // 
            this.lblUpdateQuantity.AutoSize = true;
            this.lblUpdateQuantity.Location = new System.Drawing.Point(143, 345);
            this.lblUpdateQuantity.Name = "lblUpdateQuantity";
            this.lblUpdateQuantity.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateQuantity.TabIndex = 38;
            this.lblUpdateQuantity.Text = "Add Quantity";
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Enabled = false;
            this.btnUpdateQuantity.Location = new System.Drawing.Point(343, 340);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(92, 23);
            this.btnUpdateQuantity.TabIndex = 39;
            this.btnUpdateQuantity.Text = "Add Quantity";
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // nudUpdateQuantity
            // 
            this.nudUpdateQuantity.Enabled = false;
            this.nudUpdateQuantity.Location = new System.Drawing.Point(217, 341);
            this.nudUpdateQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudUpdateQuantity.Name = "nudUpdateQuantity";
            this.nudUpdateQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudUpdateQuantity.TabIndex = 40;
            this.nudUpdateQuantity.Click += new System.EventHandler(this.nudUpdateQuantity_Click);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(86, 32);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(121, 21);
            this.cmbEmployees.TabIndex = 41;
            this.cmbEmployees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEmployees_KeyPress);
            // 
            // InventoryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.cmbEmployees);
            this.Controls.Add(this.nudUpdateQuantity);
            this.Controls.Add(this.btnUpdateQuantity);
            this.Controls.Add(this.lblUpdateQuantity);
            this.Controls.Add(this.btnNewTransaction);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.currentDateLbl);
            this.Controls.Add(this.employeeIdLbl);
            this.Controls.Add(this.dateLbl);
            this.Name = "InventoryFrm";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.InventoryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label employeeIdLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label currentDateLbl;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.ListView lstInventory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.Label lblUpdateQuantity;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.NumericUpDown nudUpdateQuantity;
        private System.Windows.Forms.ComboBox cmbEmployees;
    }
}