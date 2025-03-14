using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Lead)
                .WithMany(l => l.Inscricoes)
                .HasForeignKey(i => i.LeadId);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.ProcessoSeletivo)
                .WithMany(p => p.Inscricoes)
                .HasForeignKey(i => i.ProcessoSeletivoId);

            modelBuilder.Entity<Inscricao>()
                .HasOne(i => i.Oferta)
                .WithMany(o => o.Inscricoes)
                .HasForeignKey(i => i.OfertaId);
        }
    }

}

