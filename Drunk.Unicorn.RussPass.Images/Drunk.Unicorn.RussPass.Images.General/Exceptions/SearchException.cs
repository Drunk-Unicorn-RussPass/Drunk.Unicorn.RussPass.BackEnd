using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.General.Exceptions
{
    public class SearchException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public SearchException(string errorMessage, HttpStatusCode statusCode) : base(errorMessage)
        {
            StatusCode = statusCode;
        }
    }
}
