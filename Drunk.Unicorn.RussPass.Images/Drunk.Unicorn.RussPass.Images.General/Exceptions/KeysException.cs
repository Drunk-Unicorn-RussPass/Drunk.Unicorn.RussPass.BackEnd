using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.General.Exceptions
{
    public class KeysException : Exception
    {
        public KeysException(string errorMessage) : base(errorMessage) { }

    }
}
