namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public class GetSongByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongByIdQuery, Song>
{
    public async Task<Song> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.SongRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
