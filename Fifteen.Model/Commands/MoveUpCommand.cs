using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveUpCommand : ICommand
    {
        private Desk desk;
        public MoveUpCommand(Desk desk)
        {
            this.desk = desk;
        }
        public bool Execute()
        {
            return desk.MoveUp();
        }

        public void Undo()
        {
            desk.MoveDown();
        }
    }
}
