using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Dtos
{
    public class PosicaoVeiculoCreationDto
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public long VeiculoId { get; set; }
    }
}