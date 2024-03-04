using JimHalpert.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace JimHalpert.Repository.Maps
{
    class TarefaItemMap
    {
        public static void MapTarefaItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaItem>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorHora).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Servico)
                    .WithMany(p => p.TarefaItem)
                    .HasForeignKey(d => d.ServicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarefaItem_Servico");

                entity.HasOne(d => d.Tarefa)
                    .WithMany(p => p.TarefaItem)
                    .HasForeignKey(d => d.TarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarefaItem_Tarefa");
            });

        }

    }
}
