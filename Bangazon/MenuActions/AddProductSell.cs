using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    //Written by: Chaz Henricks
    public class AddProductToSell
    {
        public static List<ProductType> productTypeList = new List<ProductType>();
        //Also need to pass in customer ID as an argument

        //Does the add product for a customer to sell. 
        //Needs a product manager and a product type manager
        public static void DoAction(ProductManager products, ProductTypeManager ptm)

        {
            Console.Clear();
            Console.WriteLine("What is the name of the product you are selling?");
            Console.Write ("> ");
            string name = Console.ReadLine();
            //checks to make sure a name is entered
            name = NoEmptyAnswers.notAOne(name, "Please enter a name for the product you are selling");

            Console.Clear();
            Console.WriteLine($"Please provide a short description of {name}:");
            Console.Write("> ");
            string desc = Console.ReadLine();
            desc = NoEmptyAnswers.notAOne(desc, "Please enter a description for your product");
            Double doublePrice = 0;
            //do loop will check that value is an integer
            do{
            Console.Clear();
            Console.WriteLine($"How much do you wish to sell {name} for?");
            Console.Write("> ");
            string price = Console.ReadLine();
            price = NoEmptyAnswers.notAOne(price, "Please enter a price for your product");
            
            try{
                doublePrice = Convert.ToDouble(price);
                } catch {
                    Console.WriteLine("Please enter a number for a price");
                    price = Console.ReadLine();
                    Double.TryParse(price, out doublePrice);
                }
            }while(doublePrice == 0);

            Console.Clear();
            
            int intChoice = 0;
            int counter = 1;
            int selectedTypeIndex;
            productTypeList = ptm.GetProductTypeList();
            //Checks to make sure the selection is in the range of the availble product types
            //Check the selected value agains the length of the list
            do{
                do{
                Console.WriteLine($"What kind of product is {name}?");
                counter = 1;
                foreach(ProductType item in productTypeList)
                {
                    Console.WriteLine($"{counter}. {item.name}");
                    counter++;
                }
                string choice = Console.ReadLine();
                choice = NoEmptyAnswers.notAOne(choice, "Please select a number for a value type");
                    try{ 
                            intChoice = Convert.ToInt32(choice);
                        } catch {
                            Console.WriteLine("Please enter a number");
                        }
                }while(intChoice == 0);
                
                selectedTypeIndex = intChoice -1;
            }while(selectedTypeIndex > productTypeList.Count);

            Console.Clear();
            Console.WriteLine($"How many are you posting for sale?");
            String quantity = Console.ReadLine();
            int intQuantity = 0;
            quantity = NoEmptyAnswers.notAOne(quantity, "Please enter a quantity");
            do{
                try{
                    intQuantity = Convert.ToInt32(quantity);
                } catch{
                    Console.WriteLine("Please enter a quantity");
                    quantity = Console.ReadLine();
                    Int32.TryParse(quantity, out intQuantity);
                }

            }while(intQuantity == 0);
           

            Product newProduct = new Product();
                newProduct.name = name;
                newProduct.description = desc;
                newProduct.price = doublePrice;
                newProduct.dateCreated= DateTime.Today;
                newProduct.quantity = intQuantity;
                newProduct.customerID = CustomerManager.currentCustomer.customerID;
                newProduct.productTypeID = productTypeList[selectedTypeIndex].productTypeID;
                products.AddNewProduct(newProduct);
                Console.Clear();
               Console.WriteLine($"{newProduct.name} was successfully added! Press any key to continue");
               Console.ReadKey();
        }
    }
}











