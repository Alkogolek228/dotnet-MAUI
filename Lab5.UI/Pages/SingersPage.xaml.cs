using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages;

public partial class SingersPage : ContentPage
{
	public SingersPage(SingersViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}