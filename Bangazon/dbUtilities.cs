using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BangazonCLI
{
    // Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
    public class dbUtilities
    {
        private string _connectionString;
        private SqliteConnection _connection;
        // Constructor methodm sets up the database. "Constructors the database"
        public dbUtilities(string database)
        {
            string env = $"{Environment.GetEnvironmentVariable(database)}";
            _connectionString = $"Data Source={env}";
            _connection = new SqliteConnection(_connectionString);
        }
        // Deletes things from the database based upon the command passed in as an argument.
        public void Delete(string command)
        {
            using(_connection)
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
        // Checks to see if a customer table exists, if it doesn't it creates the table in the database.
        public void CheckCustomer ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the customer table to see if table is created
                dbcmd.CommandText = $"select customerID from customer";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table customer (
                            `customerID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `firstName`	varchar(80) not null, 
                            `lastName`	varchar(80) not null, 
                            `streetAddress`	varchar(160) not null, 
                            `state`	varchar(80) not null, 
                            `postalCode` integer not null,
                            `phoneNumber`	varchar(20) not null
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }
        // Checks to see if a product type table exists, if it doesn't it creates the table in the database.
        public void CheckProductType ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the productType table to see if table is created
                dbcmd.CommandText = $"select productTypeID from productType";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table productType (
                            `productTypeID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name`	varchar(80) not null
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }
        //Written By Chaz Henricks
        //DB checks if a Product Table exists
        public void CheckProduct ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the product table to see if table is created
                dbcmd.CommandText = $"select productID from product";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table product (
                            `ProductID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name`	varchar(80) not null, 
                            `Description`	varchar(1000) not null, 
                            `ProductTypeID`	integer not null,
                            `Price`	double not null,
                            `CustomerID`	integer not null,
                            `DateCreated`   varchar(80) not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`),
                            FOREIGN KEY(`ProductTypeID`) REFERENCES `ProductType`(`ProductTypeID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }

                // Checks to see if a customer table exists, if it doesn't it creates the table in the database.
        public void CheckOrder ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the order table to see if table is created
                dbcmd.CommandText = $"select orderId from order";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        //double check syntax for all of the command below
                        dbcmd.CommandText = $@"create table customer (
                            `orderID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            FOREIGN KEY(`customerID`) REFERENCES `customer`(`id`),
                            FOREIGN KEY(`paymentTypeID`) REFERENCES `paymentType`(`id`),
                            FOREIGN KEY(`productID`) REFERENCES `productOrder`(`id`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }
        // Checks to see if PaymentType exists, if it doesn't it creates the table.
        public void CheckPaymentType ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the product table to see if table is created
                dbcmd.CommandText = $"select paymentTypeID from paymentType";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader())
                    {
                        
                    }
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"create table paymentType (
                            `PaymentTypeID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `AccountNumber`	integer not null,
                            `CustomerID`	integer not null,
                            `Name`   varchar(80) not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }


        
        
    }
}