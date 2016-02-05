using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
