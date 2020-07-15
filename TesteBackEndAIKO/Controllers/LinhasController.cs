using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhasController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Linha>> GetAllLinhas()
        {
            
        }
    }
}