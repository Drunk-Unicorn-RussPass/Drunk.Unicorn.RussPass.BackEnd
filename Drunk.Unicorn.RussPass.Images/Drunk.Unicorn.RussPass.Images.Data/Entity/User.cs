using Drunk.Unicorn.RussPass.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Drunk.Unicorn.RussPass.Points.Data.Entity
{
    public class LocationStatus : Base
    {
        [Column(TypeName = "varchar(24)")]
        public LocationStatusEnum Status { get; set; }
    }
}
