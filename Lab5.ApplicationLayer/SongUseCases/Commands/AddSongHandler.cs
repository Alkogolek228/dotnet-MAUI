namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public class AddSongHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSongCommand, Song>
{
    public async Task<Song> Handle(AddSongCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.AddAsync(request.Song, cancellationToken);
        return request.Song;
    }
}