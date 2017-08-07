using System;

//Written by:  Chaz Henricks
namespace BangazonCLI
{
    // Gets and sets public properties of a Product.
    public class Product
    {
        public int ProductID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public Double Price {get; set;}
        public DateTime? DateCreated {get; set;}
        public int CustomerID {get; set;}
        public int ProductTypeID {get; set;}
    }
}
