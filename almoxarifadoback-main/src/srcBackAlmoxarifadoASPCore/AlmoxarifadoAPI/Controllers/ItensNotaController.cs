using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;

        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarItemNota(ItensNotaPostDTO itemNota)
        {
            try
            {
                var itemNotaSalvo = _itensNotaService.CriarItemNota(itemNota);
                return Ok(itemNotaSalvo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
