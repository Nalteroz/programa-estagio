using System.Collections.Generic;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Data
{
    public interface ILinhaDB
    {
        IEnumerable<Linha> GetAllLinhas();
        Linha GetLinha(Linha linha1);
        int CreateLinha(Linha linha);
        int UpdateLinha(Linha linha);
        int DeleteLinha(Linha linha);
    }
}

