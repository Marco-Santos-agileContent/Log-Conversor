using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItaasSolution
{
    public static class LogProperties
    {
        public static string Provider { get; set; }
        public static string HttpMethod { get; set; }
        public static string StatusCode { get; set; }
        public static string UriPath { get; set; }
        public static string TimeTaken { get; set; }
        public static string ResponseSize { get; set; }
        public static string CacheStatus { get; set; }
    }
}
