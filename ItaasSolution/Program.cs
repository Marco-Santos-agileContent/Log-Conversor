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

            if (!treatment.VerifyPathIsValid(args[1]))
            {
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!treatment.VerifyURLIsValid(args[0]))
            {
                Console.WriteLine("The URL is not valid. Please inform a valid one");
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!treatment.VerifyPathExists(args[1]))
            {
                Console.WriteLine("The application will be closed, press anything to continue");
                Console.ReadLine();
                Environment.Exit(0);
            }

            args[1] = treatment.VerifyFileExtension(args[1]);


            if (treatment.VerifyWhereUserWantToSave(args[1]))
            {
                args[1] = Path.Combine(@"C:\\ItaasCDNLogConvertor", args[1]);
            }
            

            if (convert.GenerateCDNLog(args[0], args[1]))
            {
                Console.WriteLine("sucessefuly converted");
            }
        }
    }
}
