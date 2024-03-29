using Lab5.Persistence.Data;

namespace Lab5.Persistence.Repository;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Lazy<IRepository<Song>> _songRepository;
    private readonly Lazy<IRepository<Singer>> _singerRepository;

    public EfUnitOfWork(AppDbContext context)
    {
        _context = context;
        _songRepository = new(() => new EfRepository<Song>(context));
        _singerRepository = new(() => new EfRepository<Singer>(context));
    }

    public async Task CreateDatabaseAsync()
    {
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task RemoveDatabaseAsync()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    public async Task SaveAllAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IRepository<Song> SongRepository => _songRepository.Value;

    public IRepository<Singer> SingerRepository => _singerRepository.Value;
}