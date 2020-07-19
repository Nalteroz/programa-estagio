using AutoMapper;
using TesteBackEndAIKO.Models;
using TesteBackEndAIKO.Dtos;

namespace TesteBackEndAIKO.Profiles
{
    public class PosicaoVeiculoProfile : Profile
    {
        public PosicaoVeiculoProfile()
        {
            CreateMap<PosicaoVeiculoCreationDto, PosicaoVeiculo>();
            CreateMap<PosicaoVeiculo, PosicaoVeiculoCreationDto>();
        }
    }
}