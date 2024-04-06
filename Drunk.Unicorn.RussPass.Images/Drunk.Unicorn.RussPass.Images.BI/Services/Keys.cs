using Drunk.Unicorn.RussPass.Images.BI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.BI.Services
{
    public class Keys
    {
        private readonly IEnumerator<string> _keys;

        public Keys(Config config)
        {
            _keys = Enumerat config.SerpKeys;
        }
    }
}
