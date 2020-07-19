using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteBackEndAIKO.Data;
using TesteBackEndAIKO.Models;
using System.Linq;
using System;

namespace TesteBackEndAIKO.Controllers
{   
    [ApiController]
    public class MetodosController : ControllerBase
    {
        private readonly ILinhaRepository _linhaRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IParadaRepository _paradaRepository;

        public MetodosController(ILinhaRepository linhaRepository, IVeiculoRepository veiculoRepository, IParadaRepository paradaRepository)
        {
            _linhaRepository = linhaRepository;
            _veiculoRepository = veiculoRepository;
            _paradaRepository = paradaRepository;
        }

        [HttpGet("api/LinhaPorParada/{paradaId}")]
        public ActionResult<IEnumerable<Linha>> LinhaPorParada(long paradaId)
        {
            if(paradaId < 0) return BadRequest();

            IEnumerable<Linha> selectedLinhas, allLinhas = _linhaRepository.GetAllLinhas();

            selectedLinhas = allLinhas.Where(linha => linha.Paradas.Contains(paradaId));

            if(selectedLinhas.Count() == 0)
                return NotFound();
            else
                return Ok(selectedLinhas);
        }

        [HttpGet("api/VeiculosPorLinha/{linhaId}")]
        public ActionResult<IEnumerable<Veiculo>> VeiculosPorLinha(long linhaId)
        {
            if(linhaId < 0) return BadRequest();

            IEnumerable<Veiculo> selectedVeiculos, veiculos = _veiculoRepository.GetAllVeiculos();
            selectedVeiculos = veiculos.Where( v => v.LinhaId == linhaId);

            if(selectedVeiculos.Count() == 0)
                return NotFound();
            else
                return Ok(selectedVeiculos);
        }

        [HttpGet("api/ParadasProximas/{latitude}/{longitude}/{distanciaMaxima}")]
        public ActionResult<IEnumerable<Parada>> ParadasProximas(double latitude, double longitude, double distanciaMaxima)
        {
            if(distanciaMaxima < 0) return BadRequest();

            IEnumerable<Parada> selectedParadas, allParadas = _paradaRepository.GetAllParadas();
            selectedParadas = allParadas.Where( parada => 
                Math.Sqrt( 
                    Math.Pow( (latitude - parada.Latitude), 2) + Math.Pow((longitude - parada.Longitude), 2) )
                    <= distanciaMaxima
            );

            if(selectedParadas.Count() == 0)
                return NotFound();
            else
                return Ok(selectedParadas);

        }
    }
}