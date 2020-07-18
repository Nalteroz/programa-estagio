using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IPosicaoVeiculoRepository
    {
        public IEnumerable<PosicaoVeiculo> GetAllPosicaoVeiculos();
        public PosicaoVeiculo GetPosicaoVeiculo(long veiculoId);
        public void CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        public void UpdatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        public void DeletePosicaoVeiculo(long veiculoId);
    }
}

