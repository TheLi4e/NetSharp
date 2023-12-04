using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetSharp
{
    internal class Lesson3
    {
        //Task1
        //Напише приложение для одновременного выполнения двух задач в потоках созданных с помощью  Task.
        //Нужно подсчитать сумму элементов каждого из массивов а потом сложить эти суммы полученные после
        //выполнения каждого из потоков и вывести результат на экран.

        public static int _sum1 = 0;
        public static int _sum2 = 0;

        public static int[] _arr1 = { 1, 5, 8, 8, 7, 1, 7, 6, 4 };
        public static int[] _arr2 = { 1, 9, 2, 3, 1, 4, 6, 4, 4 };

        public static async Task<int> Task1()
        {
            return await Task.Run(() => _arr1.Sum());
        }
        public static async Task<int> Task2()
        {
            return await Task.Run(() => _arr2.Sum());
        }



        //Task2
        //Напишите многопоточное приложение, которое определяет все IP-адреса интернет-ресурса
        //и определяет до которого из них лучше Ping. Приложение должно работать с помощью Task.


        public static async Task Task3()
        {
            const string sait = "yandex.ru";

            IPAddress[] iPAddress = Dns.GetHostAddresses(sait, System.Net.Sockets.AddressFamily.InterNetwork);

            foreach (var item in iPAddress)
            {
                Console.WriteLine(item);
            }

            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();

            List<Task> tasks = new List<Task>();
            foreach (var item in iPAddress)
            {
                var task1 = Task.Run(async () =>
                {
                    Ping p = new Ping();
                    PingReply pingReply = await p.SendPingAsync(item);
                    pings.Add(item, pingReply.RoundtripTime);
                    Console.WriteLine($"{item} : {pingReply.RoundtripTime}");
                });
                tasks.Add(task1);
            }

            Task.WaitAll(tasks.ToArray());

            long minPing = pings.Min(x => x.Value);

            Console.WriteLine($"Минимальный пинг = {minPing}");
        }

        //Task3
        //Добавляем многопоточность в чат позволяя серверной части получать
        //сообщения сразу от нескольких респондентов.Перепишем многопоточность с помощью Task
    }
}
