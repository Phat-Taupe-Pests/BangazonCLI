using System;
using System.Collections.Generic;
using BangazonCLI.MenuActions;

namespace BangazonCLI
{
    public class RevenueReport
    {
        public int orderID { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        // Written By : Matt Augsburger


        // Formats the incoming revenue report 
        // takes arguments of name, quantity, and price
        // returns a formatted string to be printed to the console
        public static string FormatRevenueReport(string name, int quantity, double price)
        {

            string frmString;
            string padName;
            if (name.Length > 20)
            {
                frmString = name.Remove(17) + "...";
                padName = frmString.PadRight(32, ' ');
            }else
            {
                int num = 32 - name.Length;
                frmString = name.PadRight(num, ' ');
                padName = frmString.PadRight(32, ' ');
            };

            string strQuantity;
            string padStrQuantity;
            if (quantity < 10)
            {
                strQuantity = quantity.ToString();
                padStrQuantity = strQuantity.PadRight(10, ' ');
            }else
            {
                strQuantity = quantity.ToString();
                padStrQuantity = strQuantity.PadRight(9, ' ');
            }

            string strPrice = price.ToString();

            string formattedString = padName+padStrQuantity+"$"+strPrice;

            return formattedString;
        }

        // Writes the Revenue Report of the currentCustomer
        // Takes an argument of an instance of OrderManager

        public static void ShowRevenueReport(OrderManager om)
        {
            double total = 0;
            string dash = "";
            dash = dash.PadLeft(52, '-');
            var completedOrderList = om.GetCompletedOrders();
            Console.Clear();
            Console.WriteLine($"Revenue Report for {CustomerManager.currentCustomer.firstName} {CustomerManager.currentCustomer.lastName}:");
            Console.WriteLine("");
            
            foreach(RevenueReport rr in completedOrderList)
            {
                string formattedString = FormatRevenueReport(rr.name, rr.quantity, (rr.price * rr.quantity));
                Console.WriteLine($"Order #{rr.orderID}");
                Console.WriteLine(dash);
                Console.WriteLine(formattedString);
                Console.WriteLine("");
                total += (rr.price * rr.quantity);
         
            }
            Console.WriteLine($"Total Revenue: ${total}");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
    
    }
}