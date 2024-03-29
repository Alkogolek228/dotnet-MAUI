using System.Linq.Expressions;

namespace Lab5.Persistence.Repository;

public class FakeSongRepository : IRepository<Song>
{
    private readonly List<Song> _songs;

    public FakeSongRepository()
    {
        _songs = [];
        for (int i = 1; i <= 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _songs.Add(new()
                {
                    Id = j+10*(i-1),
                    Name = $"SongName{i}{j}",
                    DurationInSeconds = 120 + i * j,
                    Position = j * 2 + i,
                    SingerId = i,
                });
            }
        }
    }

    public Task AddAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Song> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Song>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Song>> GetFilteredAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
    {
        IQueryable<Song> data = _songs.AsQueryable();
        return Task.Run(() => data.Where(filter).ToList() as IReadOnlyList<Song>);
    }

    public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

