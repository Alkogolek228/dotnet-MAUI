namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public record UpdateSingerCommand(Singer Singer) : IRequest<Singer>;
