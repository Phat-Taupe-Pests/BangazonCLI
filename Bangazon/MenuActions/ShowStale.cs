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
            //Products: 20 chars
            Console.WriteLine($"Products            Quantity            Date Product Created ");
            Console.WriteLine($"*************************************************************");
            foreach (Product thing in staleProducts)
            {
                string formattedProduct = formatThings(thing.name);
                string quantityString = thing.quantity.ToString();
                string formattedQuantity = formatThings(quantityString);
                string dateString = thing.dateCreated.ToString().Remove(7);
                
                string formattedDate = formatThings(dateString);
                Console.WriteLine($"{formattedProduct}{formattedQuantity}{formattedDate}");
                c++;
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
        
        public static string formatThings(string thing)
        {
            string formattedThing;
            if (thing.Length < 20)
            {
                string paddingString = thing.PadRight(22, ' ');
                formattedThing = paddingString.Remove(20);
                return formattedThing;
            } else {
                formattedThing = thing.Remove(17) + "...";
                return formattedThing;
            }
        }
    }
}