using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupo>().HasKey(g => g.ID_GRU);
            modelBuilder.Entity<Nota_Fiscal>().HasKey(nf => nf.ID_NOTA);
            modelBuilder.Entity<ItensNota>().HasKey(i => i.ITEM_NUM);
        }


        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Nota_Fiscal> Nota_Fiscal { get; set; }
        public DbSet<ItensNota> Itens_Nota { get; set; }
    }
}
