using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

    //Written by: Adam Reidelbach, Matt Augsburger
    namespace BangazonCLI.MenuActions
    {
        // Manages order related methods
        public class OrderManager
        {
        private dbUtilities _db;

        private int _orderID;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public OrderManager(dbUtilities db)
        {
            _db = db;
        }

        //Passing in the currentCustomerID, returns the currentCustomer order (object) 
        public Order GetCustomerOrder(int customerID)
        {
            Order customerOrder = new Order();
            _db.Query($"SELECT * FROM `order` WHERE customerID = {customerID}", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    customerOrder.orderID = reader.GetInt32(0);
                    customerOrder.customerID = reader.GetInt32(1);
                    customerOrder.paymentTypeID = reader[2] as int? ?? null;
                    customerOrder.dateCreated = reader.GetDateTime(3);
                }
            });
            return customerOrder;
        }

        //Pass in product IDs of products to be added an order
        public int CreateNewOrder(int productID)
        {
            int orderID = _db.Insert($"INSERT INTO `order` values (null, {CustomerManager.currentCustomer.customerID}, null, '{DateTime.Now}')");
            _db.Insert($"INSERT INTO productOrder values (null, {productID}, {orderID})");
            return orderID;
        }

        // Adds a product to the active customer's order
        public int AddProductToOrder(int productID)
        {
            int customerID = CustomerManager.currentCustomer.customerID;
            _db.Query($"SELECT orderID FROM `order` WHERE customerID = {customerID} and paymentTypeID = null", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    _orderID = reader.GetInt32(0);
                }
            });
            _db.Insert( $"insert into productOrder values (null, {productID}, {_orderID})");
            return _orderID;
        }
        
        //Gets/Returns a List of revenueReports from the currentCustomer
        public List<RevenueReport> GetCompletedOrders()
        {
            List<RevenueReport> revenueReports = new List<RevenueReport>();
            int customerID = CustomerManager.currentCustomer.customerID;
            _db.Query($"SELECT p.name, p.price, COUNT(po.productOrderID), o.orderID  FROM product p, productOrder po, `order` o WHERE p.customerID = {customerID} AND p.productID = po.productID AND po.orderID = o.orderID GROUP BY o.orderID",
            (SqliteDataReader reader) => {
                while(reader.Read())
                {
                    revenueReports.Add(new RevenueReport() {
                        name = reader[0].ToString(),
                        price = reader.GetDouble(1),
                        quantity = reader.GetInt32(2),
                        orderID = reader.GetInt32(3)
                    });
                }
            });

            return revenueReports;
        }
    }
}