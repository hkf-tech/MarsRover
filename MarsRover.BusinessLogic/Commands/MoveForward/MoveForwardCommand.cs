using MarsRover.BusinessLogic.Models;
using MediatR;
using System.Drawing;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveForwardCommand : IRequest<Coordinates>
    {
        public MoveForwardCommand(Coordinates currentCoordinates, Point maxAllowedCoordinates)
        {
            CurrentCoordinates = currentCoordinates;
            MaxAllowedCoordinates = maxAllowedCoordinates;
        }
        public Coordinates CurrentCoordinates { get; set; }
        public Point MaxAllowedCoordinates { get; set; }
    }
}
