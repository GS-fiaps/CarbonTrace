using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public sealed class Ocorrencia(DateTime dataOcorrencia, string descricao, double areaEstimadaKm2, Guid idRegiao, Guid idUsuario) : BaseEntity()
{
    public DateTime DataOcorrencia { get; private set; } = dataOcorrencia;
    public string Descricao { get; private set; } = descricao;
    public double AreaEstimadaKm2 { get; private set; } = areaEstimadaKm2;

    // N:1
    public Guid IdRegiao { get; private set; } = idRegiao;
    public Regiao Regiao { get; private set; } = null!;

    public Guid IdUsuario { get; private set; } = idUsuario;
    public Usuario Usuario { get; private set; } = null!;

    private Ocorrencia() : this(DateTime.UtcNow, string.Empty, 0, Guid.Empty, Guid.Empty) { }
    
    public void Update(DateTime dataOcorrencia, string descricao, double areaEstimadaKm2)
    {
        DataOcorrencia = dataOcorrencia;
        Descricao = descricao.Trim();
        AreaEstimadaKm2 = areaEstimadaKm2;
    }
}