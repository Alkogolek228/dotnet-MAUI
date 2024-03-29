namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public record AddSongCommand(Song Song):IRequest<Song>;
