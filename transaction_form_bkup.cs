using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SofkhaPOSLib;

namespace Sofka_Application
{
    public partial class InventoryFrm : Form
    {
        public InventoryFrm()
        {
            InitializeComponent();
        }

        Product[] products = Product.GetAllProducts();
        Employee employee;
        private void employeeIdTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void currentDateLbl_Click(object sender, EventArgs e)
        {
            currentDateLbl.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            //lstInventory.Items.Clear();

            //currentDateLbl.Text = DateTime.Now.ToLongDateString();

            int empID = Convert.ToInt32(employeeIdTxtBx.Text);
            employee = Employee.FindEmployee(empID);

            lstInventory.Items.Clear();
            foreach(Product i in products)
            {
                ListViewItem lvi = new ListViewItem(i.productName);
                lvi.SubItems.Add(i.productQuantity.ToString());
                lvi.SubItems.Add(i.productBuyPrice.ToString());
                lstInventory.Items.Add(lvi);
            }
            timer1.Enabled = true;
            //try
            //{


                

            //    if (employee.EmployeeID == 0)
            //        throw new Exception();
            //    else
            //    {
            //        for (int i = 0; i < products.Length; i++)
            //        {
            //            productname.Add(products[i].productName);
            //            quantity.Add(products[i].productQuantity.ToString());
            //            cost.Add(products[i].productBuyPrice);
            //        }

            //        for (int i = 0; i < products.Length; i++)
            //        {
            //            txtBxDisplayinventory.AppendText(string.Format("\r\n\t{0}", productname[i]));
            //            txtBxDisplayinventory.AppendText(string.Format("\r\n\tRemaining: {0}", quantity[i].ToString()));
            //            txtBxDisplayinventory.AppendText(string.Format("\r\n\tPurchase Cost per case: {0:C}",cost[i]*24));
            //            txtBxDisplayinventory.AppendText("\r\n");
            //        }

            //        string empName = string.Format("{0} {1}",employee.FirstName,employee.LastName);
            //        lblEmpName.Text = empName;
            //        string userlog = string.Format("User {0} {1} logged to inventory", empID, empName);
            //        Logging.Log(userlog);
            //    }                
            //}
            //catch(Exception)
            //{
            //    MessageBox.Show("Please supply valid employee ID");
            //}
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            foreach (Product i in products)
            {
                i.SyncProduct();
            }

            for(int i = 0; i < products.Length; i++)
            {
                lstInventory.Items[i].SubItems[1].Text = products[i].productQuantity.ToString();
            }
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            transFrm myFrm = new transFrm(employee);
            myFrm.Show();
        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUpdateQuantity.Enabled = true;
            int selected = lstInventory.SelectedIndices[0];
            int currentQty = products[selected].productQuantity;

            txtUpdateQuantity.Text = currentQty.ToString();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            int selected = lstInventory.SelectedIndices[0]; 
            Product selectedProd = products[selected]; 
            Transaction updateQty = new Transaction(selectedProd.discountPrice, selectedProd);

            updateQty.associatedProduct.productQuantity = 10;
            updateQty.UpdateTransaction();
        }
    }
}
