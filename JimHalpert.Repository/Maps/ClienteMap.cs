using Microsoft.EntityFrameworkCore;
using JimHalpert.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JimHalpert.Repository.Maps
{
    public static class ClienteMap
    {
        public static void MapCliente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CadastroMunicipal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Contato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataAlteracao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InscricaoEstadual)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CidadeId)
                    .HasConstraintName("FK_Cliente_Cidade");

                entity.HasOne(d => d.TipoDeCliente)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.TipoDeClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_TipoDeCliente");

                entity.HasOne(d => d.TipoDePessoa)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.TipoDePessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_TipoDePessoa");
            });

        }
    }
}
