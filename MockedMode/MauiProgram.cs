using Microsoft.Extensions.Logging;
using MockedMode.Features.ViewRandomCatFact;
using MockedMode.Pages;

namespace MockedMode
{
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IRandomCatFactQuery, RandomCatFactQuery>();

            builder.Services.AddSingleton<RandomCatFactViewModel>();
            builder.Services.AddSingleton<RandomCatFactView>(s => new RandomCatFactView()
            {
                BindingContext = s.GetRequiredService<RandomCatFactViewModel>()
            });

            return builder.Build();
        }
    }
}