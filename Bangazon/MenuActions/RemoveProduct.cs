using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{

    // Written By : Chaz Henricks
    // Method displays the Remove Product From Sale Menu
    // Accepts Argument of an instance of ProductManager
    // Shows a list of products offered for sales by the active customer.
    // Deletes a product if one is selected
    public class RemoveProductToSell
    {
        public static void RemoveProductToSellMenu(ProductManager products)
        {
            Console.Clear();
            Console.WriteLine("Select a product you wish to remove from sale:");
            int custID = CustomerManager.currentCustomer.customerID;
            List<Product> ProductList = products.GetProductList(custID);
            int counter = 1;
            foreach(Product item in ProductList)
            {
                Console.WriteLine($"{counter}. {item.name}");
                counter++;
            }
            Console.Write ("> ");
            int productChoice;
             Int32.TryParse (Console.ReadLine(), out productChoice);
            int selectedProductIndex = productChoice -1;
            products.RemoveProductToSell(ProductList[selectedProductIndex].productID);
        }
    }
}