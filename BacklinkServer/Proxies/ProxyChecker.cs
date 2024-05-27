using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BacklinkServer.LogManager;
namespace BacklinkServer.Proxies
{
    public class ProxyChecker
    {
		public readonly static string testURL = "https://www.google.com/";
        public async static Task<bool> CheckProxy(ProxySettings proxy)
        {
			try
			{
				string buildProxy = "http://"+proxy.ProxyIP + ":" + proxy.ProxyPort;	
				WebProxy webProxy = new WebProxy(buildProxy)
				{
					Credentials = new NetworkCredential(proxy.Username,proxy.Password)
				};
				WebRequest request = WebRequest.Create(testURL);
				request.Proxy = webProxy;
				using (WebResponse response = request.GetResponse())
				{
                    Logger.Log(ELogTypes.Succesfully, $"Succesfully connected on ---  {buildProxy} ");
                    return true;
				}
			}
			catch (Exception e)
			{
				Logger.Log(ELogTypes.Error, $"BAD PROXY / UNSUCCESFULL CONNECT ---  {e.Message} " );
				return false;
			}
        }
    }
}
