using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IPosicaoVeiculoDB
    {
        PosicaoVeiculo GetPosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        int CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        int UpdatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        int DeletePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
    }
}

