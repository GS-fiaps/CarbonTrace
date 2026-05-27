using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Domain.Entities;

public class Estado(string nome, string sigla)  : BaseEntity
{
    public string Nome { get; set; } = nome;
    public string Sigla { get; set; } = sigla;
    
    
    // 1:N
    public List<Regiao> Regioes { get; set; } = [];
    public List<OrgaoAmbiental> OrgaosAmbientais { get; set; } = [];

    private Estado() : this(string.Empty, string.Empty) { }
    
    public void Update(string nome, string sigla)
    {
        Nome = nome.Trim();
        Sigla = sigla.Trim().ToUpperInvariant();
    }
}