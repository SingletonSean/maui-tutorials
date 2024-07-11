using CrudDemo.Features.DeleteTicket;
using CrudDemo.Pages;
using CrudDemo.Shared;
using Microsoft.Extensions.Logging;

namespace CrudDemo
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

            builder.Services.AddSingleton<SqliteConnectionFactory>();

            builder.Services.AddSingleton<DeleteTicketMutation>();

            builder.Services.AddSingleton<BacklogView>();
            builder.Services.AddSingleton<BacklogViewModel>();

            return builder.Build();
        }
    }
}
