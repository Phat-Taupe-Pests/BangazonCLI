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
            NoEmptyAnswers.notAOne(firstName, "a customer first name");

            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");
            string lastName = Console.ReadLine();
            NoEmptyAnswers.notAOne(lastName, "a customer last name");

            Console.Clear();
            Console.WriteLine ("Enter customer street address");
            Console.Write ("> ");
            string streetAddress = Console.ReadLine();
            NoEmptyAnswers.notAOne(streetAddress, "a customer street address");
            
            Console.Clear();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");
            string city = Console.ReadLine();
            NoEmptyAnswers.notAOne(city, "a customer city");

            Console.Clear();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");
            string state = Console.ReadLine();
            NoEmptyAnswers.notAOne(state, "a customer state");

            Console.Clear();
            int postalCode = 0;
            do {
                Console.WriteLine ("Enter customer postal code");
                Console.Write ("> ");
                string stringPostalCode = Console.ReadLine();
                if (stringPostalCode.Length < 5 || stringPostalCode.Length > 5){
                    Console.WriteLine("Please enter a five digit postal code.");
                    Console.Write ("> ");
                    stringPostalCode = Console.ReadLine();
                }
                try{
                    postalCode = Convert.ToInt32(stringPostalCode);

                } catch {
                    Console.WriteLine("Please enter a five digit postal code.");
                }

            } while (postalCode == 0);
            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();
            NoEmptyAnswers.notAOne(phoneNumber, "a customer phone number");
            Customer newCustomer = new Customer()
            {
                firstName = firstName,
                lastName = lastName,
                streetAddress = streetAddress,
                state = state,
                city = city,
                postalCode = postalCode,
                phoneNumber = phoneNumber
            };
            cm.AddNewCustomer(newCustomer);
        }

    }
}