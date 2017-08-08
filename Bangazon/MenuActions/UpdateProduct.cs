using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class UpdateProduct
    {
        public static void UpdateProductMenu(ProductManager pm)
        {
            Console.Clear();
            Console.WriteLine("Select a product you would like to update:");
            int custID = CustomerManager.currentCustomer.customerID;
            int updateCounter = 1;
            List<Product> updateList = pm.GetProductList(custID);
            foreach(Product item in updateList)
            {
                Console.WriteLine($"{updateCounter}. {item.name}");
                updateCounter++;
            }
            Console.Write("> ");
            int updateChoice;
		    Int32.TryParse (Console.ReadLine(), out updateChoice);
            int selectedProductIndex = updateChoice -1;
            Product selectedProduct = updateList[selectedProductIndex];

            Console.Clear();
            Console.WriteLine("Select the field you wish to update:");
            Console.WriteLine($"1. Change Name: {selectedProduct.name}");
            Console.WriteLine($"1.  Change Description: {selectedProduct.description}");
            Console.WriteLine($"1.  Change Price: {selectedProduct.price}");
            Console.WriteLine($"1.  Change Quantity: {selectedProduct.quantity}");
        }
    }
}