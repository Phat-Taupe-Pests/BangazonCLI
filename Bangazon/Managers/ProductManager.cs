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
        // Adds a new Product--passed in as an argument--to the database. Returns the product's productID.
        public int AddNewProduct(Product newProduct){
            int id = _db.Insert( $"insert into Product values (null, '{newProduct.name}', '{newProduct.description}', '{newProduct.price}', '{newProduct.dateCreated}', '{newProduct.quantity}', '{newProduct.customerID}', '{newProduct.productTypeID}')");
            return id;     
        }
        // Gets a list of Products. Take a customerID. Returns a list of products.
        public List<Product> GetProductList(int custID)
        {
                 _db.Query($"SELECT * FROM Product WHERE CustomerID = {custID};",
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
                            quantity = reader.GetInt32(5),
                            customerID = reader.GetInt32(6),
                            productTypeID = reader.GetInt32(7)
                        });
                    }
                }
            );
            return _products;
        }

        //Gets all products on an order. Takes an orderID and returns a list of products.
        public List <Product> GetProductsOnOrder (int orderID)         {
            List<Product> ordersProducts = new List<Product>();
            List<ProductOrder> lineItems = new List<ProductOrder>();
            _db.Query($"SELECT * FROM ProductOrder WHERE orderID = {orderID};",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        lineItems.Add(new ProductOrder(){
                            productOrderID = reader.GetInt32(0),
                            orderID = reader.GetInt32(1),
                            productID = reader.GetInt32(2),
                        });
                    }
                }
            );
            foreach(ProductOrder item in lineItems)
            {
                Product thisProduct = GetSingleProduct(item.productID);
                ordersProducts.Add(thisProduct);
            }
            return ordersProducts;
        }
        //Gets a single product. Takes a productID and returns a Product
        public Product GetSingleProduct(int productID)
        {
            Product finalProduct = new Product();
            _db.Query($"SELECT * FROM Product WHERE productID = {productID};",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                            finalProduct.productID = reader.GetInt32(0);
                            finalProduct.name = reader[1].ToString();
                            finalProduct.description = reader[2].ToString();
                            finalProduct.price = reader.GetDouble(3);
                            finalProduct.dateCreated = reader.GetDateTime(4);
                            finalProduct.quantity = reader.GetInt32(5);
                            finalProduct.customerID = reader.GetInt32(6);
                            finalProduct.productTypeID = reader.GetInt32(7);
                    }
                }
            );
            return finalProduct;
        }
        //Removes an item from the database based on the productID passed as an argument. 
        public void RemoveProductToSell(int prodID)
        {
            _db.Delete($"DELETE FROM Product WHERE ProductID = {prodID};");
        }
        //Updates a product detail, taking a SQL string and returning nothing.
        public void UpdateProduct(String updateString)
        {
            _db.Update(updateString);
        }
    }
}