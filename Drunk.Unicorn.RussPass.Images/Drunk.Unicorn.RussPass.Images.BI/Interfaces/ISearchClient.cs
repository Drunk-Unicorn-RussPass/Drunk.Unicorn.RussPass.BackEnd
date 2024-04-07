using Drunk.Unicorn.RussPass.Images.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.BI.Interfaces
{
    public interface ISearchClient
    {
        Task<TResult> Search<TResult, TSearch>(TSearch value) where TSearch : SearchBase;
    }
}
