using Drunk.Unicorn.RussPass.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.BI.Interfaces
{
    public interface ILocations
    {
        Task SetStatus(int locationId, int trackId, LocationStatusEnum status);
    }
}
