using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.General.Exceptions
{
    public class SearchKeyNotValidException : SearchException
    {
        public SearchKeyNotValidException(string errorMessage, HttpStatusCode statusCode) : base(errorMessage, statusCode) { }
    }
}
