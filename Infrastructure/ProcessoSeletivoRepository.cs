using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProcessoSeletivoRepository : IProcessoSeletivo
    {
        private readonly Context _context;

        public ProcessoSeletivoRepository(Context context)
        {
            _context = context;
        }
        public void Add(ProcessoSeletivo processoSeletivo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProcessoSeletivo> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProcessoSeletivo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProcessoSeletivo processoSeletivo)
        {
            throw new NotImplementedException();
        }
    }
}
