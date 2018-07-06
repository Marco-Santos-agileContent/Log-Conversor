using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Itaas.Validations
{
    public static class InputValidation
    {
        public static bool VerifyUrl(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }

        public static Tuple<string, bool> VerifyPath(string targetPath)
        {
            string errorMessage = "";

            try
            {
                Path.GetFullPath(targetPath);
            }
            catch(PathTooLongException)
            {
                errorMessage = "The path is too big. Please keep it under Windows's 260 max chars limit.";
                return Tuple.Create(errorMessage, false);
            }
            catch
            {
                errorMessage = "There's a problem with the target Path.";
                return Tuple.Create(errorMessage, false);
            }

            if (targetPath == "")
            {
                errorMessage = "Path Cannot be null";
                return Tuple.Create(errorMessage, false);
            }

            FileInfo fileInfo = new FileInfo(targetPath);

            if (!fileInfo.Exists && !Directory.Exists(targetPath))
            {
                try { Directory.CreateDirectory(fileInfo.Directory.FullName); }

                catch (Exception e)
                {
                    errorMessage = "The target Path does not exist, and it's not possible to create.";
                    return Tuple.Create(errorMessage, false);
                }
            }

            return Tuple.Create(errorMessage, true);
        }
    }
}