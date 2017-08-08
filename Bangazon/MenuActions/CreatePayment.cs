using System;

namespace BangazonCLI.MenuActions
{
    // Written by: Eliza Meeks
    // Menu action to create a payment type.
    public class CreatePayment
    {
        // Method to create the menu and allow the user to input a payment type name and account number.
        public static void CreatePaymentMenu(PaymentTypeManager ptm)
        {
            
            Console.Clear();
            //Prompt and then takes payment type
            Console.WriteLine($"Enter payment type (e.g. AmEx, Visa, Checking)");
            Console.WriteLine($">");
            string paymentName = Console.ReadLine();

            //Prompts and then takes account number
            Console.WriteLine($"Enter Account Number");
            Console.WriteLine($">");

            int accountNumber = int.Parse(Console.ReadLine());

            PaymentType newPaymentType = new PaymentType() { accountNumber=accountNumber, name=paymentName };
            ptm.AddNewPaymentType(newPaymentType);


        }
    }
}