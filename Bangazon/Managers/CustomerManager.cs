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
        // Constructor method to establish a connection with the database, database conenction is passed in as an argument..
        public CustomerManager(dbUtilities db)
        {
            _db = db;
        }
        // Adds a new customer--passed in as an argument--to the database
        public int AddNewCustomer(Customer newCustomer){
            return 4;
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
            _currentCustomer = new Customer();
                _currentCustomer.customerID = 1;
                _currentCustomer.firstName = "Brain"; 
                _currentCustomer.lastName= "Pinky"; 
                _currentCustomer.streetAddress = "114 Street Place"; 
                _currentCustomer.state= "Tennesseetopia"; 
                _currentCustomer.postalCode= 55555; 
                _currentCustomer.phoneNumber= "555-123-4567"; 
            return _currentCustomer;
        }
    }
}