using System.Collections.Generic;
//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
namespace BangazonCLI
{
    // Manages customer related methods
    public class ProductTypeManager
    {
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public ProductTypeManager(dbUtilities db)
        {
            _db = db;
        }

        // Gets a list of ProductTypes.
        public List<ProductType> GetProductTypeList()
        {
            List<ProductType> productTypeList = new List<ProductType>();
            productTypeList.Add(new ProductType(){name = "food"});
            productTypeList.Add(new ProductType(){name = "cars"});
            productTypeList.Add(new ProductType(){name = "stuffed animals"});
            productTypeList.Add(new ProductType(){name = "dolls"});
            productTypeList.Add(new ProductType(){name = "media"});
            return productTypeList;
        }
    }
}