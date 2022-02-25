using MarsRover.BusinessLogic;
using MarsRover.BusinessLogic.Commands;
using MarsRover.BusinessLogic.Models;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.TestProject
{
    [TestFixture]
    public class MoveFowrwardCommandHandlerTests
    {
        MoveFowrwardCommandHandler _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new MoveFowrwardCommandHandler();
        }

        [Test]
        public async Task When_Direction_Is_North_Increment_Y_When_Less_Than_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 1), Direction.North);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, result.CurrentPosition.Y);
        }

        [Test]
        public async Task When_Direction_Is_North_Dont_Increment_X_When_Less_Than_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 1), Direction.North);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(1, result.CurrentPosition.X);
        }

        [TestCase(Direction.East)]
        [TestCase(Direction.North)]
        [TestCase(Direction.West)]
        [TestCase(Direction.South)]
        public async Task When_Moved_Forward_Dont_Change_Direction(Direction direction)
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 1), direction);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(direction, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_North_IgnoreCommand_When_Equal_To_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 5), Direction.North);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(5, result.CurrentPosition.Y);
            Assert.AreEqual(1, result.CurrentPosition.X);
            Assert.AreEqual(Direction.North, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_East_Increment_X_When_Less_Than_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 1), Direction.East);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, result.CurrentPosition.X);
        }

        [Test]
        public async Task When_Direction_Is_East_Dont_Increment_Y_When_Less_Than_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 1), Direction.East);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(1, result.CurrentPosition.Y);
        }

       
        [Test]
        public async Task When_Direction_Is_East_IgnoreCommand_When_Equal_To_Maximum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(5, 3), Direction.East);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(5, result.CurrentPosition.X);
            Assert.AreEqual(3, result.CurrentPosition.Y);
            Assert.AreEqual(Direction.East, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_South_Decrement_Y_When_Greater_Than_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 3), Direction.South);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, result.CurrentPosition.Y);
        }

        [Test]
        public async Task When_Direction_Is_South_Dont_Decrement_X_When_Greater_Than_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(2, 3), Direction.South);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, result.CurrentPosition.X);
        }


        [Test]
        public async Task When_Direction_Is_South_Ignore_Command_When_Equal_To_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(5, 1), Direction.South);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(1, result.CurrentPosition.Y);
            Assert.AreEqual(5, result.CurrentPosition.X);
            Assert.AreEqual(Direction.South, result.Direction);
        }

        [Test]
        public async Task When_Direction_Is_West_Decrement_X_When_Greater_Than_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.West);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(2, result.CurrentPosition.X);
        }

        [Test]
        public async Task When_Direction_Is_West_Dont_Decrement_Y_When_Greater_Than_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(3, 3), Direction.West);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(3, result.CurrentPosition.Y);
        }


        [Test]
        public async Task When_Direction_Is_West_Ignore_Command_When_Equal_To_Minimum_Allowed()
        {
            var currentCoodinates = new Coordinates(new System.Drawing.Point(1, 3), Direction.West);
            var maxAllowedCoordinates = new System.Drawing.Point(5, 5);
            var command = new MoveForwardCommand(currentCoodinates, maxAllowedCoordinates);

            var result = await _sut.Handle(command, CancellationToken.None);

            Assert.AreEqual(3, result.CurrentPosition.Y);
            Assert.AreEqual(1, result.CurrentPosition.X);
            Assert.AreEqual(Direction.West, result.Direction);
        }
    }
}