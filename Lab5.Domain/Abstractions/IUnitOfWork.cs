using Lab5.Domain.Entities;

namespace Lab5.Domain.Abstractions;

public interface IUnitOfWork
{
    IRepository<Song> SongRepository { get; }
    IRepository<Singer> SingerRepository { get; }
    public Task RemoveDatabaseAsync();
    public Task CreateDatabaseAsync();
    public Task SaveAllAsync();
}
