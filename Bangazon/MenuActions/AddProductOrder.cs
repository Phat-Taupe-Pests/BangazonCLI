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
                Order ActiveOrder = om.GetActiveCustomerOrder(custID);
                if (ActiveOrder.orderID == 0) {
                    om.CreateNewOrder(products[index].productID);
                    //decrement product quantity by one
                    string updateString = $"UPDATE product SET quantity = {products[index].quantity - 1} WHERE productID = {products[index].productID} and quantity > 0";
                    pm.UpdateProduct(updateString);
                    Console.WriteLine($"{products[index].name} successfully added to your order");
                    products = pm.GetProductsNotSoldByCustomer(custID);
                    choice = DisplayProductList(products);
                }
                if (ActiveOrder.orderID != 0) {
                    om.AddProductToOrder(products[index].productID);
                    //decrement product quantity by one
                    string updateString = $"UPDATE product SET quantity = {products[index].quantity - 1} WHERE productID = {products[index].productID} and quantity > 0";
                    pm.UpdateProduct(updateString);
                    Console.WriteLine($"{products[index].name} successfully added to your order");
                    products = pm.GetProductsNotSoldByCustomer(custID);
                    choice = DisplayProductList(products);
                }
            } while(choice != 0);
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