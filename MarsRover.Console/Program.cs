using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MarsRover.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<EntryPoint>().Run();
        }
    }
}
