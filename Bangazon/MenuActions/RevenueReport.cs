using System;
using System.Collections.Generic;

namespace BangazonCLI.MenuActions
{
    public class RevenueReport
    {
        // Written By : Matt Augsburger
        public Customer cust { get; set; }
        public List<Order> orderList { get; set; }

        public static void createRevenueReport (OrderManager om, ProductManager pm)
        {
            List<Order> allCustomersOrders = om.GetAllClosedCustomersOrders(CustomerManager.currentCustomer.customerID);
            foreach (Order order in allCustomersOrders)
            {
                order.products = pm.GetProductsOnOrder(order.orderID);
            }
            // This line pauses the console until the press a key. Great to let them see results before reverting to main menu.
            Console.ReadKey();
        }
    }
}