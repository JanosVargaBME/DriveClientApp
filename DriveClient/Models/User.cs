using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Models
{
    /// <summary>
    /// The class <c>User</c> represents the User information
    /// what we use to log into Google Drive to collect data.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The Username, the User gives to log in.
        /// </summary>
        public string username { get; set; } = string.Empty;
        /// <summary>
        /// The Password, the User gives to log in.
        /// </summary>
        public string password { get; set; } = string.Empty;
        /// <summary>
        /// The authentication token, taken from the API with the user info.
        /// </summary>
        public string token { get; set; } = string.Empty;
    }
}
