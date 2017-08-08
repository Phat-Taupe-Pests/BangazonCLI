using System.Collections.Generic;
using Microsoft.Data.Sqlite;
//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
namespace BangazonCLI
{
    // Manages customer related methods
    public class CustomerManager
    {
        private dbUtilities _db;

        // Hold the Current Customer. -Matt Augsburger
        private Customer _currentCustomer;
                    
        // Holds the list of Customers in the database
        private List<Customer> _customerList = new List<Customer>();

        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public CustomerManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new customer--passed in as an argument--to the database
        public int AddNewCustomer(Customer newCustomer){
            
            _customerList.Add(newCustomer);
            int id = _db.Insert( $"insert into customer values (null, '{newCustomer.firstName}', '{newCustomer.lastName}', '{newCustomer.streetAddress}', '{newCustomer.state}', {newCustomer.postalCode}, '{newCustomer.phoneNumber}')");

            return id;
        }
        // Gets/returns a list of customers from the database
        public List<Customer> GetCustomerList()
        {
            _db.Query("SELECT customerId, firstName, lastName, streetAddress, state, postalCode, phoneNumber FROM Customer;", 
                (SqliteDataReader reader) => {
                    _customerList.Clear();
                    while (reader.Read())
                    {
                        _customerList.Add(new Customer() {
                            customerID = reader.GetInt32(0),
                            firstName = reader[1].ToString(),
                            lastName = reader[2].ToString(),
                            streetAddress = reader[3].ToString(),
                            state = reader[4].ToString(),
                            postalCode = reader.GetInt16(5),
                            phoneNumber = reader[6].ToString()
                        });
                    }
                });
            return _customerList;
        }
        // Sets the current customer
        //takes a customer as an argument
        public void SetCurrentCustomer(Customer customer)
        {
            _currentCustomer = customer;
        }
        // Gets/returns the current customer
        public Customer GetCurrentCustomer()
        {
            return _currentCustomer;
        }
    }
}