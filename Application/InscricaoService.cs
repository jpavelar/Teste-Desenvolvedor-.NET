using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class InscricaoService
    {
        private readonly IInscricao _inscricaoRepo;
        private readonly Context _context;
        public InscricaoService(IInscricao inscricaoRepository, Context context)
        {
            _inscricaoRepo = inscricaoRepository;
            _context = context;

        }

        public void Adicionar(Inscricao inscricao) => _inscricaoRepo.Add(inscricao);

        public Inscricao ObterPorId(int id) => _inscricaoRepo.GetById(id);

        public IEnumerable<Inscricao> ObterTodos() => _inscricaoRepo.GetAll();

        public void Atualizar(Inscricao inscricao) => _inscricaoRepo.Update(inscricao);

        public void Remover(int id) => _inscricaoRepo.Delete(id);

        public async Task<List<Inscricao>> ObterInscricoesPorCpf(string cpf)
        {
            return await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.Oferta)
                .Include(i => i.ProcessoSeletivo)
                .Where(i => i.Lead.CPF == cpf)
                .ToListAsync();
        }

        public async Task<List<Inscricao>> ObterInscricoesPorOferta(int ofertaId)
        {
            return await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.Oferta)
                .Include(i => i.ProcessoSeletivo)
                .Where(i => i.OfertaId == ofertaId)
                .ToListAsync();
        }

    }
}
