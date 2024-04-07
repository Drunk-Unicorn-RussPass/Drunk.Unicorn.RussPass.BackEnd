using Drunk.Unicorn.RussPass.Data.Enums;
using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.BI.Services
{
    public class LocationsService : ILocations
    {
        private readonly ServiceDbContext _context;

        public LocationsService(ServiceDbContext context)
        {
            _context = context;
        }

        public async Task SetStatus(int locationId, int trackId, LocationStatusEnum status)
        {
            var locationToTrack = _context.LocationsProcess.FirstOrDefault(x => x.TrackId == trackId && x.LocationId ==  locationId);
            locationToTrack.Status = (int)status;
            _context.Update(locationToTrack);
            await _context.SaveChangesAsync();
        }
    }
}
