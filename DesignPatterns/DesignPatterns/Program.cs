using DesignPatterns.App_Start;
using DesignPatterns.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!args.Any())
            {
                return;
            }

            var container = Bootstrapper.Initialise();
            var fileService = container.Resolve<IFileService>();

            fileService.IsFileExists(args[0]);
            Console.ReadKey();
        }
    }
}
