namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public record DeleteSongCommand(Song Song) : IRequest<Song>;
