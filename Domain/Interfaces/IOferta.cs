using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOferta
    {
        void Add(Oferta oferta);
        Oferta GetById(int id);
        IEnumerable<Oferta> GetAll();
        void Delete(int id);

        void Update(Oferta id);
    }
}
