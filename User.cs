using System;
using System.Collections.Generic;

//User class
namespace Assingment
{
     public class User
    {
        //Private user details only accessible from the server side
        public string Email
        { get; private set; }
        public string Name
        { get; private set; }
        public string Password
        { get; private set; }
        //Constructor with parameters
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        // A method to check the same user email in database to what the user has typed in. Returns true if it matches.
        public bool SameAs(object obj)
        {
            return Email == ((User)obj).Email;
        }

        //Allows the user to be dispalyed in console rather than a generic list name.
        public override string ToString()
        {
            return $"{Name} ({Email})";
        }
    }
}
