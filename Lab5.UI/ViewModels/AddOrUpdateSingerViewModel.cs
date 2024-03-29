using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lab5.UI.ViewModels;

[QueryProperty("AddOrUpdate", "Action")]
[QueryProperty("SingerToAddOrUpdate", nameof(Singer))]
public partial class AddOrUpdateSingerViewModel : ObservableObject
{
    [ObservableProperty]
    public Singer singerToAddOrUpdate = new();

    public Func<Singer, Task<Singer>> AddOrUpdate { get; set; }

    [RelayCommand]
    public async Task AddOrUpdateSinger()
    {
        if (string.IsNullOrEmpty(singerToAddOrUpdate.Name))
            return;

        await AddOrUpdate(singerToAddOrUpdate);

        await Shell.Current.GoToAsync("..");
    }
}
