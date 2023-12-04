using System.Net.Sockets;
using System.Net;
using NetSharp;
using System.Text;
using System.Net.Security;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

internal class Program
{
    static async Task Main(string[] args)
    {
        //Task1
        var Task1 = Lesson3.Task1();
        var Task2 = Lesson3.Task2();
        int num1 = Task1.Result;
        int num2 = await Task2;
        Console.WriteLine(num1 + num2);

        Console.WriteLine($"{num1} + {num2} = {num1+num2}");


        ////Task2
        //const string sait = "yandex.ru";

        //IPAddress[] iPAddress = Dns.GetHostAddresses(sait, System.Net.Sockets.AddressFamily.InterNetwork);


        //foreach (var item in iPAddress)
        //{
        //    Thread tr = new Thread(() =>
        //    {
        //        Ping ping = new Ping();
        //        PingReply pr = ping.Send(item);
        //        pings.Add(item, pr.RoundtripTime);
        //        Console.WriteLine($"{item} {pr.RoundtripTime}");

        //    });
        //    tr.Start();
        //    tr.Join();
        //}

        Lesson3.Task3();
    }
}