using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArnaudCore.Services
{
    public interface IFileStorage
    {
        void ChangeDirectory(string directory);
        string[] GetCurrentFiles();
    }

    public class FileStorageService : IFileStorage
    {
        string directory;

        public void ChangeDirectory(string directory)
        {
            this.directory = directory;
        }

        public string[] GetCurrentFiles()
        {
            return System.IO.Directory.GetFiles(directory);
        }
    }
}
