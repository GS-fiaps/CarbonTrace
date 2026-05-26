using CarbonTrace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonTrace.Infrastructure;

/// <summary>
/// Contexto EF CORE do projeto Carbo Trace
/// Configura o mapeamento das entidades para o banco de dados
/// </summary>
public class CarbonTraceContext(DbContextOptions<CarbonTraceContext> options) : DbContext(options)
{
    // CODE FIRST
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
}