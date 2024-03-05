using JimHalpert.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace JimHalpert.Repository.Maps
{
    public static class UsuarioMap
    {
        public static void MapUsuario(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).ValueGeneratedOnAdd();
                entity.Property(e => e.Login).IsRequired().HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Celular).IsRequired().HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Documento).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Senha).IsRequired();
                entity.Ignore(e => e.SenhaTexto);
                entity.Property(e => e.DataNascimento).HasColumnType("date").IsRequired();
                entity.Property(e => e.DataLogin).HasColumnType("datetime");
                entity.Property(e => e.DataCriacao).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");
                entity.Property(e => e.ValidadeSenha).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.Admin).HasColumnType("bit").IsRequired();
                entity.Property(e => e.Ativo).HasColumnType("bit").IsRequired();

            });

        }
    }
}
