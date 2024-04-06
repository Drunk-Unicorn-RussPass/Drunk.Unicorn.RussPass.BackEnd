using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Drunk.Unicorn.RussPass.Points.Data;
using Drunk.Unicorn.RussPass.Points.Data.Entity;
using System;
using System.Linq;

namespace Drunk.Unicorn.RussPass.Points.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
