using JimHalpert.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using static JimHalpert.Repository.Maps.CidadeMap;
using static JimHalpert.Repository.Maps.ClienteMap;
using static JimHalpert.Repository.Maps.ServicoMap;
using static JimHalpert.Repository.Maps.TarefaItemMap;
using static JimHalpert.Repository.Maps.TipoDeClienteMap;
using static JimHalpert.Repository.Maps.TipoDePessoaMap;
using static Microsoft.Extensions.Configuration.ConfigurationExtensions;


namespace JimHalpert.Repository.Context
{
    public partial class JimHalpertContext : DbContext
    {

        public JimHalpertContext()
        {
            //this.
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public JimHalpertContext(DbContextOptions<JimHalpertContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        //new
        public virtual DbSet<ArquivoNotaFiscal> ArquivoNotaFiscal { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ComposicaoNotaFiscal> ComposicaoNotaFiscal { get; set; }
        public virtual DbSet<Cor> Cor { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Faturamento> Faturamento { get; set; }
        public virtual DbSet<Mes> Mes { get; set; }
        public virtual DbSet<NotaFiscal> NotaFiscal { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<StatusNotaFiscal> StatusNotaFiscal { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<TarefaItem> TarefaItem { get; set; }
        public virtual DbSet<TipoDeCliente> TipoDeCliente { get; set; }
        public virtual DbSet<TipoDePessoa> TipoDePessoa { get; set; }
        public virtual DbSet<Tributo> Tributo { get; set; }
        public virtual DbSet<TributoNotaFiscal> TributoNotaFiscal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("JimHalpertContext");
                optionsBuilder.UseSqlServer(connectionString);
            }


            // Obtenha uma instância do LoggerFactory
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(); // Registra o log no console
                //builder.AddDebug(); // Se preferir, também pode adicionar o log no debugger
            });

            // Configure o DbContext para usar o loggerFactory
            optionsBuilder.UseLoggerFactory(loggerFactory);
 
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=.\Web17;Database=RedDragon;Trusted_Connection=True;");
            //    optionsBuilder.UseLazyLoadingProxies(false);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapCidade(modelBuilder);
            MapCliente(modelBuilder);
            MapServico(modelBuilder);
            MapTarefaItem(modelBuilder);
            MapTipoDeCliente(modelBuilder);
            MapTipoDePessoa(modelBuilder);

            //mapear!
            //init to mapear
            modelBuilder.Entity<ArquivoNotaFiscal>(entity =>
            {
                entity.Property(e => e.Arquivo).IsRequired();

                entity.HasOne(d => d.NotaFiscal)
                    .WithMany(p => p.ArquivoNotaFiscal)
                    .HasForeignKey(d => d.NotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArquivoNotaFiscal_NotaFiscal");
            });

            modelBuilder.Entity<ComposicaoNotaFiscal>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.NotaFiscal)
                    .WithMany(p => p.ComposicaoNotaFiscal)
                    .HasForeignKey(d => d.NotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComposicaoNotaFiscal_NotaFiscal");

                entity.HasOne(d => d.Tarefa)
                    .WithMany(p => p.ComposicaoNotaFiscal)
                    .HasForeignKey(d => d.TarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComposicaoNotaFiscal_Tarefa");
            });

            modelBuilder.Entity<Cor>(entity =>
            {
                entity.Property(e => e.CorId).HasComment("Codigo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Descricao");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.NomeUf)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Descricao");

                entity.Property(e => e.SiglaUf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("UF");
            });

            modelBuilder.Entity<Faturamento>(entity =>
            {
                entity.Property(e => e.Valor).HasColumnType("numeric(18, 5)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Faturamento)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faturamento_Cliente");
            });

            modelBuilder.Entity<Mes>(entity =>
            {
                entity.Property(e => e.MesId).HasComment("Numero");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Nome");
            });

            modelBuilder.Entity<NotaFiscal>(entity =>
            {
                entity.Property(e => e.CodigoVerificacao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImpostoTotalRetido).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValorLiquido).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.NotaFiscal)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotaFiscal_Cliente");

                entity.HasOne(d => d.StatusNotaFiscal)
                    .WithMany(p => p.NotaFiscal)
                    .HasForeignKey(d => d.StatusNotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotaFiscal_StatusNotaFiscal");
            });

            modelBuilder.Entity<StatusNotaFiscal>(entity =>
            {
                entity.Property(e => e.StatusNotaFiscalId).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ValorOrcado).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tarefa_Cliente");
            });

            modelBuilder.Entity<Tributo>(entity =>
            {
                entity.Property(e => e.TributoId).HasComment("Codigo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Descricao");

                entity.Property(e => e.FaixaFinal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.FaixaInicial).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Percentual)
                    .HasColumnType("numeric(18, 2)")
                    .HasComment("Valor");

                entity.Property(e => e.ValorDeducao).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TributoNotaFiscal>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.NotaFiscal)
                    .WithMany(p => p.TributoNotaFiscal)
                    .HasForeignKey(d => d.NotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TributoNotaFiscal_NotaFiscal");

                entity.HasOne(d => d.Tributo)
                    .WithMany(p => p.TributoNotaFiscal)
                    .HasForeignKey(d => d.TributoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TributoNotaFiscal_Tributo");
            });

            //end to mapear

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}