using Microsoft.EntityFrameworkCore;
using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Repository.Maps
{
    public static class TipoDePessoaMap
    {
        public static void MapTipoDePessoa(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDePessoa>(entity =>
            {
                entity.Property(e => e.TipoDePessoaId).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}
