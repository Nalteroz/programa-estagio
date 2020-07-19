using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Models;
using TesteBackEndAIKO.Dtos;
using AutoMapper;

namespace TesteBackEndAIKO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicaoVeiculosController : ControllerBase
    {
        private readonly IPosicaoVeiculoRepository _repository;
        private readonly IMapper _mapper;

        public PosicaoVeiculosController(IPosicaoVeiculoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllPositions()
        {
            return Ok(_repository.GetAllPosicaoVeiculos());
        }

        [HttpGet("{id}", Name= "GetPositionByVeiculoId")]
        public ActionResult<PosicaoVeiculo> GetPositionByVeiculoId(long id)
        {
            PosicaoVeiculo posicaoVeiculo = _repository.GetPosicaoVeiculo(id);
            if(posicaoVeiculo == null) 
                return NotFound();
            else
                return Ok(posicaoVeiculo);
        }

        [HttpPost]
        public ActionResult<PosicaoVeiculo> CreatePosicaoVeiculo(PosicaoVeiculoCreationDto inputPV)
        {
            PosicaoVeiculo posicaoveiculo = _mapper.Map<PosicaoVeiculo>(inputPV);
            if(_repository.CreatePosicaoVeiculo(posicaoveiculo))
                return CreatedAtRoute(nameof(GetPositionByVeiculoId), new{Id = posicaoveiculo.Id}, posicaoveiculo);
            else
                return BadRequest();
        }

        [HttpDelete("{veiculoId}")]
        public ActionResult DeletePosicaoVeiculo(long veiculoId)
        {
            if(_repository.DeletePosicaoVeiculo(veiculoId))
                return NoContent();
            else
                return NotFound();
        }

        [HttpPatch("{veiculoId}")]
        public ActionResult UpdatePosicaoVeiculo(long veiculoId, JsonPatchDocument<PosicaoVeiculoCreationDto> patchDocument)
        {
            PosicaoVeiculo posicaoVeiculoBD = _repository.GetPosicaoVeiculo(veiculoId);
            if(posicaoVeiculoBD == null) 
                return NotFound();

            PosicaoVeiculoCreationDto posicaoToUpdate = _mapper.Map<PosicaoVeiculoCreationDto>(posicaoVeiculoBD);
            patchDocument.ApplyTo(posicaoToUpdate, ModelState);
            if(!TryValidateModel(posicaoToUpdate))
            {
                ValidationProblem(ModelState);
            }

            if(posicaoVeiculoBD.VeiculoId != posicaoToUpdate.VeiculoId || posicaoToUpdate.Latitude == 0 || posicaoToUpdate.Longitude == 0)
                return BadRequest();
            
            _mapper.Map(posicaoToUpdate, posicaoVeiculoBD);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}