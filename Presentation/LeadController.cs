using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly LeadService _service;
        public LeadController(LeadService leadService)
        {
            _service = leadService;
        }


        [HttpPost]
        public IActionResult Create(Lead lead)
        {
            _service.Adicionar(lead);
            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lead = _service.ObterPorId(id);
            return lead == null ? NotFound() : Ok(lead);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObterTodos());

        [HttpPut("{id}")]
        public IActionResult Update(int id, Lead lead)
        {
            if (id != lead.Id) return BadRequest();
            _service.Atualizar(lead);
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
