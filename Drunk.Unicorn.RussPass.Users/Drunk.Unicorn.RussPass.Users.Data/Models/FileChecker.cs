using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.Data.Models
{
    public class FileChecker
    {
        public IFormFile File { get; set; }

        public int LocationId { get; set; }

        public int TrackId { get; set; }
    }
}
