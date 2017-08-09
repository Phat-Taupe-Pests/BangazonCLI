using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

    //Written by: Adam Reidelbach
    namespace BangazonCLI
    {
        // Manages order related methods
        public class OrderManager
        {
        private dbUtilities _db;

        private List<Order> _orderList;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public OrderManager(dbUtilities db)
        {
            _db = db;
        }

        public List<Order> GetCustomerOrders(int customerID)
        {
            List<Order> customerOrders = new List<Order>();
            _db.Query($"SELECT * FROM order WHERE customerID = {customerID}", (SqliteDataReader reader) => {
                customerOrders.Clear();
                while (reader.Read())
                {
                    customerOrders.Add(new Order() {
                        orderID = reader.GetInt32(0),
                        customerID = reader.GetInt32(0),
                        paymentTypeID = reader.GetInt32(0),
                    });
                }
            });
            return customerOrders;
        }

        //Pass in product ID of product to be added to order
        //Customer will always be the active customer
        public int CreateNewOrder(List<int> productID)
        {
            int orderID = _db.Insert($"INSERT INTO `order` values (null, {CustomerManager.currentCustomer.customerID}, null)");
            foreach(int id in productID)
            {
                _db.Insert($"INSERT INTO productOrder values (null, {id}, {orderID})");
            }
            return orderID;
        }

        // Adds a product to the active customer's order
        public int AddProductToOrder(List<int> productID)
        {
            int customerID = CustomerManager.currentCustomer.customerID;
            int orderID;
            _db.Query($"SELECT orderID FROM order WHERE customerID = {customerID} and paymentType = null", (SqliteDataReader reader) => {
                _orderList.Clear();
                while (reader.Read())
                {
                    orderID = reader.GetInt32(0);
                }
            });
            int id = _db.Insert( $"insert into productOrder values (null, '{productID}', {orderID})");
            return id;
        }
    }
}