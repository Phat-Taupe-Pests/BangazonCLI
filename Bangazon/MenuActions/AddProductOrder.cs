using System;
using System.Collections.Generic;

namespace BangazonCLI.MenuActions
{
public class AddProductOrder
  {
    public static void DoAction(CustomerManager cm, dbUtilities db, ProductManager pm, OrderManager om)
    {
        //Get current active customer. If there is not one, alert user to activate a customer.
        if (cm.GetCurrentCustomer() == null) {
            Console.WriteLine ("There is no active customer. Return to the main menu and activate a customer.");
        }
        //** allow user to return to main menu

        //Show list of products inside of customer's order
        Console.WriteLine ("Choose a product to add to the order");
        Console.Write ("> ");
        List<Product> products = pm.GetProductList();
        int productCounter = 0;
        foreach (Product product in products)
        {
            Console.WriteLine(productCounter + ". " + product.name);
            productCounter++;
        }
        Console.WriteLine ("> ");
        string productChoice = Console.ReadLine();

        //add productChoice to customer's order
        //** set code below equal to something?
        Product productToAdd = om.AddProductToOrder(int.Parse(productChoice));      

        // After the user selects a product to add to the customer's order, display the menu of products again. Make sure the last option provides the option to go back to main menu.


      // Console.WriteLine ("Enter toy");
      // Console.Write ("> ");
      // string toyName = Console.ReadLine();
      // bag.Add(toyName, kid);
    }
  }
}