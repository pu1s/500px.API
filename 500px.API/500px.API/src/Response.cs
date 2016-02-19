
using System.Net;

namespace _500px.API
{
    public class Response
    {
        public string Content { get; set; }
        public string Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
