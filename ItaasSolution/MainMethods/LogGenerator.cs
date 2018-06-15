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

            StreamWriter writer = File.AppendText(targetPath);
            writer.WriteLine("#Version: 1.0");
            writer.WriteLine("#Date: " + DateTime.Now);
            writer.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size");
            writer.WriteLine("cache-status");
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
                            writer.WriteLine(ConvertToCDNFormat(line));
                        }
                    }
                    catch
                    {
                        writer.Close();
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

            writer.Close();
            return true;

        }
    }
}

