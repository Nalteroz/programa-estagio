using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TesteBackEndAIKO.Models
{
    public class Linha
    {
        [Key]
        public long Id { get; private set; }

        public string Name { get; set; }

        [NotMapped]
        public List<Parada> Paradas { get; set; }

        [Required]
        public string ParadasString 
        { 
            get 
            { 
                return (Paradas != null) ? JsonConvert.SerializeObject(Paradas) : "";
            }

            set
            {
                ParadasString = value;
                Paradas = JsonConvert.DeserializeObject<List<Parada>>(value);
            }
        }

        public Linha(long id, string name = "")
        {
            Id = id;
            Name = name;
            Paradas = new List<Parada>();
        }
    }
}