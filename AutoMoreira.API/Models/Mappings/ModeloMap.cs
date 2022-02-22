using AutoMoreira.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Mappings
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");

            builder.HasKey(p => p.ModeloId);

            /* // Se eu quiser criar uma chave manualmente
            builder.Property(p => p.Id)
                .ValueGeneratedNever(); */



            /* Tenho uma categoria para muios livros ( Ele por padrao ja faz isto)
            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId); */

            builder.HasData(
                new Modelo(1,"A3"),
                new Modelo(2, "Serie 1")
                );
        }
    }
}
