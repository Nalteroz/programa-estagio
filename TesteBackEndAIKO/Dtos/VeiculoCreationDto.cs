using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBackEndAIKO.Dtos
{
    public class VeiculoCreationDto
    {
        public string Name { get; set; }
        public string Modelo { get; set; }

        [ForeignKey("Linha")]
        public long LinhaId { get; set; }
    }
}