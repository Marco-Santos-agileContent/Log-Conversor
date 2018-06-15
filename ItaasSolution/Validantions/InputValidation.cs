using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Itaas.Validations
{
    public class InputValidation
    {

        public bool VerifyURLIsValid(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }

        public bool VerifyWhereUserWantToSave(string targetPath)
        {
            if(!Path.IsPathRooted(targetPath))
            {
                Console.WriteLine("The Path Informed is not root and the file will be saved in the program file\n" +
                    "Do you want to save it in (C:)? Y/N");

                string userOption = Console.ReadLine();
                if (userOption.Equals("y",StringComparison.InvariantCultureIgnoreCase) || userOption.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                {
                    return true; 
                }
            }

            return false;
        }

        public bool VerifyPathIsValid(string targetPath)
        {

            try
            {
                Path.GetFullPath(targetPath);
            }
            catch(PathTooLongException)
            {
                Console.WriteLine("The path is too big. Please keep it under Windows's 260 max chars limit");
                return false;
            }
            catch
            {
                Console.WriteLine("There's a problem with the target Path");
            }

            if (targetPath == "")
            {
                Console.WriteLine("Path Cannot be null");
                return false;
            }
            
            return true;
        }

        public string VerifyFileExtension(string targetPath)
        {
            if (Path.GetExtension(targetPath) != ".txt" && Path.GetExtension(targetPath) != ".csv")
            {
                string newPath = Path.GetFullPath(targetPath);
                newPath = newPath + ".txt";
                return newPath;
            }
            return targetPath;
        }

        public bool VerifyPathExists(string targetPath)
        {
        
            FileInfo fileInfo = new FileInfo(targetPath);

            if (!fileInfo.Exists && !Directory.Exists(targetPath))
            {
                try { Directory.CreateDirectory(fileInfo.Directory.FullName); }

                catch(Exception e)
                {
                    Console.WriteLine("The target Path does not exist, and it's not possible to create " + e);
                    return false;
                }
            }

            return true;
        }
    }
}
