using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveLeftCommand : ICommand
    {
        private Desk desk;
        public MoveLeftCommand(Desk desk)
        {
            this.desk = desk;
        }
        public bool Execute()
        {
            return desk.MoveLeft();
        }

        public void Undo()
        {
            desk.MoveRight();
        }
    }
}
