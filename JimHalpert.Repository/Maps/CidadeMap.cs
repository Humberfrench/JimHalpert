using Microsoft.EntityFrameworkCore;
using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Repository.Maps
{
    public static class CidadeMap
    {
        public static void MapCidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.CidadeId).HasComment("Codigo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nome");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidade_Estado");
            });

        }
    }
}
