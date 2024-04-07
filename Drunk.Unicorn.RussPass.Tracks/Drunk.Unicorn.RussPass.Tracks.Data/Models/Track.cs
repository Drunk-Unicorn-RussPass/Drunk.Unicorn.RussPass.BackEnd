using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Tracks.Data.Models
{

    public enum TrackStatus
    {
        Processing,
        Edit,
        None
    }

    public enum TrackType
    {
        Secret1,
        Secret2,
        Secret3,
        None,
        WithSecrets
    }

    public class Track
    {
        public bool IsInclusivity { get; set; }

        public TrackStatus Status { get; set; }

        /// <summary>
        /// Продолжительность /Часы
        /// </summary>
        public int Duraction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Distance { get; set; }

        public TrackType Type { get; set; }

        public List<Point> Points { get; set; }
    }

    public class SecretTrack : Track
    {
        public int CountPoints { get; set; }
    }
}
