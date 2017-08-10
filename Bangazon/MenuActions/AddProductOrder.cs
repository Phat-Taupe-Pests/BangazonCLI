using System;
using System.Collections.Generic;

namespace BangazonCLI.MenuActions
    {
    public class AddProductOrder
    {
        public static void AddProductToOrder(CustomerManager cm, dbUtilities db, ProductManager pm, OrderManager om)
        {
            Console.Clear();
            int choice;
            do
            {
                int custID = CustomerManager.currentCustomer.customerID;
                //Get a list of products
                Console.WriteLine ("Choose a product to add to the order");
                List<Product> products = pm.GetProductsNotSoldByCustomer(custID);
                //Display the list of products
                int productCounter = 1;
                foreach (Product product in products)
                {
                    Console.WriteLine($"{productCounter}. {product.name}");
                    productCounter++;
                }
                Console.WriteLine("Press ESC key to exit");
                Console.WriteLine ("> ");
                choice = int.Parse(Console.ReadLine());
                int index = choice -1;

                Product selectedProduct = products[index];
                om.AddProductToOrder(selectedProduct.productID);
            }while(choice != 9);

            // After the user selects a product to add to the customer's order, display the menu of products again. Make sure the last option provides the option to go back to main menu.
        }
    }
}