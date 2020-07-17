using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBackEndAIKO.Models
{
    public class Veiculo
    {
        [Key]
        public long Id { get; private set; }
        public string Name { get; set; }
        public string Modelo { get; set; }

        [ForeignKey("Linha")]
        public long LinhaId { get; set; }

        public Veiculo(long id, long linhaId, string name = "", string modelo = "")
        {
            Id = id;
            Name = name;
            Modelo = modelo;
            LinhaId = linhaId;
        }
    }
}