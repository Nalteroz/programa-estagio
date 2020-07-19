using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteBackEndAIKO.Dtos
{
    public class LinhaCreationDto
    {
        public string Name { get; set; }

        [Required]
        public string ParadasString { get; set; }
    }
}