# Backlink-Server
### This Project is abondoned. 

A TCP-based server to grab backlinks for specific keywords.
GoogleSearchResults Library used to grab google results. : https://github.com/maxmanusv1/GoogleSearchResults

It uses proxy to scrap google results. 

## Usage
```csharp
public class Send
{
    public string Licence { get; set; }
    public string Keyword { get; set; }
    public FocusedWebsites FocusedWebsites { get; set; }
}
// License does not matter for now.
// Specific keyword to scrape, e.g., betta fish
// Specific website/forum to scrape, e.g., FocusedWebsites.Xenforo
// Client that you created to connect to the server.
public void SendPacket(string licence, string keyword, FocusedWebsites websites, SimpleTcpClient client)
{
    var obj = new Send
    {
        Licence = licence,
        Keyword = keyword,
        FocusedWebsites = websites,
    };
        string json = JsonConvert.SerializeObject(obj);
        client.Send(json);
}
// You will receive it as a GoogleSearchResult object.
private void Events_DataReceived(object sender, DataReceivedEventArgs e)
{
    string input = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
    List<GoogleSearchResult> results = new List<GoogleSearchResult>();
    results = JsonConvert.DeserializeObject<List<GoogleSearchResult>>(input);
}      
```