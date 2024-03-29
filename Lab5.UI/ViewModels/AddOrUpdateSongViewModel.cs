using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lab5.UI.ViewModels;

[QueryProperty("AddOrUpdate", "Action")]
[QueryProperty("SongToAddOrUpdate", nameof(Song))]
[QueryProperty("Singer", nameof(Singer))]
public partial class AddOrUpdateSongViewModel : ObservableObject
{
    [ObservableProperty]
    Song songToAddOrUpdate = new();

    [ObservableProperty]
    Singer singer = new();

    [ObservableProperty]
    FileResult image;

    [RelayCommand]
    public async Task PickImage()
    {
        var customFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                    { DevicePlatform.Android, new[] { ".png", ".jpg" } },
                    { DevicePlatform.WinUI, new[] { ".png", ".jpg" } },
            });

        PickOptions options = new()
        {
            PickerTitle = "Please select a png image",
            FileTypes = customFileType,
        };

        try
        {
            var result = await FilePicker.Default.PickAsync(options);

            if (result is not null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    Image = result;
                }
            }
        }
        catch (Exception)
        {
            return;
        }

        return;
    }

    public Func<Song, Task<Song>> AddOrUpdate { get; set; }

    [RelayCommand]
    public async Task AddOrUpdateSong()
    {
        if (string.IsNullOrEmpty(SongToAddOrUpdate.Name) ||
            SongToAddOrUpdate.Position<1 ||
            SongToAddOrUpdate.DurationInSeconds < 1
            )
        {
            return;
        }

        SongToAddOrUpdate.Singer = SongToAddOrUpdate.Singer ?? Singer;

        await AddOrUpdate(SongToAddOrUpdate);

        if (Image is not null)
        {
            using var stream = await Image.OpenReadAsync();
            var image = ImageSource.FromStream(() => stream);

            string filename = Path.Combine(Preferences.Default.Get<string>("LocalData", null), $"{SongToAddOrUpdate.Id}.png");

            using var fileStream = File.Create(filename);
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
            stream.Seek(0, SeekOrigin.Begin);
        }

        await Shell.Current.GoToAsync("..");
    }
}
