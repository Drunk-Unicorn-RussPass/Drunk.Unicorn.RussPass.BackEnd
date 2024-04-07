using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Tracks.Data.Models
{
    public class TaskTrack
    {
        public int IdTrack { get; set; }

        public int IdPoint { get; set; }

        public string Task { get; set; }

        public string Advice { get; set; }
    }

    /// <summary>
    /// абстракция
    /// </summary>
    public class Point
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public long Duraction { get; set; }

        public string Category { get; set; }

        public PointType Type { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string Image { get; set; }
    }

    public class Cafe : Point
    {
        public int Rating { get; set; }
    }

    public class Location : Point
    {
        public bool IsVisable { get; set; }

        public bool IsSecret { get; set; }

        public int Reward { get; set; }
    }

    public enum PointType
    {
        Location,
        Cafe,
        Excursion
    }
}
