using System;
using System.Collections.Generic;

namespace BangazonCLI.MenuActions
    {
    public class AddProductOrder
    {
        public static void AddProductToOrder(CustomerManager cm, ProductManager pm, OrderManager om)
        {
            Console.Clear();
            int custID = CustomerManager.currentCustomer.customerID;
            List<Product> products = pm.GetProductsNotSoldByCustomer(custID);
            int choice = DisplayProductList(products);
            do
            {
                int index = choice -1;
                //call getActiveCustomerOrder
                // if orderID = 0
                // run CreateNewOrder
                // else run the rest of this logic
                om.AddProductToOrder(products[index].productID);
                products = pm.GetProductsNotSoldByCustomer(custID);
                Console.WriteLine("It worked");
                DisplayProductList(products);
            } while(choice != 0);
            Console.WriteLine("Hit any key to return to the main menu");
            Console.ReadLine();
            return;
        }

        public static int DisplayProductList (List<Product>ProductList)
        {
            int choice;
            //Get a list of products
            Console.WriteLine ("Choose a product to add to the order");
            //Display the list of products
            int productCounter = 1;
            foreach (Product product in ProductList)
            {
                Console.WriteLine($"{productCounter}. {product.name}");
                productCounter++;
            }
            Console.WriteLine("Press 0 to exit");
            Console.WriteLine ("> ");
            choice = int.Parse(Console.ReadLine());

            return choice;
        }
    }
}