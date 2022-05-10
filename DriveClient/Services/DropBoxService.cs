using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveClient.Models;
using Dropbox.Api;

namespace DriveClient.Services
{
    internal class DropBoxService
    {
        private string accessToken = "";

        public string actualUser = "";

        public static DropBoxService Instance { get; private set; } = new DropBoxService();
        
        public async Task<bool> IsValidLogin(string token)
        {
            accessToken = token;

            try
            {
                using (var db = new DropboxClient(accessToken))
                {
                    var id = await db.Users.GetCurrentAccountAsync();

                    actualUser = id.Name.DisplayName;
                }
                return true;
            }
            catch (Exception)
            {
                actualUser = "";
            }

            return false;
        }

        public async Task<List<DirectoryItem>> GetDirectories(string path)
        {
            List<DirectoryItem> directories = new List<DirectoryItem>();

            using (var db = new DropboxClient(accessToken))
            {
                var list = await db.Files.ListFolderAsync(path);

                //Good til this point

                foreach (var file in list.Entries.Where(i => i.IsFolder))
                {
                    directories.Add(new DirectoryItem
                    {
                        ID = file.AsFolder.Id,
                        Name = file.AsFolder.Name,
                        FullPath = file.AsFolder.PathDisplay,
                        createdTime = DateTime.Now,
                        FileCount = 0,
                        Type = "Folder",
                    });
                }
            }
            return directories;
        }
        
    }
}
