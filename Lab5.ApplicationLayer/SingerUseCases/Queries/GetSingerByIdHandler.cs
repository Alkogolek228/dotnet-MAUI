namespace Lab5.ApplicationLayer.SingerUseCases.Queries;

public class GetSingerByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSingerByIdQuery, Singer>
{
    public async Task<Singer> Handle(GetSingerByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.SingerRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
