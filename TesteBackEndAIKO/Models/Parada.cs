using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Models
{
    public class Parada
    {
        [Key]
        public long Id { get; private set; }
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public Parada(long id, double latitude, double longitude, string name = "")
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}