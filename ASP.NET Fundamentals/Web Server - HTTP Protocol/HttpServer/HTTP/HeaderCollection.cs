using System.Collections.Generic;

namespace HttpServer.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            this.headers = new Dictionary<string, Header>();
        }
        public int Count => this.headers.Count;

        public void Add(string headerName, string headerValue)
        {
            if (!this.headers.ContainsKey(headerName))
            {
                this.headers[headerName] = new Header(headerName, headerValue);
            }
        }
    }
}
