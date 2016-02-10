using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SofkhaPOSLib;
using SofkhaPOSLib.Database;
using System.Data;

namespace Sofkha_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            khalil();
            Console.ReadKey();
            // Logging.Log("PLEASE WORK!!");
            DataRowCollection rows = DatabaseController.GetQueryResults("SELECT * FROM Log_T", new Dictionary<string, object>());

            for (int i = 0; i < rows.Count; i++)
            {
                Console.WriteLine((string)rows[i]["Content"]);
            }

            foreach(Product i in Product.GetAllProducts())
            {
                Console.WriteLine(i.discountPrice);
            }

            Console.ReadKey();

        }

        static void khalil()
        {
            TransactionHandler th = new TransactionHandler();
            //th.AddTransaction(new Transaction(0.0M, Product.GetAllProducts()[0]));
            //th.AddTransaction(new Transaction(0.0M, Product.GetAllProducts()[1]));

            Transaction t = new Transaction(2.00M, Product.GetAllProducts()[0]);
            Transaction r = TransactionHandler.GetReversedTransaction(t);

            Console.WriteLine(t.calcCostWithExclusiveDisc());
            t.purchasedQuantity = 5;
            t.UpdateTransaction();
            //th.ApplyGlobalDiscount(15);
            Console.WriteLine(r.calcCostWithExclusiveDisc());
        }
    }
}
