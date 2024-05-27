using BacklinkServer.LogManager;
using BacklinkServer.Proxies;
using BacklinkServer.Scraper;
using GoogleSearchResults;
using GoogleSearchResults.Google;
using Newtonsoft.Json;
using SuperSimpleTcp;
using System.Collections.Generic;

namespace BacklinkServer.TCP
{
    public class Receive
    {
        public string Licence { get; set; }
        public string Keyword { get; set; }
        public FocusedWebsites FocusedWebsites { get; set; }
    }
    public class ReceiveFuncs
    {
        public async static void Received(string json, SimpleTcpServer server, string IP)
        {
            List<GoogleSearchResult> results = new List<GoogleSearchResult>();
            Receive receive = JsonConvert.DeserializeObject<Receive>(json);
            ProxyOptions options = await Proxy.GetProxy();
            results =  await  GoogleScraper.Scrap(receive.Keyword, options, receive.FocusedWebsites);
            string finalResult = JsonConvert.SerializeObject(results);
            server.Send(IP,finalResult);
        }
    }
}
