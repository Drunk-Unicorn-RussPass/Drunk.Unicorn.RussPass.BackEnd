using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Interfaces
{
    public interface ICheck
    {
        Task SendImage(Stream image, string fileName, int locationId, int trackId);
    }
}
