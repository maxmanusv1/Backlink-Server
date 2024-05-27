using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacklinkServer.Proxies;
using BacklinkServer.Scraper;
using BacklinkServer.TCP;
using GoogleSearchResults.Google;

namespace BacklinkServer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TCPFuncs funcs = new TCPFuncs();
            await funcs.MainTCP();

            Console.ReadKey();
        }
    }
}
