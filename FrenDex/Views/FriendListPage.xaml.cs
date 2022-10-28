using FrenDex.ViewModels;

namespace FrenDex.Views;

public partial class FriendListPage : ContentPage
{
	private FriendListViewModel _viewModel;
	public FriendListPage(FriendListViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetFriendListAsyncCommand.Execute(null);
	}
}