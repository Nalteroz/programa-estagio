using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Dtos
{
    public class LinhaCreationDto
    {
        public string Name { get; set; }

        public List<long> Paradas { get; set;}
    }
}