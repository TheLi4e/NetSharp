﻿using System.Net.Sockets;
using System.Net;
using NetSharp;
using System.Text;
using System.Net.Security;

internal class Program
{
    static void Main(string[] args)
    {
        var server = new Server();
        server.Start();
    }
}