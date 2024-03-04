using JimHalpert.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JimHalpert.Repository.Maps
{
    public static class ServicoMap
    {
        public static void MapServico(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

        }
    }
}
