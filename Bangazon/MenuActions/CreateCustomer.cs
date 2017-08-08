using System;


namespace BangazonCLI
{
    public class CreateCustomer
    {
        // Written By : Matt Augsburger
        // Method displays the Create Customer Menu
        // Accepts Argument of an instance of CustomerManager
        // Adds Created Customer to DB
         public static void CreateCustomerMenu(CustomerManager cm)
        {
            Console.Clear();
            Console.WriteLine ("Enter customer first name");
            Console.Write ("> ");
            string firstName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");
            string lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");
            string streetAddress = Console.ReadLine();
            Console.Clear();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");
            string state = Console.ReadLine();
            Console.Clear();
            Console.WriteLine ("Enter customer postal code");
            Console.Write ("> ");
            int postalCode = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();
            Customer newCustomer = new Customer()
            {
                firstName = firstName,
                lastName = lastName,
                streetAddress = streetAddress,
                state = state,
                postalCode = postalCode,
                phoneNumber = phoneNumber
            };
            cm.AddNewCustomer(newCustomer);
        }
    }
}