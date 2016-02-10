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
        Employee[] employees = Employee.GetAllEmployees();

        public InventoryFrm()
        {
            InitializeComponent();
        }

        Product[] products = Product.GetAllProducts();

        private void currentDateLbl_Click(object sender, EventArgs e)
        {
            currentDateLbl.Text = DateTime.Now.ToShortTimeString();
        }

        private void do_update()
        {

            try
            {
                while (true)
                {
                    foreach (Product i in products)
                    {
                        i.SyncProduct();
                    }

                    for (int i = 0; i < products.Length; i++)
                    {
                        lstInventory.Invoke(new MethodInvoker(() =>
                            {
                                lstInventory.Items[i].SubItems[1].Text = products[i].productQuantity.ToString();
                            }
                        ));
                    }

                    System.Threading.Thread.Sleep(50);
                }
            }
            catch { }

        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            transFrm myFrm = new transFrm(employees[cmbEmployees.SelectedIndex]);
            myFrm.Show();
        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstInventory.SelectedIndices.Count == 0)
            {
                btnUpdateQuantity.Enabled = false;
                nudUpdateQuantity.Enabled = false;
                return;
            }

            nudUpdateQuantity.Enabled = true;
            btnUpdateQuantity.Enabled = true;

            int selected = lstInventory.SelectedIndices[0];
            int currentQty = products[selected].productQuantity;
            nudUpdateQuantity.Value = 0;
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            int selected = lstInventory.SelectedIndices[0]; 
            Product selectedProd = products[selected]; 

            selectedProd.SyncProduct();
            selectedProd.productQuantity += (int)nudUpdateQuantity.Value;
            selectedProd.UpdateProduct();

            nudUpdateQuantity.Value = 0;
        }

        private void InventoryFrm_Load(object sender, EventArgs e)
        {
            foreach (Employee i in employees)
            {
                cmbEmployees.Items.Add(i.FirstName + " " + i.LastName);
            }
            

            var dBuffered = typeof(ListView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            dBuffered.SetValue(lstInventory, true, null);

            cmbEmployees.SelectedIndex = 0;

            lstInventory.Items.Clear();
            foreach (Product i in products)
            {
                ListViewItem lvi = new ListViewItem(i.productName);
                lvi.SubItems.Add(i.productQuantity.ToString());
                lvi.SubItems.Add(i.productBuyPrice.ToString());
                lstInventory.Items.Add(lvi);
            }
            
            System.Threading.Thread t = new System.Threading.Thread(do_update);
            t.Start();
        }

        private void cmbEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void nudUpdateQuantity_Click(object sender, EventArgs e)
        {
            if(nudUpdateQuantity.Value == 0)
            {
                nudUpdateQuantity.Select(0, 1);
            }
        }
    }
}
