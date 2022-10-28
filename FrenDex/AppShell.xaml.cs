using FrenDex.Views;

namespace FrenDex;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateFriendPage), typeof(AddUpdateFriendPage));
	}
}
