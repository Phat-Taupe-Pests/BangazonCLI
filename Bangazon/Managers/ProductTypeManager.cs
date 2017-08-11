using System.Collections.Generic;
using Microsoft.Data.Sqlite;
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
            _db.Query("SELECT * FROM ProductType;", 
                (SqliteDataReader reader) => {
                    while (reader.Read())
                    {
                        productTypeList.Add(new ProductType() {
                            productTypeID = reader.GetInt32(0),
                            name = reader[1].ToString()
                        });
                    }
                });
            return productTypeList;
        }
    }
}