using GoogleSearchResults;
using GoogleSearchResults.Google;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BacklinkServer.Scraper
{
    public class GoogleScraper
    {
        public async static Task<List<GoogleSearchResult>> Scrap(string queryKeyword, ProxyOptions options, FocusedWebsites websites)
        {
            var obj = new GoogleSearch();
            List<GoogleSearchResult> searchResults = new List<GoogleSearchResult>();
            searchResults = await obj.GetSearchResults(queryKeyword,30,3, options, SearchOptions.Backlink, websites);
            return searchResults;
        }

    }
}
