using System;

namespace HttpServer.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode, string body)
        {
            StatusCode = statusCode;
            Headers = new HeaderCollection();
            Headers.Add("Server", "My Web Server");
            Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }
        public StatusCode StatusCode { get; set; }
        public HeaderCollection Headers { get; }
        public string Body { get; set; }

    }
}
