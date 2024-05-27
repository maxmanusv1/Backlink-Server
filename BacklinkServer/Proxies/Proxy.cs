using GoogleSearchResults.Google;
using System;
using System.IO;
using System.Runtime;
using System.Threading.Tasks;

namespace BacklinkServer.Proxies
{
    public class Proxy
    {
        static readonly string proxyPath = @"ProxyList.txt";
        public async static Task<ProxyOptions> GetProxy()
        {
            ProxyOptions options;
            ProxySettings settings = await RandomizeProxy();
            if (settings !=null)
            {
                options = new ProxyOptions {
                    IP = settings.ProxyIP, Port = settings.ProxyPort, Username = settings.Username, Password = settings.Password, UseProxy = true
                };
                return options;
            }
            return null;
        } 
        public async static Task<ProxySettings> RandomizeProxy()
        {
            bool checkerResult;
            Random random = new Random();
            ProxySettings settings;
            string[] lines = File.ReadAllLines(proxyPath);
            int attemptCounter = 0;
            do
            {
                int randomizedNumber = random.Next(0, lines.Length - 1);
                string[] splittedProxy = lines[randomizedNumber].Split(':');
                settings = new ProxySettings
                {
                    ProxyIP = splittedProxy[0],
                    ProxyPort = splittedProxy[1],
                    Username = splittedProxy[2],
                    Password = splittedProxy[3]
                };
                checkerResult = await ProxyChecker.CheckProxy(settings);
                if (checkerResult)
                    return settings;
                attemptCounter++;
            } while (attemptCounter <= 10);
            return null;
        }
    }
}
