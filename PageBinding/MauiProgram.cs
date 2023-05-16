using Microsoft.Extensions.Logging;
using PageBinding.Entities;
using PageBinding.Pages;

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

            services.AddSingleton<ProfileViewModel>();
            services.AddSingleton<ProfileView>(serviceProvider => new ProfileView()
            {
                BindingContext = serviceProvider.GetRequiredService<ProfileViewModel>()
            });

            return builder.Build();
        }

        private static void AddView<TView, TViewModel>(this IServiceCollection services)
            where TView : ContentPage, new()
        {
            services.AddSingleton<TView>(serviceProvider => new TView()
            {
                BindingContext = serviceProvider.GetRequiredService<TViewModel>()
            });
        }
    }
}