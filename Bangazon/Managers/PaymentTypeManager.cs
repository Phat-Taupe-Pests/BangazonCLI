using System.Collections.Generic;
//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
namespace BangazonCLI
{
    // Manages PaymentType related methods
    public class PaymentTypeManager
    {
        private dbUtilities _db;
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public PaymentTypeManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new PaymentType--passed in as an argument--to the database
        public int AddNewPaymentType(PaymentType newPaymentType){
            
            return 4;
        }
    }
}