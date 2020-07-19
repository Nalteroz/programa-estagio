using AutoMapper;
using TesteBackEndAIKO.Models;
using TesteBackEndAIKO.Dtos;

namespace TesteBackEndAIKO.Profiles
{
    public class LinhaProfile : Profile
    {
        public LinhaProfile()
        {
            CreateMap<LinhaCreationDto, Linha>();
            CreateMap<Linha, LinhaCreationDto>();
        }
    }
}