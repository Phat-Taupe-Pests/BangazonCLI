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
        // Creates a customer manager and connection with the database..
        
        public PaymentTypeManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _ptm = new PaymentTypeManager(_db);
            // _db.CheckCustomer();
        }
        // Tests to see if customers are really being added by our methods.
        [Fact]
        public void AddNewPaymentType()
        {
            PaymentType newPaymentType = new PaymentType(){ customerID = 1, accountNumber=12345, name="Visa" };
            
            int paymentTypeID = _ptm.AddNewPaymentType(newPaymentType);

            Assert.True(paymentTypeID !=0);
        }

        // Burns the database down because the paint color is wrong.
            public void Dispose()
        {
            // _db.Delete("DELETE FROM customer");
        }
    }
}