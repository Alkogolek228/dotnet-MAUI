namespace Lab5.ApplicationLayer.SingerUseCases.Queries;

public record GetSingerByIdQuery(int Id) : IRequest<Singer>;
