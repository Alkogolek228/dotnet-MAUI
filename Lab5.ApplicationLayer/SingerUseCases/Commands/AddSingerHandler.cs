namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public class AddSingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSingerCommand, Singer>
{
    public async Task<Singer> Handle(AddSingerCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.SingerRepository.AddAsync(request.Singer, cancellationToken);
        return request.Singer;
    }
}