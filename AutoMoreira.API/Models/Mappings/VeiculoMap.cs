using AutoMoreira.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Mappings
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(p => p.VeiculoId);

            /* // Se eu quiser criar uma chave manualmente
            builder.Property(p => p.Id)
                .ValueGeneratedNever(); */

            

            /* Tenho uma categoria para muios livros ( Ele por padrao ja faz isto)
            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId); */

            builder.HasData(
                new Veiculo(1,1,1,"GTI","Diesel",15000,2020,"Azul","Bem Top","sdfsdf.png"),
                new Veiculo(2, 2, 2, "GTI", "Diesel", 15000, 2020, "Azul", "Bem Top", "sdfsdf.png")
                );
        }
    }
    
}
