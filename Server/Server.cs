using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetSharp
{
    internal enum TypeSend
    {
        ToAll,
        ToOne,
        defaultmes
    }
    internal class Server
    {
        private readonly UdpClient _udpClient;
        private IPEndPoint _iPEndPoint;
        private Manager _manager;
        public string Name { get => "Server-1"; }
        internal Dictionary<string, IPEndPoint> Users { get; set; }
        internal Dictionary<string, Message> unreadMes { get; set; }

        internal Server()
        {
            _udpClient = new UdpClient(12345);
            _iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _manager = new Manager(this);
        }

        internal Message Listen()
        {
            byte[] buffer = _udpClient.Receive(ref _iPEndPoint);
            var messageText = Encoding.UTF8.GetString(buffer);
            Message message = Message.DeserializeFromJson(messageText);
            message.Print();
            return message;
        }
     
        internal void Send(Message message)
        {
            byte[] mes = Encoding.UTF8.GetBytes(message.SerializeMessageToJson());
            if (Users.TryGetValue(message.NicknameTo, out IPEndPoint ep))
            {
                _udpClient.Send(mes, mes.Length, ep);
            }
            else
            {
                _udpClient.Send(mes, mes.Length, _iPEndPoint);
            }
        }

        internal void Reply ()
        {
            byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");
            int bytes =  _udpClient.Send(reply, reply.Length, _iPEndPoint);
            Console.WriteLine($"Отправлено {bytes} байт");
        }

        internal async Task Start()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("Сервер ждет сообщение от клиента...");

            while (!cts.IsCancellationRequested)
            {
                try
                {
                    var mes = Listen();
                    Manager.Execute(mes, _iPEndPoint);
                    Send(mes);
                    Reply();
                    if (mes.Text.Equals("exit")) cts.Cancel();
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString());}
            }

            Console.WriteLine("Сервер остановлен.");
            Console.ReadLine();
        }
    }
}
