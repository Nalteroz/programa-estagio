using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IVeiculoRepository
    {
        public IEnumerable<Veiculo> GetAllVeiculos();
        public Veiculo GetVeiculo(long id);
        public bool CreateVeiculo(Veiculo veiculo);
        public bool CheckLinha(long linhaId);
        public bool DeleteVeiculo(long id);
        public bool SaveChanges();
    }
}

