using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Entities;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public sealed class ImagemSatelitalRepository(CarbonTraceContext context)
    : Repository<ImagemSatelital>(context), IImagemSatelitalRepository
{
    /// <inheritdoc />
    public IReadOnlyList<ImagemSatelital> GetByRegiao(Guid idRegiao)
    {
        return Context.ImagensSatelitais
            .Where(i => i.IdRegiao == idRegiao)
            .OrderBy(i => i.CreatedAt)
            .ToList();
    }

    /// <inheritdoc />
    public IReadOnlyList<ImagemSatelital> GetBySatelite(Guid idSatelite)
    {
        return Context.ImagensSatelitais
            .Where(i => i.IdSatelite == idSatelite)
            .OrderBy(i => i.CreatedAt)
            .ToList();
    }
}