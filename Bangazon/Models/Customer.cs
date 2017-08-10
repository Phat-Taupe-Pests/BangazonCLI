using System;

//Written by: Eliza Meeks, Adam Reidelbach, Chaz Henricks, Ben Greaves, Matt Augsburger

namespace BangazonCLI
{
    //Represents a customer in the SQL database, including the customerID, firstName, lastName, streetAddress, state, postalCode, and phoneNumber.
    public class Customer
    {
        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postalCode { get; set; }
        public string phoneNumber { get; set; }
    }
}