using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Models
{
    public class PosicaoVeiculo
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Key]
        public long VeiculoId { get; private set; }

        public PosicaoVeiculo(long veiculoId, double latitude, double longitude)
        {
            VeiculoId = veiculoId;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}