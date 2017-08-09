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

        //Tests that you can get a list of orders from currentCustomer
        [Fact]
        public void GetCustomerOrder()
        {
            Customer _currentCustomer = new Customer();
            _currentCustomer.customerID = 1;
            _currentCustomer.firstName = "Brain"; 
            _currentCustomer.lastName= "Pinky"; 
            _currentCustomer.streetAddress = "114 Street Place"; 
            _currentCustomer.state= "Tennesseetopia"; 
            _currentCustomer.postalCode= 55555; 
            _currentCustomer.phoneNumber= "555-123-4567";
            CustomerManager.currentCustomer = _currentCustomer;

            List<int> ProductID = new List<int>();
            ProductID.Add(1);
            ProductID.Add(2);
            _om.CreateNewOrder(ProductID);
            List<Order> customerOrders = _om.GetCustomerOrder(_currentCustomer.customerID);
            Assert.IsType<List<Order>>(customerOrders);
        }

        //Get the current customer and create a new order
        [Fact]
        public void CreateNewOrder()
        {
            Customer _currentCustomer = new Customer();
            _currentCustomer.customerID = 1;
            _currentCustomer.firstName = "Brain"; 
            _currentCustomer.lastName= "Pinky"; 
            _currentCustomer.streetAddress = "114 Street Place"; 
            _currentCustomer.state= "Tennesseetopia"; 
            _currentCustomer.postalCode= 55555; 
            _currentCustomer.phoneNumber= "555-123-4567";
            CustomerManager.currentCustomer = _currentCustomer;

            List<int> ProductID = new List<int>();
            ProductID.Add(1);
            ProductID.Add(2);
            var result = _om.CreateNewOrder(ProductID);
            Assert.IsType<int>(result);
        }

        //Find an open order for current customer and add products to that order
        [Fact]
        public void AddProductToOrder()
        {
            Customer _currentCustomer = new Customer();
            _currentCustomer.customerID = 1;
            _currentCustomer.firstName = "Brain"; 
            _currentCustomer.lastName= "Pinky"; 
            _currentCustomer.streetAddress = "114 Street Place"; 
            _currentCustomer.state= "Tennesseetopia"; 
            _currentCustomer.postalCode= 55555; 
            _currentCustomer.phoneNumber= "555-123-4567";
            CustomerManager.currentCustomer = _currentCustomer;

            List<int> ProductID = new List<int>();
            ProductID.Add(1);
            ProductID.Add(2);
            _om.CreateNewOrder(ProductID);
            var result = _om.AddProductToOrder(ProductID);
            Assert.IsType<int>(result);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM productOrder");
        }
    }
}
