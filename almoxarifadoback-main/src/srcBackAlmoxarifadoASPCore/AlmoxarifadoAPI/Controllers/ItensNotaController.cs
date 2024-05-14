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

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var itemNota = _itensNotaService.ObterItemNotaPorID(id);
                if (itemNota == null)
                {
                    return NotFound("Nenhum item de nota encontrado com este ID.");
                }
                return Ok(itemNota);
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
                return CreatedAtAction(nameof(Get), new { id = itemNotaSalvo.ITEM_NUM }, itemNotaSalvo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
