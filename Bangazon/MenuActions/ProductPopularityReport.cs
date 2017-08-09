using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class ProductPopularityReport
    {
        //writes the popularity report
        public static void ProductPopularityReportMenu()
        {
            Console.Clear();
            String product = FormatPurchases("Products");
            String orders = FormatOrders("Orders");
            String purchasers = FormatPurchasersRevenue("Purchasers");
            String revenue = FormatPurchasersRevenue("Revenue");

            Console.WriteLine($"{product}{orders}{purchasers}{revenue}");
            Console.WriteLine($"*************************************************************");
            // Console.WriteLine($"{product1}{orders1}{purchasers1}{revenue1}");
            // Console.WriteLine($"{product2}{orders2}{purchasers2}{revenue2}");
            // Console.WriteLine($"{product3}{orders3}{purchasers3}{revenue3}");
            Console.WriteLine($"*************************************************************");
            // Console.WriteLine($"{productTotal}{ordersTotal}{purchasersTotal}{revenueTotal}");
            Console.WriteLine("Press Any Key To Exit");

            Console.ReadKey();
        }
        //formats any string passed in to be 20 characters long
        //if > 20 adds padding
        //if < 20 chops the excess and adds ... 
        public static string FormatPurchases(String toFormat)
        {
            String formattedString;
            if(toFormat.Length > 17)
            {
                formattedString = toFormat.Remove(16) + "...";
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
        public static string FormatOrders(String toFormat)
        {
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

        public static string FormatPurchasersRevenue(String toFormat)
        {
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