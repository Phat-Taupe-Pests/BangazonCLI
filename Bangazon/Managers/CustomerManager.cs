using System.Collections.Generic;
//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger
namespace BangazonCLI
{
    // Manages customer related methods
    public class CustomerManager
    {
        private dbUtilities _db;

        // Hold the Current Customer. -Matt Augsburger
        private Customer _currentCustomer;

        // private List<Customer> _customers = new List <Customer>(); // NOT sure this is needed
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public CustomerManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new customer--passed in as an argument--to the database
        public int AddNewCustomer(Customer newCustomer){

            int id = _db.Insert( $"insert into customer values (null, '{newCustomer.firstName}', '{newCustomer.lastName}', '{newCustomer.streetAddress}', '{newCustomer.state}', {newCustomer.postalCode}, '{newCustomer.phoneNumber}')");

            return id;
        }
        // Gets a list of customers.
        public List<Customer> GetCustomerList()
        {
            
            return new List<Customer>();
        }

        public void SetCurrentCustomer(Customer customer)
        {
            _currentCustomer = customer;
        }

        public Customer GetCurrentCustomer()
        {
            return _currentCustomer;
        }
    }
}