using System;
using System.Collections.Generic;

namespace BangazonCLI.MenuActions
    {
    // Purpose: Allows user to add a product to an order
    // Written By : Adam Reidelbach and Eliza Meeks
    // Uses CustomerManger to get current customer, ProductManager for getting products not sold by the active customer, and OrderManager for creating a new order and adding a product to an order
    public class AddProductOrder
    {
        public static void AddProductToOrder(CustomerManager cm, ProductManager pm, OrderManager om)
        {
            Console.Clear();
            int custID = CustomerManager.currentCustomer.customerID;
            List<Product> products = pm.GetProductsNotSoldByCustomer(custID);
            //int[] is an array of integers
            int[] choice = DisplayProductList(products);
            do
            {
                int index = choice[0] -1;
                Order ActiveOrder = om.GetActiveCustomerOrder(custID);
                //if there is NOT an active customer, run this
                if (ActiveOrder.orderID == 0) {
                    //if user choice is less than product count, create a new order
                    if (choice[0] < products.Count){
                        om.CreateNewOrder(products[index].productID);
                    //if user choice does not equal the exit number, run this menu again 
                    } else if (choice[0] != choice[1]) {
                        Console.Clear();
                        Console.WriteLine("That is not a valid option for a product, press enter to continue!");
                        Console.ReadLine();
                        AddProductOrder.AddProductToOrder(cm, pm, om);
                    // if the user choice equals the exit number, exit the menu
                    } else if (choice[0] == choice[1]){
                        break;
                    }
                    //decrement product quantity by one
                    string updateString = $"UPDATE product SET quantity = {products[index].quantity - 1} WHERE productID = {products[index].productID} and quantity > 0";
                    pm.UpdateProduct(updateString);
                    Console.WriteLine($"{products[index].name} successfully added to your order");
                    products = pm.GetProductsNotSoldByCustomer(custID);
                    choice = DisplayProductList(products);
                }
                //if there IS an active customer, run this
                if (ActiveOrder.orderID != 0) {
                    if (choice[0] < products.Count){
                        om.AddProductToOrder(products[index].productID);
                    } else if (choice[0] != choice[1]) {
                        Console.Clear();
                        Console.WriteLine("That is not a valid option for a product, press enter to continue!");
                        Console.ReadLine();
                        AddProductOrder.AddProductToOrder(cm, pm, om);
                    } else if (choice[0] == choice[1]){
                        break;
                    }
                    //decrement product quantity by one
                    string updateString = $"UPDATE product SET quantity = {products[index].quantity - 1} WHERE productID = {products[index].productID} and quantity > 0";
                    pm.UpdateProduct(updateString);
                    Console.WriteLine($"{products[index].name} successfully added to your order");
                    products = pm.GetProductsNotSoldByCustomer(custID);
                    choice = DisplayProductList(products);
                }
            } while(choice[0] != choice[1]);
            return;
        }

        //Helper method to display list of products
        public static int[] DisplayProductList (List<Product>ProductList)
        {
            //exitNum allows user to select the last number in the list to return to the main menu
            int choice = 0;
            int exitNum = ProductList.Count + 1;
            do {
                Console.WriteLine ("Choose a product to add to the order");
                int productCounter = 1;
                foreach (Product product in ProductList)
                {
                    Console.WriteLine($"{productCounter}. {product.name}");
                    productCounter++;
                }
                Console.WriteLine($"Press {exitNum} to exit");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write ("> ");
                Console.ResetColor();
                Int32.TryParse(Console.ReadLine(), out choice);

            } while (choice == 0);

            int[] choiceArray = new int[]{choice, exitNum};

            return choiceArray;
        }
    }
}