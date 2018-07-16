using Itaas.MainMethods;
using ItaasSolution.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItaasSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.VerifyInputs(args);

            if (!Helper.Result)
            {
                Console.Write(Helper.ErrorMessage);
                Environment.Exit(0);
            }

            LogGenerator convert = new LogGenerator(args[0], args[1]);
            convert.GenerateCDNLog();
        }
    }
}
