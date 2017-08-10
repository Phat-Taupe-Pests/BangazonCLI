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

        public static void ShowRevenueReport(OrderManager om)
        {
            double total = 0;
            var completedOrderList = om.GetCompletedOrders();
            Console.Clear();
            Console.WriteLine($"Revenue Report for {CustomerManager.currentCustomer.firstName} {CustomerManager.currentCustomer.lastName}");
            Console.WriteLine("");
            
            foreach(RevenueReport rr in completedOrderList)
            {
                string dash = "-";
                Console.WriteLine($"Order #{rr.orderID}");
                Console.WriteLine(dash.PadLeft(29, '-'));

                total += (rr.price * rr.quantity);
                Console.WriteLine($"{rr.name}{rr.quantity.ToString().PadLeft(10, ' ')}     ${(rr.price*rr.quantity).ToString()}");
                Console.WriteLine("");
         
            }
            Console.WriteLine($"Total Revenue: ${total}");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
    
    }
}