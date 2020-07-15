using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IVeiculoDB
    {
        IEnumerable<Parada> GetAllVeiculos();
        Linha GetVeiculo(Veiculo veiculo);
        bool CreateVeiculo(Veiculo veiculo);
        bool UpdateVeiculo(Veiculo veiculo);
        bool DeleteVeiculo(Veiculo veiculo);
    }
}

