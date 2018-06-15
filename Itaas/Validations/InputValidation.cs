using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Itaas.Validations
{
    public class InputValidation
    {
        public bool VerifyPathExists(string targetPath)
        {
            

            if (!Directory.Exists(targetPath))
            {
                try
                {
                    Directory.CreateDirectory(targetPath);
                }
                catch
                {
                    Console.WriteLine("The does not exist, and it's not possible to create");
                }
            }

            return true;
        }
    }
}
