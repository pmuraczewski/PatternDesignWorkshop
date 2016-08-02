using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public class FileService : IFileService
    {
        public bool IsFileExists(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            return File.Exists(path);
        }
    }
}
