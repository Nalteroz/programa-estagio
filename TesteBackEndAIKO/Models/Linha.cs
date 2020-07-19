using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Linq;

namespace TesteBackEndAIKO.Models
{
    public class Linha
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string ParadasString { get; set; }

        [NotMapped]
        public List<long> Paradas 
        { 
            get => JsonConvert.DeserializeObject<List<long>>(ParadasString);
            set
            {
                ParadasString = JsonConvert.SerializeObject(value);
            }
        }

    }
}