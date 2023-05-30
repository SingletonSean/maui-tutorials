using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MockedMode.Features.ViewRandomCatFact;
using MockedMode.Features.ViewRandomCatFact.Mock;
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

            bool isMockedMode = Environment.GetCommandLineArgs().Any(a => a == "MOCKED_MODE");

            if (isMockedMode)
            {
                builder.Services.AddSingleton<IRandomCatFactQuery, MockRandomCatFactQuery>();
            }
            else
            {
                builder.Services.AddSingleton<IRandomCatFactQuery, RandomCatFactQuery>();
            }

            builder.Services.AddSingleton<RandomCatFactViewModel>();
            builder.Services.AddSingleton<RandomCatFactView>(s => new RandomCatFactView()
            {
                BindingContext = s.GetRequiredService<RandomCatFactViewModel>()
            });

            return builder.Build();
        }
    }
}