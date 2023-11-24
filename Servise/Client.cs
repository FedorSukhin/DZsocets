using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZsocets.Servise
{
    public class Client
    {
        Socket client;
        byte[] buffer;
        public Client(string serverIpStr, int serverPort)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPAddress serverIp = IPAddress.Parse(serverIpStr);
            IPEndPoint serverEndpoint = new IPEndPoint(serverIp, serverPort);
            client.Connect(serverEndpoint);

        }
        public void Start()
        {
            buffer = new byte[1024];
            try
            {
                //  Thread.Sleep(1000);
                Console.WriteLine("Client start");
                string message = $"(Client intered)";
                client.Send(Encoding.UTF8.GetBytes(message));

                int byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Server: {message}");


                message = $"I need some bread";
                client.Send(Encoding.UTF8.GetBytes(message));


                byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Server: {message}");


                message = $"Very bad";
                client.Send(Encoding.UTF8.GetBytes(message));


                byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Server: {message}");

                message = $"GoodBye";
                client.Send(Encoding.UTF8.GetBytes(message));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"server> При работе сервера возникло исключение: {ex.Message} ");
            }
            finally
            {
                // закрыть сокеты

                client?.Close();
            }

        }
    }
}
