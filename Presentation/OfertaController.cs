using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly OfertaService _service;
        public OfertaController(OfertaService ofertaService)
        {
            _service = ofertaService;
        }

        [HttpPost]
        public IActionResult Create(Oferta oferta)
        {
            _service.Adicionar(oferta);
            return CreatedAtAction(nameof(GetById), new { id = oferta.Id }, oferta);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var oferta = _service.ObterPorId(id);
            return oferta == null ? NotFound() : Ok(oferta);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObterTodos());

        [HttpPut("{id}")]
        public IActionResult Update(int id, Oferta oferta)
        {
            if (id != oferta.Id) return BadRequest();
            _service.Atualizar(oferta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
