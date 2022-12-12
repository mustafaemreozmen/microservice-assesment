using AutoMapper;
using Directory.API.DTOs;
using Directory.Data.Entities;

namespace Directory.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<InformationDTO, Information>();
        }
    }
}
