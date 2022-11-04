using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager
    {

        public List<IUser> users = new();
        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            Admin admin = new Admin("admin", "password", Enums.Countries.Sweden);

            User user = new User("Gandalf", "password", Enums.Countries.Denmark);


            Models.Trip paris = new("Paris", 3, Countries.France, TripTypes.Work);
            Models.Vacation stockholm = new("Stockholm", 8, Countries.Sweden, true);
            
            //Add 2 travels for Gandalf.

            user.Travels.Add(paris);
            user.Travels.Add(stockholm);

            //Add user and admin.

            users.Add(user);
            users.Add(admin);

        }

        //Get all users from the list

        public List<IUser> GetAllUsers()
        {
            return users;
        }

        //Add user to the list incl username, password and location

        public void AddUser(string username, string password, Countries location)
        {
            User user = new(username, password, location);

            users.Add(user);
        }



        public void RemoveUser(User userToDelete)
        {
            users.Remove(userToDelete);
        }


        //Change old username to a new one in user details window

        public bool updateUsername(IUser userToUpdate, string newUsername)
        {
            if(!ValidateUsername(newUsername))
            {
                return false;
            }

            userToUpdate.Username = newUsername;

            return true;
        }

        //Change old password to a new one in user details window
        public bool updatePassword(IUser userToUpdate, string newPassword)
        {
            if (!ValidatePassword(newPassword))
            {
                return false;
            }

            userToUpdate.Password = newPassword;

            return true;
        }


        //Check if user already exists
        public bool ValidateUsername(string newUsername)
        {
            foreach (IUser user in users)
            {
                if (user.Username == newUsername)
                {
                    return false;
                }
            }

            return true;
        }

        //Check if it's a new password when we're updating it
        public bool ValidatePassword(string newPassword)
        {
            foreach (IUser user in users)
            {
                if (user.Password == newPassword)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
