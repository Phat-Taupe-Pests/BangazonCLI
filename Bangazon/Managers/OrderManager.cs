using System.Collections.Generic;

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
        public bool AddProductToOrder(Product product){
            return true;
        }
    }
}