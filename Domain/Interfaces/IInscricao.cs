using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInscricao
    {
        void Add(Inscricao inscricao);
        Inscricao GetById(int id);
        IEnumerable<Inscricao> GetAll();
        void Update(Inscricao inscricao);
        void Delete(int id);
    }
}
