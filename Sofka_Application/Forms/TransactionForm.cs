using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SofkhaPOSLib.Database;
using SofkhaPOSLib;

namespace Sofka_Application
{
    public partial class transFrm : Form
    {
        Product[] products = Product.GetAllProducts();
        TransactionHandler tHandler = new TransactionHandler();
        Employee current;
        public transFrm(Employee employee)
        {
            current = employee;
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            employeeIdTxtBx.Text = current.FirstName + " " + current.LastName;
            employeeIdTxtBx.ReadOnly = true;

            


            for (int i = 0; i < products.Length; i++  )
            {
                productsCmbBx.Items.Add(products[i].productName);
            }
        }

        private void transBtn_Click(object sender, EventArgs e)
        {
            products[productsCmbBx.SelectedIndex].SyncProduct();
            if (products[productsCmbBx.SelectedIndex].productQuantity < (int)qtyBx.Value)
            {
                MessageBox.Show("Insufficient stock.");
                return;
            }

            Transaction newTransaction = tHandler.AddTransaction(products[productsCmbBx.SelectedIndex]);
            newTransaction.purchasedQuantity = (int)qtyBx.Value;
            if (exclusiveDsctChckBx.Checked)
            {
                try
                {
                    newTransaction.exclusiveDiscount = decimal.Parse(discountTxtBx.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            newTransaction.UpdateTransaction();
            UpdateListView();
        }

        public void UpdateListView()
        {
            transactionList.Items.Clear();
            foreach(Transaction i in tHandler.GetTransactions())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = i.associatedProduct.productName;
                lvi.SubItems.Add(i.purchasedQuantity.ToString());
                lvi.SubItems.Add(i.exclusiveDiscount.ToString("C"));
                lvi.SubItems.Add(i.calcCostWithExclusiveDisc().ToString("C"));
                transactionList.Items.Add(lvi);
            }
            label1.Text = "Total Cost: " + tHandler.GetFinalSalesCost().ToString("C");
        }

        TimeSpan _elapsed = new TimeSpan();
        private void currentTimer_Tick(object sender, EventArgs e)
        {
            _elapsed = _elapsed.Add(TimeSpan.FromMinutes(1));
            currentDateLbl.Text = DateTime.Now.ToString();
        }

        private void costTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void qtyBx_ValueChanged(object sender, EventArgs e)
        {
            decimal Qty = qtyBx.Value;
            Product selectedProduct = products[productsCmbBx.SelectedIndex];

            if (discountTxtBx.Text.Trim().Length == 0)
            {
                costTxtBx.Text = ((Qty * selectedProduct.discountPrice)).ToString("C");
                totalTxtBx.Text = ((Qty * selectedProduct.discountPrice) * Transaction.tax).ToString("C");
            }
            else
            {
                if (selectedProduct.isDiscounted)
                {
                    costTxtBx.Text = ((Qty * selectedProduct.discountPrice)).ToString("C");
                    totalTxtBx.Text = (((Qty * selectedProduct.discountPrice) - decimal.Parse(discountTxtBx.Text)) * Transaction.tax).ToString("C");
                }
                else
                {
                    costTxtBx.Text = ((Qty * selectedProduct.discountPrice)).ToString("C");
                    totalTxtBx.Text = (((Qty * selectedProduct.discountPrice)) * Transaction.tax).ToString("C");
                }
            }
        }

        private void productsCmbBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            products[productsCmbBx.SelectedIndex].SyncProduct();
            if(products[productsCmbBx.SelectedIndex].productQuantity <= 0)
            {
                MessageBox.Show("Insufficient stock. Beer is sold out");
                productsCmbBx.SelectionStart = 0;
                productsCmbBx.SelectionLength = 0;
                qtyBx.Enabled = false;
                transBtn.Enabled = false;
                return;
            }
            qtyBx.Enabled = true;
            transBtn.Enabled = true;
            qtyBx_ValueChanged(null, null);
            qtyBx.Value = 1;
            qtyBx.Minimum = 1;
            exclusiveDsctChckBx.Checked = false;

            qtyBx.Maximum = (int)products[productsCmbBx.SelectedIndex].productQuantity;
            products[productsCmbBx.SelectedIndex].isDiscounted = false;
        }

        private void clearTrnsBtn_Click(object sender, EventArgs e)
        {
            tHandler = new TransactionHandler();
            transactionList.Items.Clear();
            this.Close();
        }

        private void productsCmbBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void totalTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void discountTxtBx_TextChanged(object sender, EventArgs e)
        {
            if (discountTxtBx.Text == string.Empty) discountTxtBx.Text = "0.00";
            decimal Qty = qtyBx.Value;
            Product selectedProduct = products[productsCmbBx.SelectedIndex];
            
            if (selectedProduct.isDiscounted)
            {
                costTxtBx.Text = ((Qty * selectedProduct.discountPrice)).ToString("C");
                totalTxtBx.Text = (((Qty * selectedProduct.discountPrice) - decimal.Parse(discountTxtBx.Text)) * Transaction.tax).ToString("C");
            }
            else
            {
                costTxtBx.Text = ((Qty * selectedProduct.discountPrice)).ToString("C");
                totalTxtBx.Text = (((Qty * selectedProduct.discountPrice)) * Transaction.tax).ToString("C");
            }
        }

        private void exclusiveDsctChckBx_CheckedChanged(object sender, EventArgs e)
        {
            Product selectedProduct = products[productsCmbBx.SelectedIndex];
            selectedProduct.isDiscounted = exclusiveDsctChckBx.Checked;
            discountTxtBx_TextChanged(null,null);
        }

        private void discountTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && (e.KeyChar != '.' || discountTxtBx.Text.Contains('.')))
            {
                e.Handled = true;
            }

            if(discountTxtBx.Text.Contains('.') && char.IsNumber(e.KeyChar) && !discountTxtBx.SelectedText.Contains("."))
            {
                if(discountTxtBx.Text.Length  - 1 - discountTxtBx.Text.IndexOf(".") == 2)
                {
                    e.Handled = true;
                }
            }
        }
        
    }
}
