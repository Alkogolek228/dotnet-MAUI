namespace Lab5.ApplicationLayer.SingerUseCases.Commands;

public record AddSingerCommand(Singer Singer):IRequest<Singer>;
