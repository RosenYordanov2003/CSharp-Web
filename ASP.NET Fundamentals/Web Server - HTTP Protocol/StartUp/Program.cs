using System;
using System.Net;
namespace Basic_Web_Server
{
    using HttpServer;
    public class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(IPAddress.Loopback, 8080);
            server.Start();
        }
    }
}
