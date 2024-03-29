using Lab5.UI.Pages;
using Lab5.UI.ViewModels;
using CommunityToolkit.Maui;
using Lab5.ApplicationLayer;
using Lab5.Persistence;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Lab5.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;

namespace Lab5.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "Lab5.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);

        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = string.Format(connStr, dataDirectory);

        builder
            .UseMauiApp<App>()
            .UseFontAwesome()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;
       
        builder.Services
            .AddApplication()
            .AddPersistence(options)
            .RegisterPages()
            .RegisterViewModels();

        DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();

        return builder.Build();
    }

    static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddTransient<SingersPage>()
            .AddTransient<SongDetailsPage>()
            .AddTransient<AddOrUpdateSingerPage>()
            .AddTransient<AddOrUpdateSongPage>();

        return services;
    }
    static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddTransient<SingersViewModel>()
            .AddTransient<SongDetailsViewModel>()
            .AddTransient<AddOrUpdateSingerViewModel>()
            .AddTransient<AddOrUpdateSongViewModel>();

        return services;
    }


}