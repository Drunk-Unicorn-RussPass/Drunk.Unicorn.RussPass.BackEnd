using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.Data.Models;
using Drunk.Unicorn.RussPass.Users.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Services
{
    public class ProcessTrackService : IProcessTrackService, IProcessLocation, IProcessAdmin
    {
        private readonly ServiceDbContext _dbContext;

        public ProcessTrackService(ServiceDbContext context)
        {
            _dbContext = context;
        }

        public Task<ProcessLocation> GetProcessLocation(int id)
        {
            return _dbContext.ProcessLocations.FirstOrDefaultAsync(x => x.LocationId == id);
        }

        public Task<List<ProcessLocation>> GetProcessLocations(int[] ids)
        {
            return _dbContext.ProcessLocations.Where(x => ids.Any(y => y == x.LocationId)).ToListAsync();
        }

        public Task<ProcessTrack> GetProcessTrack(int id)
        {
            return _dbContext.ProcessTracks.FirstOrDefaultAsync(x => x.TrackId == id);
        }

        public Task<List<ProcessTrack>> GetProcessTracks(int[] ids)
        {
            return _dbContext.ProcessTracks.Where(x => ids.Any(y => y == x.TrackId)).ToListAsync();
        }

        public async Task SetStatusLocation(int locationId, ProcessStatus status)
        {
            var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == locationId);

            location.Status = (int)status;

            _dbContext.Update(location);
            await _dbContext.SaveChangesAsync();
        }
    }
}
