using System.Collections.Generic;

//Written by: Adam Reidelbach
namespace BangazonCLI
{
    // Manages customer related methods
    public class OrderManager
    {
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public OrderManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new customer--passed in as an argument--to the database
        public int AddProductToOrder(Product product){
            return 5;
        }
    }
}