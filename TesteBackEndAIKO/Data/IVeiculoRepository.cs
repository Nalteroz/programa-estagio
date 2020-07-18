using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IVeiculoRepository
    {
        public IEnumerable<Veiculo> GetAllVeiculos();
        public Veiculo GetVeiculo(long id);
        public void CreateVeiculo(Veiculo veiculo);
        public void UpdateVeiculo(Veiculo veiculo);
        public void DeleteVeiculo(long id);
    }
}

