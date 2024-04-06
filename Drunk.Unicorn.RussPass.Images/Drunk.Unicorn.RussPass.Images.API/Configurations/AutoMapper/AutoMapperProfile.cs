using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Drunk.Unicorn.RussPass.Images.Data;
using Drunk.Unicorn.RussPass.Images.Data.Entity;
using System;
using System.Linq;

namespace Drunk.Unicorn.RussPass.Images.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
