using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{
    public class ValidationService : IValidationService
    {
        private IFileService fileService;

        public ValidationService(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public bool IsArgumentValid(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine(string.Format("File path can't be null and empty"));
                return false;
            }

            if (!fileService.IsFileExists(args[0]))
            {
                Console.WriteLine(string.Format("The file doesn't exist at this address: {0}", args[0]));
                return false;
            }

            return true;
        }
    }
}