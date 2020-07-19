using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IPosicaoVeiculoRepository
    {
        public IEnumerable<PosicaoVeiculo> GetAllPosicaoVeiculos();
        public PosicaoVeiculo GetPosicaoVeiculo(long veiculoId);
        public bool CreatePosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        public bool DeletePosicaoVeiculo(long veiculoId);
        public bool CheckPosicaoVeiculo(PosicaoVeiculo posicaoVeiculo);
        public bool SaveChanges();
    }
}

