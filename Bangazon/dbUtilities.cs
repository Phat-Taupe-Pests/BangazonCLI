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
        // Constructor method sets up the relationship with the database.
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
        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader()) 
                {
                    handler (dataReader);
                }
                _connection.Close ();
            }
        }
        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open ();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery ();
                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );
                _connection.Close ();
            }
            return insertedItemId;
        }
        public void CheckTables ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

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
                            `firstName`	    varchar(80) not null, 
                            `lastName`	    varchar(80) not null, 
                            `streetAddress`	varchar(160) not null, 
                            `state`	        varchar(80) not null, 
                            `postalCode`    integer not null,
                            `phoneNumber`	varchar(20) not null
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
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
                            `PaymentTypeID`	    integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `AccountNumber`	    integer not null,
                            `CustomerID`	    integer not null,
                            `Name`              varchar(80) not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
                dbcmd.CommandText = $"select orderId from `order`";
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
                        dbcmd.CommandText = $@"create table `order` (
                            `orderID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `customerID`	integer not null,
                            `paymentTypeID`	integer not null,
                            FOREIGN KEY(`customerID`) REFERENCES `customer`(`customerID`),
                            FOREIGN KEY(`paymentTypeID`) REFERENCES `paymentType`(`paymentTypeID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
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
                            `ProductTypeID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name`	        varchar(80) not null
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
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
                            `Description`	    varchar(1000) not null, 
                            `ProductTypeID`	    integer not null,
                            `Price`	            double not null,
                            `CustomerID`	    integer not null,
                            `DateCreated`       varchar(80) not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`),
                            FOREIGN KEY(`ProductTypeID`) REFERENCES `ProductType`(`ProductTypeID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
                dbcmd.CommandText = $"select productOrderID from productOrder";
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
                        dbcmd.CommandText = $@"create table productOrder (
                            `ProductOrderID`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `OrderID`	        integer not null,
                            `ProductID`	        integer not null,
                            FOREIGN KEY(`OrderID`) REFERENCES `Order`(`OrderID`),
                            FOREIGN KEY(`ProductID`) REFERENCES `Product`(`ProductID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                dbcmd.Dispose();
                _connection.Close ();
            }
        }
    }
}