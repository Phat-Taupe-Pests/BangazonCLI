using System;


namespace BangazonCLI
{
    public class CreateCustomer
    {
        public void CreateCustomerMenu(CustomerManager cm)
        {

            Console.WriteLine ("Enter customer first name");
            Console.Write ("> ");
            string firstName = Console.ReadLine();
            Console.WriteLine ("Enter customer last name");
            Console.Write ("> ");
            string lastName = Console.ReadLine();
            Console.WriteLine ("Enter customer city");
            Console.Write ("> ");
            string streetAddress = Console.ReadLine();
            Console.WriteLine ("Enter customer state");
            Console.Write ("> ");
            string state = Console.ReadLine();
            Console.WriteLine ("Enter customer postal code");
            Console.Write ("> ");
            int postalCode = Convert.ToInt32(Console.ReadLine());
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