using System.Net.Sockets;
using System.Net;
using NetSharp;
using System.Text;
using System.Net.Security;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

internal class Program
{
    static void Main(string[] args)
    {
        //Task1
        Thread tr1 = new Thread((sum => sum = Lesson2._arr1.Sum()));
        Thread tr2 = new Thread((sum => sum = Lesson2._arr2.Sum()));

        tr1.Start();
        tr2.Start();
        tr1.Join(1000); tr2.Join(1000);

        Console.WriteLine($"{Lesson2._sum1} : {Lesson2._sum2} : {Lesson2._sum1 + Lesson2._sum2}");

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
    }
}