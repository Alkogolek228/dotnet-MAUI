namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public record GetSongsBySingerQuery(int SingerId) : IRequest<IEnumerable<Song>>;
