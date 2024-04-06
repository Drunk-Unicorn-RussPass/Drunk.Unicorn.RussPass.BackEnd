using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PrimaryTypeAttribute : Attribute
    {

        public PrimaryTypeAttribute()
        {

        }
    }
}
