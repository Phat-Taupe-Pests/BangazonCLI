using System;

//Written by: Eliza Meeks

namespace BangazonCLI
{
    // Gets and sets public properties of a payment type.
    public class PaymentType
    {
        public int paymentTypeID {get;}
        public int customerID {get; set;}
        public int accountNumber {get; set;}
        public string name {get; set;}

    }
}