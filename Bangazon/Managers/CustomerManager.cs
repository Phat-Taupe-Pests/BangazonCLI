using System.Collections.Generic;

namespace BangazonCLI
{
    public class CustomerManager
    {
        private dbUtilities _db;
        
        public CustomerManager(dbUtilities db)
        {
            _db = db;
        }

        public int AddNewCustomer(Customer newCustomer){
            return 4;
        }

        public List<Customer> GetCustomerList()
        {
            
            return new List<Customer>();
        }
    }
}