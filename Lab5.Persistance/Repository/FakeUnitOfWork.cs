namespace Lab5.Persistence.Repository;

public class FakeUnitOfWork:IUnitOfWork
{
    private readonly FakeSongRepository _songRepository;
    private readonly FakeSingerRepository _singerRepository;

    public FakeUnitOfWork()
    {
        _songRepository = new();
        _singerRepository = new();
    }
    public IRepository<Song> SongRepository => _songRepository;

    public IRepository<Singer> SingerRepository => _singerRepository;

    public Task CreateDatabaseAsync()
    {
        throw new NotImplementedException();
    }

    public Task RemoveDatabaseAsync()
    {
        throw new NotImplementedException();
    }

    public Task SaveAllAsync()
    {
        throw new NotImplementedException();
    }
}
