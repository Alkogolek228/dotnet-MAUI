namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public record GetAllSongsQuery : IRequest<IEnumerable<Song>>;
