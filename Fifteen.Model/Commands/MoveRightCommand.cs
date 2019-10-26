using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveRightCommand : ICommand
    {
        private Desk desk;
        public MoveRightCommand(Desk desk)
        {
            this.desk = desk;
        }
        public bool Execute()
        {
            return desk.MoveRight();
        }

        public void Undo()
        {
            desk.MoveLeft();
        }
    }
}
