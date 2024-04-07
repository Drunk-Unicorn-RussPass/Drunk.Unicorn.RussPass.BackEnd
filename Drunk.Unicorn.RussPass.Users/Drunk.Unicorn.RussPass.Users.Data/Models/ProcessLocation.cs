using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.Data.Models
{
    public class ProcessTrack
    {
        public int TrackId { get; set; }

        public int PassedCoins { get; set; }

        public int PassedSecrets { get; set; }

        public ProcessStatusTrack Status { get; set; }

        public int CountPassedLocations { get; set; }

        public int Steps { get; set; }

        public int Kk { get; set; }
    }

    public class ProcessLocation
    {
        public int LocationId { get; set; }

        public ProcessStatus Status { get; set; }

        public bool InVisible { get; set; }

        public int Order { get; set; }
    }


    public enum ProcessStatusTrack
    {
        /// <summary>
        /// Нет статуса
        /// </summary>
        None,
        /// <summary>
        /// Маршрут в процессе
        /// </summary>
        Processing,
        /// <summary>
        /// Завершен
        /// </summary>
        Passed
    }

    public enum ProcessStatus
    {
        /// <summary>
        /// Нет статуса
        /// </summary>
        None = 100,
        /// <summary>
        /// Пользователь в пути до данной точки
        /// </summary>
        Inway = 50,
        /// <summary>
        /// В процессе чек-ина
        /// </summary>
        Processing = 20,
        /// <summary>
        /// Ошибка
        /// </summary>
        Error = 10,
        /// <summary>
        /// Успешно распознанно
        /// </summary>
        Done = 1,
        /// <summary>
        /// Пользователь пропустил точку
        /// </summary>
        DoneNotCheckIn = 2,
    }
}
