using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class ShowStale
    {
        //Also need to pass in customer ID as an argument

        public static void DoAction(OrderManager om)

        {
            Console.Clear();
            List<Product> staleProducts = om.getStaleProducts();
            int c = 1;
            Customer currentCustomer = CustomerManager.currentCustomer;
            Console.WriteLine($"Stale Products for {currentCustomer.firstName} {currentCustomer.lastName}");
            foreach (Product thing in staleProducts)
            {
                Console.WriteLine($"{c}. {thing.name}");
                c++;
            }
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
    }
}