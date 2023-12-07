﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetSharp
{
    internal class UDPServer
    {
        public static void Server()
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Сервер ждет сообщение от клиента.");
            Console.WriteLine("Чтобы завершить работу сервера нажмите Enter.");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);

                Task.Run(()=> {
                    Message message = Message.DeserializeFromJson(messageText);
                    message.Print();

                    byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено.");
                    udpClient.Send(reply, reply.Length, iPEndPoint);
                    Console.WriteLine($"Отправлено {reply.Length}");
                });
            }
            Console.WriteLine("Сервер остановлен.");
            Console.ReadLine();
        }
    }
}
