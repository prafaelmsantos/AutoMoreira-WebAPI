using AutoMoreira.API.Mappings;
using AutoMoreira.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Context
{
    public class AutoMoreiraContext: DbContext
    {
        // Vai fazer a modelagem das entidades que vai virar tabela

        public AutoMoreiraContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());


        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

    }
}
