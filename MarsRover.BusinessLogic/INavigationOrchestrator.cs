using MarsRover.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.BusinessLogic
{
    public interface INavigationOrchestrator
    {
        Task<Coordinates> NavigateRover(Point maxAllowedCoordinates, string moveCommands);
    }
}
