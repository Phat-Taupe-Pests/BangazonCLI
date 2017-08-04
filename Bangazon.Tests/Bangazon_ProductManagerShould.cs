using System;
using System.Collections.Generic;
using Xunit;

namespace BangazonCLI.Tests
{
    // Written by: Chaz Henricks
    // Tests Functionality of Product manager; adds new Product and gets a list of Products.
    public class ProductManagerShould : IDisposable
    {
        private readonly ProductManager _pm;
        private readonly dbUtilities _db;
        // Creates a Product manager and connection with the database..
        
        public ProductManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _pm = new ProductManager(_db);
            _db.CheckProduct();
        }
        // Tests to see if Products are really being added by our methods.
        [Fact]
        public void AddNewProduct()
        {
            Product newProduct = new Product();
            
                newProduct.Name = "Ball"; 
                newProduct.Description= "Its a ball"; 
                newProduct.Price = 9000; 
                newProduct.DateCreated= DateTime.Today; 

            

        var result = _pm.AddNewProduct(newProduct);

            Assert.True(result !=0);
        }
        // Tests to see if our methods are getting a list of Products.
        [Fact]
        public void ListProducts()
        {

            List<Product> ProductList = _pm.GetProductList();

            Product newProduct = new Product();
                newProduct.Name = "Ball"; 
                newProduct.Description= "Its a ball"; 
                newProduct.Price = 9000; 
                newProduct.DateCreated= DateTime.Today; 


            // ProductList.Add(newProduct);
            Assert.IsType<List<Product>>(ProductList);
            // Assert.True(ProductList.Count > 0);
        }
        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            _db.Delete("DELETE FROM Product");
        }
    }
}
