using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveUpCommand : Command
    {
        public MoveUpCommand(Desk desk) : base(desk)
        {
        }
        public override bool Execute()
        {
            return desk.MoveUp();
        }
        public override void Undo()
        {
            desk.MoveDown();
        }
    }
}
