using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Dtos;
using TesteBackEndAIKO.Models;

namespace TesteBackEndAIKO.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _repository;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Veiculo>> GetAllVeiculos()
        {
            return Ok(_repository.GetAllVeiculos());
        }

        [HttpGet("{id}", Name="GetVeiculoById")]
        public ActionResult<Veiculo> GetVeiculoById(long id)
        {
            if(id < 0) return BadRequest();
            
            Veiculo veiculo = _repository.GetVeiculo(id);
            if( veiculo == null)
                return NotFound();
            else
                return Ok(veiculo);
        }

        [HttpPost]
        public ActionResult CreateVeiculo(VeiculoCreationDto inputVeiculo)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(inputVeiculo);
            if(_repository.CreateVeiculo(veiculo))
                return CreatedAtRoute(nameof(GetVeiculoById), new{Id=veiculo.Id}, veiculo);
            else
                return BadRequest();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateVeiculo(int id, JsonPatchDocument<VeiculoCreationDto> patchDocument)
        {
            if(id < 0) return BadRequest();

            Veiculo veiculoBD = _repository.GetVeiculo(id);
            if(veiculoBD == null) return NotFound();

            VeiculoCreationDto veiculoToUpdate = _mapper.Map<VeiculoCreationDto>(veiculoBD);
            patchDocument.ApplyTo( veiculoToUpdate, ModelState);
            if(!TryValidateModel(veiculoToUpdate))
            {
                ValidationProblem(ModelState);
            }
            if(!_repository.CheckLinha(veiculoToUpdate.LinhaId))
                return BadRequest();
            
            _mapper.Map(veiculoToUpdate, veiculoBD);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVeiculo(long id)
        {
            if(id < 0) return BadRequest();

            if(_repository.DeleteVeiculo(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}