using FrenDex.Repositories;
using FrenDex.ViewModels;
using FrenDex.Views;

namespace FrenDex;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        #region Dependency Injections

		// Services
        builder.Services.AddSingleton<IFriendRepository, FriendRepository>();

        // Views
        builder.Services.AddSingleton<FriendListPage>();
		builder.Services.AddTransient<AddUpdateFriendPage>();

        // ViewModels
        builder.Services.AddSingleton<FriendListViewModel>();
		builder.Services.AddTransient<AddUpdateFriendViewModel>();

        #endregion

        return builder.Build();
	}
}
