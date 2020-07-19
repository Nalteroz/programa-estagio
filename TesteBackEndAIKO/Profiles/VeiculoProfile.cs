using AutoMapper;
using TesteBackEndAIKO.Dtos;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<VeiculoCreationDto, Veiculo>();
            CreateMap<Veiculo, VeiculoCreationDto>();
        }
    }
    
}