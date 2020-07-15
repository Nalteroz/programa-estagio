using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface ILinhaDB
    {
        IEnumerable<Linha> GetAllLinhas();
        Linha GetLinha(Linha linha1);
        bool CreateLinha(Linha linha);
        bool UpdateLinha(Linha linha);
        bool DeleteLinha(Linha linha);
    }
}

