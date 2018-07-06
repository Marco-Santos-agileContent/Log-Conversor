using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Itaas.MainMethods
{
    public class LogGenerator : Convertor
    {

        public bool GenerateCDNLog(string sourceUrl, string targetPath)
        {

            StreamWriter fileWriter = File.AppendText(targetPath);
            fileWriter.WriteLine("#Version: 1.0");
            fileWriter.WriteLine("#Date: " + DateTime.Now);
            fileWriter.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");
        
            try
            {
                var client = new WebClient();
                using (var stream = client.OpenRead(sourceUrl))
                using (var reader = new StreamReader(stream))
                {
                    string line;

                    try
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            fileWriter.WriteLine(ConvertToCDNFormat(line));
                        }
                    }
                    catch
                    {
                        fileWriter.Close();
                        Console.WriteLine("Error while writing the File");
                        return false;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error when connecting to the Url");
                return false;
            }

            fileWriter.Close();
            return true;

        }
    }
}

