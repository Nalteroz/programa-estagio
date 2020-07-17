using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhasController : ControllerBase
    {
        private readonly ILinhaRepository _repository;
        public LinhasController(ILinhaRepository repository)
        {
            _repository = repository;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Linha>> GetAllLinhas()
        //{
            
        //}
    }
}