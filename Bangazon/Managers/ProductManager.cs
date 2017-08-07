using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
//Written by:Chaz Henricks
namespace BangazonCLI
{
    // Manages Product related methods
    public class ProductManager
    {
        private List<Product> _products = new List<Product>();
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public ProductManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new Product--passed in as an argument--to the database
        public int AddNewProduct(Product newProduct, int customer, int productType){
             int id = _db.Insert( $"insert into Product values (null, '{newProduct.Name}', '{newProduct.Description}', '{newProduct.Price}', '{newProduct.DateCreated}', '{customer}', '{productType}')");

            _products.Add(
                new Product()
                {
                    ProductID = id,
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    Price = newProduct.Price,
                    DateCreated = newProduct.DateCreated,
                    CustomerID = customer,
                    ProductTypeID = productType,

                }
            );

            return id;     
       
        }
        // Gets a list of Products.
        public List<Product> GetProductList()
        {
            
            return new List<Product>();
        }
    }
}