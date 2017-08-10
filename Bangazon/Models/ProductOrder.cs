using System;

//Written by: Adam Reidelbach
namespace BangazonCLI
{
    //Represents a product in the SQL database, including the productOrderID, productID, and OrderID.
    public class ProductOrder
    {
        public int productOrderID {get; set;}
        public int productID {get; set;}
        public int orderID {get; set;}
    }
}