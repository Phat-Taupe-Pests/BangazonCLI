using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

    //Written by: Adam Reidelbach, Matt Augsburger
    namespace BangazonCLI
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
        public Order GetActiveCustomerOrder(int customerID)
        {
            Order customerOrder = new Order();
            _db.Query($"SELECT * FROM `order` WHERE customerID = {customerID} AND paymenttypeID IS null", (SqliteDataReader reader) => {
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

        public List <Order> GetAllClosedCustomersOrders(int customerID)
        {
            List <Order> customersOrders = new List <Order>();
            _db.Query($"SELECT * FROM `order` WHERE customerID = {customerID} AND paymenttypeID IS NOT null", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    customersOrders.Add(new Order(){
                        orderID = reader.GetInt32(0),
                        customerID = reader.GetInt32(1),
                        paymentTypeID = reader[2] as int? ?? null,
                        dateCreated = reader.GetDateTime(3)
                    });
                }
            });
            return customersOrders;
        }

        public int CompleteOrder(Order order)
        {
             _db.Insert($"UPDATE `order` SET paymentTypeID = {order.paymentTypeID} WHERE orderID = {order.orderID}");
            return order.orderID;
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

        // Gets stale products. Written by Eliza Meeks and Chaz Henricks.
        public List<Product> getStaleProducts()
        {
            int customerID = CustomerManager.currentCustomer.customerID;
            List<Product> staleProducts = new List<Product>();
            _db.Query($"SELECT p.* FROM Product p INNER JOIN ProductOrder po On p.ProductID = po.ProductID INNER JOIN `Order` o ON po.OrderID = o.OrderID WHERE p.customerID = {customerID} AND o.PaymentTypeID IS NOT NULL AND p.Quantity != 0 AND p.DateCreated < date('now','-180 days') UNION SELECT p.* FROM Product p, `Order` o INNER JOIN ProductOrder po ON p.productID = po.productID WHERE p.customerID = {customerID} AND o.paymentTypeID IS NULL AND o.DateCreated <= date('now', '-90 days') UNION SELECT p.* FROM Product p LEFT JOIN ProductOrder po ON p.ProductID = po.ProductID WHERE p.customerID = {customerID} AND po.ProductID IS NULL AND p.DateCreated <= date('now','-180 days') GROUP BY p.Name;", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    staleProducts.Add(new Product(){
                        productID = reader.GetInt32(0),
                        name = reader[1].ToString(),
                        description = reader[2].ToString(),
                        price =  reader.GetDouble(3),
                        dateCreated = reader.GetDateTime(4),
                        quantity = reader.GetInt32(5),
                        customerID = reader.GetInt32(6),
                        productTypeID = reader.GetInt32(7)
                    });
                }
            });
            return staleProducts;
        }
    }
}