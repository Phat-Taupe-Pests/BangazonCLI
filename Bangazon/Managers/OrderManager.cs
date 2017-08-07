using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

//Written by: Adam Reidelbach
namespace BangazonCLI
{
    // Manages order related methods
    public class OrderManager
    {
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public OrderManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a product to the active customer's order
        public int AddProductToOrder(Product product){

            int _lastId = 0; // Will store the id of the last inserted record
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand();

                dbcmd.CommandText = ($"insert into ToyBag values (null, '{toyName}', {childId})");
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery();

                // Get the id of the new row
                dbcmd.CommandText = $"select last_insert_rowid()";
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    if (dr.Read()) {
                        _lastId = dr.GetInt32(0);
                    } else {
                        throw new Exception("Unable to insert value");
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _lastId;
        }
    }
}