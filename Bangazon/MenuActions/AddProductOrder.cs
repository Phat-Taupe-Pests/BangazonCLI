using System;
using System.Collections.Generic;
//Written by Adam Reidelbach

namespace BangazonCLI.MenuActions
    {
    //Manages to the menu to add products to an order
    public class AddProductOrder
    {

        //The primary functionality of this menu
        public static void AddProductToOrder(CustomerManager cm, dbUtilities db, ProductManager pm, OrderManager om)
        {
            Console.Clear();
            int custID = CustomerManager.currentCustomer.customerID;
            //Get a list of products
            Console.WriteLine ("Choose a product to add to the order");
            List<Product> products = pm.GetProductList(custID);
            //Display the list of products
            int productCounter = 1;
            foreach (Product product in products)
            {
                Console.WriteLine($"{productCounter}. {product.name}");
                productCounter++;
            }
            Console.WriteLine($"{productCounter}. Done Adding Products");
            Console.WriteLine ("> ");
            int choice = int.Parse(Console.ReadLine());
            int index = choice -1;

            Product selectedProduct = products[index];
            om.AddProductToOrder(selectedProduct.productID);

            
            
            // After the user selects a product to add to the customer's order, display the menu of products again. Make sure the last option provides the option to go back to main menu.
        }
    }
}