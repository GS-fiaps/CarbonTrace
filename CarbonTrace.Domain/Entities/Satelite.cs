using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public sealed class Satelite(string nome, string agencia, double altitudeKm, int anoLancamento) : BaseEntity()
{
    public string Nome { get; private set; } = nome;
    public string Agencia { get; private set; } = agencia;
    public double AltitudeKm { get; private set; } = altitudeKm;
    public int AnoLancamento { get; private set; } = anoLancamento;

    // 1:N
    public List<ImagemSatelital> ImagensSatelitais { get; set; } = [];

    private Satelite() : this(string.Empty, string.Empty, 0, 0) { }
    
    public void Update(string nome, string agencia, double altitudeKm, int anoLancamento)
    {
        Nome = nome.Trim();
        Agencia = agencia.Trim();
        AltitudeKm = altitudeKm;
        AnoLancamento = anoLancamento;
    }
}