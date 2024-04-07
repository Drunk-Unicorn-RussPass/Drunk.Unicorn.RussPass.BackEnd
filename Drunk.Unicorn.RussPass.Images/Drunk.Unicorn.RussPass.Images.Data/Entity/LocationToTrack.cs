using Drunk.Unicorn.RussPass.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Drunk.Unicorn.RussPass.Images.Data.Entity
{
    public class LocationToTrack : Base
    {
        public int Status { get; set; }

        public int LocationId { get; set; }

        public int TrackId { get; set; }
    }
}
