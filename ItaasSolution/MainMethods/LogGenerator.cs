using ItaasSolution.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Itaas.MainMethods
{
    public class LogGenerator
    {
        public string targetPath;
        public string SourceUrl;

        StreamWriter sw;

        public LogGenerator(string sourceUrl, string targetPath)
        {

        }

        private void LogHeader()
        {
            sw = File.AppendText(targetPath);
            sw.WriteLine("#Version: 1.0");
            sw.WriteLine("#Date: " + DateTime.Now);
            sw.WriteLine("#Fields:    provider    http-method    status-code    uri-path    time-taken    response-size    cache-status");
        }

        private void LogBody()
        {
            var convertor = new Convertor();
            //convertor.ConvertToCDNFormat();
        }

        public bool GenerateCDNLog(string sourceUrl, string targetPath)
        {
        
            try
            {
                var client = new WebClient();
                using (var stream = client.OpenRead(sourceUrl))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    //reader.

                    try
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            //sw.WriteLine(ConvertToCDNFormat(line));
                        }
                    }
                    catch
                    {
                        sw.Close();
                        Helper.ErrorMessage = "Error while writing the File";
                        return false;
                    }
                }
            }
            catch
            {
                Helper.ErrorMessage = "Error when connecting to the Url";
                return false;
            }

            sw.Close();
            return true;
        }


    }
}

