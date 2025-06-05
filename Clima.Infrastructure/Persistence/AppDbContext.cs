using Clima.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clima.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<DadoClimatico> DadosClimaticos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("RM556480");

            // Tabela: TB_DISPOSITIVO
            modelBuilder.Entity<Dispositivo>(entity =>
            {
                entity.ToTable("TB_DISPOSITIVO");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_DISPOSITIVO");

                entity.Property(e => e.Identificador).HasColumnType("VARCHAR2(100)").HasColumnName("IDENTIFICADOR").IsRequired();
                entity.Property(e => e.Localizacao).HasColumnType("VARCHAR2(200)").HasColumnName("LOCALIZACAO").IsRequired();
                entity.Property(e => e.Latitude).HasColumnType("NUMBER(9,6)").HasColumnName("LATITUDE");
                entity.Property(e => e.Longitude).HasColumnType("NUMBER(9,6)").HasColumnName("LONGITUDE");
                entity.Property(e => e.Status).HasColumnType("VARCHAR2(20)").HasColumnName("STATUS").IsRequired();
                entity.Property(e => e.UltimaConexao).HasColumnType("TIMESTAMP").HasColumnName("ULTIMA_CONEXAO");
            });

            // Tabela: TB_DADOS_CLIMATICOS
            modelBuilder.Entity<DadoClimatico>(entity =>
            {
                entity.ToTable("TB_DADOS_CLIMATICOS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_DADO");

                entity.Property(e => e.DispositivoId).HasColumnName("ID_DISPOSITIVO");
                entity.Property(e => e.DataColeta).HasColumnType("DATE").HasColumnName("DATA_COLETA").IsRequired();
                entity.Property(e => e.Temperatura).HasColumnType("NUMBER(5,2)").HasColumnName("TEMPERATURA");
                entity.Property(e => e.Umidade).HasColumnType("NUMBER(5,2)").HasColumnName("UMIDADE");
                entity.Property(e => e.Chuva1h).HasColumnType("NUMBER(5,2)").HasColumnName("CHUVA_MM_1H");
                entity.Property(e => e.Chuva3h).HasColumnType("NUMBER(5,2)").HasColumnName("CHUVA_MM_3H");
                entity.Property(e => e.VentoVelocidade).HasColumnType("NUMBER(5,2)").HasColumnName("VENTO_VEL_KMH");
                entity.Property(e => e.DescricaoClima).HasColumnType("VARCHAR2(100)").HasColumnName("DESCRICAO_CLIMA");
                entity.Property(e => e.Cidade).HasColumnType("VARCHAR2(100)").HasColumnName("CIDADE");
                entity.Property(e => e.LatApi).HasColumnType("NUMBER(9,6)").HasColumnName("LAT_API");
                entity.Property(e => e.LonApi).HasColumnType("NUMBER(9,6)").HasColumnName("LON_API");

                entity.HasOne(e => e.Dispositivo)
                      .WithMany(p => p.DadosClimaticos)
                      .HasForeignKey(e => e.DispositivoId)
                      .HasConstraintName("FK_DADOS_DISPOSITIVO")
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
