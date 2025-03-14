using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly ProcessoSeletivoService _service;

        public ProcessoSeletivoController(ProcessoSeletivoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(ProcessoSeletivo processo)
        {
            _service.Adicionar(processo);
            return CreatedAtAction(nameof(GetById), new { id = processo.Id }, processo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var processo = _service.ObterPorId(id);
            return processo == null ? NotFound() : Ok(processo);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObterTodos());

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProcessoSeletivo processo)
        {
            if (id != processo.Id) return BadRequest();
            _service.Atualizar(processo);
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
