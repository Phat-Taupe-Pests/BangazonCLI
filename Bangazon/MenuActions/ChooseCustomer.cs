using System;
using System.Collections.Generic;

namespace BangazonCLI
{
    public class ChooseCustomer
    {
        // Written By : Matt Augsburger
        // Method displays the Choose Customer Menu
        // Accepts Argument of an instance of CustomerManager and dbUtilities
        // Lists Customers in the database
        // Sets selected Customer to _currentCustomer
         public static void ChooseCustomerMenu(CustomerManager cm, dbUtilities db)
        {
            var custList = cm.GetCustomerList();
            Dictionary<int, Customer> custDictionary = new Dictionary<int, Customer>();
            Console.Clear();
            int counter = 1;
            Console.WriteLine("Select customer");
            foreach(Customer c in custList)
            {
                custDictionary.Add(counter, c);
                Console.WriteLine($"{counter}. {c.firstName} {c.lastName}");
                counter++;

            }
            Console.WriteLine(">");

           

            int choiceInt = 0; 
 
            while (!int.TryParse(Console.ReadLine(), out choiceInt))
            {
                 Console.WriteLine("Please Enter a valid numerical value!");
            }

            foreach(KeyValuePair<int, Customer> kvp in custDictionary)
            {
                if(choiceInt == kvp.Key)
                {
                    Console.Clear();
                    Console.WriteLine($"You selected {kvp.Value.firstName} {kvp.Value.lastName} as the current customer");
                    CustomerManager.currentCustomer = kvp.Value;
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                }else if (choiceInt > custDictionary.Count){
                    Console.Clear();
                    Console.WriteLine("That is not a valid option for a current customer, try again!");
                    Console.ReadLine();
                    ChooseCustomer.ChooseCustomerMenu(cm, db);

                    return;
                }
            }

        }
    }
}