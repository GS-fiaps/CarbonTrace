using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonTrace.Infrastructure;

public class CarbonTraceContext(DbContextOptions<CarbonTraceContext> options) : DbContext(options)
{
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Satelite> Satelites { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Regiao> Regioes { get; set; }
    public DbSet<OrgaoAmbiental> OrgaosAmbientais { get; set; }
    public DbSet<ImagemSatelital> ImagensSatelitais { get; set; }
    public DbSet<Analise> Analises { get; set; }
    public DbSet<Alerta> Alertas { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }
    public DbSet<AlertaOrgao> AlertasOrgaos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarbonTraceContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //  Garante que todos os Guid sejam armazenados como VARCHAR2(36) no Oracle
        configurationBuilder
            .Properties<Guid>()
            .HaveColumnType("VARCHAR2(36)");

        //  Garante que todos os bool sejam armazenados como NUMBER(1) no Oracle
        configurationBuilder
            .Properties<bool>()
            .HaveColumnType("NUMBER(1)");
    }
}