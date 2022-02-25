using MarsRover.BusinessLogic.Models;
using MediatR;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveRightCommand : IRequest<Coordinates>
    {
        public MoveRightCommand(Coordinates cuurentCoordinates)
        {
            CurrentCoordinates = cuurentCoordinates;
        }
        public Coordinates CurrentCoordinates { get; set; }
    }
}
