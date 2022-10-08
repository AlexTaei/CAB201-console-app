using System;
using System.Collections.Generic;
using System.Linq;

// Server class which essentially mimics what the server side of the application would process.
// Therefore, it is mostly methods
namespace Assingment
{
    class Server
    {
        //private list of registered users and the current signed in account to ensure protection
        private List<User> RegisteredUsers { get; set; } = new List<User>();
        private User CurrentAccount 
        { get; set; }
        public List<Properties> PropertiesList { get; set; } = new List<Properties>();

        //Register method handles the registering form
        public void Register()
        {
            string regName = UserInterface.GetInput("Please enter your Name");
            while (String.IsNullOrWhiteSpace(regName)) //While the field is empty, keep asking the user to enter a valid field.
            {
                Console.WriteLine("Your name cannot be blank. Please try again!");
                regName = UserInterface.GetInput("Please enter your Name");
            }
            string regEmail = UserInterface.GetInput("Please enter your Email");
            while (String.IsNullOrWhiteSpace(regEmail))
            {
                Console.WriteLine("Your email cannot be blank. Please try again!");
                regEmail = UserInterface.GetInput("Please enter your Email");
            }
            string regPassword = UserInterface.GetPassword("Please enter your password");
            while (String.IsNullOrWhiteSpace(regPassword))
            {
                Console.WriteLine("Your password cannot be blank. Please try again!");
                regPassword = UserInterface.GetPassword("Please enter your password");
            }
            //Look for if any of the inputted email is already registered. Return True if it already exists.
            bool reapeatedEmail = RegisteredUsers.Any(users => users.Email == regEmail); 
            if (reapeatedEmail == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Email already exists! Please Sign in.");
                Console.WriteLine("");
            }
            else if (reapeatedEmail != true) //If unique email is enetered, register a new account.
            {
             RegisteredUsers.Add(new User(regName, regEmail, regPassword));

            Console.WriteLine("");
            Console.WriteLine($"Successfully registered, {regName}!");
            Console.WriteLine("Please sign in with your new account.");
            Console.WriteLine("");
            }
            
        }
        //Log in method to handle log in form.
        public void Login()
        {
            string loginEmail = UserInterface.GetInput("Please enter your Email");
            while (String.IsNullOrWhiteSpace(loginEmail))
            {
                Console.WriteLine("Your email cannot be blank. Please try again!");
                loginEmail = UserInterface.GetInput("Please enter your Name");
            }
            string loginPassword = UserInterface.GetPassword("Please enter your password");
            while (String.IsNullOrWhiteSpace(loginPassword))
            {
                Console.WriteLine("Your password cannot be blank. Please try again!");
                loginPassword = UserInterface.GetInput("Please enter your Name");
            }
            bool emailExists = RegisteredUsers.Any(users => users.Email == loginEmail); //Returns true if email is registered
            bool passwordExists = RegisteredUsers.Any(users => users.Password == loginPassword); //Returns true if password is registered
            int emailExistsIndex = RegisteredUsers.FindIndex(users => users.Email == loginEmail); //Returns an index number of the email entered
            int passwordExistsIndex = RegisteredUsers.FindIndex(users => users.Password == loginPassword);//Returns an index number of the password entered
            //-1 is returned if either email or password does not already exists.
            if (emailExists && passwordExists) //If email and password exists...
            {
                //Makes sure the passwords and emails cannot be mix matched
                if (emailExistsIndex == passwordExistsIndex)//And if the indexes are the same then it must be the correct user
                {
                    //Finds the registered user for the email entered and sets the curent account to the user.
                    CurrentAccount = RegisteredUsers.Find(users => users.SameAs(new User(null, loginEmail, null)));
                    Console.WriteLine("");
                    Console.WriteLine($"Wecome back, {CurrentAccount.Name} ({CurrentAccount.Email})!");
                    Console.WriteLine("");
                }
                else if (emailExistsIndex != passwordExistsIndex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong email or password. Please try again.");
                    Console.WriteLine("");
                }
            }
            else if (emailExistsIndex == -1) //If email int is -1, the user does not exist
            {
                Console.WriteLine("");
                Console.WriteLine($"No accounted is associated with the email, {loginEmail}.");
                Console.WriteLine("");
            }
            else if (emailExistsIndex != passwordExistsIndex)
            {
                Console.WriteLine("");
                Console.WriteLine("Wrong email or password. Please try again.");
                Console.WriteLine("");
            }
        }
        //bool method for the current log in status
        public bool LoggedIn()
        {
            return CurrentAccount != null;
        }
        // method to clear the logged in account to reset the menu system in MainMenu class
        public void Logout()
        {
            CurrentAccount = null;
        }
        // method to exit application/console
        public void Exit()
        {
            Environment.Exit(0);
        }

        //Method to create Land listings
        public void CreateLandAd()
        {
            Console.WriteLine("Please fill in the following details:");
            string getAddress = UserInterface.GetInput("Address");
            while (String.IsNullOrWhiteSpace(getAddress)) //Checks if the field is empty
            {
                Console.WriteLine("Your address cannot be blank. Please try again!");
                getAddress = UserInterface.GetInput("Address");
            }
            string getPostcode = UserInterface.GetInput("Postcode");
            //Another error handling to make sure the user inputs a number for postcode
            while (String.IsNullOrWhiteSpace(getPostcode) || !Int32.TryParse(getPostcode, out int searchPostcodeInt))
            {
                Console.WriteLine("Please enter a valid postcode. Please try again!");
                getPostcode = UserInterface.GetInput("Postcode");
            }
            string getStringArea = UserInterface.GetInput("Area in square metres");
            while (String.IsNullOrWhiteSpace(getStringArea))
            {
                Console.WriteLine("Your area cannot be blank. Please try again!");
                getStringArea = UserInterface.GetInput("Area in square metres");
            }
            double getArea;
            while (!Double.TryParse(getStringArea, out getArea))
            {
                Console.WriteLine("Please enter a valid area!");
                getStringArea = UserInterface.GetInput("Area in square metres");
            }
            //Add the entered Land into the main properties list under the currently logged in account.
            PropertiesList.Add(new Land(CurrentAccount, getAddress, getPostcode, getArea)); 
            Console.WriteLine("");
            Console.WriteLine($"{getArea}m^2 at {getAddress} {getPostcode}, Successfully listed.");
            Console.WriteLine("");
        }
        //Same approach as the Land listing method
        public void CreateHouseAd()
        {
            Console.WriteLine("Please fill in the following details:");
            string getAddress = UserInterface.GetInput("Address");
            while (String.IsNullOrWhiteSpace(getAddress))
            {
                Console.WriteLine("Your Address cannot be blank. Please try again!");
                getAddress = UserInterface.GetInput("Address");
            }
            string getPostcode = UserInterface.GetInput("Postcode");
            while (String.IsNullOrWhiteSpace(getPostcode) || !Int32.TryParse(getPostcode, out int searchPostcodeInt))
            {
                Console.WriteLine("Please enter a valid postcode. Please try again!");
                getPostcode = UserInterface.GetInput("Postcode");
            }
            string getDescription = UserInterface.GetInput("Description of house");
            while (String.IsNullOrWhiteSpace(getDescription))
            {
                Console.WriteLine("Your Description cannot be blank. Please try again!");
                getDescription = UserInterface.GetInput("Description");
            }
            PropertiesList.Add(new House(CurrentAccount, getAddress, getPostcode, getDescription));
            Console.WriteLine("");
            Console.WriteLine($"{getAddress}, {getPostcode}: {getDescription}. Successfully listed.");
            Console.WriteLine("");
        }
        //Method to return a list containing all the propertries listed by the current logged in account
        public List<Properties> CurrentLoggedInProperties()
        {
            return PropertiesList.Where(land => (land.Seller).Equals(CurrentAccount)).ToList();
        }
        //Method to display a list containing all the properties listed by user using the previous method
        public void ViewMyAds()
        {
            List<Properties> myProperties = CurrentLoggedInProperties();
            UserInterface.DisplayList("You have the following listed for sale:", myProperties);
        }
        //Method to view all listings in the marketplace including the user's own properties
        public void ViewAllAds()
        {
            UserInterface.DisplayList("All properties listed in market:", PropertiesList);
        }
        //Method to return a list filtered by the entered postcode
        public List<Properties> PropertiesByPostcode(string searchPostcode)
        {
            return PropertiesList.Where(land => (land.Postcode) == searchPostcode).ToList();
        }
        //Method to show a list of properties on marketplace by the serached postcode
        public void SearchPostcode()
        {
            string searchPostcode = UserInterface.GetInput("Postcode");
            //Error handling to obtain a valid postcode
            while (String.IsNullOrWhiteSpace(searchPostcode) || !Int32.TryParse(searchPostcode, out int searchPostcodeInt))
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid postcode to search!");
                searchPostcode = UserInterface.GetInput("Postcode");
            }
            List<Properties> propertiesByPostcode = PropertiesByPostcode(searchPostcode);
            Console.WriteLine("");
            UserInterface.DisplayList($"The properties on marktet for {searchPostcode} postcode:", propertiesByPostcode);
        }
        //Method to return a list of properties other than the current user's properties
        public List<Properties> OtherProperties()
        {
            return PropertiesList.Where(land => (!(land.Seller).Equals(CurrentAccount))).ToList();
        }
        //Returns the same list as above but with postcode filtering
        public List<Properties> OtherPropertiesByPostCode(string searchPostcode)
        {
            List<Properties> otherProperties = OtherProperties();
            return otherProperties.Where(land => (land.Postcode) == searchPostcode).ToList();
        }
        //Method for placing bids to properties that are not the current user's own ads
        public void PlaceBid()
        {
            List<Properties> otherProperties = OtherProperties();
            bool noProperties = !otherProperties.Any(); 
            if (!noProperties) //If there are any other properties than the current user's own listed properties...
            {
                string searchPostcode = UserInterface.GetInput("Enter postcode or press enter to view all properties to bid");
                bool emptyPostcode = String.IsNullOrWhiteSpace(searchPostcode);
                if (!emptyPostcode) //Error handling
                {
                    while (!Int32.TryParse(searchPostcode, out int searchPostcodeInt))
                    {
                        Console.WriteLine("Please enter a valid postcode or press enter to view all properties. Please try again!");
                        searchPostcode = UserInterface.GetInput("Postcode");
                    }
                }//Ask for a either a postcode to search by or an empty field to show other properties by postcode or all other properties
                List<Properties> otherPropertiesByPostcode = OtherPropertiesByPostCode(searchPostcode);
                bool noPropertiesBySearch = !otherPropertiesByPostcode.Any();
                if (searchPostcode == "") //If the user does not enter in a postcode, show all possible options to bid
                {
                    Console.WriteLine("You have selected all postcodes.");
                    Properties propertyToBid = UserInterface.ChooseFromList(otherProperties);
                    string bidStringPrice = UserInterface.GetInput("Place your bid $");
                    double bidPrice;
                    while (!Double.TryParse(bidStringPrice, out bidPrice))
                    {
                        Console.WriteLine("Please enter a valid amount in $.");
                        bidStringPrice = UserInterface.GetInput("Place your bid $");
                    }
                    propertyToBid.PlaceBid(CurrentAccount, bidPrice);
                    Console.WriteLine("");
                    Console.WriteLine($"You have place ${bidPrice} on {propertyToBid}");
                    Console.WriteLine("");
                }
                else if (noPropertiesBySearch)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"There are no properties listed on market for the following postcode: {searchPostcode}.");
                    Console.WriteLine("");
                }
                else //The user has entered a postcode to filter by
                {
                    Console.WriteLine($"You have selected {searchPostcode}.");
                    Properties propertyToBid = UserInterface.ChooseFromList(otherPropertiesByPostcode);
                    string bidStringPrice = UserInterface.GetInput("Place your bid $");
                    double bidPrice;
                    while (!Double.TryParse(bidStringPrice, out bidPrice))
                    {
                        Console.WriteLine("Please enter a valid amount in $.");
                        bidStringPrice = UserInterface.GetInput("Place your bid $");
                    }
                    propertyToBid.PlaceBid(CurrentAccount, bidPrice);
                    Console.WriteLine("");
                    Console.WriteLine($"You have place ${bidPrice} on {propertyToBid}");
                    Console.WriteLine("");
                }
            }
            else //If the only properties on the markets are the current user's then display this message
            {
                Console.WriteLine("There are no other properties listed on market for your to bid.");
                Console.WriteLine("");
            }
            
        }
        //Method to show bids on the current user's properties
        public void ViewBids()
        {
            List<Properties> myPropertiesBids = CurrentLoggedInProperties();
            bool emptyList = !myPropertiesBids.Any();
            if (!emptyList)
            {
                Properties selectedProperty = UserInterface.ChooseFromList(myPropertiesBids);
                bool anyBids = !selectedProperty.BiddingList.Any();
                if (!anyBids)
                {
                    UserInterface.DisplayList($"Bids placed for {selectedProperty.Address}", selectedProperty.BiddingList);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"There are no bids placed for {selectedProperty}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("You do not have any properties listed for sale");
                Console.WriteLine("");
            }

        }
        //Method to handle the selling of property to highest bidder and transferring ownership
        public void SellProperty()
        {
            List<Properties> myProperties = CurrentLoggedInProperties();
            bool emptyList = !myProperties.Any();
            if (!emptyList)
            {
                Properties selectedProperty = UserInterface.ChooseFromList(myProperties);
                bool anyBids = !selectedProperty.BiddingList.Any();
                if (!anyBids)
                {
                    double highestBidPrice = selectedProperty.BiddingList.Max(bids => bids.BiddingPrice); 
                    Auction highestBid = selectedProperty.BiddingList.Find(bids => bids.BiddingPrice == highestBidPrice); 
                    Console.WriteLine($"{selectedProperty} has successfully been sold to {highestBid.Bidder} for ${highestBid.BiddingPrice}");
                    Console.WriteLine("");
                    double taxPayable = selectedProperty.TaxPayable(); //TaxPayable is the overriden method found in House and Land class
                    Console.WriteLine($"The total tax payable on your recent sale is ${taxPayable}");
                    Console.WriteLine("");
                    selectedProperty.SoldTo(highestBid.Bidder); //SoldTo method from the Properties class transfers the ownership to the highest bidder that won
                }
                else
                {
                    Console.WriteLine("You have no bids for the selected property");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("You do not have any properties listed");
                Console.WriteLine("");
            }
        }
    }
}
