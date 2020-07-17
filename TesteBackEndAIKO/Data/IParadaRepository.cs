using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IParadaRepository
    {
        public IEnumerable<Parada> GetAllParadas();
        public Parada GetParada(long id);
        public void CreateParada(Parada parada);
        public void UpdateParada(Parada parada);
        public void DeleteParada(long id);
    }
}

