using System;
using System.Collections.Generic;
using System.Linq;

namespace BangazonCLI.MenuActions
{
    // A menu action to assist the user in completing a customer order
    public class CompleteOrder
    {
        //Produces the actual menu the user will interact with. Utilizes the ordermanager, product manager, and paymenttype manager to get all relevant info to complete a customer's order.
        public static void CompleteOrderMenu(OrderManager om, ProductManager pm, PaymentTypeManager ptm)
        {
            Order activeOrder = om.GetActiveCustomerOrder(CustomerManager.currentCustomer.customerID);
            if (activeOrder.orderID == 0)
            {
                Console.WriteLine("Please add some products to your order first. Press any key to return to main menu.");
                Console.ReadKey();
                return;
            }
            activeOrder.products = pm.GetProductsOnOrder(activeOrder.orderID);
            double orderTotal = activeOrder.products.Sum(product => product.price);
            string completeChoice = showCompletionOption(orderTotal);
            while (completeChoice != "Y" && completeChoice != "y" && completeChoice != "N" && completeChoice != "n")
            {
                Console.WriteLine(completeChoice);
                Console.WriteLine("Sorry, I didn't understand your input.");
                completeChoice = showCompletionOption(orderTotal);
            }
            if (completeChoice == "N" || completeChoice == "n")
            {
                Console.WriteLine("Order not completed. Press any key to return to main menu.");
                Console.ReadKey();
                return;
            }
            List <PaymentType> customersPaymentTypes = ptm.GetCustomersPaymentTypes(CustomerManager.currentCustomer.customerID);
            int ptindex = 1;
            Console.WriteLine("Please select a previously stored payment option:");
            foreach (PaymentType paymenttype in customersPaymentTypes)
            {
                Console.WriteLine($"{ptindex}. {paymenttype.name}");
                ptindex++;
            }
            Console.WriteLine ("> ");
            int paymentChoiceIndex = int.Parse(Console.ReadLine());
            paymentChoiceIndex -= 1;
            activeOrder.paymentTypeID = customersPaymentTypes[paymentChoiceIndex].paymentTypeID;
            om.CompleteOrder(activeOrder);
            Console.WriteLine("You order is now complete. Press any key to return to the main menu.");
            Console.ReadKey();
            return;

        }
        // A helper method that displays over and over until the user selects yes or no.
        public static string showCompletionOption (double total)
        {
            string selection;
            Console.WriteLine($"Your order total is ${total}. Complete this order?");
            Console.WriteLine("Y/N");
            Console.WriteLine ("> ");
            selection = Console.ReadLine();
            return selection;
        }

    }
} 