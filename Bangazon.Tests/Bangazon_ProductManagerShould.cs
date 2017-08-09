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

        private readonly OrderManager _om;

        private readonly dbUtilities _db;
        // Creates a Product manager and connection with the database..
        
        public ProductManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _pm = new ProductManager(_db);
            _om = new OrderManager(_db);
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
            
                newProduct.name = name; 
                newProduct.description= desc; 
                newProduct.price = price; 
                newProduct.dateCreated= DateTime.Today;
                newProduct.quantity = 1;
                newProduct.customerID = 1;
                newProduct.productTypeID = 1;

            var result = _pm.AddNewProduct(newProduct);

            Assert.True(result !=0);
        }
        [Theory]
        [InlineData("Ball", "Its a ball", 9000)]
        [InlineData("Double Ball", "Its, like 2 balls", 8000)]
        [InlineData("2 CHAINZ", "TRu", 19.99)]
        //this test will add 3 products to the products table and then return a list of all the products added. 
        //Takes a name, description and a price as arguments
        public void ListProducts(string name, string desc, double price)
        {
            // builds a new product to add
            Product newProduct = new Product();
                newProduct.name = name; 
                newProduct.description = desc; 
                newProduct.price = price; 
                newProduct.dateCreated = DateTime.Today;
                newProduct.quantity = 1;
                newProduct.customerID = 1;
                newProduct.productTypeID = 1;

            _pm.AddNewProduct(newProduct);

            List<Product> ProductList = _pm.GetProductList(1);
            foreach(Product product in ProductList)
            {
                Console.WriteLine($"{product.dateCreated}");
            }
            Assert.IsType<List<Product>>(ProductList);
            Assert.True(ProductList.Count > 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void getProductsOnOrder(int orderID)
        {
            _om.CreateNewOrder(1);
            var result = _pm.GetProductsOnOrder(1);
            Assert.IsType<List<Product>>(result);
        }
        [Theory]
        [InlineData("Ball", "Its a ball", 9000)]
        [InlineData("Double Ball", "Its, like 2 balls", 8000)]
        [InlineData("2 CHAINZ", "TRu", 19.99)]
        public void RemoveAProductFromListOfCustomerProducts(string name, string desc, double price)
        {
            Product newProduct = new Product();
                newProduct.name = name; 
                newProduct.description= desc; 
                newProduct.price = price; 
                newProduct.dateCreated= DateTime.Today;
                newProduct.customerID = 1;
                newProduct.productTypeID = 1;
            _pm.AddNewProduct(newProduct);
            _pm.RemoveProductToSell(1);

            List<Product> ProductList =  _pm.GetProductList(1);
            List<int> ProductIdList = new List<int>();

            foreach(Product item in ProductList)
            {
                ProductIdList.Add(item.productID);
            }
        
            Assert.DoesNotContain(1, ProductIdList);
        }

        public void GetSingleProduct(int productID)
        {
            Product dummyProduct = new Product()
            {
                name = "Dummy"
            };
            _pm.AddNewProduct(dummyProduct);
            var result = _pm.GetSingleProduct(1);
            Assert(IsType<Product>(result));
        }
        
        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            _db.Delete("DELETE FROM Product");
        }
    }
}
