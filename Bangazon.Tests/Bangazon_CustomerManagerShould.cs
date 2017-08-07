using System;
using System.Collections.Generic;
using Xunit;

namespace BangazonCLI.Tests
{
    // Written by: Chaz Henricks, Ben Greaves, Matt Augsburger, Eliza Meeks, Adam Reidelbach
    // Tests Functionality of customer manager; adds new customer and gets a list of customers.
    public class CustomerManagerShould : IDisposable
    {
        private readonly CustomerManager _cm;
        private readonly dbUtilities _db;
        // Creates a customer manager and connection with the database..
        
        public CustomerManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _cm = new CustomerManager(_db);
            _db.CheckCustomer();
        }
        // Tests to see if customers are really being added by our methods.
        [Fact]
        public void AddNewCustomer()
        {
            Customer newCustomer = new Customer();
            
                newCustomer.firstName = "Brain"; 
                newCustomer.lastName= "Pinky"; 
                newCustomer.streetAddress = "112 Street Place"; 
                newCustomer.state= "Tennesseetopia"; 
                newCustomer.postalCode= 55555; 
                newCustomer.phoneNumber= "555-123-4567"; 
            

            var result = _cm.AddNewCustomer(newCustomer);

            Assert.True(result !=0);
        }
        // Tests to see if our methods are getting a list of customers.
        [Fact]
        public void ListCustomers()
        {

            List<Customer> customerList = _cm.GetCustomerList();
            customerList.Add(new Customer(){firstName="Brain", lastName="Pinky", streetAddress="114 Street Place", state= "Tennesseetopia", postalCode= 55555, phoneNumber= "555-123-4567"});
            Assert.IsType<List<Customer>>(customerList);
            Assert.True(customerList.Count > 0);
        }
        // Tests to see if the method sets the Current Customer - Matt Augsburger
        [Fact]
        public void SetCurrentCustomer()
        {
            _cm.SetCurrentCustomer(new Customer(){firstName="Brain", lastName="Pinky", streetAddress="114 Street Place", state= "Tennesseetopia", postalCode= 55555, phoneNumber= "555-123-4567"});
            Customer currentCustomer = _cm.GetCurrentCustomer();
            Assert.IsType<Customer>(currentCustomer);
        }
        // Tests to see if the method returns the current customer - Matt Augsburger
        [Fact]
        public void GetCurrentCustomer()
        {
            _cm.SetCurrentCustomer(new Customer(){firstName="Brain", lastName="Pinky", streetAddress="114 Street Place", state= "Tennesseetopia", postalCode= 55555, phoneNumber= "555-123-4567"});
            Customer currentCustomer = _cm.GetCurrentCustomer();
            Assert.IsType<Customer>(currentCustomer);

        }
        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }
    }
}
