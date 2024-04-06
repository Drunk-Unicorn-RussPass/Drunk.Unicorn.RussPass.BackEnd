using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Drunk.Unicorn.RussPass.Tracks.Data;
using Drunk.Unicorn.RussPass.Tracks.Data.Entity;
using System;
using System.Linq;

namespace Drunk.Unicorn.RussPass.Tracks.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<ClassDTO, ClassEntity>();
        }
    }
}
