using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class ProductPopularityReport
    {
  
        //writes the popularity report
        public static void ProductPopularityReportMenu(ProductManager pm)
        {
            Console.Clear();

            List<PopProducts> PopularProducts = pm.GetPopularProducts();


            String product1 = FormatPurchases(PopularProducts[0].name);
            String product2 = FormatPurchases(PopularProducts[1].name);
            String product3 = FormatPurchases(PopularProducts[2].name);

            String orders1 = FormatOrders(PopularProducts[0].orders);
            String orders2 = FormatOrders(PopularProducts[1].orders);
            String orders3 = FormatOrders(PopularProducts[2].orders);

            String purchasers1 = FormatPurchasers(PopularProducts[0].purchasers);
            String purchasers2 = FormatPurchasers(PopularProducts[1].purchasers);
            String purchasers3 = FormatPurchasers(PopularProducts[2].purchasers);


            String revenue1 = FormatRevenue(PopularProducts[0].orders, PopularProducts[0].price);
            String revenue2 = FormatRevenue(PopularProducts[1].orders, PopularProducts[1].price);
            String revenue3 = FormatRevenue(PopularProducts[2].orders, PopularProducts[2].price);

            String ordersTotal = FormatOrders((PopularProducts[0].orders + PopularProducts[1].orders + PopularProducts[2].orders));
            String purchasersTotal = FormatPurchasers((PopularProducts[0].purchasers + PopularProducts[1].purchasers + PopularProducts[2].purchasers));
            String revenueTotal = FormatPurchasers((Convert.ToInt32(PopularProducts[0].orders * PopularProducts[0].price)) + (Convert.ToInt32(PopularProducts[1].orders * PopularProducts[1].price)) + (Convert.ToInt32(PopularProducts[2].orders * PopularProducts[2].price)));



            Console.WriteLine($"Products            Orders     Purchasers     Revenue        ");
            Console.WriteLine($"*************************************************************");
            Console.WriteLine($"{product1}{orders1}{purchasers1}{revenue1}");
            Console.WriteLine($"{product2}{orders2}{purchasers2}{revenue2}");
            Console.WriteLine($"{product3}{orders3}{purchasers3}{revenue3}");
            Console.WriteLine($"*************************************************************");
            Console.WriteLine($"Totals:             {ordersTotal}{purchasersTotal}{revenueTotal}");
            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit");

            Console.ReadKey();
        }
        //formats any string passed in to be 20 characters long
        //if > 20 adds padding
        //if < 20 chops the excess and adds ... 
        public static string FormatPurchases(String toFormat)
        {
            String formattedString;
            if(toFormat.Length > 20)
            {
                formattedString = toFormat.Remove(17) + "...";
                return formattedString;
            }
            else if(toFormat.Length < 20)
            {
                String paddingString = toFormat.PadRight(22, ' ');
                formattedString = paddingString.Remove(20);
                return formattedString;
            }
            else
            {
                return toFormat;
            }
        }
        public static string FormatOrders(int number)
        {
            String toFormat = number.ToString();
            String formattedString;
            if(toFormat.Length < 11)
            {
                String paddingString = toFormat.PadRight(13, ' ');
                formattedString = paddingString.Remove(11);
                return formattedString;
            }
            else
            {
                return toFormat;
            }
        }

        public static string FormatPurchasers(int number)
        {
            String toFormat = number.ToString();
            String formattedString;
            if(toFormat.Length < 15)
            {
                String paddingString = toFormat.PadRight(16, ' ');
                formattedString = paddingString.Remove(15);
                return formattedString;
            }
            else
            {
                return toFormat;
            }
        }
        public static string FormatRevenue(int orders, double price)
        {

            Convert.ToDouble(orders);
            double revenue = orders * price;
            String toFormat = revenue.ToString();
            String formattedString;
            if(toFormat.Length < 15)
            {
                String paddingString = toFormat.PadRight(16, ' ');
                formattedString = paddingString.Remove(15);
                return formattedString;
            }
            else
            {
                return toFormat;
            }
        }
    }   
}