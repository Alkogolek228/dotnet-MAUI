namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public class UpdateSingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateSingerCommand, Singer>
{
    public async Task<Singer> Handle(UpdateSingerCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SingerRepository.UpdateAsync(request.Singer, cancellationToken);
        return request.Singer;
    }
}
