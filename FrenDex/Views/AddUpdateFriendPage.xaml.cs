using FrenDex.ViewModels;

namespace FrenDex.Views;

public partial class AddUpdateFriendPage : ContentPage
{
	public AddUpdateFriendPage(AddUpdateFriendViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}