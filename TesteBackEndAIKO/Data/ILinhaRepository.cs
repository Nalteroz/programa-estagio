using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface ILinhaRepository
    {
        public IEnumerable<Linha> GetAllLinhas();
        public Linha GetLinha(long id);
        public void CreateLinha(Linha linha);
        public void UpdateLinha(Linha linha);
        public void DeleteLinha(long id);
    }
}

