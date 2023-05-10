using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipaddress;
        private readonly int port;
        private readonly TcpListener tcpListener;
        private const string NewLine = "\r\n";

        public HttpServer(IPAddress ipaddress, int port)
        {
            this.ipaddress = ipaddress;
            this.port = port;
            this.tcpListener = new TcpListener(ipaddress, port);
        }

        public void Start()
        {
            this.tcpListener.Start();
            Console.WriteLine($"Server started on port {this.port}");

            while (true)
            {
                TcpClient tcpClient = this.tcpListener.AcceptTcpClient();
                using NetworkStream networkStream = tcpClient.GetStream();
                string body = "<h1> Hello From the server :) </h1>";

                string response = "HTTP/1.1 200 OK" + NewLine + "Content-Type: text/html"
                     + NewLine + $"Date: {DateTime.Now.ToString("dd/mm/yyyy")}" + NewLine + "Server: Hello from Server" + NewLine + NewLine + body;
                string requestText = ReadRequest(networkStream);
                Console.WriteLine(requestText);
                WriteResponse(networkStream, response);
                networkStream.Close();
            }
        }
        private void WriteResponse(NetworkStream networkStream, string response)
        {
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            StringBuilder sb = new StringBuilder();

            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];
            int totalBytes = 0;

            while (networkStream.DataAvailable)
            {
                int bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;
                if(totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }
                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            return sb.ToString().Trim();
        }
    }
}
