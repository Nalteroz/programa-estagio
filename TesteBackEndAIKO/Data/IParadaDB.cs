using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IParadaDB
    {
        IEnumerable<Parada> GetAllParadas();
        Linha GetParada(Parada parada);
        bool CreateParada(Parada parada);
        bool UpdateParada(Parada parada);
        bool DeleteParada(Parada parada);
    }
}

