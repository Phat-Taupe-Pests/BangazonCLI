using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//Written by: Adam Reidelbach

namespace BangazonCLI
{
    //Represents an order in the SQL database, including the orderID, customerID, paymentTypeID, and a list of the products associated with that order.
    public class Order
    {
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int paymentTypeID { get; set; }
        public DateTime dateCreated {get; set;}
        public List<Product> products { get; set; }
   }
}