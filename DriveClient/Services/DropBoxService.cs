using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;

namespace DriveClient.Services
{
    internal class DropBoxService
    {
        private string accessToken = "";

        public string actualUser = "";

        public static DropBoxService Instance { get; private set; } = new DropBoxService();

        public bool SetAccessToken(string token)
        {
            //TODO
            return true;
        }
        
        public async Task GetUserName()
        {
            using(var db = new DropboxClient(accessToken))
            {
                var id = await db.Users.GetCurrentAccountAsync();

                actualUser = id.Name.DisplayName;
            }
        }
    }
}
