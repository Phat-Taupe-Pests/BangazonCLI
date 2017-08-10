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
            noEmptyAnswers(firstName, "a customer first name");

            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");
            string lastName = Console.ReadLine();
            noEmptyAnswers(lastName, "a customer last name");

            Console.Clear();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");
            string streetAddress = Console.ReadLine();
            noEmptyAnswers(streetAddress, "a customer street address");

            Console.Clear();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");
            string state = Console.ReadLine();
            noEmptyAnswers(state, "a customer state");

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
            noEmptyAnswers(phoneNumber, "a customer phone number");
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

        public static string noEmptyAnswers(string answer, string thingToEnter){
            string input = answer;
            do {
                Console.WriteLine($"Please enter {thingToEnter}.");
                Console.Write ("> ");
                input = Console.ReadLine();
            } while (input.Length == 0);
            return input;
        }
    }
}