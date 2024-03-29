namespace Lab5.ApplicationLayer.SingerUseCases.Queries;

public class GetAllSingersHandler(IUnitOfWork unitOfWork): IRequestHandler<GetAllSingersQuery, IEnumerable<Singer>>
{
    public async Task<IEnumerable<Singer>> Handle(GetAllSingersQuery request, CancellationToken cancellationToken)
    { 
        return await unitOfWork.SingerRepository.GetAllAsync(cancellationToken);
    }
}
