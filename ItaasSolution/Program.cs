using Itaas.MainMethods;
using Itaas.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItaasSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            LogGenerator convert = new LogGenerator();

            //if (args.Length < 2)
            //{
            //    Console.WriteLine("There´s no parameter for URL or Target Path");
            //    Console.WriteLine("The application will be closed, press anything to continue");
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}

            var pathValidations = InputValidation.VerifyPath("");

            if (pathValidations.Item2 == false)
            {
                Console.WriteLine(pathValidations.Item1);
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (InputValidation.VerifyUrl(args[0]))
            {
                Console.WriteLine("The URL is not valid. Please inform a valid one");
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }
            

            if (convert.GenerateCDNLog(args[0], args[1]))
            {
                Console.WriteLine("sucessefuly converted");
            }
        }
    }
}
