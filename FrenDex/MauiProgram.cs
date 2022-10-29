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
                fonts.AddFont("Montserrat-Medium.ttf", "RegularFont");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MediumFont");
                fonts.AddFont("Montserrat-Bold.ttf", "BoldFont");
            });

        #region Dependency Injections

		// Services
        builder.Services.AddSingleton<IFriendRepository, FriendRepository>();

        // Views
        builder.Services.AddSingleton<FriendListPage>();
		builder.Services.AddTransient<AddUpdateFriendPage>();
		builder.Services.AddTransient<FriendDetailsPage>();

        // ViewModels
        builder.Services.AddSingleton<FriendListViewModel>();
		builder.Services.AddTransient<AddUpdateFriendViewModel>();
		builder.Services.AddTransient<FriendDetailsViewModel>();

        #endregion

        return builder.Build();
	}
}
