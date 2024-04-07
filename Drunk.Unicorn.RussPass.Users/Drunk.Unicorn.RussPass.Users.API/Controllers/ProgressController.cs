using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.Data.Models;
using HotChocolate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly ILogger<ProgressController> _logger;
        private readonly IProcessLocation _locations;
        private readonly IProcessTrackService _tracks;

        public ProgressController(ILogger<ProgressController> logger, IProcessLocation locations, IProcessTrackService tracks)
        {
            _logger = logger;
            _locations = locations;
            _tracks = tracks;
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetStatusLocation([FromQuery] int locationId)
        {
            return Ok(await _locations.GetProcessLocation(locationId));
        }


        [HttpGet("locations")]
        public async Task<IActionResult> GetStatusLocations([FromQuery] int[] locationIds)
        {
            return Ok(await _locations.GetProcessLocations(locationIds));
        }


        [HttpGet("track")]
        public async Task<IActionResult> GetStatusTrack([FromQuery] int trackId)
        {
            return Ok(await _tracks.GetProcessTrack(trackId));
        }


        [HttpGet("tracks")]
        public async Task<IActionResult> GetStatusTracks([FromQuery] int[] trackIds)
        {
            return Ok(await _tracks.GetProcessTracks(trackIds));
        }
    }
}
