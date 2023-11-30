using NetSharp;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    internal class UDPClient
    {
        public static void SendMessage(string from, string ip)
        {

            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                string messageText;
                do
                {
                    Console.Clear();
                    Console.Write("Введите сообщение: ");
                    messageText = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(messageText));

                Message message = new() { Text = messageText, DateTime = DateTime.Now, NickNameFrom = "Li4e", NickNameTo = "Server" };
                string json = message.SerializeMessageToJson();
                var data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);
            }
        }
    }
}
