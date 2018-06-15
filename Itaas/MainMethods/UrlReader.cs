using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Itaas.MainMethods
{
    public partial class Convertor
    {

        public bool ConvertToCDNFormat(string sourceUrl, string targetPath)
        {
            try
            {
                StreamWriter writer = File.AppendText(targetPath);
                writer.WriteLine("#Version: 1.0");
                writer.WriteLine("#Date: " + DateTime.Now);
                writer.WriteLine("#Fields: provider http-method status-code uri-path time-taken response-size");
                writer.WriteLine("cache-status");

                    var client = new WebClient();
                    using (var stream = client.OpenRead(sourceUrl))
                    using (var reader = new StreamReader(stream))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(Format(line));
                        }

                    }
                    writer.Close();
                    return true;
        }
            catch
            {
                Console.WriteLine("The url or the target path");
                return false;
            }
}
    }
}
