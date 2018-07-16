using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItaasSolution.Validations
{
    public partial class Helper
    {
        public static void VerifyUrl(string url)
        {
            try
            {
                HttpClient urlTest = new HttpClient();
                urlTest.GetAsync(url);
            }
            catch
            {
                ErrorMessage = "The URL is not Valid, please informe a valid one";
                Result = false;
                return;
            }
        }

        public static void VerifyPath(string targetPath)
        {
            try
            {
                Path.GetFullPath(targetPath);
            }
            catch (PathTooLongException)
            {
                ErrorMessage = "The path is too big. Please keep it under Windows's 260 max chars limit.";
                Result = false;
                return;
            }
            catch
            {
                ErrorMessage = "There's a problem with the target Path.";
                Result = false;
                return;
            }

            Result = true;
        }

        public static void VerifyNotMissingParameter(string[] args)
        {
            if (args.Length < 2)
            {
                ErrorMessage = "There´s no parameter for URL or Target Path";
                Result = false;
                return;
            }

            Result = true;
        }
    }
}
