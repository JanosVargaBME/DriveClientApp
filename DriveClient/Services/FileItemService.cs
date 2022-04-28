using DriveClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriveClient.Services
{
    public class FileItemService
    {
        private List<FileItem> files = new List<FileItem>();
        public static FileItemService Instance { get; private set; } = new FileItemService();
        
        protected FileItemService() { dummyDataInit(); }

        private void dummyDataInit()
        {
            FileItem f1 = new FileItem
            {
                Name = "Fajl1",
                ID = "1",
                Description = "Ez egy fajl",
            };
            FileItem f2 = new FileItem
            {
                Name = "Fajl2",
                ID = "2",
                Description = "Ez egy fajl",
            };
            AddFile(f1);
            AddFile(f2);
        }
        public List<FileItem> GetFiles()
        {
            return files;
        }

        public FileItem GetFile(string ID)
        {
            return files.Find(x => x.ID == ID);
        }

        public bool AddFile(FileItem fi)
        {
            files.Add(fi);
            return true;
        }

        public bool DeleteFile(string ID)
        {
            foreach (var x in files)
            {
                if (x.ID == ID)
                {
                    files.Remove(x);
                    return true;
                }
            }
            return false;
        }
    }
}
