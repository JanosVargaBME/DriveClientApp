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
            for (int i = 1; i < 10; i++)
            {
                AddFile(new FileItem
                {
                    Name = "Fajl" + i.ToString(),
                    ID = i.ToString(),
                    Description = "Ez egy fajl" + i.ToString(),
                    Size = 200,
                    MimeType = "zip" + i.ToString()
                });
            }
            
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
