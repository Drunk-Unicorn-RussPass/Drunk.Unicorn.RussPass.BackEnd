using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.BI.Services;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Reflection;

namespace Neironka.Controllers
{
    [ApiController]
    [Route("user")]
    public class AIController : ControllerBase
    {
        private ConcurrentDictionary<int, string> Locations = new ConcurrentDictionary<int, string>();

        private readonly ILogger<AIController> _logger;
        private readonly ISearch _search;
        private readonly ICheck _checker;

        public AIController(ILogger<AIController> logger, ICheck checker, ISearch search)
        {
            Locations.TryAdd(1, "парк горького");
            Locations.TryAdd(2, "памятник единорожки");
            Locations.TryAdd(3, "крымский мост");
            Locations.TryAdd(4, "non solo");
            Locations.TryAdd(5, "музей парка горького");
            Locations.TryAdd(6, "мгу");

            _checker = checker;
            _search = search;
            _logger = logger;
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> Get([FromForm] FileChecker checker)
        {
            if (checker.File == null || checker.File.Length == 0)
                return BadRequest("Данные о файле недоступны!");


            using var memoryStream = new MemoryStream();
            checker.File.CopyTo(memoryStream);
            memoryStream.Position = 0;

            var link = await _checker.SendImageReturnUrl(memoryStream, checker.File.FileName);

            if (!Locations.TryGetValue(checker.LocationId, out string locationName))
                return BadRequest();
            
            if(await _search.FindImageAsync(new Drunk.Unicorn.RussPass.Images.Data.Models.YandexSearch()
            {
                Url = link,
                Key = "ea2639ac3bc4e56a8d4562815f39aaa4ec6b178166ebe0262fa3980b50d3b695",
                LocationName = locationName,
            }))
                return Ok();

            return BadRequest();
        }
    }

    public class FileChecker
    {
        public IFormFile File { get; set; }

        public int LocationId { get; set; }

        public int TrackId { get; set; }
    }
}