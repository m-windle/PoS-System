using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SofkhaPOSLib
{
    public class Transaction
    {
        public decimal exclusiveDiscount { get; set; }   
        public Product associatedProduct { get; set; }
        public DateTime saleDate { get; set; }
        public const decimal tax = 1.13M;
        private int transactionid;
        public int transactionID { get { return transactionid; } }
        public int purchasedQuantity { get; set; }

        //Constructors
        public Transaction(decimal ExclusiveDiscount, Product assocProduct)
            : this(ExclusiveDiscount, assocProduct, 1, DateTime.Now) { }

        public Transaction(decimal ExclusiveDiscount, Product assocProduct, int purchasedQuantity)
            : this(ExclusiveDiscount, assocProduct, purchasedQuantity, DateTime.Now) { }

        public Transaction(decimal ExclusiveDiscount, Product assocProduct, int purchasedQuantity, DateTime SaleDate)
        {
            this.exclusiveDiscount = ExclusiveDiscount;
            this.associatedProduct = assocProduct;
            this.saleDate = SaleDate;
            this.purchasedQuantity = purchasedQuantity;
            this.transactionid = getNextTransactionId();
        }

        /// <summary>
        /// Creates a new instance of a transaction and stores it in the database. 
        /// </summary>
        /// <returns>
        /// Returns the ID of the newly created transaction
        /// </returns>
        private int getNextTransactionId()
        {
            string query = "SELECT TOP 1 ID FROM Transaction_T ORDER BY ID DESC";
            DataRowCollection res = Database.DatabaseController.GetQueryResults(query, new Dictionary<string, object>());
            int id = res.Count == 0 ? 0 : (int)res[0]["ID"];
            id++;

            Dictionary<string, object> myDic = new Dictionary<string, object>();
            query = "INSERT INTO Transaction_T (ID, ProductQuantity, PurchasedProduct, ExclusiveDiscount, Tax, TotalSale, SaleDate) VALUES (@id, @quantity, @product, @discount, @tax, @totalsale, CURRENT_TIMESTAMP)";
            myDic.Add("@id", id);
            myDic.Add("@quantity", purchasedQuantity);
            myDic.Add("@product", associatedProduct.productName);
            myDic.Add("@discount", exclusiveDiscount);
            myDic.Add("@tax", decimal.Round((purchasedQuantity * associatedProduct.productSalePrice * (tax - 1)), 2));
            myDic.Add("@totalsale", decimal.Round(calcCostWithExclusiveDisc(), 2));
            
            Database.DatabaseController.NonQuery(query, myDic);

            Logging.Log("New transaction created with ID {0}", id);
            return id;
        }

        /// <summary>
        /// Updates the values of a transaction stored in the database and 
        /// then creates a log entry with the ID of the updated transaction
        /// </summary>
        public void UpdateTransaction()
        {
            Dictionary<string, object> myDic = new Dictionary<string, object>();
            string query = "UPDATE Transaction_T SET ProductQuantity = @quantity, PurchasedProduct = @product, ExclusiveDiscount = @discount, Tax = @tax, TotalSale = @totalsale, SaleDate = CURRENT_TIMESTAMP WHERE ID = @id";
            myDic.Add("@id", transactionid);
            myDic.Add("@quantity", purchasedQuantity);
            myDic.Add("@product", associatedProduct.productName);
            myDic.Add("@discount", exclusiveDiscount);
            myDic.Add("@tax", decimal.Round((purchasedQuantity * associatedProduct.productSalePrice * (tax - 1)), 2));
            myDic.Add("@totalsale", decimal.Round(calcCostWithExclusiveDisc(), 2));

            this.associatedProduct.productQuantity -= this.purchasedQuantity;
            this.associatedProduct.UpdateProduct();
            Database.DatabaseController.NonQuery(query, myDic);
            Logging.Log("Transaction ID {0} successfully updated.", transactionid);
        }

        /// <summary>
        /// Calculates the value of the cost of a product with a discount applied
        /// </summary>
        /// <returns>
        /// Returns the cost with the discount applied
        /// </returns>
        public decimal calcCostWithExclusiveDisc()
        {
            decimal cost = 0;
            if (this.associatedProduct.isDiscounted)
                cost = (this.associatedProduct.discountPrice * this.purchasedQuantity - this.exclusiveDiscount) * Transaction.tax;
            else
                cost = (this.associatedProduct.productSalePrice * this.purchasedQuantity) * Transaction.tax;
            return cost;
        }
    }
}
