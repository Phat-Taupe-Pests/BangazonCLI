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
        // Constructor method sets up the database. "Constructors the database"
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
        // Updates an item in database based upon the command passed in as an argument.
        public void Update(string command)
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
        // Executes a query using the SQL command provided. Processes the data using the handler provided.
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
        // Inserts a line item using the SQL command provided. Returns the ID of the inserted item.
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
        // Written By Chaz Henricks
        // Checks to see if a product table exists, if it doesn't it creates the table in the database.
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
                            `Price`	double not null,
                            `DateCreated`   varchar(80) not null,
                            `Quantity`      integer not null,
                            `CustomerID`	integer not null,
                            `ProductTypeID`	integer not null,
                            FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`CustomerID`),
                            FOREIGN KEY(`ProductTypeID`) REFERENCES `ProductType`(`ProductTypeID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }
        // Written By Eliza Meeks
        // Checks to see if a productType table exists, if it doesn't it creates the table in the database.
        public void CheckProductType ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the product table to see if table is created
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
                            `Name`	varchar(80) not null
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }

        // Checks to see if a productOrder table exists, if it doesn't it creates the table in the database.
        public void CheckProductOrder ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the product table to see if table is created
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
                            `ProductOrderID`	integer PRIMARY KEY AUTOINCREMENT,
                            `OrderID`	integer not null,
                            `ProductID`	integer not null,
                            FOREIGN KEY(`OrderID`) REFERENCES `Order`(`OrderID`),
                            FOREIGN KEY(`ProductID`) REFERENCES `Product`(`ProductID`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }
        }  

        // Checks to see if a order table exists, if it doesn't it creates the table in the database.
        public void CheckOrder ()
        {
            using (_connection)
            // putting sqliteCommand in a using statement removes need to do a .Dispose throughout
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();

                // Query the order table to see if table is created
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
                            `orderID`	integer PRIMARY KEY AUTOINCREMENT,
                            `customerID`	integer not null,
                            `paymentTypeID`	integer,
                            'DateCreated' varchar(80) not null,
                            FOREIGN KEY(`customerID`) REFERENCES `customer`(`id`),
                            FOREIGN KEY(`paymentTypeID`) REFERENCES `paymentType`(`id`)
                        )";
                        dbcmd.ExecuteNonQuery ();
                    }
                }
                _connection.Close ();
            }

        }

        // Checks to see if a paymentType table exists, if it doesn't it creates the table in the database.
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

        // Seeds the DB every time the the program is run.
        // Executes an external file.
        public void SeedTables()
        {
            string seedText = File.ReadAllText("./dbSeed.sqlite.sql"); // .sql file path
            using (_connection)
            using (SqliteCommand dbcmd = _connection.CreateCommand ())
            {
                _connection.Open();
                    dbcmd.CommandText = seedText;
                    dbcmd.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}