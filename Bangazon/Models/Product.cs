using System;

//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger

namespace BangazonCLI
{
    // Gets and sets public properties of a customer.
    public class Product
    {
        public string productTypeID {get; set;}
        public string price {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public int customerID {get; set;}
        public DateTime dateCreated {get; set;}

    }
}