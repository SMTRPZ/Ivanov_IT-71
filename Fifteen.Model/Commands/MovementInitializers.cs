using Fifteen.BLL.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public static class MovementInitializers
    {
        public static readonly Dictionary<MoveDirection, Func<Desk, Command>> Initializers = new Dictionary<MoveDirection, Func<Desk, Command>>()
        {
            {MoveDirection.Up, desk => new MoveUpCommand(desk) },
            {MoveDirection.Down, desk => new MoveDownCommand(desk) },
            {MoveDirection.Left, desk => new MoveLeftCommand(desk) },
            {MoveDirection.Right, desk => new MoveRightCommand(desk) }
        };
    }
}
