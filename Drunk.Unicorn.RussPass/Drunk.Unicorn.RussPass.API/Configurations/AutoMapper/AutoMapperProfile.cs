using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Drunk.Unicorn.RussPass.Data;
using Drunk.Unicorn.RussPass.Data.Entity;
using System;
using System.Linq;

namespace Drunk.Unicorn.RussPass.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
