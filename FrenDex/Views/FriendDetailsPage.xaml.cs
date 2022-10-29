using FrenDex.ViewModels;

namespace FrenDex.Views;

public partial class FriendDetailsPage : ContentPage
{
	public FriendDetailsPage(FriendDetailsViewModel friendDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = friendDetailsViewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}