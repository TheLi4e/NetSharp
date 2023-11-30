using Client;

internal class Program
{
    static void Main(string[] args)
    {
        UDPClient.SendMessage(args[0], args[1]);
    }
}