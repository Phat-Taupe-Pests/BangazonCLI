using System;

//Written by:  Chaz Henricks
namespace BangazonCLI
{
    // Gets and sets public properties of a Product.
    public class Product
    {
        public int productID {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public Double price {get; set;}
        public DateTime? dateCreated {get; set;}
        public int customerID {get; set;}
        public int productTypeID {get; set;}
    }
}
