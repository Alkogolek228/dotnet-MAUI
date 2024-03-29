namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public record GetSongByIdQuery(int Id) : IRequest<Song>;
