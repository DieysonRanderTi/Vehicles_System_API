using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Response
{
    public class ResultResponse<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public IList<Errors> Erros { get; set; }
        public HttpStatusCode? StatusCode { get; set; }

        public class Errors
        {
            public Guid Id { get; set; }
            public string Message { get; set; }
            public string Details { get; set; }

        }
    }
}
