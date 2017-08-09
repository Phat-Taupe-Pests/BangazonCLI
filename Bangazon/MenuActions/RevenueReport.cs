using System;
using System.Collections.Generic;

namespace BangazonCLI
{
    public class RevenueReport
    {
        // Written By : Matt Augsburger
        public List<Order> orderList { get; set; }

        public RevenueReport()
        {
            // orderList = GetCustomerOrders(CustomerManager.currentCustomer.customerID);
        }

        public static void ShowRevenueReport()
        {
            double total = 0;
            if (CustomerManager.currentCustomer == null)
            {
                return;
            }
            Console.Clear();
            Console.WriteLine($"Revenue Report for {CustomerManager.currentCustomer.firstName} {CustomerManager.currentCustomer.lastName}");
            Console.WriteLine("");
            
            foreach(Order o in orderList)
            {
                string dash = "-";
                Console.WriteLine($"Order #{o.orderID}");
                Console.WriteLine(dash.PadLeft(24, '-'));
                foreach(Product p in o.products)
                {
                    total += (p.price * p.quantity);
                    Console.WriteLine($"{p.name}{p.quantity.ToString().PadLeft(15, ' ')}{p.price.ToString().PadLeft(5, ' ')}");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine($"Total Revenue: ${total}");
        }
    
    }



}