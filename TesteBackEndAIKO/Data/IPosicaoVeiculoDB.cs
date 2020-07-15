using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IPosicaoVeiculoDB
    {
        Linha GetPosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        bool CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        bool UpdatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        bool DeletePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
    }
}

