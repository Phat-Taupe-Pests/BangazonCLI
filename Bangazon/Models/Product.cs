using System;

//Written by:  Chaz Henricks
namespace BangazonCLI
{
    // Gets and sets public properties of a Product.
    public class Product
    {
        public int ProductId {get;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int Price {get; set;}
        public DateTime? DateCreated {get; set;}
        public Customer customer {get; set;}
        public ProductType productType {get; set;}
    }
}