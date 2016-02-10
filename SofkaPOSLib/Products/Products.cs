using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SofkhaPOSLib.Database;

namespace SofkhaPOSLib
{
    public class Product
    {
        public decimal discountPrice { get; set; }
        public bool isDiscounted { get; set; }
        public decimal productBuyPrice { get; set; }
        public string productDescription { get; set; }
        private int productid;
        public int productID { get { return productid; } }
        public string productName { get; set; }
        public int productQuantity { get; set; }
        public decimal productSalePrice { get; set; }

        //Constructors
        public Product() 
            : this(0.00M, false, 0.00M, "", 0, "", 0, 0.00M) { }

        public Product(decimal DiscountPrice)
            : this(DiscountPrice, false, 0.00M, "", 0, "", 0, 0.00M) { }

        public Product(decimal DiscountPrice, bool IsDiscounted)
            : this(DiscountPrice, IsDiscounted, 0.00M, "", 0, "", 0, 0.00M) { }

        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice)
            : this(DiscountPrice, IsDiscounted, ProductBuyPrice, "", 0, "", 0, 0.00M) { }

        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice, string ProductDescription)
            : this(DiscountPrice, IsDiscounted, ProductBuyPrice, ProductDescription, 0, "", 0, 0.00M) { }

        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice, string ProductDescription, int ProductID)
            : this(DiscountPrice, IsDiscounted, ProductBuyPrice, ProductDescription, ProductID, "", 0, 0.00M) { }


        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice, string ProductDescription, int ProductID, string ProductName)
            : this(DiscountPrice, IsDiscounted, ProductBuyPrice, ProductDescription, ProductID, ProductName, 0, 0.00M) { }

        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice, string ProductDescription, int ProductID, string ProductName, int ProductQuantity)
            : this(DiscountPrice, IsDiscounted, ProductBuyPrice, ProductDescription, ProductID, ProductName, ProductQuantity, 0.00M) { }
      

        public Product(decimal DiscountPrice, bool IsDiscounted, decimal ProductBuyPrice, string ProductDescription, int ProductID, string ProductName, int ProductQuantity,decimal ProductSalePrice)
        {
            this.discountPrice = DiscountPrice;
            this.isDiscounted = IsDiscounted;
            this.productBuyPrice = ProductBuyPrice;
            this.productDescription = ProductDescription;
            this.productid = ProductID;
            this.productName = ProductName;
            this.productQuantity = ProductQuantity;
            this.productSalePrice = ProductSalePrice;
        }

        public void addDiscount(decimal DiscountPrice)
        {
            string discount;
           
            try
            {
                if(!this.isDiscounted)
                {
                    this.discountPrice = DiscountPrice;
                    this.productSalePrice = this.productSalePrice - this.discountPrice;
                    this.isDiscounted = true;
                    discount = Convert.ToString(String.Format("Discounted price for product {0} is {1:C}", this.productid, this.productSalePrice));
                    this.UpdateProduct();
                }
                else throw new Exception("Product is already discounted");
            }
            catch (Exception e)
            {
                discount = Convert.ToString(e);
            }

            Logging.Log(discount);
        }
    
        public void removeDiscount()
        {
            string discount;
           
            try
            {
                if(this.isDiscounted)
                {
                    this.productSalePrice = this.productSalePrice + this.discountPrice;
                    this.discountPrice = 0;
                    this.isDiscounted = false;
                    this.UpdateProduct();
                } else throw new Exception("Product is not currently discounted");
            }
            catch(Exception e)
            {
                discount = Convert.ToString(e);
            }
           
            discount = Convert.ToString(String.Format("Full price for product {0} is {1:C}", productid, this.productSalePrice));
           
            Logging.Log(discount);
        }
       
        public void renameProduct(string newProductName)
        {
            string oldProductName = this.productName;
            this.productName = newProductName;
            Logging.Log(string.Format("Product name for product {0} changed from {1} to {2}", productid, oldProductName, this.productName));
        }

        /// <summary>
        /// Changes the values of a specific product object when the values are changed in run time
        /// </summary>
        public void UpdateProduct()
        {
            if (this.productid == 0) return;
            string query = "UPDATE Product_T SET DiscountedPrice = @discount, isDiscounted = @isdiscounted, ProductQuantity = @quantity WHERE ID=@ID";
            Dictionary<string, object> myDic = new Dictionary<string, object>();
            myDic.Add("@discount", this.discountPrice);
            myDic.Add("@isdiscounted", new byte[] {isDiscounted ? (byte)1 : (byte)0});
            myDic.Add("@quantity", this.productQuantity);
            myDic.Add("@ID", this.productID);
            DatabaseController.NonQuery(query, myDic);
            Logging.Log("Product with ID {0} successfully updated", productid);
        }

        /// <summary>
        /// Retrieves any changes made to a product object during run time
        /// </summary>
        public void SyncProduct()
        {
            Dictionary<string, object> myDic = new Dictionary<string, object>();
            myDic.Add("@ID", this.productid);
            DataRowCollection rows = DatabaseController.GetQueryResults("SELECT * FROM Product_T WHERE ID=@ID", myDic, false);
            this.discountPrice = (decimal)rows[0]["DiscountedPrice"];
            this.isDiscounted = ((byte[])rows[0]["isDiscounted"])[0] == 1 ? true : false;
            this.productName = (string)rows[0]["ProductName"];
            this.productDescription = (string)rows[0]["ProductDescription"];
            this.productBuyPrice = (decimal)rows[0]["ProductBuyPrice"];
            this.productSalePrice = (decimal)rows[0]["ProductSalePrice"];
            this.productid = (int)rows[0]["ID"];
            this.productQuantity = (int)rows[0]["ProductQuantity"];
        }

        /// <summary>
        /// Queries the database for all objects stored in it
        /// </summary>
        /// <returns>
        /// Returns an array of product objects who's values are stored in the database
        /// </returns>
        public static Product[] GetAllProducts()
        {
            DataRowCollection rows = DatabaseController.GetQueryResults("SELECT * FROM Product_T", new Dictionary<string,object>());

            List<Product> pList = new List<Product>();

            foreach(DataRow dr in rows)
            {
                decimal discountedPrice = (decimal)dr["DiscountedPrice"];
                bool isDicounted = ((byte[])dr["isDiscounted"])[0] == 1 ? true : false;
                string productName = (string)dr["ProductName"];
                string productDescription = (string)dr["ProductDescription"];
                decimal productBuyPrice = (decimal)dr["ProductBuyPrice"];
                decimal productSalesPrice = (decimal)dr["ProductSalePrice"];
                int productId = (int)dr["ID"];
                int productQuantity = (int)dr["ProductQuantity"];

                Product nProduct = new Product(discountedPrice, isDicounted, productBuyPrice, productDescription, productId, productName, productQuantity, productSalesPrice);
                pList.Add(nProduct);
            }

            return pList.ToArray();
        }
    }   
}
