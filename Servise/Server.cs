using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DZsocets.Servise
{
    public class Server
    {
        private Socket server;
        private Socket client;
        byte[] buffer;
        int byteReader;
        public Server(string serverIpStr, int serverPort)
        {
            IPAddress serverIP = IPAddress.Parse(serverIpStr);
            IPEndPoint serverEndPoint = new IPEndPoint(serverIP, serverPort);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(serverEndPoint);
            server.Listen(1);
        }
        public void Start()
        {
            buffer = new byte[1024];
            try
            {
                Console.WriteLine("Server start");
                this.client = server.Accept();

                int byteRead = client.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Client: {message}");

                message = $"Hello, can I help you?";
                client.Send(Encoding.UTF8.GetBytes(message));



                byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Client: {message}");


                message = $"Unfortunately not";
                client.Send(Encoding.UTF8.GetBytes(message));


                byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Client: {message}");

                message = $"GoodBye";
                client.Send(Encoding.UTF8.GetBytes(message));


                byteRead = client.Receive(buffer);
                message = Encoding.UTF8.GetString(buffer, 0, byteRead);
                Console.WriteLine($"Client: {message}");


                client.Shutdown(SocketShutdown.Both);
                Console.WriteLine("server> Завершение работы сервера ...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"server> При работе сервера возникло исключение: {ex.Message} ");
            }
            finally
            {
                // закрыть сокеты
                server?.Close();
                client?.Close();
            }
        }
    }
}
