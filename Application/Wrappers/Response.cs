using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Message = message;
            Data = data;
        }
        public Response(string message = null)
        {
            Message = message;
        }

        public bool Succeded { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
