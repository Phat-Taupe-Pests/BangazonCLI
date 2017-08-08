using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class AddProductToSell
    {
        //Also need to pass in customer ID as an argument
        public static void DoAction(ProductManager products, ProductTypeManager ptm, dbUtilities db, int customer)
        {
            Console.Clear();
            Console.WriteLine("What is the name of the product you are selling?");
            Console.Write ("> ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please provide a short description of {name}:");
            Console.Write("> ");
            string desc = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"How much do you wish to sell {name} for?");
            Console.Write("> ");
            Double price;
            Double.TryParse (Console.ReadLine(), out price);
            Console.Clear();
            Console.WriteLine($"What kind of product is {name}?");
            List<ProductType> productTypeList = ptm.GetProductTypeList();
            int counter = 1;
            foreach(ProductType item in productTypeList)
            {
                Console.WriteLine($"{counter}. {item.name}");
                counter++;
            }
            int choice;
		    Int32.TryParse (Console.ReadLine(), out choice);
            int selectedTypeIndex = choice -1;
            int quantity;
            Console.Clear();
            Console.WriteLine($"How many are you posting for sale?");
            Int32.TryParse (Console.ReadLine(), out quantity);

            Product newProduct = new Product();
                newProduct.name = name;
                newProduct.description = desc;
                newProduct.price = price;
                newProduct.dateCreated= DateTime.Today;
                newProduct.customerID = 1;
                newProduct.productTypeID = selectedTypeIndex;
                newProduct.quantity = quantity;
                products.AddNewProduct(newProduct);
                productTypeList.Clear();
        }
    }
}