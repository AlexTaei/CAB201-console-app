using System;
using System.Collections.Generic;

//Main Menu class for handling the the main menus: Register/Login page and the Logged in page.
namespace Assingment
{
    class MainMenu
    {
        readonly Menu registerLoginMenu= new Menu();
        readonly Menu mainMenu = new Menu();
        readonly Server server = new Server();

        public void Start()
        {
            //Register/Login page
            registerLoginMenu.Add("Register for a new account", server.Register);
            registerLoginMenu.Add("Sign in to an existing account", server.Login);
            registerLoginMenu.Add("Close program", server.Exit);
            //Logged in page
            mainMenu.Add("List land for sale", server.CreateLandAd);
            mainMenu.Add("List house and land for sale", server.CreateHouseAd);
            mainMenu.Add("View all my properties", server.ViewMyAds);
            mainMenu.Add("View all market properties for sale", server.ViewAllAds);
            mainMenu.Add("Search properties by postcode", server.SearchPostcode);
            mainMenu.Add("Place bids on properties", server.PlaceBid);
            mainMenu.Add("View bids placed on my properties", server.ViewBids);
            mainMenu.Add("Sell my property to the highest bidder", server.SellProperty);
            mainMenu.Add("Sign out", server.Logout);
            mainMenu.Add("Close program", server.Exit);

            //Algorithm for showing which menu to display according to user token
            while (!server.LoggedIn())
            {
                registerLoginMenu.Display();
                while (server.LoggedIn())
                {
                    mainMenu.Display();
                }
            }
        }

        //Running Main program
        static void Main(string[] args)
        {
            MainMenu assingment = new MainMenu();
            assingment.Start();
        }
    }
}
