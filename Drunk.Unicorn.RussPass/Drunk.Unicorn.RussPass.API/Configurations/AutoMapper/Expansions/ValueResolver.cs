using AutoMapper;
using Drunk.Unicorn.RussPass.BI.Options;
using Drunk.Unicorn.RussPass.Data.Entity;
using Drunk.Unicorn.RussPass.General.Expansions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.API.Configurations.AutoMapper
{
    public class FormatterObjectToString : IValueResolver<object, object, string>
    {
        private readonly IMapper _mapper;

        public FormatterObjectToString(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string Resolve(object source, object destination, string result, ResolutionContext context)
        {
            return result;
        }
    }

}