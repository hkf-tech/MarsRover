using MarsRover.BusinessLogic.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveFowrwardCommandHandler : IRequestHandler<MoveForwardCommand, Coordinates>
    {
        public Task<Coordinates> Handle(MoveForwardCommand command, CancellationToken cancellationToken)
        {
            var coordinates = command.CurrentCoordinates;
            switch (coordinates.Direction)
            {
                case Direction.North:
                    if (coordinates.CurrentPosition.Y < command.MaxAllowedCoordinates.Y)
                    {
                        coordinates.CurrentPosition = new System.Drawing.Point(coordinates.CurrentPosition.X, coordinates.CurrentPosition.Y +1);
                    }
                    break;

                case Direction.East:
                    if (coordinates.CurrentPosition.X < command.MaxAllowedCoordinates.X)
                    {
                        coordinates.CurrentPosition = new System.Drawing.Point(coordinates.CurrentPosition.X+1, coordinates.CurrentPosition.Y);
                    }
                    break;

                case Direction.South:
                    if (coordinates.CurrentPosition.Y > 1)
                    {
                        coordinates.CurrentPosition = new System.Drawing.Point(coordinates.CurrentPosition.X, coordinates.CurrentPosition.Y - 1);
                    }
                    break;

                case Direction.West:
                    if (coordinates.CurrentPosition.X > 1)
                    {
                        coordinates.CurrentPosition = new System.Drawing.Point(coordinates.CurrentPosition.X - 1, coordinates.CurrentPosition.Y);
                    }
                    break;
            }
            return Task.FromResult(coordinates);
        }
    }
}
