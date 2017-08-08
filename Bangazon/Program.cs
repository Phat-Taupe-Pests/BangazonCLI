using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using BangazonCLI.MenuActions;


namespace BangazonCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seed the database if none exists
            dbUtilities db = new dbUtilities("BANGAZONCLI_DB");
            CustomerManager cm = new CustomerManager(db);
            PaymentTypeManager paytm = new PaymentTypeManager(db);
            db.CheckCustomer();
            db.CheckPaymentType();
            db.CheckOrder();
            db.CheckProductType();
            db.CheckProduct();
            db.CheckProductOrder();
            db.SeedTables();

            MainMenu menu = new MainMenu();

            ProductManager pm = new ProductManager(db);
            ProductTypeManager ptm = new ProductTypeManager(db);



            int choice;

            do
            {
                // Show the Main Menu
                choice = menu.ShowMainMenu();

                switch (choice)
                {
                    case 1:
                        // Displays the Create Customer Menu
                        CreateCustomer.CreateCustomerMenu(cm);
                        break;
                    case 2:
                        ChooseCustomer.ChooseCustomerMenu(cm, db);
                        break;
                    case 3:
                        CreatePayment.CreatePaymentMenu(paytm);
                        break;
                    case 4:
                        AddProductToSell.DoAction(pm, ptm, cm);
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        RemoveProductToSell.RemoveProductToSellMenu(pm, 1);
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                }

            } while(choice != 12);
        }
    }
}
