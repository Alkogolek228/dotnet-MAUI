namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public class DeleteSingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteSingerCommand, Singer>
{
    public async Task<Singer> Handle(DeleteSingerCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SingerRepository.DeleteAsync(request.Singer, cancellationToken);
        return request.Singer;
    }
}
