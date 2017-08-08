using System.Collections.Generic;
//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
namespace BangazonCLI
{
    // Manages PaymentType related methods
    public class PaymentTypeManager
    {
        private dbUtilities _db;
        private CustomerManager _cm;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public PaymentTypeManager(dbUtilities db)
        {
            _cm = new CustomerManager(db);
            _db = db;
        }
        // Adds a new PaymentType--passed in as an argument--to the database
        public int AddNewPaymentType(PaymentType newPaymentType){
            Customer activeCustomer = _cm.GetCurrentCustomer();
            int returnedID = _db.Insert($"insert into paymentType values (null, {activeCustomer.customerID}, {newPaymentType.accountNumber}, '{newPaymentType.name}')");
            return returnedID;
        }
    }
}