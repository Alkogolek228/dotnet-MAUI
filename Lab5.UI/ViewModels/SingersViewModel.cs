using Lab5.ApplicationLayer.SingerUseCases.Commands;
using Lab5.ApplicationLayer.SingerUseCases.Queries;
using Lab5.ApplicationLayer.SongUseCases.Commands;
using Lab5.ApplicationLayer.SongUseCases.Queries;
using Lab5.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Lab5.UI.ViewModels;

public partial class SingersViewModel(IMediator mediator) : ObservableObject
{
    private readonly IMediator _mediator = mediator;

    [ObservableProperty]
    private ObservableCollection<Singer> _singers = [];

    [ObservableProperty]
    private ObservableCollection<Song> _songs = [];

    [ObservableProperty]
    private Singer selectedSinger;

    [RelayCommand]
    async Task ShowDetails(Song song) => await GotoDetailsPage(song);

    private async Task GotoDetailsPage(Song song)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Song", song }
            };

        await Shell.Current.GoToAsync(nameof(SongDetailsPage), parameters);
    }

    [RelayCommand]
    public async Task AddSong()
    {
        if (SelectedSinger is not null)
        {
            await GotoAddOrUpdatePage<AddOrUpdateSongPage, Song>((Song song)=>_mediator.Send(new AddSongCommand(song)), SelectedSinger);
        }
    }
    [RelayCommand]
    public async Task AddSinger() => await GotoAddOrUpdatePage<AddOrUpdateSingerPage, Singer>((Singer singer)=>_mediator.Send(new AddSingerCommand(singer)), SelectedSinger);

    [RelayCommand]
    public async Task UpdateSinger()
    {
        if (SelectedSinger is not null)
        {
            await GotoAddOrUpdatePage<AddOrUpdateSingerPage, Singer>((Singer singer)=>_mediator.Send(new UpdateSingerCommand(singer)), SelectedSinger);
        }
    }

    [RelayCommand]
    public async Task DeleteSinger()
    {
        if(SelectedSinger is not null)
        {
            await _mediator.Send(new DeleteSingerCommand(SelectedSinger));
            await UpdateSingers();
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
            if (entity is not null)
            {
                string name = entity.GetType().Name;
                parameters.Add(name, entity);
            }
        }

        await Shell.Current.GoToAsync(typeof(Page).Name, parameters);
    }

    [RelayCommand]
    public async Task UpdateSingers() => await GetSingers();

    [RelayCommand]
    public async Task UpdateSongs() => await GetSongs();
    public async Task GetSingers()
    {
        var singers = await _mediator.Send(new GetAllSingersQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Singers.Clear();
            foreach (var singer in singers)
                Singers.Add(singer);
        });
    }
    public async Task GetSongs()
    {
        if (SelectedSinger is null)
            return; 
        else
        {
            var songs = await _mediator.Send(new GetSongsBySingerQuery(SelectedSinger.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Songs.Clear();
                foreach (var song in songs)
                    Songs.Add(song);
            });
        }
    }
}
