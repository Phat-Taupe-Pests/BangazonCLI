using System;
using System.Collections.Generic;
using Xunit;

namespace BangazonCLI.Tests
{
    // Written by: Eliza Meeks
    // Tests Functionality of payment type manager.
    public class PaymentTypeManagerShould : IDisposable
    {
        private readonly PaymentTypeManager _ptm;
        private readonly dbUtilities _db;

        // Customer Manager is initialized to proide a current customer when needed2
        private readonly CustomerManager _cm;
        // Creates a payment type manager and connection with the database..
        public PaymentTypeManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _ptm = new PaymentTypeManager(_db);
            _db.CheckPaymentType();
            _cm = new CustomerManager(_db);
        }
        // Tests to see if payment types are really being added by our methods.
        [Fact]
        public void AddNewPaymentType()
        {
            // Sets the current customer so a payment type can be added
            Customer _currentCustomer = new Customer();
            _currentCustomer.customerID = 1;
            _currentCustomer.firstName = "Brain"; 
            _currentCustomer.lastName= "Pinky"; 
            _currentCustomer.streetAddress = "114 Street Place"; 
            _currentCustomer.state= "Tennesseetopia"; 
            _currentCustomer.postalCode= 55555; 
            _currentCustomer.phoneNumber= "555-123-4567";
            CustomerManager.currentCustomer = _currentCustomer;
            
            PaymentType newPaymentType = new PaymentType(){ accountNumber= 12345, name="Visa" };
            
            int paymentTypeID = _ptm.AddNewPaymentType(newPaymentType);

            Assert.True(paymentTypeID !=0);
        }
        // Tests to see if this method returns a customer's saved payment types.
        public void GetCustomersPaymentTypes()
        {
            Customer _currentCustomer = new Customer();
            _currentCustomer.customerID = 1;
            CustomerManager.currentCustomer = _currentCustomer;
            var result = _ptm.GetCustomersPaymentTypes(CustomerManager.currentCustomer.customerID);
            Assert.IsType<List<PaymentType>>(result);
        }
        // Burns the database down because the paint color is wrong (resets the test database).
            public void Dispose()
        {
            _db.Delete("DELETE FROM paymentType");
        }
    }
}
