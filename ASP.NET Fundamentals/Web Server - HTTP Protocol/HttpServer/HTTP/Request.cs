using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpServer.HTTP
{
    public class Request
    {
        public HttpMethod Method { get; set; }
        public string Url { get; set; }
        public HeaderCollection Headers { get; private set; }
        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            string[] lines = request.Split("\r\n");
            string[] startLine = lines[0].Split(' ');
            HttpMethod method = ParseMethod(startLine[0]);
            string url = startLine[1];
            HeaderCollection headers = ParseHeaders(lines.Skip(1));
            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray();
            string body = string.Join("\r\n", bodyLines);

            return new Request()
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> collection)
        {
            HeaderCollection headerCollection = new HeaderCollection();
            foreach (string item in collection)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    break;
                }
                string[] headers = item.Split(":", 2);
                if (headers.Length != 2)
                {
                    throw new InvalidOperationException("Invalid Request!");
                }
                string headerName = headers[0];
                string headerValue = headers[1];
                headerCollection.Add(headerName, headerValue);
            }
            return headerCollection;
        }

        private static HttpMethod ParseMethod(string method)
        {
            try
            {
                return (HttpMethod)Enum.Parse(typeof(HttpMethod), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{method}' is not supported.");
            }
        }
    }
}
