using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Drunk.Unicorn.RussPass.Users.Data;
using Drunk.Unicorn.RussPass.Users.Data.Entity;
using System;
using System.Linq;

namespace Drunk.Unicorn.RussPass.Users.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
