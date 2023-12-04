using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetSharp
{
    internal class UDPServer
    {
        public void Task1()
        {
            Message messages = new Message() { Text = "Hello!", DateTime = DateTime.Now, NickNameFrom = "Li4e", NickNameTo = "All" };
            string json = messages.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msgDeserialized = Message.DeserializeFromJson(json);
        }
        public static void Server(string name)
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер ждет сообщение от клиента");
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                if (buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);
                Message message = Message.DeserializeFromJson(messageText);
                message.Print();
            }
        }
    }
}
