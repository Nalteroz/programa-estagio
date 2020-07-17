using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IVeiculoDB
    {
        IEnumerable<Parada> GetAllVeiculos();
        Veiculo GetVeiculo(Veiculo veiculo);
        int CreateVeiculo(Veiculo veiculo);
        int UpdateVeiculo(Veiculo veiculo);
        int DeleteVeiculo(Veiculo veiculo);
    }
}

