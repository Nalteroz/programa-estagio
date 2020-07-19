using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Dtos
{
    public class ParadaCreationDto
    {
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}