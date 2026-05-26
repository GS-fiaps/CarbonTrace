using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public sealed class Relatorio(string titulo, DateTime periodoInicio, DateTime periodoFim, Guid idUsuario) : BaseEntity()
{
    public string Titulo { get; private set; } = titulo;
    public DateTime DataGeracao { get; private set; } = DateTime.UtcNow;
    public DateTime PeriodoInicio { get; private set; } = periodoInicio;
    public DateTime PeriodoFim { get; private set; } = periodoFim;

    // N:1
    public Guid IdUsuario { get; private set; } = idUsuario;
    public Usuario Usuario { get; private set; } = null!;

    private Relatorio() : this(string.Empty, DateTime.UtcNow, DateTime.UtcNow, Guid.Empty) { }
    
    public void Update(string titulo, DateTime periodoInicio, DateTime periodoFim)
    {
        Titulo = titulo.Trim();
        PeriodoInicio = periodoInicio;
        PeriodoFim = periodoFim;
    }
}