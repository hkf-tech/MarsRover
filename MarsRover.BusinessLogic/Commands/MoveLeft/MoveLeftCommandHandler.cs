using MarsRover.BusinessLogic.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.BusinessLogic.Commands
{
    public class MoveLeftCommandHandler : IRequestHandler<MoveLeftCommand, Coordinates>
    {
        public Task<Coordinates> Handle(MoveLeftCommand request, CancellationToken cancellationToken)
        {
            var coordinates = request.CurrentCoordinates;
            switch (coordinates.Direction)
            {
                case Direction.North:
                    coordinates.Direction = Direction.West;
                    break;

                case Direction.East:
                    coordinates.Direction = Direction.North;
                    break;

                case Direction.South:
                    coordinates.Direction = Direction.East;
                    break;

                case Direction.West:
                    coordinates.Direction = Direction.South;
                    break;
            }
            return Task.FromResult(coordinates);
        }
    }
}
