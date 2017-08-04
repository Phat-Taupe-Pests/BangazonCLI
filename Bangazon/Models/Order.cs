using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

//Written by: Adam Reidelbach

namespace BangazonCLI
{
    // Gets public properties of an order.
    public class Order
    {
        public int customerID { get; set; }
        public int paymentTypeID { get; set; }
        public List<Product> products { get; set; }

   }
}