using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveLeftCommand : Command
    {
        public MoveLeftCommand(Desk desk) : base (desk)
        {
        }

        public override bool Execute()
        {
            return desk.MoveLeft();
        }
        public override void Undo()
        {
            desk.MoveRight();
        }
    }
}
