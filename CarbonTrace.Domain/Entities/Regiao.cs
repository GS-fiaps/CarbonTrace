using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public sealed class Regiao(string nome, double latitude, double longitude, double areaKm2, Guid idEstado) : BaseEntity()
{
    public string Nome { get; private set; } = nome;
    public double Latitude { get; private set; } = latitude;
    public double Longitude { get; private set; } = longitude;
    public double AreaKm2 { get; private set; } = areaKm2;

    // N:1
    public Guid IdEstado { get; private set; } = idEstado;
    public Estado Estado { get; private set; } = null!;

    // 1:N
    public List<ImagemSatelital> ImagensSatelitais { get; set; } = [];
    public List<Ocorrencia> Ocorrencias { get; set; } = [];

    private Regiao() : this(string.Empty, 0, 0, 0, Guid.Empty) { }
}