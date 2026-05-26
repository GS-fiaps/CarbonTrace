using CarbonTrace.Domain.Commom;
using CarbonTrace.Domain.Enum;

namespace CarbonTrace.Domain.Entities;

public sealed class Analise(DateTime dataAnalise, double areaDesmatadaKm2, double percentualVariacao, StatusAlertaEnum statusAlerta, Guid idImagem) : BaseEntity()
{
    public DateTime DataAnalise { get; private set; } = dataAnalise;
    public double AreaDesmatadaKm2 { get; private set; } = areaDesmatadaKm2;
    public double PercentualVariacao { get; private set; } = percentualVariacao;
    public StatusAlertaEnum StatusAlerta { get; private set; } = statusAlerta;

    // N:1
    public Guid IdImagem { get; private set; } = idImagem;
    public ImagemSatelital ImagemSatelital { get; private set; } = null!;

    // 1:N
    public List<Alerta> Alertas { get; set; } = [];

    private Analise() : this(DateTime.UtcNow, 0, 0, StatusAlertaEnum.NORMAL, Guid.Empty) { }
    
    public void Update(DateTime dataAnalise, double areaDesmatadaKm2, double percentualVariacao, StatusAlertaEnum statusAlerta)
    {
        DataAnalise = dataAnalise;
        AreaDesmatadaKm2 = areaDesmatadaKm2;
        PercentualVariacao = percentualVariacao;
        StatusAlerta = statusAlerta;
    }
}