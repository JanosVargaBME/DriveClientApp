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
            DirectoryItem di1 = new DirectoryItem
            {
                Name = "Mappa",
                ID = "1",
                Description = "Ez egy mappa",
                fullPath = "hello/folder"
            };
            DirectoryItem di2 = new DirectoryItem
            {
                Name = "Mappa2",
                ID = "2",
                Description = "Ez egy mappa2",
                fullPath = "hello/folder2"
            };
            AddDirectory(di1);
            AddDirectory(di2);
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
