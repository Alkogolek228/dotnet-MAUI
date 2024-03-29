namespace Lab5.ApplicationLayer.SongUseCases.Commands;

public class UpdateSongHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateSongCommand, Song>
{
    public async Task<Song> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SongRepository.UpdateAsync(request.Song, cancellationToken);
        return request.Song;
    }
}