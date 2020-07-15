using System.Collections.Generic;

namespace TesteBackEndAIKO.Models
{
    public class Linha
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Parada> Paradas { get; private set; }

        public Linha(long id = long.MinValue, string name = "", IEnumerable<Parada> paradas = null)
        {
            Id = id;
            Name = name;
            Paradas = paradas;
        }

        public void UpdateLinha(Linha linha)
        {
            Id = (linha.Id != long.MinValue) ? linha.Id : Id;
            Name = (linha.Name != "") ? linha.Name : Name;
            Paradas = (linha.Paradas != null) ? linha.Paradas: Paradas;
        }
    }
}