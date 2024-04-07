using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Interfaces
{
    public interface IFilesProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns>Вернёт url файла</returns>
        Task<string> SendFile(Stream file, string fileName);
    }
}
