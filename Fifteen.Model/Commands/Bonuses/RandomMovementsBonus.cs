using Fifteen.BLL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fifteen.BLL.Model.Enums;

namespace Fifteen.BLL.Bonuses
{
    public class RandomMovementsBonus : Command
    {
        private readonly int _movementsCount;
        private readonly Stack<Command> _commands;

        public RandomMovementsBonus(Desk desk, int movementsCount) : base(desk)
        {
            _movementsCount = movementsCount;
            _commands = new Stack<Command>(movementsCount);
        }

        public override bool Execute()
        {
            var tmp = desk.GetDesk();
            var rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < _movementsCount; i++)
            {
                MoveDirection direction = (MoveDirection)rnd.Next(4);
                Command command = MovementInitializers.Initializers[direction].Invoke(desk);
                if (!command.Execute())
                    i--;
                else
                    _commands.Push(command);
            }
            return tmp != desk.GetDesk();
        }

        public override void Undo()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Pop();
                command.Undo();
            }
        }
    }
}
