using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItaasSolution.Validations
{
    public static partial class Helper
    {
        public static string ErrorMessage { get; set; } = "";
        public static bool Result { get; set; } = true;

        public static void VerifyInputs(string[] args)
        {
            VerifyNotMissingParameter(args);

            if (Result != false) VerifyPath(args[1]);
            if (Result != false) CreatePathIfDoesNotExist(args[1]);
            if (Result != false) VerifyUrl(args[0]);
        }

        private static void CreatePathIfDoesNotExist(string targetPath)
        {
            FileInfo fileInfo = new FileInfo(targetPath);

            if (!fileInfo.Exists && !Directory.Exists(targetPath))
            {
                try
                {
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }

                catch (Exception)
                {
                    ErrorMessage = "The target Path does not exist, and it's not possible to create.";
                    Result = false;
                    return;
                }
            }
        }
    }
}
