using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Options
{
    public class FileConfig
    {
        public string Url { get; set; }

        public string AcceptKey { get; set; }   

        public string SecretKey { get; set; }

        public string MainBucket { get; set; }
    }
}
