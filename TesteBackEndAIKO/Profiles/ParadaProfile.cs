using AutoMapper;
using TesteBackEndAIKO.Models;
using TesteBackEndAIKO.Dtos;

namespace TesteBackEndAIKO.Profiles
{
    public class ParadaProfile : Profile
    {
        public ParadaProfile()
        {
            CreateMap<ParadaCreationDto, Parada>();
            CreateMap<Parada, ParadaCreationDto>();
        }
    }
}