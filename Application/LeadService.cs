using Domain.Entities;
using Domain.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class LeadService
    {
        private readonly ILead _leadRepository;
        public LeadService(ILead leadRepository) {
            _leadRepository = leadRepository;
        }

        public void Adicionar(Lead lead) => _leadRepository.Add(lead);

        public Lead ObterPorId(int id) => _leadRepository.GetById(id);

        public IEnumerable<Lead> ObterTodos() => _leadRepository.GetAll();

        public void Atualizar(Lead lead) => _leadRepository.Update(lead);

        public void Remover(int id) => _leadRepository.Delete(id);
    }
}
