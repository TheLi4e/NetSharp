using NetSharp;
using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Client
{
    internal class UDPClient
    {
        public static void SendMessage(string from, string ip = "127.0.0.1")
        {

            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            bool run = true;
            Console.WriteLine("Добро пожаловать в чат.");
            while (run)
            {
                Console.Write("Если Вы хотите отправить сообщение -" +
                    " введите go. Если хотите выйти - введите exit: ");
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "go":
                        Console.Write("Введите сообщение: ");
                        string messageText = Console.ReadLine().ToLower();

                        Message message = new() { Text = messageText, DateTime = DateTime.Now, NickNameFrom = from, NickNameTo = "Server" };
                        string json = message.SerializeMessageToJson();

                        var data = Encoding.UTF8.GetBytes(json);
                        udpClient.Send(data, data.Length, iPEndPoint);
                        Console.WriteLine($"Отправлено {data.Length} байт.");

                        byte[] buffer = udpClient.Receive(ref iPEndPoint);
                        var answer = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine(answer);
                        break;
                    case "exit":
                        run = false;
                        Console.WriteLine("Чат завершает работу...");
                        break;
                    default: 
                        Console.WriteLine("Неправильная команда. Попробуйте снова.");
                        break;

                }

                    
                
            }
        }
    }
}
