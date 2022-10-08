using System;
using System.Collections.Generic;
using System.Text;

// Auction class which organises the bidding user stories
namespace Assingment
{
    public class Auction
    {
        public User Bidder
        { get; set; }
        public double BiddingPrice
        { get; set; }

        //Constructor 
        public Auction(User bidder, double biddingPrice)
        {
            Bidder = bidder;
            BiddingPrice = biddingPrice;
        }
        //Allows for the list to be readable in the console once displayed
        public override string ToString()
        {
            return $"Bid price ${BiddingPrice} AUD, by {Bidder}";
        }
    }
}
