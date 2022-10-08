using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

// House class with the properties class inherited
namespace Assingment
{
    class House : Properties //Inheritance
    {
        public string Description
        { get; set; }
        //Constructor with the base parameters inherited from Properties class. Just adds a new parameter, description.
        public House(User seller, string address, string postcode, string description) : base(seller, address, postcode)
        {
            Description = description;
        }
        // Allows for the list to be properly displayed in console
        public override string ToString()
        {
            return $"House: {Postcode}, {Address}, {Description}";
        }
        // Method for calculting the taxpayable. It is override so that the same Method name can be called depending on the context, House or Land.
        public override double TaxPayable()
        {
            double soldPrice = BiddingList.Max(bids => bids.BiddingPrice);
            double tax = Math.Round(soldPrice * 0.10);
            return tax;
        }
    }
}
