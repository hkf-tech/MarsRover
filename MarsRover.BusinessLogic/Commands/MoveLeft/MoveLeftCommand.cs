using MarsRover.BusinessLogic.Models;
using MediatR;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveLeftCommand : IRequest<Coordinates>
    {
        public MoveLeftCommand(Coordinates cuurentCoordinates)
        {
            CurrentCoordinates = cuurentCoordinates;
        }
        public Coordinates CurrentCoordinates { get; set; }
    }
}
