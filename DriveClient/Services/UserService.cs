using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();
        public static UserService Instance { get; private set; } = new UserService();

        protected UserService() { dummyDataInit(); }

        private void dummyDataInit()
        {
            User u = new User
            {
                username = "felh_nev",
                password = "jelszo",
                token = "token"
            };
            User u2 = new User
            {
                username = "felh_nev2",
                password = "jelszo2",
                token = "token2"
            };
            users.Add(u);
            users.Add(u2);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
