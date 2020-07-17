using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IParadaDB
    {
        IEnumerable<Parada> GetAllParadas();
        Parada GetParada(Parada parada);
        int CreateParada(Parada parada);
        int UpdateParada(Parada parada);
        int DeleteParada(Parada parada);
    }
}

