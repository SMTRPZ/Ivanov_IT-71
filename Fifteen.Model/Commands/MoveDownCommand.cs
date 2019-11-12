using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveDownCommand : Command
    {
        public MoveDownCommand(Desk desk) : base (desk)
        {
        }

        public override bool Execute()
        {
            return desk.MoveDown();
        }

        public override void Undo()
        {
            desk.MoveUp();
        }
    }
}
