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
             int id = _db.Insert( $"insert into Product values (null, '{newProduct.name}', '{newProduct.description}', '{newProduct.price}', '{newProduct.dateCreated}', '{customer}', '{productType}')");

            _products.Add(
                new Product()
                {
                    productID = id,
                    name = newProduct.name,
                    description = newProduct.description,
                    price = newProduct.price,
                    dateCreated = newProduct.dateCreated,
                    customerID = customer,
                    productTypeID = productType,

                }
            );

            return id;     
       
        }
        // Gets a list of Products.
        public List<Product> GetProductList()
        {
            
             _db.Query("select * from Product;",
                (SqliteDataReader reader) => {
                    _products.Clear();  
                    while (reader.Read ())
                    {
                        _products.Add(new Product(){
                            productID = reader.GetInt32(0),
                            name = reader[1].ToString(),
                            description = reader[2].ToString(),
                            price = reader.GetDouble(3),
                            dateCreated = reader.GetDateTime(4),
                            customerID = reader.GetInt32(5),
                            productTypeID = reader.GetInt32(6)
                        });
                    }
                }
            );

            return _products;

        }

        public Product GetProduct(int id)
        {
        Product returnProduct = new Product();
         foreach(Product item in _products)
         {
             if(item.productID == id)
             {
                 returnProduct = item;
             }
         }
        return returnProduct;
        }
            
    }
}