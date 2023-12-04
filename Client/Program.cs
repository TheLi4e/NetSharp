using Client;

internal class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
           int num  = i;    
           new Task(()=> UDPClient.SendMessage("Li4e", num)).RunSynchronously();
        }
        Console.ReadKey();
    }
}