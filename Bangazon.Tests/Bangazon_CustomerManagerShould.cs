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
                newCustomer.streetAddress = "114 Street Place"; 
                newCustomer.state= "Tennesseetopia"; 
                newCustomer.postalCode= 55555; 
                newCustomer.phoneNumber= "555-123-4567"; 
            

            var result = _cm.AddNewCustomer(newCustomer);

            Assert.True(result !=0);
        }
        // Tests to see if our methods are getting a list of customers.
        [Theory]
        [InlineData("Matt", "Augsburger", "1309 60th Ave. N.", "Tenneesee", 37209, "615-497-3139")]
        [InlineData("Chaz", "Henricks", "Somewhere", "Tenneesee", 37209, "555-555-5555")]
        [InlineData("Ben", "Greaves", "Somewhere Else", "Tenneesee", 37209, "666-666-6666")]
        public void ListCustomers(String firstName, String lastName, String streetAddress, String state, int postalCode, String phoneNumber)
        {
            Customer cust = new Customer();
            cust.firstName = firstName;
            cust.lastName = lastName;
            cust.streetAddress = streetAddress;
            cust.state = state;
            cust.postalCode = postalCode;
            cust.phoneNumber = phoneNumber;

            _cm.AddNewCustomer(cust);

            List<Customer> customerList = _cm.GetCustomerList();
            Assert.IsType<List<Customer>>(customerList);
            Assert.True(customerList.Count > 0);
        }

        //Tests to see if we can get a customer's revenue report
        [Fact]
        public void getRevenueReport()
        {
            int customerId = 1;
            RevenueReport revenueReport = _cm.GetRevenueReport(customerId);

            Assert.IsType<RevenueReport>(revenueReport);
        }
        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }
    }
}
