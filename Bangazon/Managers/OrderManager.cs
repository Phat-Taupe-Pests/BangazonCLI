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
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public OrderManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a product to the active customer's order
        public int AddProductToOrder(ProductOrder productOrder){
            int id = _db.Insert( $"insert into productOrder values (null, '{productOrder.productID}', '{productOrder.orderID}')");

            return id;
        }
    }
}