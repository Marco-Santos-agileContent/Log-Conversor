using ItaasSolution;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Itaas.MainMethods
{
    public static class Convertor
    {   
        public static string ConvertToCDNFormat(string line)
        {
            List<string> SplitedFileds = line.Split('|').ToList();
            SplitedFileds.AddRange(SplitedFileds[3].Split(' '));

            LogProperties.Provider = "\"Minha CDN\"";
            LogProperties.CacheStatus = SplitedFileds[2];
            LogProperties.HttpMethod = SplitedFileds[5].Remove(0,1);
            LogProperties.ResponseSize = SplitedFileds[0];
            LogProperties.StatusCode = SplitedFileds[1];
            LogProperties.TimeTaken = SplitedFileds[4];
            LogProperties.UriPath = SplitedFileds[6];

            if (LogProperties.CacheStatus == "INVALIDATE")
                LogProperties.CacheStatus = "REFRESH_HIT";

            LogProperties.TimeTaken = String.Format("{0:0}", float.Parse(LogProperties.TimeTaken, CultureInfo.InvariantCulture.NumberFormat));

            string agoraFormat = $"{LogProperties.Provider}    {LogProperties.HttpMethod}    {LogProperties.StatusCode}" +
                $"    {LogProperties.UriPath}    {LogProperties.TimeTaken}    {LogProperties.ResponseSize}    {LogProperties.CacheStatus}";
            
            return agoraFormat;
        }

    }
}