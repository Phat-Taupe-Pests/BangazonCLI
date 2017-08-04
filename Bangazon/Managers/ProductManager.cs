using System.Collections.Generic;
//Written by:Chaz Henricks
namespace BangazonCLI
{
    // Manages Product related methods
    public class ProductManager
    {
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public ProductManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new Product--passed in as an argument--to the database
        public int AddNewProduct(Product newProduct){
            return 4;
        }
        // Gets a list of Products.
        public List<Product> GetProductList()
        {
            
            return new List<Product>();
        }
    }
}