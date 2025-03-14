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
    public class OfertaService
    {
        private readonly IOferta _ofertaRepository;
        public OfertaService(IOferta ofertaRepository) { 

            _ofertaRepository = ofertaRepository;
        }

        public void Adicionar(Oferta lead) => _ofertaRepository.Add(lead);

        public Oferta ObterPorId(int id) => _ofertaRepository.GetById(id);

        public IEnumerable<Oferta> ObterTodos() => _ofertaRepository.GetAll();

        public void Atualizar(Oferta oferta) => _ofertaRepository.Update(oferta);

        public void Remover(int id) => _ofertaRepository.Delete(id);
    }
}
