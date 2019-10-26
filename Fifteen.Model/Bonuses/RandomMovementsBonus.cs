using Fifteen.BLL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Bonuses
{
    public class RandomMovementsBonus : BonusBase, ICommand
    {
        private readonly int _movementsCount;
        private readonly Stack<ICommand> _commands;

        public RandomMovementsBonus(Desk desk, int movementsCount) : base(desk)
        {
            _movementsCount = movementsCount;
            _commands = new Stack<ICommand>(movementsCount);
        }

        public bool Execute()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            while(_commands.Count > 0){
                var command = _commands.Pop();
                command.Undo();
            }
        }

        public override void Use()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < _movementsCount; i++)
            {
                switch (rnd.Next(4))
                {
                    case 0:
                        var upCommand = new MoveUpCommand(_desk);
                        if (!upCommand.Execute())
                            i--;
                        else
                            _commands.Push(upCommand);
                        break;
                    case 1:
                        var rightCommand = new MoveRightCommand(_desk);
                        if (!rightCommand.Execute())
                            i--;
                        else
                            _commands.Push(rightCommand);
                        break;
                    case 2:
                        var downCommand = new MoveDownCommand(_desk);
                        if (!downCommand.Execute())
                            i--;
                        else
                            _commands.Push(downCommand);
                        break;
                    case 3:
                        var leftCommand = new MoveLeftCommand(_desk);
                        if (!leftCommand.Execute())
                            i--;
                        else
                            _commands.Push(leftCommand);
                        break;
                }
            }
        }
    }
}
