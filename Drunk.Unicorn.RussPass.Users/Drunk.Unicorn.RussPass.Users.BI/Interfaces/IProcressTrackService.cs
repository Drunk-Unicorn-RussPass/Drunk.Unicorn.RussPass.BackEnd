using Drunk.Unicorn.RussPass.Users.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Interfaces
{
    public interface IProcessLocation
    {
        Task<ProcessLocation> GetProcessLocation(int id);

        Task<List<ProcessLocation>> GetProcessLocations(int[] ids);
    }

    public interface IProcessTrackService
    {
        Task<ProcessTrack> GetProcessTrack(int id);

        Task<List<ProcessTrack>> GetProcessTracks(int[] ids);
    }

    public interface IProcessAdmin
    {
        Task SetStatusLocation(int locationId, ProcessStatus status);
    }
}
