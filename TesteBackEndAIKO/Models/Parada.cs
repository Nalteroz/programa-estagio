using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Models
{
    public class Parada
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

    }
}