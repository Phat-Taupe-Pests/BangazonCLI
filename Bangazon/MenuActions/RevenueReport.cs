using System;
using System.Collections.Generic;

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
            if (CustomerManager.currentCustomer == null)
            {
                return;
            }
            var orderList = om.GetCompletedOrders();
            Console.Clear();
            Console.WriteLine($"Revenue Report for {CustomerManager.currentCustomer.firstName} {CustomerManager.currentCustomer.lastName}");
            Console.WriteLine("");
            
            foreach(RevenueReport rr in orderList)
            {
                string dash = "-";
                Console.WriteLine($"Order #{rr.orderID}");
                Console.WriteLine(dash.PadLeft(24, '-'));
                // foreach(RevenueReport r in rr)
                // {
                //     total += (rr2.price * rr2.quantity);
                //     Console.WriteLine($"{rr2.name}{rr2.quantity.ToString().PadLeft(15, ' ')}{rr2.price.ToString().PadLeft(5, ' ')}");
                //     Console.WriteLine("");
                // }
            }
            Console.WriteLine($"Total Revenue: ${total}");
        }
    
    }



}