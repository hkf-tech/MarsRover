using AutoFixture;
using MarsRover.BusinessLogic;
using MarsRover.BusinessLogic.Commands;
using MarsRover.BusinessLogic.Models;
using MediatR;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.TestProject
{
    [TestFixture]
    public class NavigrationOrchestratorTests
    {
        NavigrationOrchestrator _sut;
        Mock<IMediator> _mediator;
        System.Drawing.Point _maxAllowedCoordinates;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            _maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var coordinates = new Coordinates(new System.Drawing.Point(2, 2), Direction.North);
   
            _mediator = new Mock<IMediator>();
            _mediator.Setup(x => x.Send(It.IsAny<MoveLeftCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => coordinates);
            _mediator.Setup(x => x.Send(It.IsAny<MoveRightCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => coordinates);
            _mediator.Setup(x => x.Send(It.IsAny<MoveForwardCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => coordinates);

            _sut = new NavigrationOrchestrator(_mediator.Object);
        }

        [Test]
        public async Task Moved_Left_When_the_Command_Is_L()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "L");

            _mediator.Verify(x => x.Send(It.IsAny<MoveLeftCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task When_Move_Left_Only_Move_Left_Command_Is_Send()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "L");

            _mediator.Verify(x => x.Send(It.IsAny<MoveRightCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            _mediator.Verify(x => x.Send(It.IsAny<MoveForwardCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task Moved_Left_When_the_Command_Is_R()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "R");

            _mediator.Verify(x => x.Send(It.IsAny<MoveRightCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task When_Move_Right_Only_Move_Right_Command_Is_Send()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "R");

            _mediator.Verify(x => x.Send(It.IsAny<MoveLeftCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            _mediator.Verify(x => x.Send(It.IsAny<MoveForwardCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task Moved_Left_When_the_Command_Is_F()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "F");

            _mediator.Verify(x => x.Send(It.IsAny<MoveForwardCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }


        [Test]
        public async Task When_Move_Forward_Only_Move_Forward_Command_Is_Send()
        {
            await _sut.NavigateRover(_maxAllowedCoordinates, "F");

            _mediator.Verify(x => x.Send(It.IsAny<MoveLeftCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            _mediator.Verify(x => x.Send(It.IsAny<MoveRightCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
