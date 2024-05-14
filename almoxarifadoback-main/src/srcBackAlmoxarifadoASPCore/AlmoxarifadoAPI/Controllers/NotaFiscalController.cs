using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;

        public NotaFiscalController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notasFiscais = _notaFiscalService.ObterTodasNotasFiscais();
                return Ok(notasFiscais);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            try
            {
                var notaFiscalSalva = _notaFiscalService.CriarNotaFiscal(notaFiscal);
                return CreatedAtAction(nameof(Get), new { id = notaFiscalSalva.ID_NOTA }, notaFiscalSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
