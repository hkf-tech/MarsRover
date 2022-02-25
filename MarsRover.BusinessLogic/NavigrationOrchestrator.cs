using MarsRover.BusinessLogic.Commands;
using MarsRover.BusinessLogic.Models;
using MediatR;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.BusinessLogic
{
    public class NavigrationOrchestrator : INavigationOrchestrator
    {
        private readonly IMediator _mediator;

        public NavigrationOrchestrator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Coordinates> NavigateRover(Point maxAllowedCoordinates, string moveCommands)
        {
            Coordinates result = new Coordinates(new Point(1, 1), Direction.North);

            foreach (var moveCommand  in moveCommands.ToCharArray())
            {
                switch(moveCommand)
                {
                    case 'L':
                        result = await _mediator.Send(new MoveLeftCommand(result), CancellationToken.None);
                        break;
                    case 'R':
                        result = await _mediator.Send(new MoveRightCommand(result), CancellationToken.None);
                        break;
                    case 'F':
                        result = await _mediator.Send(new MoveForwardCommand(result,maxAllowedCoordinates) , CancellationToken.None);
                        break;
                }
            }

            return result;
        }
    }
}
