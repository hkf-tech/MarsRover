using MediatR;
using MarsRover.BusinessLogic;
using MarsRover.BusinessLogic.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Console
{
    public class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddMediatR(typeof(MoveFowrwardCommandHandler));

            services.AddSingleton<INavigationOrchestrator, NavigrationOrchestrator>();

            services.AddTransient<EntryPoint>();

            return services;
        }
    }
}
