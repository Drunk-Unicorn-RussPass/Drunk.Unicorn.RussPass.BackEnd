using Drunk.Unicorn.RussPass.Images.BI.Options;
using Drunk.Unicorn.RussPass.Images.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drunk.Unicorn.RussPass.Images.General.Exceptions;

namespace Drunk.Unicorn.RussPass.Images.BI.Services
{
    public class Keys
    {
        private readonly IEnumerator<string> _keys;
        private string _key;

        public Keys(IConfiguration configuration)
        {
            var config = configuration.GetSection("Search").Get<Config>();

            _keys = config.Keys;

            if (_keys.MoveNext())
                _key = _keys.Current;
            else
                throw new KeysException("Список ключей пустой!");
        }

        public string GetNextKey()
        {
            if (_keys.MoveNext())
                _key = _keys.Current;
            else
                throw new KeysException("Больше нет валидных ключей!");
            return _key;
        }
    }
}
