using MarsRover.BusinessLogic;
using MarsRover.BusinessLogic.Commands;
using MarsRover.BusinessLogic.Models;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.TestProject
{
    [TestFixture]
    public class MoveRightCommandHandlerTests
    {
        MoveRightCommandHandler _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MoveRightCommandHandler();
        }

        [Test]
        public async Task When_Direction_Is_North_Change_Direction_To_East()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.North);
            var command = new MoveRightCommand(currentCoodinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual( Direction.East, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_East_Change_Direction_To_South()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.East);
            var command = new MoveRightCommand(currentCoodinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(Direction.South, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_South_Change_Direction_To_West()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.South);
            var command = new MoveRightCommand(currentCoodinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(Direction.West, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_West_Change_Direction_To_North()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.West);
            var command = new MoveRightCommand(currentCoodinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(Direction.North, result.Direction);
        }

        [TestCase(Direction.East)]
        [TestCase(Direction.North)]
        [TestCase(Direction.West)]
        [TestCase(Direction.South)]
        public async Task When_Moved_Right_Position_Doesnt_Change(Direction direction)
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), direction);
            var command = new MoveRightCommand(currentCoodinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(3, result.CurrentPosition.X);
            Assert.AreEqual(3, result.CurrentPosition.Y);
        }
    }
}
