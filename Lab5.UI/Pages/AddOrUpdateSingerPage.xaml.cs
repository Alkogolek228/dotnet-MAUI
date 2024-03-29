using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class AddOrUpdateSingerPage : ContentPage
{
	public AddOrUpdateSingerPage(AddOrUpdateSingerViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}