using System;
using System.Collections.Generic;
using BangazonCLI;
using BangazonCLI.MenuActions;
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
        //Tests that you can get the list current Customer's orders
        [Fact]
        public void GetActiveCustomerOrder()        
        {
            int ProductID = 1;
            _om.CreateNewOrder(ProductID);
            Order customerOrder = _om.GetActiveCustomerOrder(1);
            Assert.IsType<Order>(customerOrder);
        }
        //Tests whether our method gets all closed customer orders.
        [Fact]
         public void GetAllClosedCustomersOrders()
         {
             Customer currentCustomer = new Customer(){customerID = 1};
             CustomerManager.currentCustomer = currentCustomer;
             int ProductID1 = 1;
             int ProductID2 = 2;
             _om.CreateNewOrder(ProductID1);
             _om.CreateNewOrder(ProductID2);
             List<Order> customerOrders = _om.GetAllClosedCustomersOrders(1);
             Assert.IsType<List<Order>>(customerOrders);
          }

        //Tests whether our method creates a new order and saves a product to it.
        [Fact]
        public void CreateNewOrder()
        {
            Customer currentCustomer = new Customer(){customerID = 1};
            CustomerManager.currentCustomer = currentCustomer;
            int ProductID = 1;
            var result = _om.CreateNewOrder(ProductID);
            Assert.IsType<int>(result);
        }
        //Tests whether our method actually completes and order by updating an order with a paymentType
        public void CompleteOrder()
        {
            Customer currentCustomer = new Customer(){customerID = 1};
            CustomerManager.currentCustomer = currentCustomer;
            int ProductID = 1;
            int orderID = _om.CreateNewOrder(ProductID);
            Order updatedOrder = new Order()
            {
                orderID = orderID,
                paymentTypeID = 1,
                customerID = CustomerManager.currentCustomer.customerID,
                dateCreated = DateTime.Today
            };
            var result = _om.CompleteOrder(updatedOrder);
            Assert.IsType<int>(result);
        }

        //Tests whether this method adds a product to an order (productOrder table).
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

            int ProductID = 1;
            _om.CreateNewOrder(ProductID);
            var result = _om.AddProductToOrder(ProductID);
            Assert.IsType<int>(result);
        }
        // Burns the database down because the paint color is wrong.
        public void Dispose()
        {
            _db.Delete("DELETE FROM productOrder");
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM order");
        }
    }
}
