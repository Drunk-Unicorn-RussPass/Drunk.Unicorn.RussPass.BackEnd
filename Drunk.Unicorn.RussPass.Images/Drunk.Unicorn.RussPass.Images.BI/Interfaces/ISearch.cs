using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drunk.Unicorn.RussPass.Data.Models;
using Drunk.Unicorn.RussPass.Images.Data.Models;

namespace Drunk.Unicorn.RussPass.Images.BI.Interfaces
{
    public interface ISearch
    {
        Task<bool> FindImageAsync(YandexSearch image);
    }
}
