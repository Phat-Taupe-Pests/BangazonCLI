using System;
using System.Collections.Generic;
using Xunit;

namespace BangazonCLI.Tests
{
    // Written by: Chaz Henricks, Ben Greaves, Matt Augsburger, Eliza Meeks, Adam Reidelbach
    // Tests Functionality of customer manager; adds new customer and gets a list of customers.
    public class ProductTypeManagerShould : IDisposable
    {
        private readonly ProductTypeManager _ptm;
        private readonly dbUtilities _db;
        // Creates a ProductType manager and connection with the database..
        
        public ProductTypeManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _ptm = new ProductTypeManager(_db);
            // _db.CheckProductType();
        }
        // Tests to see if our methods are getting a list of ProductTypes.
        [Fact]
        public void GetProductTypeList()
        {

            List<ProductType> productTypeList = _ptm.GetProductTypeList();
            Assert.IsType<List<ProductType>>(productTypeList);
            Assert.True(productTypeList.Count > 0);
        }
        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            // _db.Delete("DELETE FROM customer");
        }
    }
}
