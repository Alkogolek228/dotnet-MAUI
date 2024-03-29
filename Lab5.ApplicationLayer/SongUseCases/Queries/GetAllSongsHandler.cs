namespace Lab5.ApplicationLayer.SongUseCases.Queries;

public class GetAllSongsHandler(IUnitOfWork unitOfWork): IRequestHandler<GetAllSongsQuery, IEnumerable<Song>>
{
    public async Task<IEnumerable<Song>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
    { 
        return await unitOfWork.SongRepository.GetAllAsync(cancellationToken);
    }
}
