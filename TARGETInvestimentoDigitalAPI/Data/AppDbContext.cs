using Microsoft.EntityFrameworkCore;

namespace TARGETInvestimentoDigitalAPI.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientesPlano> ClientesPlanos { get; set; }
        public virtual DbSet<EnderecoCliente> EnderecoClientes { get; set; }
        public virtual DbSet<FinanceiroCliente> FinanceiroClientes { get; set; }
        public virtual DbSet<PlanoVip> PlanoVips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientesPlano>(entity =>
            {
                entity.ToTable("ClientesPlano");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClientesPlanos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientesPlano_Cliente");

                entity.HasOne(d => d.IdPlanoVipNavigation)
                    .WithMany(p => p.ClientesPlanos)
                    .HasForeignKey(d => d.IdPlanoVip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientesPlano_PlanoVip");
            });

            modelBuilder.Entity<EnderecoCliente>(entity =>
            {
                entity.ToTable("EnderecoCliente");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.EnderecoClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnderecoCliente_Cliente");
            });

            modelBuilder.Entity<FinanceiroCliente>(entity =>
            {
                entity.ToTable("FinanceiroCliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.FinanceiroClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FinanceiroCliente_Cliente");
            });

            modelBuilder.Entity<PlanoVip>(entity =>
            {
                entity.ToTable("PlanoVip");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
