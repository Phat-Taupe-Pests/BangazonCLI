using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using BangazonCLI.MenuActions;


namespace BangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seed the database if none exists
            dbUtilities db = new dbUtilities("BANGAZONCLI_DB");
            CustomerManager cm = new CustomerManager(db);
            ProductManager pm = new ProductManager(db);
            OrderManager om = new OrderManager(om);
            db.CheckCustomer();
            db.CheckProduct();
            db.CheckOrder();

            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
			Console.Write ("> ");
            Console.WriteLine ("5. Add a product to the active customer's order");
			Console.Write ("> ")

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            // If option 1 was chosen, create a new customer account
            if (choice == 1)
            {
            }

            // If option 5 was chosen, user can add a product to the active customer's order
            if (choice == 5)
            {
                AddProductOrder.DoAction(cm, db, pm, om);
            }
        }
    }
}
