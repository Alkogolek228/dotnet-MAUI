namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public class GetSongsBySingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongsBySingerQuery, IEnumerable<Song>>
{
    public async Task<IEnumerable<Song>> Handle(GetSongsBySingerQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.SongRepository.GetFilteredAsync(s => s.SingerId == request.SingerId, cancellationToken);
    }
}
