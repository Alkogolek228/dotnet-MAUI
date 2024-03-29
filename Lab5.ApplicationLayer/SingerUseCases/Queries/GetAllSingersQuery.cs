namespace Lab5.ApplicationLayer.SingerUseCases.Queries;

public record GetAllSingersQuery : IRequest<IEnumerable<Singer>>;
