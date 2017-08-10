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
            OrderManager om = new OrderManager(db);



            int choice;
            //Shows the main menu until the user types 12 (exit)
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
                        if (CustomerManager.currentCustomer == null)
                        {
                            ChooseCustomer.ChooseCustomerMenu(cm, db);
                        }
                        CreatePayment.CreatePaymentMenu(paytm);
                        break;
                    case 4:
                        if (CustomerManager.currentCustomer == null)
                        {
                            ChooseCustomer.ChooseCustomerMenu(cm, db);
                        }
                        AddProductToSell.DoAction(pm, ptm);
                        break;
                    case 5:
                    if (CustomerManager.currentCustomer == null)
                        {
                            ChooseCustomer.ChooseCustomerMenu(cm, db);
                        }
                        AddProductOrder.AddProductToOrder(cm, db, pm, om);
                        break;
                    case 6:
                         if (CustomerManager.currentCustomer == null)
                            {
                                ChooseCustomer.ChooseCustomerMenu(cm, db);  
                            }
                        CompleteOrder.CompleteOrderMenu(om, pm, paytm);
                        break;
                    case 7:
                        if (CustomerManager.currentCustomer == null)
                        {
                            ChooseCustomer.ChooseCustomerMenu(cm, db);
                        }
                        RemoveProductToSell.RemoveProductToSellMenu(pm);
                        break;
                    case 8:
                        if (CustomerManager.currentCustomer == null)
                        {
                            ChooseCustomer.ChooseCustomerMenu(cm, db);
                        }
                        UpdateProduct.UpdateProductMenu(pm);
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
