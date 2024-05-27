using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BacklinkServer.LogManager;
using SuperSimpleTcp;

namespace BacklinkServer.TCP
{
    public class TCPFuncs
    {
        SimpleTcpServer server = new SimpleTcpServer(IPAddress.Any.ToString(), 5566);
        public async Task MainTCP()
        {
            server.Events.ClientConnected += ServerEvents_ClientConnected;
            server.Events.DataReceived += ServerEvents_DataReceived;
            server.Events.ClientDisconnected += ServerEvents_ClientDisconnected;
            server.Events.DataSent += ServerEvents_DataSent;
            server.Start();
            Logger.Log(ELogTypes.Succesfully, $"Succesfully created TCP Server at {server.IpAddress}");
        }

        private void ServerEvents_DataSent(object sender, DataSentEventArgs e)
        {
            Logger.Log(ELogTypes.Information, "Data succesfully transfered to " + e.IpPort);
        }

        private void ServerEvents_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            Logger.Log(ELogTypes.Warning, "Client disconnected " + e.IpPort.ToString());

        }

        private void ServerEvents_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string input = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
            Logger.Log(ELogTypes.Information, $"Data received {e.IpPort} " + input);
            if(!string.IsNullOrEmpty(input)) ReceiveFuncs.Received(input,server,e.IpPort);  
        }

        private void ServerEvents_ClientConnected(object sender, ConnectionEventArgs e)
        {
            Logger.Log(ELogTypes.Information, "Client connected " + e.IpPort.ToString());
        }
    }
}
