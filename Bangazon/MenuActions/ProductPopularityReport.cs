using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;


namespace  BangazonCLI.MenuActions
{
    public class ProductPopularityReport
    {
        private dbUtilities _db;
        public ProductPopularityReport(dbUtilities db)
        {
            _db = db;
        }
        //writes the popularity report
        public static void ProductPopularityReportMenu()
        {
            Console.Clear();



            String product1 = FormatPurchases("This is a cool CD");
            String product2 = FormatPurchases("Bananas");
            String product3 = FormatPurchases("Im not sure what this is but its over 20 characters");

            String orders1 = FormatOrders(23);
            String orders2 = FormatOrders(500);
            String orders3 = FormatOrders(3000);

            String purchasers1 = FormatPurchasers(30);
            String purchasers2 = FormatPurchasers(30);
            String purchasers3 = FormatPurchasers(30);


            String revenue1 = FormatRevenue(23, 30);
            String revenue2 = FormatRevenue(500, 30);
            String revenue3 = FormatRevenue(3000, 30);

            String ordersTotal = FormatOrders((23 + 500 + 3000));
            String purchasersTotal = FormatPurchasers((30 + 30 + 30));
            String revenueTotal = FormatPurchasers((Int32.Parse(revenue1) +Int32.Parse(revenue2) + Int32.Parse(revenue3)));



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
        public static string FormatRevenue(int orders, int purchasers)
        {
            int revenue = orders * purchasers;
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