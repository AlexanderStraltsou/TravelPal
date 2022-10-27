using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager
    {
        private List<User> users = new();

        //public UserManager()
        //{
        //    AddAdminUser();
        //}

        //public void AddAdminUser()
        //{
        //    Admin admin = new("admin", "password");

        //    users.Add(admin);
        //}

        public List<User> GetAllUsers()
        {
            return users;
        }

        


        /*
        public void AddUser(string username, string password)
        {
            Client client = new();
            client.Username = username;
            client.Password = password;

            users.Add(client);
        }

        public void DeleteUser(Client clientToDelete)
        {
            users.Remove(clientToDelete);
        }
        */
    }
}
