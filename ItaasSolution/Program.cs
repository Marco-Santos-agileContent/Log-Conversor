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
            InputValidation treatment = new InputValidation();

            if (args.Length < 2)
            {
                Console.WriteLine("There´s no parameter for URL or Target Path");
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            string targerPath = treatment.VerifyFileExtension(args[1]);

            if (treatment.VerifyWhereUserWantToSave(targerPath))
            {
                targerPath = Path.Combine(@"C:\\ItaasCDNLogConvertor", targerPath);
            }

            if (!treatment.VerifyPathIsValid(targerPath))
            {
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!treatment.VerifyPathExists(targerPath))
            {
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!treatment.VerifyURLIsValid(args[1]))
            {
                Console.WriteLine("The URL is not valid. Please inform a valid one");
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }


            if (convert.GenerateCDNLog(args[1], targerPath))
            {
                Console.WriteLine("sucessefuly converted");
            }
        }
    }
}
