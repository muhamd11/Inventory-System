using App.Core.Models.UnitModule.DTOs;
using AutoMapper;
using InvetorySystem.Core.Models.UnitModule;

namespace App.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Unit, UnitAddRequest>().ReverseMap();

        }
    }
}
