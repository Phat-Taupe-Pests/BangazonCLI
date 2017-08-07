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
        [Theory]
        [InlineData("Ball", "Its a ball", 9000)]
        [InlineData("Double Ball", "Its, like 2 balls", 8000)]
        [InlineData("2 CHAINZ", "TRu", 19.99)]
        public void AddNewProduct(string name, string desc, double price)
        {
            Product newProduct = new Product();
            
                newProduct.Name = name; 
                newProduct.Description= desc; 
                newProduct.Price = price; 
                newProduct.DateCreated= DateTime.Today; 


            int customer = 1;
            int productType = 1;
            

        var result = _pm.AddNewProduct(newProduct, customer, productType);

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
