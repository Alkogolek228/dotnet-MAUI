using Microsoft.Extensions.DependencyInjection;

namespace Lab5.ApplicationLayer;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        await unitOfWork.RemoveDatabaseAsync();
        await unitOfWork.CreateDatabaseAsync();

        IReadOnlyList<Singer> singers =
            [
            new (){Name = "DbSingerName1", Age = 41 },
            new (){Name = "DbSingerName2", Age = 23 },
            ];

        foreach (var singer in singers)
            await unitOfWork.SingerRepository.AddAsync(singer);

        await unitOfWork.SaveAllAsync();

        for (int i = 1; i <= 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                await unitOfWork.SongRepository.AddAsync(new()
                {
                    Name = $"DbSongName{i}{j}",
                    DurationInSeconds = 120 + i * j,
                    Position = j * 2 + i,
                    SingerId = singers[i-1].Id,
                    Singer = singers[i-1]
                });
            }
        }

        await unitOfWork.SaveAllAsync();
    }
}

