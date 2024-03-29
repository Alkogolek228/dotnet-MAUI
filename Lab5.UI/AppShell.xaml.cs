using Lab5.UI.Pages;

namespace Lab5.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SongDetailsPage), typeof(SongDetailsPage));
        Routing.RegisterRoute(nameof(AddOrUpdateSingerPage), typeof(AddOrUpdateSingerPage));
        Routing.RegisterRoute(nameof(AddOrUpdateSongPage), typeof(AddOrUpdateSongPage));
    }
}
