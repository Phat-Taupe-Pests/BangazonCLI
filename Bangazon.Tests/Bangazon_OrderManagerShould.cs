using System;
using BangazonCLI;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderManagerShould
    {

        private readonly OrderManager _om;
        private readonly dbUtilities _db;
        // Creates a order manager and connection with the database..

        public OrderManagerShould()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _om = new OrderManager(_db);
            _db.CheckOrder();
        }

        [Fact]
        public void AddProductToOrder()
        {
            Product basketball = new Product();
            var result = _om.AddProductToOrder(basketball);
            Assert.True(result);
        }

        // [Fact]
        // public void CreateNewOrder()
        // {
        //     Product kite = new Product();
        //     _manager.CreateOrder(kite);
        // }

        // [Fact]
        // public void ListOrders()
        // {

        // }

        // [Fact]
        // public void AddPaymentTypeToOrder()
        // {

        // }
    }
}
