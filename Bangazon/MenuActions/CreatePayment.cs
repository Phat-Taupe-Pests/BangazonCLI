using System;

namespace BangazonCLI
{
    public class CreatePayment
    {
        public static void CreatePaymentMenu(PaymentTypeManager ptm)
        {
            
            Console.Clear();

            Console.WriteLine($"Enter payment type (e.g. AmEx, Visa, Checking)");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($">");

            string paymentName = Console.ReadLine();
            Console.WriteLine("paymentName" + paymentName);

            Console.ForegroundColor= ConsoleColor.Black;
            Console.WriteLine($"Enter Account Number");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($">");

            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("accountNumber" + accountNumber);

            Console.ForegroundColor= ConsoleColor.Black;

            PaymentType newPaymentType = new PaymentType() { accountNumber=accountNumber, name=paymentName };

            ptm.AddNewPaymentType(newPaymentType);


        }
    }
}