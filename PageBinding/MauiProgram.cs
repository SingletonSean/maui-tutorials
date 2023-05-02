using Microsoft.Extensions.Logging;
using PageBinding.Entities;

namespace PageBinding
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
            var services = builder.Services;

            services.AddSingleton(new Profile("SingletonSean", "123 Main St."));

            return builder.Build();
        }
    }
}