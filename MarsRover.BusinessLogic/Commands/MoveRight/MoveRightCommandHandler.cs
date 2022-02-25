using MarsRover.BusinessLogic.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveRightCommandHandler : IRequestHandler<MoveRightCommand, Coordinates>
    {
        public Task<Coordinates> Handle(MoveRightCommand request, CancellationToken cancellationToken)
        {
            var coordinates = request.CurrentCoordinates;
            switch (coordinates.Direction)
            {
                case Direction.North:
                    coordinates.Direction = Direction.East;
                    break;

                case Direction.East:
                    coordinates.Direction = Direction.South;
                    break;

                case Direction.South:
                    coordinates.Direction = Direction.West;
                    break;

                case Direction.West:
                    coordinates.Direction = Direction.North;
                    break;
            }
            return Task.FromResult(coordinates);
        }
    }
}
