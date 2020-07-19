using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface IParadaRepository
    {
        public IEnumerable<Parada> GetAllParadas();
        public Parada GetParada(long id);
        public bool CreateParada(Parada parada);
        public bool DeleteParada(long id);
        public bool SaveChanges();
    }
}

