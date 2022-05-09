using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Services
{
    public class DirectoryItemService
    {
        private List<DirectoryItem> directories = new List<DirectoryItem>();
        public static DirectoryItemService Instance { get; private set; } = new DirectoryItemService();
        protected DirectoryItemService(){ dummyDataInit(); }

        private void dummyDataInit()
        {
            for (int i = 100; i < 103; i++)
            {
                AddDirectory(new DirectoryItem
                {
                    Name = "Mappa",
                    ID = i.ToString(),
                    Description = "Ez egy mappa",
                    FullPath = "hello/folder",
                    Type = "Folder",
                });
            }
        }

        public List<DirectoryItem> GetDirectories()
        {
            return directories;
        }

        public DirectoryItem GetDirectory(string ID)
        {
            return directories.Find(x => x.ID == ID);
        }

        public bool AddDirectory(DirectoryItem di)
        {
            directories.Add(di);
            return true;
        }

        public bool DeleteDirectory(string ID)
        {
            foreach (var x in directories)
            {
                if (x.ID == ID)
                {
                    directories.Remove(x);
                    return true;
                }
            }
            return false;
        }
    }
}
