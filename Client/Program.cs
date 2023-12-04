using Client;

internal class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            UDPClient.SendMessage("Li4e", i);
        }
        Console.ReadKey();

    }
}