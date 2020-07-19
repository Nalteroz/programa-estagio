using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Models
{
    public class PosicaoVeiculo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public long VeiculoId { get; set; }
    }
}