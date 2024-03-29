namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public class DeleteSongHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteSongCommand, Song>
{
    public async Task<Song> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.DeleteAsync(request.Song, cancellationToken);
        return request.Song;
    }
}