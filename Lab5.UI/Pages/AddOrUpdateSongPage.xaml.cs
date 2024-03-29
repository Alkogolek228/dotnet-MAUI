using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class AddOrUpdateSongPage : ContentPage
{
	public AddOrUpdateSongPage(AddOrUpdateSongViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}