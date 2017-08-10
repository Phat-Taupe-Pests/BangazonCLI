using System;

namespace BangazonCLI
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
            paymentName = NoEmptyAnswers.notAOne(paymentName, "Please enter a payment type!!");

            //Prompts and then takes account number
            Console.WriteLine($"Enter Account Number");
            Console.WriteLine($">");

            int accountNumber = 0; 

            while (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }

            PaymentType newPaymentType = new PaymentType() { accountNumber=accountNumber, name=paymentName };
            ptm.AddNewPaymentType(newPaymentType);


        }
    }
}