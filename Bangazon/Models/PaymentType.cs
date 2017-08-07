using System;

//Written by: Eliza Meeks

namespace BangazonCLI
{
    //Represents a PaymentType in the SQL database, including the paymenttypeID, customerID, account number, and name.
    public class PaymentType
    {
        public int paymentTypeID {get;}
        public int customerID {get; set;}
        public int accountNumber {get; set;}
        public string name {get; set;}

    }
}