using System;


namespace BangazonCLI
{
    public class MainMenu
    {
        public int ShowMainMenu()
        {
             // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. Choose active customer");
            Console.WriteLine ("3. Create a payment option");
            Console.WriteLine ("4. Add product to sell");
            Console.WriteLine ("5. Add product to shopping cart");
            Console.WriteLine ("6. Complete an order");
            Console.WriteLine ("7. Remove customer product");
            Console.WriteLine ("8. Update product information");
            Console.WriteLine ("9. Show stale products");
            Console.WriteLine ("10. Show customer revenue report");
            Console.WriteLine ("11. Show overall product popularity");
            Console.WriteLine ("12. Leave Bangazon!");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);
            return choice;

        }
    }
}