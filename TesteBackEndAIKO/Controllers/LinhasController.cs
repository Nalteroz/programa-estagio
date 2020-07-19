using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Dtos;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinhasController : ControllerBase
    {
        private readonly ILinhaRepository _repository;
        private readonly IMapper _mapper;

        public LinhasController(ILinhaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Linha>> GetAllLinhas()
        {
            return Ok(_repository.GetAllLinhas());   
        }

        [HttpGet("{id}", Name="GetLinhaById")]
        public ActionResult<Linha> GetLinhaById(long id)
        {
            Linha linha = _repository.GetLinha(id);
            if(linha == null) return BadRequest();
            else return Ok(linha);
        }

        [HttpPost]
        public ActionResult<Linha> CreateLinha(LinhaCreationDto inputLinha)
        {
            Linha linha = _mapper.Map<Linha>(inputLinha);
            if(_repository.CreateLinha(linha))
            {
                return CreatedAtRoute(nameof(GetLinhaById), new{Id=linha.Id}, linha);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateLinha(long id, JsonPatchDocument<LinhaCreationDto> patchDocument)
        {
            Linha linhaDB = _repository.GetLinha(id);
            if(linhaDB == null) return NotFound();

            LinhaCreationDto linhaToUpdate = _mapper.Map<LinhaCreationDto>(linhaDB);
            patchDocument.ApplyTo(linhaToUpdate, ModelState);
            if(!TryValidateModel(linhaToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            if(!_repository.CheckParadas(linhaToUpdate.ParadasString))
                return BadRequest();

            _mapper.Map(linhaToUpdate, linhaDB);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLinha(long id)
        {
            if(_repository.DeleteLinha(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}