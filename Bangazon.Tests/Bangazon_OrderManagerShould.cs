using System;
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

        [Fact]
        public void GetCustomerOrders()
        {
            
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
