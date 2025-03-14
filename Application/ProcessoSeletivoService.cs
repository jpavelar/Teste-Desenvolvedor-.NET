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
    public class ProcessoSeletivoService
    {
        private readonly IProcessoSeletivo _processoSeletivoRepo;

        public ProcessoSeletivoService(IProcessoSeletivo processoSeletivoRepo)
        {
            _processoSeletivoRepo = processoSeletivoRepo;
        }

        public void Adicionar(ProcessoSeletivo processo) => _processoSeletivoRepo.Add(processo);

        public ProcessoSeletivo ObterPorId(int id) => _processoSeletivoRepo.GetById(id);

        public IEnumerable<ProcessoSeletivo> ObterTodos() => _processoSeletivoRepo.GetAll();

        public void Atualizar(ProcessoSeletivo processo) => _processoSeletivoRepo.Update(processo);

        public void Remover(int id) => _processoSeletivoRepo.Delete(id);
    }
}
