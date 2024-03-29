using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class SongDetailsPage : ContentPage
{
	public SongDetailsPage(SongDetailsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}