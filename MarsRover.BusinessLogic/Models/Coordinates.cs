using System.Drawing;

namespace MarsRover.BusinessLogic.Models
{
    public class Coordinates
    {
        public Coordinates(Point currentPosition, Direction direction)
        {
            CurrentPosition = currentPosition;
            Direction = direction;
        }

        public Point CurrentPosition { get; set; }
        public Direction Direction { get; set; }
    }
}
