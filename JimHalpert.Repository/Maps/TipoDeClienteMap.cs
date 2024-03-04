using JimHalpert.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JimHalpert.Repository.Maps
{
    public static class TipoDeClienteMap
    {
        public static void MapTipoDeCliente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDeCliente>(entity =>
            {
                entity.Property(e => e.TipoDeClienteId).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}
