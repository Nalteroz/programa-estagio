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
        
        public List<long> Paradas { get; set;}

    }
}