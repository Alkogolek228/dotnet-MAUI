using Lab5.ApplicationLayer.SongUseCases.Commands;
using Lab5.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.ApplicationLayer.SingerUseCases.Commands;

namespace Lab5.UI.ViewModels;

[QueryProperty("Song", "Song")]
public partial class SongDetailsViewModel(IMediator mediator) : ObservableObject
{
    private readonly IMediator _mediator = mediator;

    [ObservableProperty]
    Song song;

    [RelayCommand]
    public async Task UpdateSong() => await GotoAddOrUpdatePage<AddOrUpdateSongPage, Song>((Song song)=>_mediator.Send(new UpdateSongCommand(song)), Song);

    [RelayCommand]
    public async Task DeleteSong()
    {
        if (Song is not null)
        {
            await _mediator.Send(new DeleteSongCommand(Song));
            await Shell.Current.GoToAsync("..");
        }
    }

    private static async Task GotoAddOrUpdatePage<Page, Entity>(Func<Entity, Task<Entity>> method, params object[] entities)
        where Entity : class
        where Page : ContentPage
    {
        Dictionary<string, object> parameters = new()
            {
                { "Action", method }
            };

        foreach (object entity in entities)
        {
            string name = entity.GetType().Name;
            parameters.Add(name, entity);
        }

        await Shell.Current.GoToAsync(typeof(Page).Name, parameters);
    }
}
