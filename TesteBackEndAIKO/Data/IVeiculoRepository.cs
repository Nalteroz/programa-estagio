using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IVeiculoRepository
    {
        public IEnumerable<Parada> GetAllVeiculos();
        public Veiculo GetVeiculo(long id);
        public void CreateVeiculo(Veiculo veiculo);
        public void UpdateVeiculo(Veiculo veiculo);
        public void DeleteVeiculo(long id);
    }
}

