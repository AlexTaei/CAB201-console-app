using System;
using System.Collections.Generic;
using System.Text;

//Properties class which essentailly is the parent of both land and houses
namespace Assingment
{
    //It is public and abstract meaning to access it, it must be inherited. Land and House class inherits this class.
    public abstract class Properties
    {
        //Only this class can set the values while other class can only read
        public User Seller 
        { get; protected set; }
        public string Address
        { get; protected set; }
        public string Postcode
        { get; protected set; }
        public List<Auction> BiddingList { get; protected set; } = new List<Auction>();

        //Constructor with parameters
        public Properties(User seller, string address, string postcode)
        {
            Seller = seller;
            Address = address;
            Postcode = postcode;
        }
        //Managing the current bidding list for a property
        public void PlaceBid(User bidder, double bidPrice)
        {
            Auction bid = new Auction(bidder, bidPrice);
            BiddingList.Add(bid);
        }
        public void SoldTo(User winner)
        {
            Seller = winner;
            BiddingList.Clear();
        }
        // Abstract Methods
        public abstract override string ToString();
        public abstract double TaxPayable();

    }
}
