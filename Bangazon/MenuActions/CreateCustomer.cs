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
            firstName = NoEmptyAnswers.notAOne(firstName, "Please enter a customer first name");

            Console.Clear();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");
            string lastName = Console.ReadLine();
            lastName = NoEmptyAnswers.notAOne(lastName, "Please enter a customer last name");

            Console.Clear();
            Console.WriteLine ("Enter customer street address");
            Console.Write ("> ");
            string streetAddress = Console.ReadLine();
            streetAddress = NoEmptyAnswers.notAOne(streetAddress, "Please enter a customer street address");
            
            Console.Clear();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");
            string city = Console.ReadLine();
            city = NoEmptyAnswers.notAOne(city, "Please enter a customer city");

            Console.Clear();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");
            string state = Console.ReadLine();
            state = NoEmptyAnswers.notAOne(state, "Please enter a customer state");

            Console.Clear();
            int postalCode = 0;
            do {
                Console.WriteLine ("Enter customer postal code");
                Console.Write ("> ");
                string stringPostalCode = Console.ReadLine();
                stringPostalCode = NoEmptyAnswers.notAOne(stringPostalCode, "Please enter a postal code");
                try{
                    do {
                        Console.WriteLine("Please enter a five digit postal code.");
                        Console.Write ("> ");
                        stringPostalCode = Console.ReadLine();
                    } while(stringPostalCode.Length < 5 || stringPostalCode.Length > 5);
                    postalCode = Convert.ToInt32(stringPostalCode);

                } catch {
                    Console.WriteLine("Please enter a five digit postal code.");
                }

            } while (postalCode == 0);
            Console.Clear();
            Console.WriteLine ("Enter customer phone number");
            Console.Write ("> ");
            string phoneNumber = Console.ReadLine();
            NoEmptyAnswers.notAOne(phoneNumber, "Please enter a customer phone number");
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