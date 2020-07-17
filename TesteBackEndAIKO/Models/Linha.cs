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

        public string Name { get; private set; }

        [NotMapped]
        public IEnumerable<Parada> Paradas { get; set; }

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
                Paradas = JsonConvert.DeserializeObject<IEnumerable<Parada>>(value);
            }
        }

        public Linha()
        {
            
        }
        public Linha(long id, IEnumerable<Parada> paradas, string name = "")
        {
            Id = id;
            Name = name;
            Paradas = paradas;
        }
    }
}