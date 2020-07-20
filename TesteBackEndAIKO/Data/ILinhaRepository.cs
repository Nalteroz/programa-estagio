using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface ILinhaRepository
    {
        public IEnumerable<Linha> GetAllLinhas();
        public Linha GetLinha(long id);
        public bool CreateLinha(Linha linha);
        public bool DeleteLinha(long id);
        public bool CheckParadas(List<long> paradas);
        public bool SaveChanges();
    }
}

