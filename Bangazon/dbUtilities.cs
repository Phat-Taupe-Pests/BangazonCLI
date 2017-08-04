using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BangazonCLI
{
    public class dbUtilities
    {
        private string _connectionString;
        private SqliteConnection _connection;

        public dbUtilities(string database)
        {
            string env = $"{Environment.GetEnvironmentVariable(database)}";
            _connectionString = $"Data Source={env}";
            _connection = new SqliteConnection(_connectionString);
        }

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


        
        
    }
}