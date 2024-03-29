using System.Linq.Expressions;

namespace Lab5.Persistence.Repository;

public class FakeSingerRepository : IRepository<Singer>
{
    private readonly List<Singer> _singers;

    public FakeSingerRepository()
    {
        _singers =
            [
                new()
                {
                    Id = 1,
                    Name = "SingerName1",
                    Age = 42,
                    Songs = []
                },
                new()
                {
                    Id = 2,
                    Name = "SingerName2",
                    Age = 20,
                    Songs = []
                },
            ];
    }

    public Task AddAsync(Singer entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Singer entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Singer> FirstOrDefaultAsync(Expression<Func<Singer, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Singer> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Singer, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Singer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(() => _singers as IReadOnlyList<Singer>);
    }

    public Task<IReadOnlyList<Singer>> GetFilteredAsync(Expression<Func<Singer, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Singer, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Singer entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
