using Microsoft.Extensions.Logging;
using Project.Pages;
using Project.ViewModel;

namespace Project;

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
				fonts.AddFont("NotoSansThai.ttf", "Noto");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif


		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<SearchPage>();
		builder.Services.AddSingleton<SearchViewModel>();
		builder.Services.AddSingleton<RemoveClassPage>();
		builder.Services.AddSingleton<RemoveClassViewModel>();
		builder.Services.AddSingleton<RegisteredPage>();
		builder.Services.AddSingleton<RegisteredViewModel>();
		builder.Services.AddSingleton<ProfliePage>();
		builder.Services.AddSingleton<ProfileViewModel>();

		return builder.Build();
	}
}
