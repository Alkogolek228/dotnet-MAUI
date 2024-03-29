namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public record DeleteSingerCommand(Singer Singer) : IRequest<Singer>;
