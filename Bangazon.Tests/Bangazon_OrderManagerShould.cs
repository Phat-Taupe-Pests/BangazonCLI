using System;
using System.Collections.Generic;
using BangazonCLI;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderManagerShould : IDisposable
    {

        private readonly OrderManager _om;
        private readonly dbUtilities _db;
        // Creates a order manager and connection with the database..

        public OrderManagerShould()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _om = new OrderManager(_db);
            _db.CheckOrder();
            _db.CheckProduct();
            _db.CheckProductOrder();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCustomerOrders(int customerID)
        {
            List<Order> customerOrders = _om.GetCustomerOrders(customerID);
            Assert.IsType<List<Order>>(customerOrders);
        }

        [Theory]
        [InlineData(1)]
        public void CreateNewOrder(int productID)
        {
            var result = _om.CreateNewOrder(productID);
            Assert.IsType<int>(result);
        }

        [Fact]
        public void AddProductToOrder()
        {
            ProductOrder newProductOrder = new ProductOrder(){orderID = 1, productID = 2};
            var result = _om.AddProductToOrder(newProductOrder);
            Assert.IsType<int>(result);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM productOrder");
        }
    }
}
