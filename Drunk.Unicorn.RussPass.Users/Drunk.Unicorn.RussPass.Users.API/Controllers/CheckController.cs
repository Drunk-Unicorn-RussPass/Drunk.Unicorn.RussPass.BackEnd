using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CheckController : ControllerBase
    {
        private readonly ILogger<CheckController> _logger;
        private readonly IMapper _mapper;
        private readonly ICheck _checker;

        public CheckController(ILogger<CheckController> logger, IMapper mapper, ICheck checker)
        {
            _logger = logger;
            _mapper = mapper;
            _checker = checker;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FileChecker checker)
        {
            if (checker.File == null || checker.File.Length == 0)
                return BadRequest("Данные о файле недоступны!");

            await _checker.SendImage(checker.File.OpenReadStream(), checker.File.FileName, checker.LocationId, checker.TrackId);

            return Ok();
        }
    }
}
