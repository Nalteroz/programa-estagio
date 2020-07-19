using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Models;
using TesteBackEndAIKO.Dtos;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace TesteBackEndAIKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : ControllerBase
    {
        private readonly IParadaRepository _repository;
        private readonly IMapper _mapper;

        public ParadasController(IParadaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Parada>> GetAllParadas()
        {
            return Ok(_repository.GetAllParadas());
        }

        [HttpGet("{id}", Name="GetParadaById")]
        public ActionResult<Parada> GetParadaById(long id)
        {
            Parada parada = _repository.GetParada(id);
            if(parada != null)
                return Ok(parada);
            else
                return NotFound();

        }

        [HttpPost]
        public ActionResult<Parada> CreateParada( ParadaCreationDto inputParada)
        {   
            Parada parada = _mapper.Map<Parada>(inputParada);
            if(_repository.CreateParada(parada))
            {
                return CreatedAtRoute(nameof(GetParadaById), new{Id = parada.Id}, parada);
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateParada(int id, JsonPatchDocument<ParadaCreationDto> patchDocument)
        {
            Parada paradaDB = _repository.GetParada(id);
            if(paradaDB == null) 
            {
                return NotFound();
            }

            ParadaCreationDto paradaUpdate = _mapper.Map<ParadaCreationDto>(paradaDB);
            patchDocument.ApplyTo(paradaUpdate, ModelState);
            if(!TryValidateModel(paradaUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(paradaUpdate, paradaDB);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParada(long id)
        {
            if(_repository.DeleteParada(id)) 
                return NoContent();
            else
                return NotFound();
        }
    }
}