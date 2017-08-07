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
        // Creates a payment type manager and connection with the database..
        
        public PaymentTypeManagerShould ()
        {
            _db = new dbUtilities("BANGAZONCLI_TEST_DB");
            _ptm = new PaymentTypeManager(_db);
            _db.CheckPaymentType();
        }
        // Tests to see if payment types are really being added by our methods.
        [Fact]
        public void AddNewPaymentType()
        {
            int newAccountNumber =  12345;
            string newAccountName="Visa";
            
            int paymentTypeID = _ptm.AddNewPaymentType(newAccountNumber, newAccountName);

            Assert.True(paymentTypeID !=0);
        }

        // Burns the database down because the paint color is wrong (resets the test database).
            public void Dispose()
        {
            _db.Delete("DELETE FROM paymentType");
        }
    }
}
