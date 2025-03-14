using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly InscricaoService _service;
        public InscricaoController( InscricaoService service)
        {
            _service = service;
            
        }

        [HttpGet("por-cpf/{cpf}")]
        public async Task<ActionResult<List<Inscricao>>> ObterInscricoesPorCpf(string cpf)
        {
            var inscricoes = await _service.ObterInscricoesPorCpf(cpf);
            if (inscricoes == null || inscricoes.Count == 0)
                return NotFound("Nenhuma inscrição encontrada para este CPF.");

            return Ok(inscricoes);
        }

        [HttpGet("por-oferta/{ofertaId}")]
        public async Task<ActionResult<List<Inscricao>>> ObterInscricoesPorOferta(int ofertaId)
        {
            var inscricoes = await _service.ObterInscricoesPorOferta(ofertaId);
            if (inscricoes == null || inscricoes.Count == 0)
                return NotFound("Nenhuma inscrição encontrada para esta oferta.");

            return Ok(inscricoes);
        }

        [HttpPost]
        public IActionResult Create(Inscricao inscricao)
        {
            _service.Adicionar(inscricao);
            return CreatedAtAction(nameof(GetById), new { id = inscricao.Id }, inscricao);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inscricao = _service.ObterPorId(id);
            return inscricao == null ? NotFound("Nenhuma inscrição encontrar para este Id") : Ok(inscricao);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObterTodos());

        [HttpPut("{id}")]
        public IActionResult Update(int id, Inscricao inscricao)
        {
            if (id != inscricao.Id) return BadRequest();
            _service.Atualizar(inscricao);
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
