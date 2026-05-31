using Microsoft.EntityFrameworkCore;
using CarbonTrace.Application.Repositories;
using CarbonTrace.Domain.Commom;

namespace CarbonTrace.Infrastructure.Persistence.Repositories;

public class Repository<T>(CarbonTraceContext context) : IRepository<T> where T : BaseEntity
{
    protected CarbonTraceContext Context { get; } = context;
    private readonly DbSet<T> _set = context.Set<T>();
    private const string MainNamePropertyName = "Name";

    /// <inheritdoc />
    public bool ExistsById(Guid id)
    {
        return _set.FirstOrDefault(e => e.Id == id) is not null;
    }

    private void ThrowIfMainNameNotMapped()
    {
        var entityType = Context.Model.FindEntityType(typeof(T));
        if (entityType is null)
        {
            throw new InvalidOperationException(
                $"Não é possível usar ExistsByMainName/ExistsByName/ExistsByTitle: o tipo '{typeof(T).Name}' não está registrado no modelo do Entity Framework.");
        }

        var prop = entityType.FindProperty(MainNamePropertyName);
        if (prop is null || prop.ClrType != typeof(string))
        {
            throw new InvalidOperationException(
                $"Não é possível usar ExistsByMainName/ExistsByName/ExistsByTitle: a entidade '{typeof(T).Name}' não possui a propriedade '{MainNamePropertyName}' (texto) mapeada. " +
                "Esse método só se aplica a agregados cuja coluna principal de denominação é 'Name'.");
        }
    }

    /// <inheritdoc />
    public IReadOnlyList<T> GetAll()
    {
        return _set
            .Where(e => e.Active)
            .OrderBy(e => e.CreatedAt)
            .ToList();
    }

    /// <inheritdoc />
    public T? GetById(Guid id)
    {
        return _set.Find(id);
    }

    /// <inheritdoc />
    public T Add(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _set.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity is null)
            return false;

        entity.Active = false;
        _set.Update(entity);
        Context.SaveChanges();
        return true;
    }
    
    /// <inheritdoc />
    public T Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _set.Update(entity);
        Context.SaveChanges();
        return entity;
    }
}