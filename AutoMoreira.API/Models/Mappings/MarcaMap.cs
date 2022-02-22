using AutoMoreira.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Mappings
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marca");

            builder.HasKey(p => p.MarcaId);

            /* // Se eu quiser criar uma chave manualmente
            builder.Property(p => p.Id)
                .ValueGeneratedNever(); */



            /* Tenho uma categoria para muios livros ( Ele por padrao ja faz isto)
            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId); */

            builder.HasData(
                new Marca(1,"Audi"),
                new Marca(2, "BMW")
                );
        }
    }
}
