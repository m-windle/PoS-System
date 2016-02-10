using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofkhaPOSLib
{
    public class TransactionHandler
    {
        private List<Transaction> pTransactions;

        /// <summary>
        /// Creates an array out of a list of transactions
        /// </summary>
        /// <returns>
        /// Returns an array of transaction objects
        /// </returns>
        public Transaction[] GetTransactions()
        {
            return pTransactions.ToArray();
        }

        /// <summary>
        /// Calculats teh final sales cost of all the transactions in the current sale
        /// </summary>
        /// <returns>
        /// Returns the total cost of all the transactions added together
        /// </returns>
        public decimal GetFinalSalesCost()
        {
            decimal dReturn = 0.0M;

            foreach(Transaction i in pTransactions)
            {
                dReturn += i.calcCostWithExclusiveDisc();
            }

            return dReturn;
        }

        public void ApplyGlobalDiscount(int discountPercentage)
        {
            if(discountPercentage < 0 || discountPercentage > 100)
            {
                throw new Exception("The provided discount is not a valid percentage");
            }
            foreach(Transaction i in pTransactions)
            {
                i.exclusiveDiscount = (i.associatedProduct.productSalePrice * i.purchasedQuantity) * ((decimal)discountPercentage / 100.00M);
            }
        }

        public void ApplyGlobalDiscount(decimal discountAmount)
        {
            pTransactions.Add(new Transaction(discountAmount, new Product(0.0M, false, 0.0M, string.Empty, 0, "[DISCOUNT]"), 1, DateTime.Now));
        }


        public static Transaction GetReversedTransaction(Transaction transaction)
        {
            Transaction rTransaction = new Transaction(transaction.exclusiveDiscount * -1, transaction.associatedProduct, transaction.purchasedQuantity * -1, DateTime.Now);
            return rTransaction;
        }

        /// <summary>
        /// Adds a transaction to the list of current transactions
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Returns the newly added transaction
        /// </returns>
        public Transaction AddTransaction(Product product)
        {
            Transaction transaction = new Transaction(0.0M, product);
            pTransactions.Add(transaction);
            return transaction;
        }

        public void RemoveTransaction(Transaction transaction)
        {
            pTransactions.Remove(transaction);
        }

        public void UpdateAllTransactions()
        {
            foreach (Transaction i in pTransactions) i.UpdateTransaction();
            Logging.Log("All transactions updated successfully.");
        }

        /// <summary>
        /// Creates a new transaction handler that is a list of all the current transactions
        /// </summary>
        public TransactionHandler()
        {
            pTransactions = new List<Transaction>();
        }
    }
}
