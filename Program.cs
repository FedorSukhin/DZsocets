using DZsocets.Servise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZsocets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverIpStr = "127.0.0.1";
            int serverPort = 1024;
            Server server=new Server(serverIpStr, serverPort);
            Client client = new Client(serverIpStr,serverPort);
            Thread serverThread = new Thread(() => server.Start());
            Thread clientThread = new Thread(() => client.Start());

            serverThread.Start();
            clientThread.Start();
            
            serverThread.Join();
            clientThread.Join();


        }
    }
}
