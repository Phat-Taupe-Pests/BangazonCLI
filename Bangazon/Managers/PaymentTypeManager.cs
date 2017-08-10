using System.Collections.Generic;
using Microsoft.Data.Sqlite;
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
            Customer activeCustomer = CustomerManager.currentCustomer;
            int returnedID = _db.Insert($"insert into paymentType values (null,  {newPaymentType.accountNumber}, {activeCustomer.customerID}, '{newPaymentType.name}')");
            return returnedID;
        }

        public List <PaymentType> GetCustomersPaymentTypes(int customerID) 
        {
            List <PaymentType> customersPaymentTypes = new List <PaymentType>();
                _db.Query($"SELECT * FROM `paymentType` WHERE customerID = {customerID} ", (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    customersPaymentTypes.Add(new PaymentType()
                    {
                        paymentTypeID = reader.GetInt32(0),
                        accountNumber = reader.GetInt32(1),
                        customerID = reader.GetInt32(2),
                        name = reader[3].ToString()
                    });
                }
            });
            return customersPaymentTypes;
        }
    }
}
