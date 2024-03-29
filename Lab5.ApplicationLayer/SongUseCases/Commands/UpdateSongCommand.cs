namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public record UpdateSongCommand(Song Song):IRequest<Song>;