using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public sealed class ImagemSatelital(DateTime dataCaptura, double resolucaoMetros, string urlImagem, Guid idRegiao, Guid idSatelite) : BaseEntity()
{
    public DateTime DataCaptura { get; private set; } = dataCaptura;
    public double ResolucaoMetros { get; private set; } = resolucaoMetros;
    public string UrlImagem { get; private set; } = urlImagem;

    // N:1
    public Guid IdRegiao { get; private set; } = idRegiao;
    public Regiao Regiao { get; private set; } = null!;

    public Guid IdSatelite { get; private set; } = idSatelite;
    public Satelite Satelite { get; private set; } = null!;

    // 1:N
    public List<Analise> Analises { get; set; } = [];

    private ImagemSatelital() : this(DateTime.UtcNow, 0, string.Empty, Guid.Empty, Guid.Empty) { }
}