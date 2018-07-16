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
        public string sourceUrl;
        public StreamReader reader;
        private StreamWriter _sw;

        public LogGenerator(string sourceUrl, string targetPath)
        {
            this.targetPath = targetPath;
            this.sourceUrl = sourceUrl;
            _sw = File.AppendText(targetPath);
        }

        private void LogHeader()
        {
            _sw.WriteLine("#Version: 1.0");
            _sw.WriteLine("#Date: " + DateTime.Now);
            _sw.WriteLine("#Fields:    provider    http-method    status-code    uri-path    time-taken    response-size    cache-status");
        }

        private string LogBody(string line)
        {
            string convertedLine = Convertor.ConvertToCDNFormat(line);
            return convertedLine;
        }

        public void OpenConection()
        {
            try
            {
                var client = new WebClient();
                var stream = client.OpenRead(sourceUrl);
                reader = new StreamReader(stream);
            }
            catch
            {
                Helper.ErrorMessage = "There's a problem when reading the Url Text";
            }
        }

        public bool GenerateCDNLog()
        {
            LogHeader();
            OpenConection();
            string line;

            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    _sw.WriteLine(LogBody(line));
                }
            }
            catch
            {
                _sw.Close();
                Helper.ErrorMessage = "Error while writing the File";
                return false;
            }
            _sw.Close();
            return true;
        }
    }
}
