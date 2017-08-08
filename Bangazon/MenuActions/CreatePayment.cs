using System;

namespace BangazonCLI
{
    public class CreatePayment
    {
        public static void CreatePaymentMenu(PaymentTypeManager ptm)
        {
            
            Console.Clear();

            Console.WriteLine($"Enter payment type (e.g. AmEx, Visa, Checking)");

            Console.WriteLine($">");

            string paymentName = Console.ReadLine();
            Console.WriteLine($"Enter Account Number");
            Console.WriteLine($">");

            int accountNumber = int.Parse(Console.ReadLine());

            PaymentType newPaymentType = new PaymentType() { accountNumber=accountNumber, name=paymentName };
            ptm.AddNewPaymentType(newPaymentType);


        }
    }
}