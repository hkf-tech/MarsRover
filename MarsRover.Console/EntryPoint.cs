using MarsRover.BusinessLogic;
using System.Threading.Tasks;

namespace MarsRover.Console
{
    public class EntryPoint
    {
        private readonly INavigationOrchestrator _navigationOrchestrator;

        public EntryPoint(INavigationOrchestrator navigationOrchestrator)
        {
            _navigationOrchestrator = navigationOrchestrator;
        }

        public async Task Run()
        {
            System.Console.WriteLine("Enter the Mars plateau size in format like 5x5");
            var coordinatesAsString = System.Console.ReadLine();
            System.Console.WriteLine("Enter the Mars navigation command like FFRFLFLF");
            var commands = System.Console.ReadLine();

            var coordinatesArray = coordinatesAsString.Split('x');
            var maxCoodinates = new System.Drawing.Point(int.Parse(coordinatesArray[0]), int.Parse(coordinatesArray[1]));

            var result = await _navigationOrchestrator.NavigateRover(maxCoodinates, commands);

            System.Console.WriteLine($"{result.CurrentPosition.X}, {result.CurrentPosition.Y}, {result.Direction}");
        }
    }
}
