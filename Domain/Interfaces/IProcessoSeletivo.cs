using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProcessoSeletivo
    {
        void Add(ProcessoSeletivo processoSeletivo);
        ProcessoSeletivo GetById(int id);
        IEnumerable<ProcessoSeletivo> GetAll();
        void Delete(int id);
        void Update(ProcessoSeletivo processoSeletivo);
    }
}
