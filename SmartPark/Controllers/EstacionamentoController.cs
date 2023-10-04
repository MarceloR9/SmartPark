using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartPark.Models;
using SmartPark.Services;

namespace SmartPark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : Controller
    {
        private readonly EstacionamentoServices _estacionamentoServices;

        public EstacionamentoController(EstacionamentoServices estacionamentoServices)
        {
            _estacionamentoServices = estacionamentoServices;
        }

        [HttpPost("entrada")]
        public IActionResult Entrada([FromBody] Estacionamento estacionamento)
        {
            _estacionamentoServices.Entrada(estacionamento.Placa, estacionamento.TipoVeiculo);
            return Ok("Veículo registrado com sucesso.");
        }

        [HttpPost("saida")]
        public IActionResult Saida([FromBody] Estacionamento estacionamento)
        {
            _estacionamentoServices.Saida(estacionamento.Placa);
            return Ok("Veículo saiu do estacionamento.");
        }

        [HttpGet]
        public ActionResult<List<Estacionamento>> ListarTodos()
        {
            var estacionamentoList = _estacionamentoServices.ListarTodos();
            return Ok(estacionamentoList);
        }
    }
}
