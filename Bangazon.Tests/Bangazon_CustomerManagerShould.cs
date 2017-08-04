using System;
using System.Collections.Generic;
using Xunit;

namespace BangazonCLI.Tests
{
    public class CustomerManagerShould : IDisposable
    {
        private readonly CustomerManager _cm;
        private readonly dbUtilities _db;
        
        public CustomerManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _cm = new CustomerManager(_db);
            _db.CheckCustomer();
        }
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

        [Fact]
        public void ListCustomers()
        {

            List<Customer> customerList = _cm.GetCustomerList();
            customerList.Add(new Customer(){firstName="Brain", lastName="Pinky", streetAddress="114 Street Place", state= "Tennesseetopia", postalCode= 55555, phoneNumber= "555-123-4567"});
            Assert.IsType<List<Customer>>(customerList);
            Assert.True(customerList.Count > 0);
        }
            public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }
    }
}
