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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string firstName = Console.ReadLine();
            firstName = NoEmptyAnswers.notAOne(firstName, "Please enter a customer first name");

            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string lastName = Console.ReadLine();
            lastName = NoEmptyAnswers.notAOne(lastName, "Please enter a customer last name");

            Console.Clear();
            Console.WriteLine ("Enter customer street address");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string streetAddress = Console.ReadLine();
            streetAddress = NoEmptyAnswers.notAOne(streetAddress, "Please enter a customer street address");
            
            Console.Clear();
            Console.WriteLine ("Enter customer city");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string city = Console.ReadLine();
            city = NoEmptyAnswers.notAOne(city, "Please enter a customer city");

            Console.Clear();
            Console.WriteLine ("Enter customer state");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string state = Console.ReadLine();
            state = NoEmptyAnswers.notAOne(state, "Please enter a customer state");

            Console.Clear();
            int postalCode = 0;
            do {
                Console.WriteLine ("Enter customer postal code");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write ("> ");
                Console.ResetColor();
                string stringPostalCode = Console.ReadLine();
                stringPostalCode = NoEmptyAnswers.notAOne(stringPostalCode, "Please enter a postal code");
                try{
                    
                    postalCode = Convert.ToInt32(stringPostalCode);

                } catch {
                    Console.WriteLine("Please enter a five digit postal code.");
                    stringPostalCode = Console.ReadLine();
                    Int32.TryParse(stringPostalCode, out postalCode);
                }

            } while (postalCode == 0);
            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write ("> ");
            Console.ResetColor();
            string phoneNumber = Console.ReadLine();
            phoneNumber = NoEmptyAnswers.notAOne(phoneNumber, "Please enter a customer phone number");
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

            Console.Clear();
            Console.WriteLine($"You have created a customer! {newCustomer.firstName} {newCustomer.lastName} is now in the Bangazon System");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
}