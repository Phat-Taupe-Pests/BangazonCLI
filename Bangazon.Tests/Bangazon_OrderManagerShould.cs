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

        private readonly ProductManager _pm;
        private readonly dbUtilities _db;
        // Creates a order manager and connection with the database..

        public OrderManagerShould()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _om = new OrderManager(_db);
            _pm = new ProductManager(_db);
            _db.CheckOrder();
            _db.CheckProduct();
            _db.CheckProductOrder();
        }

        //Tests that you can get a list of orders from currentCustomer
        [Fact]
        public void GetActiveCustomerOrder()        
        {
            int ProductID = 1;
            _om.CreateNewOrder(ProductID);
            Order customerOrder = _om.GetActiveCustomerOrder(1);
            Assert.IsType<Order>(customerOrder);
        }

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

        //Get the current customer and create a new order
        [Fact]
        public void CreateNewOrder()
        {
            Customer currentCustomer = new Customer(){customerID = 1};
            CustomerManager.currentCustomer = currentCustomer;
            int ProductID = 1;
            var result = _om.CreateNewOrder(ProductID);
            Assert.IsType<int>(result);
        }

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

            int ProductID = 1;
            _om.CreateNewOrder(ProductID);
            var result = _om.AddProductToOrder(ProductID);
            Assert.IsType<int>(result);
        }

        // Checks to see if the GetCompleteOrders method works
        // This method returns a list of RevenueReports
        [Fact]
        public void GetCompletedOrders()
        {
            Customer currentCustomer = new Customer();
            currentCustomer.customerID = 1;
            currentCustomer.firstName = "Brain"; 
            currentCustomer.lastName= "Pinky"; 
            currentCustomer.streetAddress = "114 Street Place"; 
            currentCustomer.state= "Tennesseetopia"; 
            currentCustomer.postalCode= 55555; 
            currentCustomer.phoneNumber= "555-123-4567";
            CustomerManager.currentCustomer = currentCustomer;

            Order newOrder = new Order();
            newOrder.customerID = 1;
            newOrder.dateCreated = DateTime.Now;
            newOrder.paymentTypeID = 1;

            _om.CreateNewOrder(1);
            
            Product product = new Product();
            product.customerID = 2;
            product.dateCreated = DateTime.Now;
            product.description = "Cool as shit";
            product.name = "Ice";
            product.price = 5.99;
            product.productTypeID = 1;
            product.quantity = 1;
            _pm.AddNewProduct(product);

            List<RevenueReport> completedOrders = _om.GetCompletedOrders();

            Assert.IsType<List<RevenueReport>>(completedOrders);

        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM productOrder");
        }
    }
}
