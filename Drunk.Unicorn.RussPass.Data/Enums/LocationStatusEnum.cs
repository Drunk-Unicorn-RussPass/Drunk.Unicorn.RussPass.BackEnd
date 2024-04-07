using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Data.Enums
{
    /// <summary>
    /// Статусы локации
    /// </summary>
    public enum LocationStatusEnum
    {
        /// <summary>
        /// Пустой статус
        /// </summary>
        None,
        /// <summary>
        /// Пользователь в пути к данной точке
        /// </summary>
        Running,
        /// <summary>
        /// Статус проверки фото
        /// </summary>
        Processing,
        /// <summary>
        /// Фото проверено и подтверждено. Пользователю выданы призовые
        /// </summary>
        Ok,
        /// <summary>
        /// Ошибка. Или фото не удалось проверить.
        /// </summary>
        Error
    }
}
