using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveRightCommand : Command
    {
        public MoveRightCommand(Desk desk) : base(desk)
        {
        }

        public override bool Execute()
        {
            return desk.MoveRight();
        }

        public override void Undo()
        {
            desk.MoveLeft();
        }
    }
}
