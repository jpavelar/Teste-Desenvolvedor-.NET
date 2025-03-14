using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILead
    {
        void Add(Lead lead);
        Lead GetById(int id);
        IEnumerable<Lead> GetAll();
        void Delete(int id);

        void Update(Lead id);

    }
}
